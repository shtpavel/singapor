(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'pingProvider', dashboard]);

    function dashboard(common, pingProvider) {
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
            return pingProvider.get().$promise.then(function (data) {
                console.log(data.message);
                return data;
            });
        }
    }
})();