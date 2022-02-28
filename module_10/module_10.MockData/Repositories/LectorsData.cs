using Domain.Models; 
using System.Collections.Generic;
using System.Linq;

namespace module_10.MockData.Repositories
{
    public static class LectorsData
    {
        private static List<Lector> _lectors = new()
        {
            new Lector { Id = 1, Name = "Vitaly Genadievich Gromov", Age = 45, Email = "vitaly.gromov@universitat.ru", Phone = "+79010078912" },
            new Lector { Id = 2, Name = "Anatoly Vladimirovich Smolny", Age = 52, Email = "anatoly.smolny@universitat.ru", Phone = "+79011010015" },
            new Lector { Id = 3, Name = "Galina Petrovna Antonuk", Age = 43, Email = "galina.antonuk@universitat.ru", Phone = "+79019661234" },
            new Lector { Id = 4, Name = "Daria Grigorievna Anopko", Age = 48, Email = "daria.anopko@universitat.ru", Phone = "+79019051256" },
            new Lector { Id = 5, Name = "Dmitry Alexandrovich Zavyalov", Age = 39, Email = "dmitry.zavyalov@universitat.ru", Phone = "+79010987645" }
        };

        public static IEnumerable<Lector> GetAll() => _lectors;

        public static Lector Get(int id)
        {
            return GetAll().ToList().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}