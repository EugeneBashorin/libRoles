using System;

namespace LibraryProject.Models
{
    [Serializable]
    public class Book : PrintEdition
    {
        public string Author { get; set; }
     }
}