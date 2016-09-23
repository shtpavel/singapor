(function () {
    var app = angular.module('app');

    app.config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/dashboard");

        $stateProvider
            .state("dashboard", {
                url: "/dashboard",
                templateUrl: "app/dashboard/dashboard.html"
            });

        $stateProvider
            .state("project", {
                abstract: true,
                url: "/projects",
                templateUrl: "app/layout/common/itemContainer.html",
                controller: "itemContainer as vm",
                resolve: {
                    _title: function() {
                        return "Projects";
                    }
                }   
            })
            .state("project.list", {
                url: "/list",
                templateUrl: "app/projects/projects.html"
            });
    });
})();