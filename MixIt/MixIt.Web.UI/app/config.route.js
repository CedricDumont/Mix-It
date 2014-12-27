(function () {
    'use strict';

    var app = angular.module('identityApp');

    // Collect the routes
    app.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);

    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    title: 'account',
                    templateUrl: 'app/account/account.html',
                  
                }
            },
            {
                url: '/account',
                config: {
                    title: 'account',
                    templateUrl: 'app/account/account.html',
                  
                }
            },
             {
                 url: '/resources',
                 config: {
                     title: 'resources',
                     templateUrl: 'app/resources/resources.html',

                 }
             },
        ];
    }
})();