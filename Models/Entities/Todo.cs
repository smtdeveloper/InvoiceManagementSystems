using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaturaYönetimSistemleri.Models.Entities
{
    public class Todo
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }

    }
}