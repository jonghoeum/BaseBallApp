using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
    public class SupportersClass
    {
        [Key]
        public int IDX { get; set; } = 0;
        public bool IsNotice { get; set; } = false;
        [Required(ErrorMessage = "제목을 입력하세요.")]
        public string? Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "내용을 입력하세요.")]
        public string? Content { get; set; } = string.Empty;
        public string? FileName1 { get; set; } = string.Empty;
        public string? FilePath1 { get; set; } = string.Empty;
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
