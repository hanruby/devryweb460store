using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Utilities;
using DataAccessModule;

namespace DataImporter
{
    [Serializable]
    public class Reader : Engine
    {
        private readonly List<Record> m_recordList;

        public Reader()
        {
            m_recordList = new List<Record>();
        }

        public List<Record> RecordList
        {
            get
            {
                return(m_recordList);
            }
        }

        public override bool ReadFile(string P_fileName)
        {
            StreamReader reader;

            try
            {
                reader = new StreamReader(P_fileName);
            }

            catch (Exception)
            {
                return(false);
            }

                //
                // Skip first line because it is the header
                //

            var msg = String.Format("Skipping Header Row");
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            reader.ReadLine();
            var cnt = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == "")
                {
                    continue;
                }

                var rec = new Record();
                cnt ++;
                msg = String.Format("Reader Record {0}", cnt);
                SystemDebug.Log((int)TraceLevel.Verbose, msg);
                if (rec.Fill(line))
                {
                    m_recordList.Add(rec);
                }
            }

            reader.Close();

            return(true);
        }

        public override bool CreateProductList()
        {
            var cnt = 0;
            foreach (var rec in m_recordList)
            {
                cnt++;
                string msg = String.Format("Adding Product Record {0}", cnt);
                SystemDebug.Log((int)TraceLevel.Verbose, msg);
                m_productList.Add(FillProductItem(rec));
            }

            return(true);
        }

        private ProductItemDA FillProductItem(Record P_rec)
        {
            var item = new ProductItem
            {
                ItemID = P_rec.PID.ToString(),
                Category = P_rec.Section,
                Cost = P_rec.Cost,
                VendorID = VendorID,
                Picture = P_rec.Picture,
                ProductCode = P_rec.ProductCode,
                ProductDescription = P_rec.ProductDescription,
                ProductName = P_rec.ProductName,
                ProductSize = P_rec.ProductSize,
                Section = P_rec.Section,
                UPC = P_rec.UPC,
            };

            var productItemReader = new ProductItemDA
            {
                WorkingItem = item,
                InsertUpdateData = true
            };

            return (productItemReader);
        }
    }
}
