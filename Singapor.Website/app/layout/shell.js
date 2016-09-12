(function () { 
    'use strict';
    
    var controllerId = 'shell';
    angular.module('app').controller(controllerId,
        ['$rootScope', 'common', 'config', shell]);

    function shell($rootScope, common, config) {
        var vm = this;
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        var events = config.events;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.spinnerOptions = {
            radius: 40,
            lines: 7,
            length: 0,
            width: 30,
            speed: 1.7,
            corners: 1.0,
            trail: 100,
            color: '#F58A00'
        };

        activate();

        function activate() {
            common.activateController([], controllerId);

            fix_height();

            $(window).bind("load", function () {
                if ($("body").hasClass('fixed-sidebar')) {
                    $('.sidebar-collapse').slimScroll({
                        height: '100%',
                        railOpacity: 0.9
                    });
                }
            });

            $(window).bind("load resize scroll", function () {
                if (!$("body").hasClass('body-small')) {
                    fix_height();
                }
            });

            $('.full-height-scroll').slimscroll({
                height: '100%'
            })

            $(window).bind("resize", function () {
                if ($(this).width() < 769) {
                    $('body').addClass('body-small')
                } else {
                    $('body').removeClass('body-small')
                }
            });

            $('.collapse-link').click(function () {
                var ibox = $(this).closest('div.ibox');
                var button = $(this).find('i');
                var content = ibox.find('div.ibox-content');
                content.slideToggle(200);
                button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
                ibox.toggleClass('').toggleClass('border-bottom');
                setTimeout(function () {
                    ibox.resize();
                    ibox.find('[id^=map-]').resize();
                }, 50);
            });
        }

        function fix_height() {
            var heightWithoutNavbar = $("body > #wrapper").height() - 61;
            $(".sidebard-panel").css("min-height", heightWithoutNavbar + "px");

            var navbarHeigh = $('nav.navbar-default').height();
            var wrapperHeigh = $('#page-wrapper').height();

            if (navbarHeigh > wrapperHeigh) {
                $('#page-wrapper').css("min-height", navbarHeigh + "px");
            }

            if (navbarHeigh < wrapperHeigh) {
                $('#page-wrapper').css("min-height", $(window).height() + "px");
            }

            if ($('body').hasClass('fixed-nav')) {
                if (navbarHeigh > wrapperHeigh) {
                    $('#page-wrapper').css("min-height", navbarHeigh - 60 + "px");
                } else {
                    $('#page-wrapper').css("min-height", $(window).height() - 60 + "px");
                }
            }
        }

        function toggleSpinner(on) {
             vm.isBusy = on;
        }

        $rootScope.$on('$routeChangeStart',
            function (event, next, current) { toggleSpinner(true); }
        );
        
        $rootScope.$on(events.controllerActivateSuccess,
            function (data) { toggleSpinner(false); }
        );

        $rootScope.$on(events.spinnerToggle,
            function (data) { toggleSpinner(data.show); }
        );
    };
})();