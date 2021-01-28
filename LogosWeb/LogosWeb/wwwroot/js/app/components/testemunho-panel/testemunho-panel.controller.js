angular
    .module('logosApp')
    .controller('TestemunhoPanelController', ['$scope', '$http', '$timeout', TestemunhoPanelController]);

function TestemunhoPanelController($scope, $http, $timeout) {

    var self = this;

    self.testemunhos = null;

    self.init = function () {

        self.getTestemunhos();
    }

    self.getTestemunhos = function () {

        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetTestemunhos'
        }).then(function success(response) {

            if (response != null) {

                self.testemunhos = response.data;

                $timeout(function () {
                    self.refreshTestemunhoSlider();
                }, 500);
            }
        });
    }

    self.refreshTestemunhoSlider = function () {

        $('#testemunho-slider').trigger('destroy.owl.carousel');

        $('#testemunho-slider').owlCarousel($.extend({
            autoplay: 5000,
            nav: 1,
            items: 1,
            loop: 1,
            navText: [
                '<span class="ti-arrow-left"></span>',
                '<span class="ti-arrow-right"></span>'
            ],
        }, $(this).data('carousel-options')));

    }
}
