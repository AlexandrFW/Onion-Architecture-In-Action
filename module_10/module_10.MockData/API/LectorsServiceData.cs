namespace module_10.MockData.API
{
    public static class LectorsServiceData
    {
        public static string Get_All_Lectors()
        {
            return MockResources.All_Lectors_json;
        }

        public static string Get_Predefined_Lectors_Json()
        {
            return MockResources.One_Lector_json;
        }
    }
}