//Definir una clase JS utilizando prototype

function TicketViewController() {

    this.ViewName = "Tickets";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Tickets";

    //metodo constructor
    this.InitView = function () {
        //Invocar la carga de la tabla
        this.LoadTable();
    }

    //metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        //https://localhost:7053/api/Tickets/RetrieveAll
        //Endpoint que vamos a consumir
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        //Match de las columnas
        var columns = [];
        columns[0] = { 'data': 'id', title: 'ID' };
        columns[1] = { 'data': 'price', title: 'Precio' };
        columns[2] = { 'data': 'schedule', title: 'Horario' };
        columns[3] = { 'data': 'date', title: 'Fecha' };
        columns[4] = { 'data': 'type', title: 'Tipo' };
        columns[5] = { 'data': 'created', title: 'Creado' };
        columns[6] = { 'data': 'updated', title: 'Actualizado' };

        //Convertir la tabla plana en una tabla mas dinamica
        $("#tblTickets").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });
    }
}

//Instancia de la clase
$(document).ready(function () {

    var vc = new TicketViewController();
    vc.InitView();
});