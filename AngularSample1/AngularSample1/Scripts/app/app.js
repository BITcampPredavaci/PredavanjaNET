(function () {

    var app = angular.module("contactApp", ['ngCookies','jcs-autoValidate', 'contactModule']);

    app.run([
    'defaultErrorMessageResolver',
    function (defaultErrorMessageResolver) {
        // passing a culture into getErrorMessages('fr-fr') will get the culture specific messages
        // otherwise the current default culture is returned.
        defaultErrorMessageResolver.getErrorMessages().then(function (errorMessages) {
            errorMessages['tooYoung'] = 'You have to be at least {0}';
            errorMessages['tooOld'] = "Can't be over {0}";
            errorMessages['namePattern'] = "Can only contain letters";
        });
    }]);



    app.factory('httpRequestInterceptor', function ($cookies) {
        return {
            request: function (config) {
                console.log("REQUESST");
                config.headers['Authorization'] = 'Bearer ' + $cookies.get("token");
                return config;
            }
        };
    });

    app.config(function ($httpProvider, $cookiesProvider) {
        $httpProvider.interceptors.push('httpRequestInterceptor');
        $cookiesProvider.defaults.path = "/";
    });

    app.controller("LoginCtrl", ["$http", "$httpParamSerializer", "$cookies", function ($http, $httpParamSerializer, $cookies) {

        var ctrl = this;
        ctrl.user = {
            email: "mail@mail.com",
            password: "Password1!"
        };

        ctrl.login = function () {
            var login = {
                username: ctrl.user.email,
                password: ctrl.user.password,
                grant_type: "password"
            };
            $http.post("/token", $httpParamSerializer(login),
                    {
                        'Content-Type': 'application/x-www-form-urlencoded' // Note the appropriate header
                    }
                    ).then(function (response) {
                        $cookies.put("token", response.data.access_token);
                    }, function (err) {
                        console.log(err);
                    });
        };
    }]);


    app.controller("RegisterCtrl", ["$http", "$httpParamSerializer", function ($http, $httpParamSerializer) {

        var ctrl = this;
        ctrl.user = {
            email: "mail@mail.com",
            password: "Password1!",
            confirmPassword: "Password1!"
        };

        ctrl.register = function () {
            $http.post("/api/Account/Register", ctrl.user)
            .then(function (response) {
                var login = {
                    username: ctrl.user.email,
                    password: ctrl.user.password,
                    grant_type: "password"
                };
                console.log(login);
                $http.post("/token", $httpParamSerializer(login),
                    {
                        'Content-Type': 'application/x-www-form-urlencoded' // Note the appropriate header
                    }
                    ).then(function (response) {
                        console.log(response);
                    }, function (err) {
                        console.log(err);
                    });

            }, function (err) {
                console.log(err);
            });
        };

    }]);


})();