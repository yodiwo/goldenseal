namespace GoldenSealWebApi.DTOs.SchoolTournamentAPI
{
    public class Response
    {
        public string message { get; set; }
        public bool status { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string student_count { get; set; }
        public string company_name { get; set; }
        public string company_logo { get; set; }
        public int total_fm_with_scale { get; set; }
        public List<Top3Fm> top3_fm { get; set; }
        public List<AllFmWithGenerated> all_fm_with_generated { get; set; }
        public List<SmartScalesWeightByCategory> smart_scales_weight_by_category { get; set; }
    }
    public class AllFmWithGenerated
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_image { get; set; }
        public string total_generated { get; set; }
        public int rank { get; set; }
    }

    public class GeneratedWeightByCat
    {
        public string scale_type { get; set; }
        public string weight { get; set; }
        public string scale_type_id { get; set; }
    }
    public class SmartScalesWeightByCategory
    {
        public string type { get; set; }
        public string total_generated { get; set; }
    }
    public class Top3Fm
    {
        public string name { get; set; }
        public string total_generated { get; set; }
        public string profile_image { get; set; }
        public List<GeneratedWeightByCat> generated_weight_by_cat { get; set; }
    }
}
