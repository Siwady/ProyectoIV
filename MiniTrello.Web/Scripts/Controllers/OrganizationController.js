// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')



    // Path: /login
    .controller('OrganizationController', ['$scope', '$location', '$window', 'OrganizationServices', '$stateParams', function ($scope, $location, $window, organizationServices, $stateParams) {

        $scope.newOrganizationModel = { Title: '', Description: '' };

        $scope.organizations = [];
        $scope.deleteOrganization = {Id:''};
        $scope.getOrganizationsForLoggedUser = function () {

            organizationServices
                .getOrganizationsForLoggedUser()
              .success(function (data, status, headers, config) {
                  $scope.organizations = data;
              })
              .error(function (data, status, headers, config) {
                  console.log(data);
              });
            //$location.path('/');
        };

        $scope.delete = function (organizationId) {
            $scope.deleteOrganization.Id = organizationId;
            organizationServices
                .delete($scope.deleteOrganization)
              .success(function (data, status, headers, config) {
                  $location.path('/organizations');
              })
              .error(function (data, status, headers, config) {
                  console.log(data);
              });
            //$location.path('/');
        };
        $scope.addOrganization= function () {
            console.log("dentro de la funcion");
            organizationServices
                .addOrganization($scope.newOrganizationModel)
              .success(function (data, status, headers, config) {
                      $location.path('/organizations');
              })
              .error(function (data, status, headers, config) {
                  $location.path('/organizations');
              });
            //$location.path('/');
        };

        $scope.getOrganizationsForLoggedUser();
        
        $scope.GoToNewOrganization = function () {
            $location.path('/organizations/newOrganization');
        };

        $scope.GoToOrganization = function () {
            $location.path('/organizations');
        };

        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);