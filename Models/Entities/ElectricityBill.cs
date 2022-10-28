using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class ElectricityBill
    {
        [Key]
        public int ElectricityBillID { get; set; }
        public string ElectricityBillSerialNumber { get; set; } // Seri No
        public string ElectricityBillSequenceNo { get; set; } // Sıra No
        public string ElectricityBillCompanyName { get; set; }
        public int ElectricityBillPrice { get; set; }
        public DateTime ElectricityBillDate { get; set; }
        public string ElectricityBillDescription { get; set; }
        public bool ElectricityBillStatus { get; set; } = false;

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}