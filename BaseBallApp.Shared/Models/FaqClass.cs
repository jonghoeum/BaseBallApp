using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
    public class FaqClass
    {
        [Key]
        public int IDX { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? FileName1 { get; set; }
        public string? FilePath1 { get; set; }
        public int ViewCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
