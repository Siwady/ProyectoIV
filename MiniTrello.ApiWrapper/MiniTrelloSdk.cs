using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MiniTrello.Win8Phone.Models;
using MiniTrello.Domain.Entities;
using RestSharp;

namespace MiniTrello.ApiWrapper
{
    public class MiniTrelloSdk
    {
        private static RestRequest InitRequest(string resource, Method method,object payload)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(payload);
            return request;
        }

        public static AuthenticationModel Login(AccountLoginModel loginModel)
        {
                var client = new RestClient(BaseUrl);
                var request = InitRequest("/login", Method.POST, loginModel);
                IRestResponse<AuthenticationModel> response = client.Execute<AuthenticationModel>(request);
                ConfigurationManager.AppSettings["accessToken"] = response.Data.Token;
                return response.Data;
        }

        public static ReturnModel Register(AccountRegisterModel registerModel)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/register", Method.POST, registerModel);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel CreateOrganization(OrganizationModel organizationModel)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/CreateOrganization/" + ConfigurationManager.AppSettings["accessToken"], Method.POST, organizationModel);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel CreateBoard(AccountBoardsModel boardModel)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/CreateBoard/" + ConfigurationManager.AppSettings["accessToken"], Method.POST, boardModel);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }
        public static ReturnModel CreateLine(LineModel laneModel)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/CreateLane/" + ConfigurationManager.AppSettings["accessToken"], Method.POST, laneModel);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel CreateCard(CardModel cardModel)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/CreateCard/" + ConfigurationManager.AppSettings["accessToken"], Method.POST, cardModel);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeBoardName(ChangeBoardsTitleModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/boards/changeName/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel Movercard(MoveCardModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/cards/moveCard/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel UpdateDate(UpdateDataModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/updateData/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ResetPassword(ResetPasswordModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/resetPassword", Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }


        public static ReturnModel DeleteBoard(BoardArchiveModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/boards/deleteBoard/" + ConfigurationManager.AppSettings["accessToken"], Method.DELETE, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        private static string BaseUrl
        {
            get { return "http://localhost:1416"; }
        }

        public static List<OrganizationModel> GetOrganization()
        {

            return null;
        } 

        
    }

    
}
