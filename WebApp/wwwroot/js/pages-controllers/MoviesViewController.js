//Definir una clase JS utilizando prototype

function MovieViewController() {

    this.ViewName = "Movies";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Movies";

    //metodo constructor
    this.InitView = function () {
        //Invocar la carga de la tabla
        this.LoadTable();
    }

    //metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        //https://localhost:7053/api/Movies/RetrieveAll
        //Endpoint que vamos a consumir
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        //Match de las columnas
        var columns = [];
        columns[0] = { 'data': 'id', title: 'ID' };
        columns[1] = { 'data': 'title', title: 'Título' };
        columns[2] = { 'data': 'director', title: 'Director' };
        columns[3] = { 'data': 'year', title: 'Año' };
        columns[4] = { 'data': 'genre', title: 'Género' };
        columns[5] = { 'data': 'classification', title: 'Clasificación' };
        columns[6] = { 'data': 'rating', title: 'Calificación' };
        columns[7] = { 'data': 'duration', title: 'Duración' };
        columns[8] = { 'data': 'created', title: 'Creado' };
        columns[9] = { 'data': 'updated', title: 'Actualizado' };

        //Convertir la tabla plana en una tabla mas dinamica
        $("#tblMovies").dataTable({
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

    var vc = new MovieViewController();
    vc.InitView();
});