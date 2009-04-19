using System;

namespace DataImporter
{
    [Serializable]
    public class Record
    {
        public int PID { get; private set; }
        public string ProductCode { get; private set; }
        public string Section { get; private set; }
        public string Category { get; private set; }
        public string Subcategories { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public string ProductWeight { get; private set; }
        public string Picture { get; private set; }
        public string ProductSize { get; private set; }
        public string Color { get; private set; }
        public string Pattern { get; private set; }
        public decimal Cost { get; private set; }
        public decimal RecommendedPrice { get; private set; }
        public decimal ShippingSurcharge { get; private set; }
        public int MinQuantity { get; private set; }
        public string UPC { get; private set; }
        public int QtyAvailable { get; private set; }

        public bool Fill(string P_rec)
        {
            string[] parts = P_rec.Split('\t');

            PID = Convert.ToInt32(parts[0]);

            ProductCode = parts[1].Length < 50 ? parts[1] : parts[1].Substring(0, 50);
            Section = parts[2].Length < 50 ? parts[2] : parts[2].Substring(0, 50);
            Category = parts[3].Length < 50 ? parts[3] : parts[3].Substring(0, 50);
            Subcategories = parts[4].Length < 50 ? parts[4] : parts[4].Substring(0, 50);
            ProductName = parts[5].Length < 50 ? parts[5] : parts[5].Substring(0, 50);
            ProductDescription = parts[6].Length < 50 ? parts[6] : parts[6].Substring(0, 50);
            ProductWeight = parts[7].Length < 50 ? parts[7] : parts[7].Substring(0, 50);
            Picture = parts[8].Length < 50 ? parts[8] : parts[8].Substring(0, 50);
            ProductSize = parts[10].Length < 50 ? parts[10] : parts[10].Substring(0, 50);
            Color = parts[11].Length < 50 ? parts[11] : parts[11].Substring(0, 50);
            Pattern = parts[12].Length < 50 ? parts[12] : parts[12].Substring(0, 50);
            Cost = Convert.ToDecimal(parts[13]);
            RecommendedPrice = Convert.ToDecimal(parts[14]);
            ShippingSurcharge = Convert.ToDecimal(parts[15]);
            MinQuantity = Convert.ToInt32(parts[16]);
            UPC = parts[17];
            QtyAvailable = Convert.ToInt32(parts[18]);

            return (true);
        }

    }
}
