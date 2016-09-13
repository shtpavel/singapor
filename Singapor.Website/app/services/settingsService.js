(function () {
    'use strict';

    var serviceId = 'settingsService';
    angular.module('app').factory(serviceId, ['common', '$http', settingsProvider]);

    function settingsProvider(common, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);

        var service = {
            getSettings: getSettings
        };

        return service;

        function getSettings() {
            return $http({
                method: 'GET',
                url: '/api/settings'
            }).then(function successCallback(response) {
                return response.data;
            }, function errorCallback(response) {
                log("Can't access settings resource!" + response);
            });
        }
    }
})();