using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.ModelsDb
{
    internal class HomeworksStudentsDb
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        public StudentDb Student { get; set; }

        [Key, Column(Order = 1)]
        public int HomeworkId { get; set; }
        public HomeworkDb Homework { get; set; }
    }
}