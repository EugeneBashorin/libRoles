using System;

namespace LibraryProject.Models
{
    [Serializable]
    public class Magazine : PrintEdition
    {
        public string Category { get; set; }
    }
}