using DataAccess.ModelsDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    internal class ApplicationDbContext : DbContext
    {
        static bool _isDatabaseCreated = false;
        public DbSet<StudentDb> Students { get; set; }

        public DbSet<HomeworkDb> Homeworks { get; set; }

        public DbSet<LectorDb> Lectors { get; set; }

        public DbSet<LectureDb> Lectures { get; set; }

        public DbSet<LecturesStudentsDb> LecturesStudents { get; set; }

        public DbSet<HomeworksStudentsDb> HomeworksStudents { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            if (!_isDatabaseCreated)
            {
                DataBaseRecreation();

                _isDatabaseCreated = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedDatabase(modelBuilder);
        }

        private void DataBaseRecreation()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var students = new StudentDb[]
            {
                new StudentDb { Id = 1, Name = "Vasily Petrov", Age = 18, Email = "v.petrov@gmail.com", Phone = "+79002318921", CreateDate = DateTime.Now },
                new StudentDb { Id = 2, Name = "Grigory Sidorov", Age = 17, Email = "g.sidorov@yandex.ru", Phone = "+79052010015", CreateDate = DateTime.Now },
                new StudentDb { Id = 3, Name = "Anna Antonova", Age = 18, Email = "anna.antonova@yandex.ru", Phone = "+79103210945", CreateDate = DateTime.Now },
                new StudentDb { Id = 4, Name = "Svatlana Vasileva", Age = 18, Email = "s.vasileva@rambler.ru", Phone = "+79603019915", CreateDate = DateTime.Now },
                new StudentDb { Id = 5, Name = "Dmitry Nevedof", Age = 19, Email = "d.nefedov@gmail.com", Phone = "+79059872213", CreateDate = DateTime.Now }
            };

            var lectors = new LectorDb[]
            {
                new LectorDb { Id = 1, Name = "Vitaly Genadievich Gromov", Age = 45, Email = "vitaly.gromov@universitat.ru", Phone = "+79010078912", CreateDate = DateTime.Now },
                new LectorDb { Id = 2, Name = "Anatoly Vladimirovich Smolny", Age = 52, Email = "anatoly.smolny@universitat.ru", Phone = "+79011010015", CreateDate = DateTime.Now },
                new LectorDb { Id = 3, Name = "Galina Petrovna Antonuk", Age = 43, Email = "galina.antonuk@universitat.ru", Phone = "+79019661234", CreateDate = DateTime.Now },
                new LectorDb { Id = 4, Name = "Daria Grigorievna Anopko", Age = 48, Email = "daria.anopko@universitat.ru", Phone = "+79019051256", CreateDate = DateTime.Now },
                new LectorDb { Id = 5, Name = "Dmitry Alexandrovich Zavyalov", Age = 39, Email = "dmitry.zavyalov@universitat.ru", Phone = "+79010987645", CreateDate = DateTime.Now }
            };

            var lectures = new LectureDb[]
            {
                new LectureDb { Id = 1, LectorId = lectors[0].Id, LectureName = "Philosophy" },
                new LectureDb { Id = 2, LectorId = lectors[1].Id, LectureName = "Information technology" },
                new LectureDb { Id = 3, LectorId = lectors[0].Id, LectureName = "Psychology" },
                new LectureDb { Id = 4, LectorId = lectors[2].Id, LectureName = "Mathematics" },
                new LectureDb { Id = 5, LectorId = lectors[3].Id, LectureName = "English" },
                new LectureDb { Id = 6, LectorId = lectors[4].Id, LectureName = "Cybernetics" },
                new LectureDb { Id = 7, LectorId = lectors[1].Id, LectureName = "Electronics" }
            };

            var homeworks = new HomeworkDb[]
            {
                new HomeworkDb { Id = 1, Subject = "Philosophy of ancient Rome", LectureId = lectures[0].Id },
                new HomeworkDb { Id = 2, Subject = "Theory of Algorithms", LectureId = lectures[1].Id },
                new HomeworkDb { Id = 3, Subject = "Passive voice", LectureId = lectures[4].Id },
                new HomeworkDb { Id = 4, Subject = "Transistors in modern electronics", LectureId = lectures[6].Id },
                new HomeworkDb { Id = 5, Subject = "Mathematical modeling", LectureId = lectures[5].Id },
                new HomeworkDb { Id = 6, Subject = "What a philosophy is: subject, object and subject of science, methods", LectureId = lectures[0].Id },
                new HomeworkDb { Id = 7, Subject = "Mathematical modeling. Part 2", LectureId = lectures[5].Id }
            };

            var homeworksStudents = new HomeworksStudentsDb[]
            {
                new HomeworksStudentsDb() { StudentId = 1, HomeworkId = 2 },
                new HomeworksStudentsDb() { StudentId = 2, HomeworkId = 2 },
                new HomeworksStudentsDb() { StudentId = 3, HomeworkId = 2 },
                new HomeworksStudentsDb() { StudentId = 4, HomeworkId = 2 },
                new HomeworksStudentsDb() { StudentId = 5, HomeworkId = 2 },
                new HomeworksStudentsDb() { StudentId = 1, HomeworkId = 1 },
                new HomeworksStudentsDb() { StudentId = 2, HomeworkId = 1 },
                new HomeworksStudentsDb() { StudentId = 3, HomeworkId = 1 },
                new HomeworksStudentsDb() { StudentId = 4, HomeworkId = 1 },
                new HomeworksStudentsDb() { StudentId = 5, HomeworkId = 1 },
                new HomeworksStudentsDb() { StudentId = 1, HomeworkId = 3 },
                new HomeworksStudentsDb() { StudentId = 2, HomeworkId = 3 },
                new HomeworksStudentsDb() { StudentId = 3, HomeworkId = 3 },
                new HomeworksStudentsDb() { StudentId = 4, HomeworkId = 3 },
                new HomeworksStudentsDb() { StudentId = 5, HomeworkId = 3 },
                new HomeworksStudentsDb() { StudentId = 1, HomeworkId = 4 },
                new HomeworksStudentsDb() { StudentId = 2, HomeworkId = 4 },
                new HomeworksStudentsDb() { StudentId = 3, HomeworkId = 4 },
                new HomeworksStudentsDb() { StudentId = 4, HomeworkId = 4 },
                new HomeworksStudentsDb() { StudentId = 5, HomeworkId = 4 }
            };

            var lecturesStudents = new LecturesStudentsDb[]
            {
                new LecturesStudentsDb
                {
                    LectureId = lectures[1].Id,
                    StudentId = students[2].Id,
                    Grade = 4,
                    IsStudentWasAttended = true,
                    LectureDate = DateTime.Now
                },
                new LecturesStudentsDb
                {
                    LectureId = lectures[1].Id,
                    StudentId = students[1].Id,
                    Grade = 0,
                    IsStudentWasAttended = false,
                    LectureDate = DateTime.Now
                },
                new LecturesStudentsDb
                {
                    LectureId = lectures[2].Id,
                    StudentId = students[4].Id,
                    Grade = 3,
                    IsStudentWasAttended = true,
                    LectureDate = DateTime.Now
                },
                new LecturesStudentsDb
                {
                    LectureId = lectures[2].Id,
                    StudentId = students[3].Id,
                    Grade = 5,
                    IsStudentWasAttended = true,
                    LectureDate = DateTime.Now
                },
                new LecturesStudentsDb
                {
                    LectureId = lectures[1].Id,
                    StudentId = students[3].Id,
                    Grade = 0,
                    IsStudentWasAttended = true,
                    LectureDate = DateTime.Now
                },
                new LecturesStudentsDb
                {
                    LectureId = lectures[1].Id,
                    StudentId = students[4].Id,
                    Grade = 0,
                    IsStudentWasAttended = false,
                    LectureDate = DateTime.Now
}
};

            modelBuilder.ApplyConfiguration(new LectureDbStudentDbConfiguration());
            modelBuilder.ApplyConfiguration(new HomeworkDbStudentDbConfiguration());

            modelBuilder.Entity<HomeworkDb>().HasData(homeworks);
            modelBuilder.Entity<StudentDb>().HasData(students);
            modelBuilder.Entity<LectureDb>().HasData(lectures);
            modelBuilder.Entity<LectorDb>().HasData(lectors);
            modelBuilder.Entity<LecturesStudentsDb>().HasData(lecturesStudents);
            modelBuilder.Entity<HomeworksStudentsDb>().HasData(homeworksStudents);
        }
    }


    // Relationships configurations
    internal class LectureDbStudentDbConfiguration : IEntityTypeConfiguration<LecturesStudentsDb>
    {
        public void Configure(EntityTypeBuilder<LecturesStudentsDb> builder)
        {
            builder.HasKey(s => new { s.StudentId, s.LectureId });

            builder.HasOne(ss => ss.Student)
                   .WithMany(s => s.LecturesStudents)
                   .HasForeignKey(ss => ss.StudentId);

            builder.HasOne(ss => ss.Lecture)
                   .WithMany(s => s.LecturesStudents)
                   .HasForeignKey(ss => ss.LectureId);
        }
    }

    internal class HomeworkDbStudentDbConfiguration : IEntityTypeConfiguration<HomeworksStudentsDb>
    {
        public void Configure(EntityTypeBuilder<HomeworksStudentsDb> builder)
        {
            builder.HasKey(s => new { s.StudentId, s.HomeworkId });

            builder.HasOne(ss => ss.Student)
                   .WithMany(s => s.HomeworksStudents)
                   .HasForeignKey(ss => ss.StudentId);

            builder.HasOne(ss => ss.Homework)
                   .WithMany(s => s.HomeworksStudents)
                   .HasForeignKey(ss => ss.HomeworkId);
        }
    }
}