namespace MiniTrello.Api.Models
{
    public class ChangePasswordModel:ReturnModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}