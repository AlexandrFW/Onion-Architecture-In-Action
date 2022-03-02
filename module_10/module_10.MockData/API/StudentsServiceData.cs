namespace module_10.MockData.API
{
    public static class StudentsServiceData
    {
        public static string Get_All_Students()
        {
            return MockResources.All_Students_json;
        }

        public static string Get_Predefined_Student_Json()
        {
            return MockResources.One_Student_json;
        }
    }
}