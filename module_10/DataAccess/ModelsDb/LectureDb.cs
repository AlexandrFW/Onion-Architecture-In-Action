using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.ModelsDb
{
    internal class LectureDb
    {
        [Key]
        [Column("LectureId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string LectureName { get; set; } = string.Empty;

        public int LectorId { get; set; }
        public LectorDb Lector { get; set; }

        public ICollection<HomeworkDb> Homeworks { get; set; }

        public ICollection<LecturesStudentsDb> LecturesStudents { get; set; }
    }
}