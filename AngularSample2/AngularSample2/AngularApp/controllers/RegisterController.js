


(function () {

    var mod = angular.module("userModule", ["ngCookies", "ui.router"]);

    mod.service("UserService",
        ["$http", "$httpParamSerializer", "$state", "$cookies",
            function ($http, $httpParamSerializer, $state, $cookies) {

                var self = this;
                self.register = register;
                self.errorMessages = [];
                self.login = login;
                self.logout = logout;

                self.username = "";
                self.access_token = "";
                self.isLoggedIn = false;

                initUser();

                function logout() {
                    $http.post("/api/account/logout").then(function(){
                        $cookies.remove("user");
                        self.username = "";
                        self.access_token = "";
                        self.isLoggedIn = false;
                    });
                    
                    
                }

                function initUser() {
                    var user = $cookies.get("user");
                    if (user) {
                        user = JSON.parse(user);
                        self.username = user.username;
                        self.isLoggedIn = true;
                        self.access_token = user.access_token;
                    } else {
                        self.isLoggedIn = false;
                    }
                }

                function login(user) {
                    user.grant_type = "password";
                    $http.post("/token",
                        $httpParamSerializer(user), {
                            "Content-Type": "application/x-www-urlformencoded"
                        }).then(function (response) {

                            var loggedInUser = {
                                username: user.username,
                                isLoggedIn: true,
                                access_token: response.data.access_token
                            };

                            $cookies.putObject("user", loggedInUser);
                            initUser();
                            $state.go("home");
                        }, function (err) {
                            self.errorMessages.push(err.data.error_description);
                        });
                }

                function register(params) {
                    self.errorMessages = [];
                    $http.post("/api/account/register", params)
                    .then(function (response) {
                        console.log(response);
                        self.login({
                            username: params.email,
                            password: params.password
                        });
                    }, function (err) {
                        var modelState = err.data.ModelState;

                        angular.forEach(modelState, function (errorMessages, attribute) {
                            if (attribute != "$id") {
                                angular.forEach(errorMessages, function (value, key) {
                                    self.errorMessages.push(value);
                                });
                            }
                        });
                    });
                }


                return self;
            }]);

    mod.controller("RegisterController", ["UserService", function (UserService) {

        var self = this;
        self.user = {
            email: "mail@mail.com",
            password: "Password1!",
            confirmPassword: "Password2!"
        };
        self.submit = submit;
        self.userService = UserService;
        self.login = login;

        function login() {
            UserService.login({
                username: self.user.email,
                password: self.user.password
            });
        }

        function submit() {
            UserService.register(self.user);
        };

    }]);

    mod.controller("NavbarController", ["UserService",
    function (UserService) {
        var self = this;
        self.userService = UserService;
    }]);

    mod.directive("navigation", function () {
        return {
            templateUrl: "/AngularApp/templates/navbar.html",
            controller: "NavbarController",
            controllerAs: "navCtrl"
        };
    });

})();