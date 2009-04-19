using System;

namespace DataAccessModule
{
    [Serializable]
    public class ItemCategories
    {
        public int CategoryID { get; set; }
        public int VendorID { get; set; }
        public string ItemID { get; set; }

        public ItemCategories()
        {
            CategoryID = -1;
            VendorID = -1;
        }
    }
}
