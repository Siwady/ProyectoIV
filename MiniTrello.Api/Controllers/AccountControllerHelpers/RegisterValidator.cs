
using MiniTrello.Win8Phone.Models;
using MiniTrello.Domain.Entities;
using MiniTrello.Domain.Services;

namespace MiniTrello.Win8Phone.Controllers.AccountControllerHelpers
{
    public class RegisterValidator : IRegisterValidator<AccountRegisterModel>
    {
        public string Validate(AccountRegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return "Claves no son iguales";
            }
            return "";
        }

    }
}