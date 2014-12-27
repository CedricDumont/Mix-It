(function () {
    'use strict';

    var app = angular.module('identityApp');

    var apiUrl = 'http://localhost:10073/';
    var idsrvUrl = 'https://localhost:44305/identity/';
    var publicApiUrl = 'http://localhost:14117/'

    var api = {
        account: apiUrl + 'api/account/',
        connect: idsrvUrl + 'connect/token',
        resource : publicApiUrl + 'resource/'
    };
    

    var config = {
        appErrorPrefix: '[ABS Error] ', //Configure the exceptionHandler decorator
        docTitle: 'Identirty',
        apiUrl: apiUrl,
        api: api,
        version: '0.1'
    };

    app.value('config', config);

    app.config(['$logProvider', function ($logProvider) {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
    }]);

})();