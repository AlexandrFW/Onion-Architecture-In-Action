namespace module_10.MockData.API
{
    public static class HomeworksServiceData
    {
        public static string Get_All_Homeworks()
        {
            return MockResources.All_Homework_json;
        }

        public static string Get_Predefined_Homework_Json()
        {
            return MockResources.One_Homework_json;
        }

        public static string Get_Json_For_New_Homework()
        {
            return MockResources.New_Homework_json;
        }
    }
}