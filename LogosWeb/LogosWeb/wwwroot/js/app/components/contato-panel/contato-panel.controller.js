angular
    .module('logosApp')
    .controller('ContatoPanelController', ['$scope', '$http', '$timeout', ContatoPanelController]);

function ContatoPanelController($scope, $http, $timeout) {

    var self = this;

    self.contatoInfo = null;
    self.testemunhos = null;

    self.init = function () {

        self.getContatoInfo();
        self.getTestemunhos();
    }

    self.getContatoInfo = function () {

        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetLogosInfo'
        }).then(function success(response) {

            if (response != null) {

                self.contatoInfo = response.data;
            }
        });
    }

    self.getTestemunhos = function () {
        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetTestemunhos'
        }).then(function success(response) {

            if (response != null) {

                self.testemunhos = response.data;

                $timeout(function () {
                    self.refreshCarousel();
                }, 500);
            }
        });
    }

    self.refreshCarousel = function () {

        if ($('.review-carousel').length > 0) {

            $('.review-carousel').trigger('destroy.owl.carousel');

            $('.review-carousel').owlCarousel($.extend({
                nav: 0,
                dots: 1,
                autoplay: 1,
                items: 1,
                loop: 1,
                margin: 30,
                responsive: {
                    768: {
                        items: 2
                    },
                    1025: {
                        items: 3
                    }
                },
                navText: [
                    '<span class="ti-angle-left"></span>',
                    '<span class="ti-angle-right"></span>'
                ],
            }, $('.review-carousel').data('carousel-options')));
        }
    }
}
