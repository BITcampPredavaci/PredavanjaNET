(function () {


    var app = angular.module("redditApp",
        [

        "ui.router",
        "jcs-autoValidate",

        "postCtrl",
        "userModule"
        ]);


    app.run([
    'defaultErrorMessageResolver',
    function (defaultErrorMessageResolver) {
        // passing a culture into getErrorMessages('fr-fr') will get the culture specific messages
        // otherwise the current default culture is returned.
        defaultErrorMessageResolver.getErrorMessages().then(function (errorMessages) {
            errorMessages['invalidPassword'] = 'Your password must contain uppercase/lowercase letters, a number and a special charcater';
        });
    }
    ]);

    app.config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/");

        $stateProvider

        .state("home", {
            url: "/",
            templateUrl: "/AngularApp/templates/index.html",
            controller: "PostController",
            controllerAs: "postCtrl"
        })

        .state("register", {
            url: "/register",
            templateUrl: "/AngularApp/templates/user/register.html",
            controller: "RegisterController",
            controllerAs: "regCtrl"
        })

        .state("login", {
            url: "/login",
            templateUrl: "/AngularApp/templates/user/login.html",
            controller: "RegisterController",
            controllerAs: "logCtrl"
        });

        ;

    });

    app.factory('httpRequestInterceptor', function ($cookies) {
        return {
            request: function (config) {
                var user = $cookies.get("user");
                if (user) {
                    user = JSON.parse(user);
                    config.headers['Authorization'] = 'Bearer ' + user.access_token;
                }
                return config;
            }
        };
    });

    app.config(function ($httpProvider, $cookiesProvider) {
        $httpProvider.interceptors.push('httpRequestInterceptor');
        $cookiesProvider.defaults.path = "/";
    });

    app.directive("home", function () {
        return {
            templateUrl: "/AngularApp/templates/index.html",
            controller: "PostController",
            controllerAs: "postCtrl"
        }
    });



})();