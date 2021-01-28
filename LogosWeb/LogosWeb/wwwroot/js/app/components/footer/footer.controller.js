angular
    .module('logosApp')
    .controller('FooterController', ['$scope', '$http', FooterController]);

function FooterController($scope, $http) {

    var self = this;

    self.endereco = 'Av. Eng. Armando de Arruda Pereira, 2747. Jabaquara, São Paulo-SP, Brasil';

    self.contatoInfo = null;

    self.init = function () {

        self.getContatoInfo();
    }

    self.getContatoInfo = function () {

        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetContatoInfo'
        }).then(function success(response) {

            if (response != null) {

                self.contatoInfo = response.data;

                self.contatoInfo.endereco = self.endereco;
            }
        });
    }
}
