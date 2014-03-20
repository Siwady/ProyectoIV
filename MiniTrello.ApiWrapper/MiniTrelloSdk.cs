using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MiniTrello.Domain.DataObjects;
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

        public static ReturnModel CreateBoard(BoardModel boardModel)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/CreateBoard/" + ConfigurationManager.AppSettings["accessToken"], Method.POST, boardModel);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }
        public static ReturnModel CreateLine(LaneModel laneModel)
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

        public static ReturnModel ChangeBoardName(ChangeBoardNameModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/boards/changeName/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeOrganizationName(ChangeOrganizationNameModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/organizations/changeName/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeOrganizationName(ChangeLaneNameModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/lanes/changeName/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeOrganizationName(ChangeCardDescriptionModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/cards/changeDescription/" + ConfigurationManager.AppSettings["accessToken"], Method.PUT, model);
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

        public static ReturnModel ChangeOrganizationName(DeleteOrganizationModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/organizations/deleteOrganization/" + ConfigurationManager.AppSettings["accessToken"], Method.DELETE, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeOrganizationName(DeleteBoardModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/boards/deleteBoard/" + ConfigurationManager.AppSettings["accessToken"], Method.DELETE, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeOrganizationName(DeleteLaneModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/lanes/deleteOrganization/" + ConfigurationManager.AppSettings["accessToken"], Method.DELETE, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        public static ReturnModel ChangeOrganizationName(DeleteCardModel model)
        {
            var client = new RestClient(BaseUrl);
            var request = InitRequest("/cards/deleteOrganization/" + ConfigurationManager.AppSettings["accessToken"], Method.DELETE, model);
            IRestResponse<ReturnModel> response = client.Execute<ReturnModel>(request);
            return response.Data;
        }

        

        private static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["baseUrl"]; }
        }

        public static List<OrganizationModel> GetOrganization()
        {

            return null;
        } 

        
    }

    public class ReturnModel
    {
    }

    public class ResetPasswordModel
    {
    }

    public class UpdateDataModel
    {
    }

    public class MoveCardModel
    {
    }

    public class DeleteCardModel
    {
    }

    public class DeleteLaneModel
    {
    }

    public class DeleteBoardModel
    {
    }

    public class DeleteOrganizationModel
    {
    }

    public class ChangeCardDescriptionModel
    {
    }

    public class ChangeLaneNameModel
    {
    }

    public class ChangeOrganizationNameModel
    {
    }

    public class ChangeBoardNameModel
    {
    }

    public class CardModel
    {
    }

    public class LaneModel
    {
    }

    public class BoardModel
    {

    }

    public class OrganizationModel
    {
    }
}
