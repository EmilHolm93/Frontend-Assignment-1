using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace CarWorkshop.Models
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int WorkorderId { get; set; }

        public string MechanicName { get; set; }

        public decimal Hours { get; set; }
        public decimal HourPrice { get; set; }
    }
}
