var app = angular.module("MyApp", []);

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('main').className += 'loaded';
});

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {

    var urlPathSystem = "";

    $('#myModalLoader').modal('show');

    $.ajax({
        type: "POST",
        url: urlPathSystem + "/Usuario/ObtenerUsuario",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {

            $scope.ListUsuario = datos;

            $scope.$apply();

            $("#myModalLoader").modal('hide');

        },
        error: function (error) {

            $("#myModalLoader").modal('hide');
        }
    });

    function MessageInfo(titulo, message) {
        $.notify({
            // options
            icon: 'fa fa-info-circle fa-lg',
            title: "<span class='title-notify'><strong>" + titulo + "</strong></span><br/>",
            message: "<span class='message-notify'>" + message + "</span><br/>"
        }, {
            // settings
            type: 'info',
            delay: 8000
        });
    }

    function MessageSuccess(titulo, message) {
        $.notify({
            // options
            icon: 'fa fa-check-circle fa-lg',
            title: "<span class='title-notify'><strong>" + titulo + "</strong></span><br/>",
            message: "<span class='message-notify'>" + message + "</span><br/>"
        }, {
            // settings
            type: 'success',
            delay: 8000
        });
    }

    function MessageDanger(titulo, message) {
        $.notify({
            // options
            icon: 'fa fa-window-close fa-lg',
            title: "<span class='title-notify'><strong>" + titulo + "</strong></span><br/>",
            message: "<span class='message-notify'>" + message + "</span><br/>"
        }, {
            // settings
            type: 'danger',
            delay: 8000
        });
    }


});