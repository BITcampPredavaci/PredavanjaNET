(function () {

    var mod = angular.module("contactModule", ['contactController']);

    mod.directive("contactList", function () {
        return {
            templateUrl: "/Scripts/app/template/contactList.html",
            controller: "ContactListCtrl as contactsCtrl"
        };
    });

    mod.directive("contactForm", function () {
        return {
            templateUrl: "/Scripts/app/template/contactForm.html",
            controller: "ContactCtrl as ctrl"
        };
    });

})();