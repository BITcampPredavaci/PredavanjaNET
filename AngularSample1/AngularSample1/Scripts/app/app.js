(function () {

    var app = angular.module("contactApp", ['jcs-autoValidate', 'contactModule']);

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
    }
    ]);

    

})();