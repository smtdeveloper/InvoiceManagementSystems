using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class Dues
    {
        [Key]
        public int DuesID { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = false;

        public int UserID { get; set; }
        public virtual User User { get; set; }
      
    }
}