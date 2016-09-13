(function () {
    'use strict';

    var serviceId = 'pingResource';

    angular
        .module('app')
        .service(serviceId, ['$resource', pingProvider]);

    function pingProvider($resource) {
        var api_url = JSON.parse(localStorage.getItem("settings")).api_url;
        return $resource(api_url + '/ping', {},
            {
                query: {
                    method: 'get',
                    isArray: false
                }
            }
        );
    }
})();