(function () { 
    'use strict';
    
    var controllerId = 'sidebar';
    angular
        .module('app')
        .controller(controllerId,
        ['config', sidebar]);

    function sidebar(config) {
        var vm = this;

        activate();

        function activate() {
            $('#side-menu').metisMenu();
        }
    };
})();
