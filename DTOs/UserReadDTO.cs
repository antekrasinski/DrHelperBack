namespace DrHelperBack.DTOs
{
    public class UserReadDTO
    {
        public int idUser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string description { get; set; }
        public int idUserType { get; set; }
    }
}
