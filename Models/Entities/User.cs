using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TCNo { get; set; }
        public string Phone { get; set; }
        public string ImageURL { get; set; }
        public string CarsPlate { get; set; }
        public bool ApartmentOwner { get; set; }
        public bool IsDelete { get; set; }
        public int ApartmentID { get; set; }

        public virtual ICollection<Apartment> Apartment { get; set; }
       
        public ICollection<Dues> Dues { get; set; }
        public ICollection<ElectricityBill> ElectricityBill { get; set; }
        public ICollection<WaterBill> WaterBill { get; set; }
        public ICollection<NaturalGasBill> NaturalGasBill { get; set; }
    }
}