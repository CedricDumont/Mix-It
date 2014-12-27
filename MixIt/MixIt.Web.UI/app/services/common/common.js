(function () {
    'use strict';

    var commonModule = angular.module('common', []);

    commonModule.factory('common',
        ['$q', '$rootScope', '$timeout', 'logger', common]);

    function common($q, $rootScope, $timeout, logger) {
        var throttles = {};

        var service = {
            // common angular dependencies
            $q: $q,
            $timeout: $timeout,
            // generic
            isNumber: isNumber,
            logger: logger, 
            textContains: textContains,
            isNull: isNull,
            isNotNull: isNotNull,
            prettyPrint: prettyPrint,
            findNonJsonLdProperties:findNonJsonLdProperties

        };

        return service;
     

        function isNumber(val) {
            // negative or positive
            return /^[-]?\d+$/.test(val);
        }

        function isNull(val) {
            if(!(val == null))
            {
                if (val === '')
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        function isNotNull(val) {
            return !isNull(val);
        }

        function textContains(text, searchText) {
            return text && -1 !== text.toLowerCase().indexOf(searchText.toLowerCase());
        }

        function prettyPrint(obj)
        {
            return JSON.stringify(obj, undefined, 2);
        }

        function findNonJsonLdProperties(doc)
        {
            var results = [];
            Object.keys(doc).forEach(function(key) {
                if(!key.startsWith('@'))
                {
                    console.log(key);
                    results.push(key);
                }
                
            });
            return results;

        }

        function findObject(collection, searchField, searchValue)
        {
            var results = [];

            for (var i = 0 ; i < collection.length ; i++) {
                if (collection[i][searchField] == searchValue) {
                    results.push(collection[i]);
                }
            }

            return results;
        };
    }
})();