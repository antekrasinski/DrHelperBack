namespace DrHelperBack.DTOs
{
    public class UserReadDTO
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string description { get; set; }
        public int id_user_type { get; set; }
    }
}
