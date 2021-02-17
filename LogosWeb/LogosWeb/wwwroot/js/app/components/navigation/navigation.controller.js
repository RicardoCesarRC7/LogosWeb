angular
    .module('logosApp')
    .controller('NavigationController', NavigationController);

function NavigationController($scope) {

    var self = this;

    self.baseUrl = window.location.protocol + '//' + window.location.host

    self.menuItems = [
        { nome: 'Home', url: self.baseUrl + '/', subMenuItems: [] },
        { nome: 'Sobre nós', url: self.baseUrl + '/Sobre', subMenuItems: [] },
        {
            nome: 'Cursos', url: self.baseUrl + '/Cursos', subMenuItems: [
                {
                    nome: 'Master', url: self.baseUrl + '/Cursos', subMenuItems: [
                        { nome: 'Ministério', url: self.baseUrl + '/Cursos/Detalhes/2' },
                        { nome: 'Aconselhamento Bíblico', url: self.baseUrl + '/Cursos/Detalhes/3' }
                    ]
                },
                {
                    nome: 'Pós-graduação', url: self.baseUrl + '/Cursos', subMenuItems: [
                        { nome: 'Aconselhamento Bíblico', url: self.baseUrl + '/Cursos/Detalhes/5' },
                        { nome: 'Exposição Bíblica', url: self.baseUrl + '/Cursos/Detalhes/6' },
                        { nome: 'Liderança Cristã', url: self.baseUrl + '/Cursos/Detalhes/7' },
                        { nome: 'Educação Musical', url: self.baseUrl + '/Cursos/Detalhes/8' },
                    ]
                },
                {
                    nome: 'Graduação', url: self.baseUrl + '/Cursos', subMenuItems: [
                        { nome: 'Teologia Ministerial', url: self.baseUrl + '/Cursos/Detalhes/1', subMenuItems: [] }
                    ]
                },
                { nome: 'Música Sacra', url: self.baseUrl + '/Cursos/Detalhes/4', subMenuItems: [] },
            ]
        },
        { nome: 'Professores', url: self.baseUrl + '/Professores', subMenuItems: [] },
        { nome: 'Blog', url: self.baseUrl + '/Blog', subMenuItems: []},
        { nome: 'Fale conosco', url: self.baseUrl + '/Contato', subMenuItems: [] },
        { nome: 'Área do aluno', url: 'https://portal.sponteeducacional.net.br/default.aspx?CID=71311', subMenuItems: [] }
    ];

    self.init = function () {

    }

}

