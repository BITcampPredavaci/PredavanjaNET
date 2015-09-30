(function () {

    var mod = angular.module("contactController", []);



    mod.controller("ContactListCtrl", ["ContactService", function (ContactService) {
        var ctrl = this;
        ctrl.contactService = ContactService;

        ctrl.selectContact = function (contact) {
            ContactService.selectContact(contact);
        };
    }]);

    mod.controller("ContactCtrl", ["ContactService", function (ContactService) {
        var ctrl = this;
        ctrl.contactService = ContactService;
    }]);


    mod.service("ContactService", function ($http) {
        var service = this;
        service.contactList = [];
        service.selected = {};
        loadContacts();

        service.selectContact = function (contact) {
            service.selected = contact;
        };

        service.saveContact = function () {
            if (service.selected.Id) {
                $http.put("/api/contacts/" + service.selected.Id, service.selected);
                service.selected = {};
            } else {
                $http.post("/api/contacts", service.selected).then(function (response) {
                    service.contactList.push(response.data);
                    service.selected = {};
                }, function (err) {
                    console.log(err);
                });
            }
        };

        function loadContacts() {
            $http.get("/api/contacts").then(function (response) {
                service.contactList = response.data;
            });
        };

        return service;
    });

})();