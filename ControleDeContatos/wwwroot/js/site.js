//..<link href="https://cdn.datatables.net/v/dt/dt-2.2.1/datatables.min.css" rel="stylesheet">
// <script src="https://cdn.datatables.net/v/dt/dt-2.2.1/datatables.min.js"></script>
//...config para traduzir o datatebal do framework jquey foi colocado em Shared em Layout

$(document).ready(function () {
    getDataTable('#tables-usuario'); // Corrigido nome da função
    getDataTable('#tables-contatos');

    $('.close-alert').click(function () {
        $('.alert').hide('hide');
    });
});
function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "columnDefs": [
            { "className": "text-center", "targets": "_all" } // Centraliza tudo
        ],
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}