'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')



    // Path: /login
    .controller('BoardController', ['$scope', '$location', '$window', 'BoardServices', '$stateParams', function ($scope, $location, $window, boardServices, $stateParams) {


        $scope.newBoardModel = { Title: '', Description: '', OrganizationId: $stateParams.organizationId};
        $scope.deleteBoard = { Id: ''};
       

        $scope.boards = [];
        $scope.addBoard = function () {
            console.log("dentro de la funcion");
            boardServices
                .addBoard($scope.newBoardModel)
              .success(function (data, status, headers, config) {
                  if(data.Code!=null)
                    $location.path('/board/'+$stateParams.organizationId);
              })
              .error(function (data, status, headers, config) {
              });
            //$location.path('/');
        };

        $scope.delete = function (boardId) {
            $scope.deleteBoard.Id = boardId;
            boardServices
                .delete($scope.deleteBoard)
              .success(function (data, status, headers, config) {
                  $location.path('/board/' + $stateParams.organizationId);
              })
              .error(function (data, status, headers, config) {
                  console.log(data);
                  $location.path('/board/' + $stateParams.organizationId);
              });
            //$location.path('/');
        };

        $scope.getBoardsForLoggedUser = function () {
            console.log($stateParams.organizationId);
            boardServices
                .getBoardsForLoggedUser($stateParams.organizationId)
              .success(function (data, status, headers, config) {
                    $scope.boards = data;
                })
              .error(function (data, status, headers, config) {
                console.log(data);
            });
            //$location.path('/');
        };

        $scope.GoToNewBoard = function () {
            $location.path('/boards/newBoard/'+$stateParams.organizationId);
        };

        $scope.getBoardsForLoggedUser();
   

       

        //$scope.$on('$viewContentLoaded', function () {
            //$window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        //});
    }]);