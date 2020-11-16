using System;

namespace getcategories
{
    public class Category
    {
        public int Id { get; set; }
        public string displayName { get; set; }
        public Nullable<byte> isActive { get; set; }
    }
}
