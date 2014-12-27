(function () {
    'use strict';
    var controllerId = 'account';
    angular.module('identityApp').controller(controllerId, ['$rootScope', '$location', '$window', 'common', 'AUTH_EVENTS', 'AuthService', account]);

    function account($rootScope, $location, $window, common, AUTH_EVENTS, AuthService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var successLogger = getLogFn(controllerId, 'success');
        var errorLogger = getLogFn(controllerId, 'error');

        var vm = this;

        vm.credentials = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: ''
        };
        vm.title = 'Login';
        vm.register = register;
        vm.login = login;
        vm.logout = logout;
        vm.authenticated = false;
        vm.createNew = false;

        function register(credentials) {
            log(credentials);
            AuthService.register(credentials).then(function (data, status, headers, config) {
                $rootScope.$broadcast(AUTH_EVENTS.registrationSuccess);
                successLogger('registered');
                resetView();
            }, function () {
                $rootScope.$broadcast(AUTH_EVENTS.registrationFailed);
                errorLogger('notregistered');
            });
        };

        function login(credentials) {
            AuthService.login(credentials).then(function () {
                $rootScope.$broadcast(AUTH_EVENTS.loginSuccess, [credentials.email]);
                successLogger('logged in ' + AuthService.isAuthenticated());
                vm.authenticated = true;
                
            }, function () {
                $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
                vm.authenticated = false;
            });
        };
      
        function logout() {
            AuthService.logout();
            vm.authenticated = false;
           
        };

        function resetView() {
            vm.credentials = {
                userName: '',
                email: '',
                password: '',
                confirmPassword: ''
            };
            vm.createNew = false;
            vm.authenticated = false;
        };

    }
})();