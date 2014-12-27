(function () {
    'use strict';
    var controllerId = 'resources';
    angular.module('identityApp').controller(controllerId, ['$http','common', 'config', resources]);

    function resources($http, common, config) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
       
        var vm = this;

        vm.resource = '';
        vm.resourceId = '';
        vm.getResource = getResource;

        function getResource(id) {
            log(id);
            $http.get(config.api.resource + id).
               success(function (data, status, headers, config) {
                   vm.resource = data;
               }).
               error(function (data, status, headers, config) {
                   vm.resource = "could not load resource : " + data;
               });
        };
    }
})();