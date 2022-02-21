using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;

namespace DataAccess.ModelsDb
{
    internal class HomeworkDb
    {
        [Key]
        [Column("HomeworkId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Subject { get; set; } = string.Empty;

        public int LectureId { get; set; }
        [Ignore]
        public LectureDb Lecture { get; set; }

        public ICollection<HomeworksStudentsDb> HomeworksStudents { get; set; }
    }
}