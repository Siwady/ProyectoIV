'use strict';

angular.module('app.services').factory('LineServices', ['$http', '$window', function ($http, $window) {

    var line = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:1416";
    var baseUrl = baseLocalUrl;

    line.getLinesForLoggedUser = function (id) {

        return $http.get(baseUrl + '/lines/' + id + '/' + $window.sessionStorage.token);
    };

    line.addLine = function (model) {
        console.log("entreeee" + model.LineId);
        return $http.post(baseUrl + '/CreateLine/' + model.BoardId + '/' + $window.sessionStorage.token, model);
    };
    return line;

}]);