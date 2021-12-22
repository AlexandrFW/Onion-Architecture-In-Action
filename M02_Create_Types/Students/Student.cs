using System;

namespace Students 
{
    public class Student : IEquatable<Student>
    {
        private const string Domain = "@epam.com";

        public string Email { get; private set; }

        public string FullName { get; private set; }

        public Student(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email argument should not be null or empty");

            Email = CapitalizedNameAndSurnameInEmailAddress(email);
            FullName = GetFullNameFromEmail(email);
        }

        public Student(string name, string surname)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name argument should not be null or empty");

            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("surname argument should not be null or empty");

            // Capitalized the first letter of a name and a surname
            string name_local = char.ToUpper(name[0]) + name.Substring(1);
            string surname_local = char.ToUpper(surname[0]) + surname.Substring(1);

            FullName = $"{name_local} {surname_local}";
            Email = $"{name_local}.{surname_local}{Domain}";
        }

        private string GetFullNameFromEmail(string email)
        {
            string[] arrSplitedStudentEmail = email.Substring(0, email.IndexOf('@')).Split('.');

            string name_local = char.ToUpper((arrSplitedStudentEmail[0])[0]) + arrSplitedStudentEmail[0].Substring(1);
            string surname_local = char.ToUpper((arrSplitedStudentEmail[1])[0]) + arrSplitedStudentEmail[1].Substring(1);

            return $"{name_local} {surname_local}";
        }

        private string CapitalizedNameAndSurnameInEmailAddress(string email)
        {
            string[] splitedEmail = email.Split('@');
            string name_surname = splitedEmail[0];
            string domain = splitedEmail[1];

            string[] arrSplitedNameAndSurname = name_surname.Split('.');

            string name_local = char.ToUpper((arrSplitedNameAndSurname[0])[0]) + arrSplitedNameAndSurname[0].Substring(1);
            string surname_local = char.ToUpper((arrSplitedNameAndSurname[1])[0]) + arrSplitedNameAndSurname[1].Substring(1);

            return $"{name_local}.{surname_local}@" + domain;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student other)
        {
            return other != null &&
                   Email == other.Email &&
                   FullName == other.FullName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, FullName);
        }
    }
}