(function () {
    'use strict';
    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ui.router',
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)
        'ngResource',
        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions

        // 3rd Party Modules
        'ui.bootstrap'      // ui-bootstrap (ex: carousel, pagination, dialog)
    ]);
})();