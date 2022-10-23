using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class WaterBill
    {
        [Key]
        public int WaterBillID { get; set; }
        public string WaterBillSerialNumber { get; set; } //Fatura Seri No
        public string WaterBillSequenceNo { get; set; } //Fatura Sıra No
        public string WaterBillCompanyName { get; set; }
        public int WaterBillPrice { get; set; }
        public DateTime WaterBillDate { get; set; }
        public string WaterBillDescription { get; set; }
        public bool WaterBillStatus { get; set; } = false;

        public User User { get; set; }
    }
}