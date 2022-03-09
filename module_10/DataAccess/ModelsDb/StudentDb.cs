using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.ModelsDb
{
    internal record StudentDb
    {
        [Key]
        [Column("StudentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public int Age { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<HomeworksStudentsDb> HomeworksStudents { get; set; }

        public ICollection<LecturesStudentsDb> LecturesStudents { get; set; }         
    }
}