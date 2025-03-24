using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CarWorkshop.Models
{
    public class Workorder
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarReg { get; set; }
        public DateTime HandinDate { get; set; }
        public string Description { get; set; }

    }

}
