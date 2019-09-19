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

            $scope.ListUsuario = datos.ListaUsuario;

            $scope.ListCatRol = datos.ListaCatRol;

            $scope.$apply();

            $("#myModalLoader").modal('hide');

        },
        error: function (error) {

            $("#myModalLoader").modal('hide');
        }
    });

    $scope.MostrarAgregarUsuario = function () {

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Usuario/MostrarAgregarUsuario",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.UsuarioAgregar = datos;

                $scope.TituloAgregarEditar = "Agregar Usuario";
                $scope.EsGuardar = true;
                $scope.EsEditar = false;

                $scope.$apply();

            },
            error: function (error) {
                
            }
        });

    }

    $scope.MostrarEditarUsuario = function (usuario) {

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Usuario/MostrarAgregarUsuario",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.RolAgregar = datos;

                $scope.$apply();

            },
            error: function (error) {

            }
        });

        $scope.UsuarioAgregar = usuario;

        $scope.TituloAgregarEditar = "Editar Usuario";
        $scope.EsGuardar = false;
        $scope.EsEditar = true;
    }

    $scope.MostrarInactivarUsuario = function (usuario) {

        $scope.UsuarioActivarInactivar = usuario;
        $scope.EsActivar = false;
        $scope.TituloActivarInactivar = "¿Esta seguro que desea inactivar el usuario?";
    }

    $scope.MostrarActivarUsuario = function (usuario) {

        $scope.UsuarioActivarInactivar = usuario;
        $scope.EsActivar = true;
        $scope.TituloActivarInactivar = "¿Esta seguro que desea activar el usuario?";
    }

    $scope.AgregarUsuario = function (usuario) {

        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Usuario/AgregarUsuario",
            data: JSON.stringify(
                {
                    'usuario': usuario,
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.ListUsuario = datos.ListaUsuario;

                $scope.$apply();

                MessageSuccess("Agregar Usuario", "Se agrego correctamente el usuario.");

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });

    }

    $scope.EditarUsuario = function (usuario) {

        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Usuario/EditarUsuario",
            data: JSON.stringify(
                {
                    'usuario': usuario,
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                //$scope.ListUsuario = datos.ListaUsuario;

                $scope.$apply();

                MessageSuccess("Agregar Usuario", "Se edito correctamente el usuario.");

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });

    }

    $scope.InactivarUsuario = function (usuario) {

        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Usuario/InactivarUsuario",
            data: JSON.stringify(
            {
                'usuario': usuario,
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                //$scope.ListUsuario = datos.ListaUsuario;

                $scope.$apply();

                MessageSuccess("Agregar Usuario", "Se inactivo correctamente el usuario.");

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });

    }

    $scope.ActivarUsuario = function (usuario) {

        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Usuario/ActivarUsuario",
            data: JSON.stringify(
            {
                'usuario': usuario,
            }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                //$scope.ListUsuario = datos.ListaUsuario;

                $scope.$apply();

                MessageSuccess("Agregar Usuario", "Se activo correctamente el usuario.");

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });

    }

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