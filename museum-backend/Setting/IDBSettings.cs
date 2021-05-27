using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace museum_backend.Setting
{
    public class DBSettings : IDBSettings
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
        public string AnimalColName { get; set;}
        public string AnimalTypeColName { get; set; }
        public string DonerColName { get; set; }
        public string MuseumInfoColName { get; set; }
        public string NewsColName { get; set; }
        public string OrganColName { get; set; }
        public string TaxonomyColName { get; set; }
    }
    public interface IDBSettings
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
        public string AnimalColName { get; set; }
        public string AnimalTypeColName { get; set; }
        public string DonerColName { get; set; }
        public string MuseumInfoColName { get; set; }
        public string NewsColName { get; set; }
        public string OrganColName { get; set; }
        public string TaxonomyColName { get; set; }
    }
}
