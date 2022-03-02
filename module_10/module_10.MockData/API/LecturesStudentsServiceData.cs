namespace module_10.MockData.API
{
    public static class LecturesStudentsServiceData
    {
        public static string Get_All_LecturesStudents()
        {
            return MockResources.All_LecturesStudents_json;
        }

        public static string Get_Predefined_LectureStudent_Json()
        {
            return MockResources.One_LectureStudent_json;
        }
    }
}