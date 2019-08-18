var app = angular.module("MyApp", []);

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('main').className += 'loaded';
});

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {

    var urlPathSystem = "";

    $scope.visibleError = false;

    $scope.ValidarLogin = function (varUsuario, varPassword) {
        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Login/ValidarLogin",
            data: JSON.stringify(
                {
                    'usuario': varUsuario,
                    'password': varPassword
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {
                
                if (datos == "OK") {
                    $window.location.href = urlPathSystem + "/MercadoCapital/MercadoCapital";
                }
                else
                {
                    $scope.visibleError = true;
                    $scope.mensajeError = datos;
                }

                $scope.$apply();

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });
    };

});