function vIndex() {

    this.chartId = 'myChart';
    this.service = 'customer';
    this.ctrlActions = new ControlActions();

    this.GetDataToChart = function (initializeChartFunction) {

        this.ctrlActions.GetToApi(this.service + '?type=millenials', initializeChartFunction);
    };

   
}