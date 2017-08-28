using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiyetisyenimBot.Models
{
    public class Questions
    {
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}