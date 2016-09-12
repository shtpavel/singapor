(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;

        var service = {
            ping: ping,
            getMessageCount: getMessageCount
        };

        return service;

        function ping() { return $q.when(72); }
    }
})();