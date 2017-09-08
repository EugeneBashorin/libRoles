using System;

namespace LibraryProject.Models
{
    [Serializable]
    public class Newspaper : PrintEdition
    {
        public string Category { get; set; }
    }
}