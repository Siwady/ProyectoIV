'use strict';

angular.module('app.services').factory('BoardServices', ['$http', '$window', function ($http, $window) {

    var board = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:1416";
    var baseUrl = baseLocalUrl;

    board.getBoardsForLoggedUser = function (id) {

        return $http.get(baseUrl + '/boards/' +id+'/'+ $window.sessionStorage.token);
    };

    board.addBoard = function (model) {
        console.log("entreeee"+ model.OrganizationId);
        return $http.post(baseUrl + '/CreateBoard/' + model.OrganizationId + '/' + $window.sessionStorage.token, model);
    };
    return board;

}]);