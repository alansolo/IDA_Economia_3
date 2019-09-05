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

    google.charts.load('current', { 'packages': ['line'] });

    $('#myModalLoader').modal('show');

    $.ajax({
        type: "POST",
        url: urlPathSystem + "/MercadoDivisa/ObtenerCatDivisa",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {

            $scope.ListCatDivisa = datos;

            $scope.$apply();

            $("#myModalLoader").modal('hide');

        },
        error: function (error) {

            $("#myModalLoader").modal('hide');
        }
    });

    $scope.ObtenerEstadistico = function () {
        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/MercadoDivisa/ObtenerEstadistico",
            data: JSON.stringify(
                {
                    "strFechaInicio": $scope.FechaInicio,
                    "strFechaFinal": $scope.FechaFinal,
                    "ListCatDivisa": $scope.ListCatDivisa
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.ListGraficoLinea = datos.ListaDatos;

                google.charts.setOnLoadCallback(drawChart);

                MessageSuccess("Mercado de Divisa", "Se realizo correctamente el calculo.");

                $scope.$apply();

                $("#myModalLoader").modal('hide');

            },
            error: function (error) {

                $("#myModalLoader").modal('hide');
            }
        });
    };

    function drawChart() {

        var ListGrafico = $scope.ListGraficoLinea;

        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Fecha');
        data.addColumn('number', 'Valor');

        //LLENAR INFORMACION
        $.each(ListGrafico, function (key, value) {

            data.addRow([value.Fecha, value.Valor]);
        });

        var options = {
            chart: {
                title: 'Grafica Divisas',
                subtitle: 'IDA Economia'
            },
            width: 900,
            height: 500,
            vAxis: { format: '#,##0.00' },
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