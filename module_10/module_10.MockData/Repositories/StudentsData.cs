using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace module_10.MockData.Repositories
{
    public static class StudentsData
    {
        private static List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Vasily Petrov", Age = 18, Email = "v.petrov@gmail.com", Phone = "+79002318921" },
            new Student { Id = 2, Name = "Grigory Sidorov", Age = 17, Email = "g.sidorov@yandex.ru", Phone = "+79052010015" },
            new Student { Id = 3, Name = "Anna Antonova", Age = 18, Email = "anna.antonova@yandex.ru", Phone = "+79103210945" },
            new Student { Id = 4, Name = "Svatlana Vasileva", Age = 18, Email = "s.vasileva@rambler.ru", Phone = "+79603019915" },
            new Student { Id = 5, Name = "Dmitry Nevedof", Age = 19, Email = "d.nefedov@gmail.com", Phone = "+79059872213" }
        };

        public static IEnumerable<Student> GetAll() => _students;

        public static Student Get(int id)
        {
            return GetAll().ToList().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}