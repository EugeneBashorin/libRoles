using System;

namespace LibraryProject.Models
{
    [Serializable]
    public abstract class PrintEdition
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
        public int Id { get; set; }
    }
}