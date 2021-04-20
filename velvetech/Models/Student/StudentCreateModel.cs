using System;
using System.ComponentModel.DataAnnotations;
using velvetech.Infrastructure;

namespace velvetech.Models
{
    public class StudentCreateModel : IStudent
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int? Pol { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(40, ErrorMessage = "Максимальная длинна 40 символов")]
        public string Fam { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(40, ErrorMessage = "Максимальная длинна 40 символов")]
        public string Nam { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(60, ErrorMessage = "Максимальная длинна 60 символов")]
        public string Oth { get; set; }

        [StringLength(16, MinimumLength = 6, ErrorMessage = "Может быть от 6 до 16 символов)")]
        public string Alias { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public DateTime? Removed { get; set; }
    }
}
