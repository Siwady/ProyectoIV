'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers')


    .controller('CardController', ['$scope', '$location', '$window', 'CardServices', '$stateParams', function ($scope, $location, $window, cardServices, $stateParams) {


        $scope.newCardModel = {
            Text: '',
            LineId: $stateParams.lineId
        };
        $scope.deleteCard = { Id: '' };
      
        $scope.cards = [];

        $scope.addCard = function () {
            console.log("dentro de la funcion___");
            console.log($scope.newCardModel);
            var ln = $stateParams.lineId;
            cardServices
                .addCard($scope.newCardModel)
              .success(function (data, status, headers, config) {
                  if (data.Code != null)
                      $location.path('/card/' + ln);
              })
              .error(function (data, status, headers, config) {
              });
            //$location.path('/');
        };

        $scope.delete = function (cardId) {
            var ln = $stateParams.lineId;
            $scope.deleteCard.Id = cardId;
            cardServices
                .delete($scope.deleteCard)
              .success(function (data, status, headers, config) {
                  $location.path('/card/' + ln);
              })
              .error(function (data, status, headers, config) {
                  console.log(data);
                  $location.path('/card/' + ln);
              });
            //$location.path('/');
        };

        $scope.getCardsForLoggedUser = function () {
            console.log($stateParams.lineId);
            cardServices
                .getCardsForLoggedUser($stateParams.lineId)
              .success(function (data, status, headers, config) {
                  $scope.cards = data;
              })
              .error(function (data, status, headers, config) {
                  console.log(data);
              });
            //$location.path('/');
        };

        $scope.GoToNewCard = function () {
            $location.path('/cards/newCard/' + $stateParams.lineId);
        };

        $scope.getCardsForLoggedUser();

    }]);