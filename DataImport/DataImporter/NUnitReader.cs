#if TESTDRIVER

using System;
using System.IO;

namespace DataImporter
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitReader
    {
        [Test]
        public void TestFileRead()
        {
            string fileName = String.Format(@".\{0}.txt", Guid.NewGuid());
            CreateImportFile(fileName);
            var reader = new Reader();

            Assert.IsTrue(reader.ReadFile(fileName));

            File.Delete(fileName);
        }

        private static void CreateImportFile(string P_fileName)
        {
            var writer = new StreamWriter(P_fileName);

            const string line1 = "PID	product_code	section	category	subcategories	product_name	product_description	product_weight	picture	thumbnail	product_size	color	pattern	cost	recommended_price	shipping_surcharge	min_quantity	UPC	QTY_available";
            const string line2 = "1882	AII61036	Aquarium	Air Pumps		Hurricane Category 2 (deluxe Battery Operated Pump)	&lt;p&gt;Hurricane Pumps   from Deep Blue   are designed to help your aquarium residents survive a temporary power loss&amp;#046;  Our deluxe Category 2 pump features &lt;/p&gt;&lt;ul&gt;&lt;li&gt;&quot;Compact design makes it ideal for fish transportation, as well as, back up aeration during temporary power loss&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Water Resistant &amp;#045; A rubber seal for both the battery compartment and power switch&amp;#046;&lt;/li&gt;&lt;li&gt;Comes with a length of silicone air tubing and an airstone&amp;#046;&lt;/li&gt;&lt;li&gt;&quot;Has two &amp;#040;2&amp;#041;  &quot;&quot;D&quot;&quot; cell battery slots&amp;#046; Batteries are not included&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Made of high quality impact plastic for durability and quiet operation&amp;#046;&lt;/li&gt;&lt;li&gt;Single outlet design&amp;#046;&lt;/li&gt;&lt;/ul&gt;		1882_pid.jpg	1882_pidt.jpg				5.45	7.35	0	1	749729610366	202	";
            const string line3 = "1883	AII61037	Aquarium	Air Pumps		Hurricane Category 5 (professional Ac/dc Battery Operated Pump)	Hurricane category 5 (professional ac/dc battery operated pump)		1883_pid.jpg	1883_pidt.jpg				75.30	101.00	0	1	749729610373	80	";
            const string line4 = "1884	AAP702A	Aquarium	Air Pumps		Rena Air 50 Pump (for Up To 10gal Tanks)	Rena air  50 pump (for up to 10gal tanks)		1884_pid.jpg	1884_pidt.jpg				11.75	15.75	0	1	17163507024	20	";

            writer.WriteLine(line1);
            writer.WriteLine(line2);
            writer.WriteLine(line3);
            writer.WriteLine(line4);

            writer.Close();
        }
    }
}

#endif