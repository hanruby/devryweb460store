using System;

namespace DataAccessModule
{
    [Serializable]
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public Category()
        {
            CategoryID = -1;
        }
    }
}
