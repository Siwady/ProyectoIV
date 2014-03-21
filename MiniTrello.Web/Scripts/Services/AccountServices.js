'use strict';

angular.module('app.services',[]).factory('AccountServices', ['$http', function ($http) {

    var account = {};

    var baseRemoteUrl = "http://minitrelloapi.apphb.com";
    var baseLocalUrl = "http://localhost:1416";
    var baseUrl = baseLocalUrl;

    account.login = function (model) {
        return $http.post(baseUrl + '/login', model);
    };

    account.register = function (model) {
        return $http.post(baseUrl + '/register', model);
    };

    account.resetPassword = function (data) {
        return $http.put(baseUrl + '/resetPassword', data);
    };

    account.ChangePassword= function (data) {
        return $http.put(baseUrl + "/ChangePassword/" + data.Token, data);
    };

    account.getNameUserLogged = function() {
        return $http.get(baseUrl + '/' + $window.sessionStorage.token);
    };
    return account;

}]);