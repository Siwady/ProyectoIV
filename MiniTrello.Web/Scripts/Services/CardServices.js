'use strict';

angular.module('app.services').factory('CardServices', ['$http', '$window', function ($http, $window) {

    var card = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:1416";
    var baseUrl = baseLocalUrl;

    card.getCardsForLoggedUser = function (id) {

        return $http.get(baseUrl + '/cards/' + id + '/' + $window.sessionStorage.token);
    };

    card.addCard = function (model) {
        console.log("entreeee" + model.OrganizationId);
        return $http.post(baseUrl + '/CreateCard/' + model.LineId + '/' + $window.sessionStorage.token, model);
    };

    card.delete = function (model) {
        return $http.put(baseUrl + '/deleteCard/' + $window.sessionStorage.token, model);
    };

    return card;

}]);