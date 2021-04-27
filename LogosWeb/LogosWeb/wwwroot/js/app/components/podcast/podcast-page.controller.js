angular
    .module('logosApp')
    .controller('PodcastPageController', ['$scope', '$timeout', PodcastPageController]);

function PodcastPageController($scope, $timeout) {

    var self = this;

    self.content = [];

    self.podcastContent = {};

    self.init = function () {

        self.content = [
            { nome: 'Devocionais', descricao: 'Devocionais curtos' },
            { nome: 'Pílulas Acadêmicas', descricao: 'Conversa sobre assuntos específicos, tratados com abordagem acadêmica' },
            { nome: 'Painéis', descricao: 'Painéis sobre assuntos interessantes' },
            { nome: 'Eventos', descricao: 'Eventos gravados' }
        ];

        $timeout(function () {
            self.refreshCarousel();
        }, 500);
    }

    self.showPodcastList = function (podcast) {

        self.podcastContent = podcast;

        $('#podcast-list-section').show();

        self.scrollToList();
    }

    self.scrollToList = function () {

        $('html, body').animate({
            scrollTop: $('#podcast-list-section').offset().top - 100
        }, 1000);
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
