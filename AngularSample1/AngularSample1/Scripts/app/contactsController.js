(function () {

    var mod = angular.module("contactController", ["ngResource", "angular-ladda"]);

    mod.config(function (laddaProvider) {
        laddaProvider.setOption({
            style: 'expand-left'
        });
    });

    mod.factory("Contact", ["$resource", function ($resource) {
        return $resource("/api/contacts/:id", null, {

            update: { method: "put" }

        });
    }]);


    mod.controller("ContactListCtrl", ["ContactService", function (ContactService) {
        var ctrl = this;
        ctrl.contactService = ContactService;

        ctrl.selectContact = function (contact) {
            ContactService.selectContact(contact);
        };

        ctrl.remove = function (index) {
            var del = ctrl.contactService.contactList[index];
            del.$delete({ id: del.Id });
            ctrl.contactService.contactList.splice(index, 1);
        }; 
    }]);

    mod.controller("ContactCtrl", ["ContactService", function (ContactService) {
        var ctrl = this;
        ctrl.contactService = ContactService;
    }]);


    mod.service("ContactService", ["Contact", function (Contact) {
        var service = this;
        service.contactList = [];
        service.selected = new Contact();
        service.loading = false;
        loadContacts();

        service.selectContact = function (contact) {
            service.selected = contact;
        };

        service.saveContact = function () {
            service.loading = true;

            if (service.selected.Id) {
                service.selected.$update({ id: service.selected.Id }, function (response) {
                    service.loading = false;
                });
                angular.forEach(service.contactList, function (value, key) {
                    if (value.Id === service.selected.Id) {
                        service.contactList[key] = service.selected;
                    }
                });
            } else {
                service.selected.$save();
                service.contactList.push(service.selected);
            }
            service.selected = new Contact();
        };

        function loadContacts() {
                service.contactList = Contact.query();
        };

        return service;
    }]);

})();