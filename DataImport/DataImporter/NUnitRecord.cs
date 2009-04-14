#if TESTDRIVER

namespace DataImporter
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitRecord
    {
        [Test]
        public void RecordRead()
        {
            const string readRec = "1882	AII61036	Aquarium	Air Pumps		Hurricane Category 2 (deluxe Battery Operated Pump)	&lt;p&gt;Hurricane Pumps   from Deep Blue   are designed to help your aquarium residents survive a temporary power loss&amp;#046;  Our deluxe Category 2 pump features &lt;/p&gt;&lt;ul&gt;&lt;li&gt;&quot;Compact design makes it ideal for fish transportation, as well as, back up aeration during temporary power loss&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Water Resistant &amp;#045; A rubber seal for both the battery compartment and power switch&amp;#046;&lt;/li&gt;&lt;li&gt;Comes with a length of silicone air tubing and an airstone&amp;#046;&lt;/li&gt;&lt;li&gt;&quot;Has two &amp;#040;2&amp;#041;  &quot;&quot;D&quot;&quot; cell battery slots&amp;#046; Batteries are not included&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Made of high quality impact plastic for durability and quiet operation&amp;#046;&lt;/li&gt;&lt;li&gt;Single outlet design&amp;#046;&lt;/li&gt;&lt;/ul&gt;		1882_pid.jpg	1882_pidt.jpg				5.45	7.35	0	1	749729610366	202	";
            var rec = new Record();

            Assert.IsTrue(rec.Fill(readRec));
            Assert.AreEqual(1882, rec.PID);
            Assert.AreEqual("AII61036", rec.ProductCode);

            Assert.AreEqual("Aquarium", rec.Section);
            Assert.AreEqual("Air Pumps", rec.Category);
            Assert.AreEqual("", rec.Subcategories);
            Assert.AreEqual("Hurricane Category 2 (deluxe Battery Operated Pump)",
                                                            rec.ProductName);
            Assert.AreEqual("&lt;p&gt;Hurricane Pumps   from Deep Blue   are designed to help your aquarium residents survive a temporary power loss&amp;#046;  Our deluxe Category 2 pump features &lt;/p&gt;&lt;ul&gt;&lt;li&gt;&quot;Compact design makes it ideal for fish transportation, as well as, back up aeration during temporary power loss&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Water Resistant &amp;#045; A rubber seal for both the battery compartment and power switch&amp;#046;&lt;/li&gt;&lt;li&gt;Comes with a length of silicone air tubing and an airstone&amp;#046;&lt;/li&gt;&lt;li&gt;&quot;Has two &amp;#040;2&amp;#041;  &quot;&quot;D&quot;&quot; cell battery slots&amp;#046; Batteries are not included&amp;#046;&quot;&lt;/li&gt;&lt;li&gt;Made of high quality impact plastic for durability and quiet operation&amp;#046;&lt;/li&gt;&lt;li&gt;Single outlet design&amp;#046;&lt;/li&gt;&lt;/ul&gt;",
                                                    rec.ProductDescription);
            Assert.AreEqual("", rec.ProductWeight);
            Assert.AreEqual("1882_pid.jpg", rec.Picture);
            Assert.AreEqual("", rec.ProductSize);
            Assert.AreEqual("", rec.Color);
            Assert.AreEqual("", rec.Pattern);
            Assert.AreEqual(5.45, rec.Cost);
            Assert.AreEqual(7.35, rec.RecommendedPrice);
            Assert.AreEqual(0, rec.ShippingSurcharge);
            Assert.AreEqual(1, rec.MinQuantity);
            Assert.AreEqual("749729610366", rec.UPC);
            Assert.AreEqual(202, rec.QtyAvailable);
        }
    }
}

#endif