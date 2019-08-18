var app = angular.module("MyApp", []);

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('main').className += 'loaded';
});

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {

    var urlPathSystem = "";

    google.charts.load('current', { 'packages': ['line'] });

    $scope.ObtenerEstadistico = function () {
        $('#myModalLoader').modal('show');

        $.ajax({
            type: "POST",
            url: urlPathSystem + "/MercadoCapital/ObtenerEstadistico",
            //data: JSON.stringify(
            //    {
            //        'usuario': varUsuario,
            //        'password': varPassword
            //    }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.ListGraficoLinea = datos.ListaCurvaVarianza;

                google.charts.setOnLoadCallback(drawChart);

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
        data.addColumn('number', 'Riegos del portafolio');
        data.addColumn('number', 'Rendimiento del portafolio');

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

});