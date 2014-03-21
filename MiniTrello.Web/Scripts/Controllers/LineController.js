'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')



    // Path: /login
    .controller('LineController', ['$scope', '$location', '$window', 'LineServices', '$stateParams', function ($scope, $location, $window, lineServices, $stateParams) {


        // $scope.boardDetailId = $stateParams.boardId;

        //console.log($location.search().boardId);
        $scope.newLineModel = { Text: '', BoardId: $stateParams.boardId };

        //console.log($scope.boardDetailId);

        $scope.lines = [];

        /*var board = { Id: 1, Name: 'Myboard1', Description: 'Description1' };
        var board1 = { Id: 2, Name: 'Myboard2', Description: 'Description2' };
        $scope.boards.push(board);
    $scope.boards.push(board1);*/
        $scope.addLine = function () {
            console.log("dentro de la funcion");
            lineServices
                .addLine($scope.newLineModel)
              .success(function (data, status, headers, config) {
                  if (data.Code != null)
                      $location.path('/line/' + $stateParams.boardId);
              })
              .error(function (data, status, headers, config) {
              });
            //$location.path('/');
        };

        $scope.getLinesForLoggedUser = function () {
            console.log($stateParams.boardId);
            lineServices
                .getLinesForLoggedUser($stateParams.boardId)
              .success(function (data, status, headers, config) {
                  $scope.lines = data;
              })
              .error(function (data, status, headers, config) {
                  console.log(data);
              });
            //$location.path('/');
        };

        $scope.GoToNewLine = function () {
            $location.path('/lines/newLine/' + $stateParams.boardId);
        };

        $scope.getLinesForLoggedUser();

    }]);