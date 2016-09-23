(function () {
    'use strict';
    var controllerId = 'projects';
    angular.module('app').controller(controllerId, ['common', projects]);

    function projects(common, pingResource) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        activate();

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Projects List View'); });
        }
    }
})();