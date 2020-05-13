
function initializeRoleEditor() {
    roleEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Admin/EditRole",
            dataType: 'json',
            data: function (d) {
                if (d.action == "create") {
                    var ownData = d.data[0];
                    ownData.action = d.action;
                    return JSON.stringify(ownData);
                }
                if (d.action == "edit") {
                    for (var prop in d.data) {
                        if (d.data.hasOwnProperty(prop)) {
                            d.data[prop].action = d.action;
                            return JSON.stringify(d.data[prop]);
                        }
                    }
                    return ({});
                }

                if (d.action == "remove") {
                    for (var prop in d.data) {
                        if (d.data.hasOwnProperty(prop)) {
                            d.data[prop].action = d.action;
                            return JSON.stringify(d.data[prop]);
                        }
                    }
                    return ({});
                }

            },

            contentType: "application/json"

        },

        i18n: {
            create: {
                button: "Ny",
                title: "Opret rolle",
                submit: "createCompany"
            },
            edit: {
                button: "Rediger",
                title: "Rediger",
                submit: "Actualiser"
            },
            remove: {
                button: "Slet",
                title: "Slet",
                submit: "Slet",
                confirm: {
                    _: "Sikker på at du vil slette?",
                    1: "Sikker på at du vil slette?"
                }
            }
        },

        table: "#roletable",

        fields:
            [
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Navn",
                    name: "name"
                }
            ]
    });


}


function initializeRoleTable() {

    roletable = $('#roletable').DataTable(
        {
            //dom: "Bript",
            //dom: "<'row'<'col-sm-12'Brlpit>>"  ,
            dom: "<'row'<'col-sm-3'B><'col-sm-3'l><'col-sm-3'i><'col-sm-3'p>>" + "<'row'<'col-sm-12't>>",
            paging: true,
            sort: true,
            searching: true,
            autoWidth: true,


            "ajax": {
                type: "POST",
                url: "/Admin/GetRoles",
                dataType: 'json',
                "dataSrc": function (json) {
                    var dummy = 1


                    return json;
                }

            },
            select: {
                style: 'single'
            },

            "language": {
                "emptyTable": "Der er ingen virksomheder oprettet",
                "info": "Viser _START_ til _END_ af _TOTAL_ forkomster",
                "infoEmpty": "Viser 0 to 0 af 0 forkomster",
                "infoFiltered": "(Filtreret fra _MAX_ total forkomster)",
                "infoPostFix": "",
                "thousands": ".",
                "lengthMenu": "Vis _MENU_ forkomster",
                "loadingRecords": "Henter...",
                "processing": "Behandler...",
                "search": "Søg:",
                "zeroRecords": "Ingen match fundet",
                "paginate": {
                    "first": "Første",
                    "last": "Sidste",
                    "next": "Næste",
                    "previous": "Forrige"
                },
                "aria": {
                    "sortAscending": ": aktiver for at sortere kolonnen stigende",
                    "sortDescending": ": aktiver for at sortere kolonnen stigende"
                },
                select: {
                    rows: "%d række(r) valgt"
                }
            },

            buttons: [

                {
                    extend: "create",
                    editor: roleEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "edit",
                    editor: roleEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: roleEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                }
            ],



            columns: [
                { "data": "id" },
                { "data": "name" }
            ],

            columnDefs: [
                {
                    "targets": 0,
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": 1,
                    "visible": true,
                    "searchable": true
                }
            ],
        });
}





function initializeRoleTableFooter() {

    $('#roletable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchRoleTableFooter() {
    roletable.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change clear', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });

    });
}

function setPresubmitEventHandlerOnRoleEditor() {
    roleEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var name = this.field('name');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!name.val()) {
                name.error('Rollenavn skal angives');
            }



            // ... additional validation rules

            // If any error was reported, cancel the submission so it can be corrected
            if (this.inError()) {
                return false;
            }
        }
    });
}