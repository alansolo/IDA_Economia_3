var app = angular.module("MyApp", []);

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('main').className += 'loaded';
});

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {

    var urlPathSystem = "";

    var myDate = new Date();
    var dd = myDate.getDate();

    var mm = myDate.getMonth() + 1;
    var yyyy = myDate.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    myDate = dd + '/' + mm + '/' + yyyy;

    //Inicializar fecha
    var date_input = $(".fecha");
    date_input.datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
        language: "es",
        setDate: myDate
    });

    $scope.FechaInicio = myDate;
    $scope.FechaFinal = myDate;

    $scope.ObtenerLog = function () {
        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/Log/ObtenerLog",
            data: JSON.stringify(
                {
                    'usuario': $scope.Usuario,
                    'strFechaInicio': $scope.FechaInicio,
                    'strFechaFinal': $scope.FechaFinal
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                if (datos.Mensaje != "") {
                    MessageInfo("Historico Actividades", datos.Mensaje);

                    $scope.$apply();

                    $("#myModalLoader").modal('hide');

                    return;
                }

                $scope.ListLog = datos.ListaLog;

                MessageSuccess("Historico Actividades", "Se obtuvo correctamente la informacion.");

                $scope.$apply();

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });
    };

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