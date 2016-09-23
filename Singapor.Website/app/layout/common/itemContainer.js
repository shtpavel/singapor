(function () {
    'use strict';
    var controllerId = 'itemContainer';
    angular.module('app').controller(controllerId, ['common', '_title', itemContainer]);

    function itemContainer(common, _title) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = _title;

        activate();

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Projects List View'); });
        }
    }

    itemContainer
})();