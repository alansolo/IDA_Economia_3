﻿var app = angular.module("MyApp", []);

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

    google.charts.load('current', { 'packages': ['line'] });

    $('#myModalLoader').modal('show');

    //$.ajax({
    //    type: "POST",
    //    url: urlPathSystem + "/MercadoCapital/ObtenerMenu",
    //    contentType: 'application/json; charset=utf-8',
    //    dataType: 'json',
    //    success: function (datos) {

    //        $scope.ListPantalla = datos;

    //        $scope.$apply();

    //        $("#myModalLoader").modal('hide');

    //    },
    //    error: function (error) {

    //        $("#myModalLoader").modal('hide');
    //    }
    //});

    $.ajax({
        type: "POST",
        url: urlPathSystem + "/MercadoCapital/ObtenerCatCapital",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {

            if (datos.Mensaje !== "OK") {
                MessageDanger("Mercado de Capitales", "No se pudo cargar la informacion de inicio, intenta de nuevo y si persiste el error contacta al administrador de sistemas.");

                $scope.$apply();

                $('#myModalLoader').on('shown.bs.modal', function (e) {
                    $("#myModalLoader").modal('hide');
                });

                return;
            }

            $scope.ListCatCapital = datos.ListaCatCapital;

            $scope.$apply();

            $('#myModalLoader').on('shown.bs.modal', function (e) {
                $("#myModalLoader").modal('hide');
            });
        },
        error: function (error) {

            $('#myModalLoader').on('shown.bs.modal', function (e) {
                $("#myModalLoader").modal('hide');
            });
        }
    });

    $scope.ObtenerEstadistico = function () {
        $('#myModalLoader').modal('show');

        var ListCatCapitalFiltro = $scope.ListCatCapital.filter(function (i, n) {
            return i.Check === true;
        });

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/MercadoCapital/ObtenerEstadistico",
            data: JSON.stringify(
                {
                    'strFechaInicio': $scope.FechaInicio,
                    'strFechaFinal': $scope.FechaFinal,
                    'ListCatCapital': ListCatCapitalFiltro
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                if (datos.Mensaje === "Sesion Expirada") {

                    $scope.$apply();

                    $('#myModalLoader').on('shown.bs.modal', function (e) {
                        $("#myModalLoader").modal('hide');
                    });

                    $window.location.href = urlPathSystem + "/Login/Login";
                }
                else if (datos.Mensaje.indexOf("Se debe") !== -1)
                {
                    MessageDanger("Mercado de Capitales", datos.Mensaje);

                    $scope.$apply();

                    $('#myModalLoader').on('shown.bs.modal', function (e) {
                        $("#myModalLoader").modal('hide');
                    });

                    return;
                }
                else if (datos.Mensaje !== "OK")
                {                  
                    MessageDanger("Mercado de Capitales", "No se pudo obtener el calculo de estadisticas, intenta de nuevo y si persiste el error contacta al administrador de sistemas.");

                    $scope.$apply();

                    $('#myModalLoader').on('shown.bs.modal', function (e) {
                        $("#myModalLoader").modal('hide');
                    });

                    return;
                }

                $scope.ListGraficoLinea = datos.ListaCurvaVarianza;

                $scope.ListEncabezadoEmpresa = datos.ListaEncabezadoEmpresa;

                $scope.ListDatos = datos.ListaDatos;

                $scope.ListEmpresa = datos.ListaEmpresa;               

                google.charts.setOnLoadCallback(drawChart);

                MessageSuccess("Mercado de Capitales", "Se realizo correctamente el calculo.");

                $scope.$apply();

                $('#myModalLoader').on('shown.bs.modal', function (e) {
                    $("#myModalLoader").modal('hide');
                });

            },
            error: function (error) {

                $('#myModalLoader').on('shown.bs.modal', function (e) {
                    $("#myModalLoader").modal('hide');
                });
            }
        });
    };

    function drawChart() {

        var ListGrafico = $scope.ListGraficoLinea;

        var data = new google.visualization.DataTable();
        data.addColumn('number', 'Riegos del \n portafolio');
        data.addColumn('number', 'Rendimiento \n del portafolio');

        //LLENAR INFORMACION
        $.each(ListGrafico, function (key, value) {

            data.addRow([value.Sigma, value.RendimientoAsumido]);
        });

        var options = {
            chart: {
                title: 'Curva de Varianza',
                subtitle: 'IDA Economia'
            },
            width: 900,
            height: 500,
            vAxis: { format: '#,##0.0000000' },
            hAxis: { format: '#,##0.0000000' },
            colors: ['#1c91c0']
        };
        
        var chart = new google.charts.Line(document.getElementById('linechart_material'));

        chart.draw(data, google.charts.Line.convertOptions(options));
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