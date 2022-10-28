using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class NaturalGasBill
    {
        [Key]
        public int NaturalGasBillID { get; set; }
        public string NaturalGasBillSerialNumber { get; set; } // Seri No
        public string NaturalGasBillSequenceNo { get; set; } // Sıra No
        public string NaturalGasBillCompanyName { get; set; }
        public int NaturalGasBillPrice { get; set; }
        public DateTime NaturalGasBillDate { get; set; }
        public string NaturalGasBilllDescription { get; set; }
        public bool NaturalGasBillStatus { get; set; } = false;

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}