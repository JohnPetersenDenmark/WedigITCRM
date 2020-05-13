


function initializeRoleOnUserEditor() {
    roleOnUserEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Admin/AddOrRemoveRoleForUser",
            dataType: 'json',
            data: function (d) {
                var selected = usertable.row({ selected: true });
                if (selected.any()) {
                    d.userId = selected.data().id;
                }

                if (d.action == "create") {
                    var ownData = d.data[0];
                    ownData.action = d.action;
                    return JSON.stringify(ownData);
                }
                if (d.action == "edit") {
                    for (var prop in d.data) {
                        if (d.data.hasOwnProperty(prop)) {
                            d.data[prop].action = d.action;
                            if (d.data[prop].active.length == 0) {
                                d.data[prop].active = 0;
                            }
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
                title: "Opret virksomhed",
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

        table: "#roleonusertable",

        fields:
            [
                {
                    label: "Active:",
                    name: "active",
                    type: "checkbox",
                    separator: "|",
                    options: [
                        { label: '', value: 1 }
                    ]
                }, 
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Navn",
                    name: "name"
                },
                
                {
                    label: "userId",
                    name: "userId",
                    type: "hidden"
                }
            ]
    });


}


function initializeRoleOnUsertable() {

    roleonusertable = $('#roleonusertable').DataTable(
        {           
            dom: "<'row'<'col-sm-3'B><'col-sm-3'l><'col-sm-3'i><'col-sm-3'p>>" + "<'row'<'col-sm-12't>>",
            paging: true,
            sort: true,
            searching: true,
            autoWidth: true,


            "ajax": {
                type: "POST",
                url: "/Admin/GetRolesForUser",
                dataType: 'json',
                "data": function (d) {
                    if ($('#usertable').length != 0) {
                        var selected = usertable.row({ selected: true });
                        if (selected.any()) {
                            d.userId = selected.data().id;
                        }
                    }
                    return (d);
                }

            },
            select: {
                style: 'single'
            },

            "language": {
                "emptyTable": "",
                "info": "Viser _START_ til _END_ af _TOTAL_ forkomster",
                "infoEmpty": "Viser 0 to 0 af 0 forkomster",
                "infoFiltered": "(Filtreret fra _MAX_ total forkomster)",
                "infoPostFix": "",
                "thousands": ".",
                "lengthMenu": "Vis _MENU_ forkomster",
                "loadingRecords": "Henter...",
                "processing": "Behandler...",
                "search": "Søg:",
                "zeroRecords": "Der er ikke valgt en bruger",
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
                    style: 'os',
                    selector: 'td:not(:last-child)' // no row selection on last column
                }
            },

            buttons: [

            ],



            columns: [
                { "data": "id" },
                { "data": "name" },
                { "data": "userId" },
                { data: "active",
                    render: function (data, type, row) {
                        if (type === 'display') {
                            return '<input type="checkbox" class="editor-active">';
                        }
                        return data;
                    },
                    className: "dt-body-center"
                }

            ],

            rowCallback: function (row, data) {
                // Set the checked state of the checkbox in the table
                $('input.editor-active', row).prop('checked', data.active == 1);
            },
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
                },
                {
                    "targets": 2,
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": 2,
                    "visible": true,
                    "searchable": true
                }
            ],
        });
}





function initializeRoleOnUserTableFooter() {

    $('#roleonusertable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchroleonusertableFooter() {
    roleonusertable.columns().every(function () {
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

function setPresubmitEventHandlerOnroleOnUserEditor() {
    roleOnUserEditor.on('preSubmit', function (e, o, action) {
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


function setRoleListenOnSelectUser() {
    var usertable = $('#usertable').DataTable();
    usertable.on('select', function (e) {
        roleonusertable.ajax.reload();
        roleOnUserEditor
            .field('userId')
            .def(usertable.row({ selected: true }).data().id);
        
    });
}

function setRoleListenOnDeselectUser() {
    var usertable = $('#usertable').DataTable();
    usertable.on('deselect', function (e) {
        roleonusertable.ajax.reload();
    });
}

function setListenerOnSelectCheckBox() {
    $('#roleonusertable').on('change', 'input.editor-active', function () {
        roleOnUserEditor
            .edit($(this).closest('tr'), false)
            .set('active', $(this).prop('checked') ? 1 : 0)
            .submit();
    });
}