namespace module_10.MockData.API
{
    public static class LecturesServiceData
    {
        public static string Get_All_Lectures()
        {
            return MockResources.All_Lectures_json;
        }

        public static string Get_Predefined_Lecture_Json()
        {
            return MockResources.One_Lecture_json;
        }
    }
}