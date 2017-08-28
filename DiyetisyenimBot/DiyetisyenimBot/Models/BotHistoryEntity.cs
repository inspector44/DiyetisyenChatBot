using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiyetisyenimBot.Models
{
    public class BotHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}