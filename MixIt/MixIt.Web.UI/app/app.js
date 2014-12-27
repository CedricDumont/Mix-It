(function () {
    'use strict';

    var app = angular.module('identityApp', [
        'ngRoute',
        'LocalStorageModule',
        'common'
    ]);

    if (typeof String.prototype.startsWith != 'function') {
  		String.prototype.startsWith = function (str){
   	 		return this.slice(0, str.length) == str;
  		};
	}
   
})();