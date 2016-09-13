(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'pingResource', dashboard]);

    function dashboard(common, pingResource) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        activate();

        function activate() {
            var promises = [ping()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function ping() {
            return pingResource.get().$promise.then(function (data) {
                console.log(data.message);
                return data;
            });
        }
    }
})();