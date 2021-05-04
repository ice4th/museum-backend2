using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace museum_backend.Models
{
    public class NewsInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> ImgPath { get; set; }
    }
}
