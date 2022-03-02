namespace module_10.MockData.API
{
    public static class HomeworkStudentsServiceData
    {
        public static string Get_All_HomeworkStudents()
        {
            return MockResources.All_HomeworksStudents_json;
        }

        public static string Get_Predefined_HomeworkStudents_Json()
        {
            return MockResources.One_HomeworkStudent_json;
        }
    }
}