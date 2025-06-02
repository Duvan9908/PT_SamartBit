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
            "url": "/Admin/Deposito/ObtenerTodos"
        },
        "columns": [
            {
                "data": "fecha",
                "render": function (data) {
                    var d = new Date(data);
                    return d.toLocaleString('es-mx', {
                        day: '2-digit',
                        month: '2-digit',
                        year: 'numeric',
                    });
                }, "whidth": "10%"
            },
            { "data": "fondoMonetario.nombre", "width": "20%" },            
            {
                "data": "monto",
                "render": function (data) {
                    return formatearMoneda(data);
                }, "width": "20%"
            },            
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div clas="text-center">
                            <a href="/Admin/Deposito/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                            <i class="bi bi-pencil-square"></i>
                            </a>
                            <a onclick=Delete("/Admin/Deposito/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
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

function formatearMoneda(data) {
          const formatter = new Intl.NumberFormat('es-CO', {
              style: 'currency',
              currency: 'COP',
              minimumFractionDigits: 0,
              maximumFractionDigits: 2
          });
          return formatter.format(data);
      }