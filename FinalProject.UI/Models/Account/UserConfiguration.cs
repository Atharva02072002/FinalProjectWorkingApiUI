namespace FinalProject.UI.Models.Account
{
    public class UserConfigurationDetail
    {
        public Dictionary<string, UserDetails> Users { get; set; }
    }

    public class UserDetails
    {
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }

}
