using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }
       
        public string ApartmentNo { get; set; }
        public string Floor { get; set; }
        public string ApartmentBlock { get; set; }
        public string HomeType { get; set; }
        public bool Status { get; set; } = false;

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}