namespace MiniTrello.Win8Phone.Models
{
    public class ChangePasswordModel:ReturnModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}