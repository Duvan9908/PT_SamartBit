let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar pagina _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Admin/Presupuesto/ObtenerTodos"
        },
        "columns": [
            { "data": "tipoGasto.nombre", "width": "20%" },
            {
                "data": "mes",
                "render": function (data) {
                    var d = new Date(data);
                    return d.toLocaleString('es-mx', {
                        month: '2-digit',
                        year: 'numeric'
                    });
                }, "width": "10%"
            },
            { "data": "monto", "width": "20%" },
            {
                "data": "fechaCreacion",
                "render": function (data) {
                    var d = new Date(data);
                    return d.toLocaleString('es-mx', {
                        day: '2-digit',
                        month: '2-digit',
                        year: 'numeric',
                    });
                }, "whidth": "10%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div clas="text-center">
                            <a href="/Admin/Presupuesto/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                            <i class="bi bi-pencil-square"></i>
                            </a>
                            <a onclick=Delete("/Admin/Presupuesto/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                            <i class="bi bi-trash3-fill"></i>
                            </a>
                        </div>
                    `;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de eliminar el registro?",
        text: "¡Este registro no se podrá recuperar!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}