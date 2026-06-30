//Definir una clase JS utilizando prototype

function UserViewController() {

    this.ViewName = "Users";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Users";

    //metodo constructor
    this.InitView = function () {
        //Invocar la carga de la tabla
        this.LoadTable();
    }

    //metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        https://localhost:7053/api/Users/RetrieveAll
        //Endpoint que vamos a consumir
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        //Match de las columnas
        var columns = [];
        columns[0] = { 'data': 'id', title: 'ID' };
        columns[1] = { 'data': 'userCode', title: 'User Code' };
        columns[2] = { 'data': 'name', title: 'Name' };
        columns[3] = { 'data': 'email', title: 'Email' };
        columns[4] = { 'data': 'password', title: 'Password' };
        columns[5] = { 'data': 'birthDate', title: 'Birth Date' };
        columns[6] = { 'data': 'status', title: 'Status' };
        columns[7] = { 'data': 'phoneNumber', title: 'Phone Number' };
        columns[8] = { 'data': 'created', title: 'Created' };
        columns[9] = { 'data': 'updated', title: 'Updated' };;

        //Convertir la tabla plana en una tabla mas dinamica
        $("#tblUsers").dataTable({
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

    var vc = new UserViewController();
    vc.InitView();
});