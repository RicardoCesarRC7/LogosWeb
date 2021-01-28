angular
    .module('logosApp')
    .controller('BottomButtonsController', ['$scope', '$timeout', BottomButtonsController]);

function BottomButtonsController($scope, $timeout) {

    var self = this;

    self.refreshModalSelect2 = function () {

        $timeout(function () {
            $('#modal-form-interesse .area-interesse-form').select2({ dropdownParent: $('#modal-form-interesse'), theme: 'classic', placeholder: 'Clique para selecionar a área de interesse' });
            $('#modal-form-interesse .curso-interesse-form').select2({ dropdownParent: $('#modal-form-interesse'), theme: 'classic', placeholder: 'Clique para selecionar o curso de interesse' })
            $('#modal-form-interesse .formato-interesse-form').select2({ dropdownParent: $('#modal-form-interesse'), theme: 'classic', placeholder: 'Clique para selecionar o formato' });
        }, 500);
    }
}
