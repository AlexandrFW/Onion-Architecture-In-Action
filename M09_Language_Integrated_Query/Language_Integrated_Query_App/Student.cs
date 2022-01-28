using System;
using System.Text.Json.Serialization;

namespace Language_Integrated_Query_App
{
    public class Student : IComparable<Student>, IEquatable<Student>
    {
        [JsonPropertyName("first_name")]
        public string First_Name { get; set; }

        [JsonPropertyName("last_name")]
        public string Last_Name { get; set; }

        [JsonPropertyName("test_name")]
        public string Test_Name { get; set; }

        [JsonPropertyName("mark")]
        public int Mark { get; set; }

        [JsonPropertyName("date_pass")]
        public DateTime Date_Pass { get; set; }

        public int CompareTo(Student other)
        {
            if (First_Name == other.First_Name &&
                Last_Name == other.Last_Name &&
                Test_Name == other.Test_Name &&
                Mark == other.Mark &&
                Date_Pass == other.Date_Pass)
                return 0;

            return -1;
        }

        public bool Equals(Student other)
        {
            if (First_Name == other.First_Name &&
                Last_Name == other.Last_Name &&
                Test_Name == other.Test_Name &&
                Mark == other.Mark &&
                Date_Pass == other.Date_Pass)
                return true;

            return false;
        }
    }
}