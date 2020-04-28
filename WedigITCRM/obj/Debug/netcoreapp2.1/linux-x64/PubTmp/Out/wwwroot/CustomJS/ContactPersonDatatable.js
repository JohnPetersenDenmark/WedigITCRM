
function initializeContactPersonEditor() {
    contactPersonEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Customer/EditContactPerson",
            dataType: 'json',
            data: function (d) {
                if ($('#companytable').length != 0) {
                    var selected = companytable.row({ selected: true });
                    if (selected.any()) {
                        d.companyId = selected.data().id;
                    }
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
                title: "Opret kontaktperson",
                submit: "createCompany",
                className: 'primary'
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

        table: "#contactpersontable",

        fields:
            [
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Titel",
                    name: "title"
                },
                {
                    label: "Fornavn",
                    name: "firstName"
                },
                {
                    label: "Efternavn:",
                    name: "lastName",
                },
                {
                    label: "Telefon",
                    name: "phoneNumber",
                },
                {
                    label: "Afdeling",
                    name: "department",
                },
                {
                    label: "Email",
                    name: "email"
                },
                {
                    label: "companyid",
                    name: "companyId",
                    type: "hidden"
                },
                {
                    label: "Ændret",
                    name: "lastEditedDate",
                    type: "readonly"
                },
                {
                    label: "Oprettet",
                    name: "createdDate",
                    type: "readonly"
                }
            ]
    });
    return contactPersonEditor;
}

function initializeContactPersonTable() {
     contactpersontable = $('#contactpersontable').DataTable(
        {
            // "processing": true,

            // dom: "Brtip",
            dom: "<'row'<'col-sm-3'B><'col-sm-3'l><'col-sm-3'i><'col-sm-3'p>>" + "<'row'<'col-sm-12't>>",
            paging: true,
            sort: true,
             searching: true,
             autoWidth: true,

            "ajax": {
                type: "GET",
                url: Myurl,
                dataType: 'json',
                "data": function (d) {
                    var y = 1;
                    if ($('#companytable').length != 0) {

                        var selected = companytable.row({ selected: true });
                        if (selected.any()) {
                            d.companyId = selected.data().id;
                        }
                    }
                    return (d);
                }
            },

            select: true,

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
                    rows: "%d række valgt"
                }
            },


            buttons: [

                {
                    extend: "create",
                    editor: contactPersonEditor,
                    formButtons: [
                        'Gem',
                        {
                            text: 'Annuler',
                            action: function () { this.close(); },
                             className: 'primary'
                        }
                    ]
                },
                {
                    extend: "edit",
                    editor: contactPersonEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuler', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: contactPersonEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuler', action: function () { this.close(); } }
                    ]
                }
            ],


            columns: [
                { "data": "id" },
                { "data": "title" },
                { "data": "firstName" },
                { "data": "lastName" },
                { "data": "phoneNumber" },
                { "data": "department" },
                { "data": "email" },
                { "data": "companyId" },
                { "data": "lastEditedDate" },
                { "data": "createdDate" }
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
                },
                {
                    "targets": 2,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 3,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 4,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 5,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 6,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 7,
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": 8,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 9,
                    "visible": true,
                    "searchable": true
                }
               
            ],


        });

    return contactpersontable;
}

function initializeContactPersonTableFooter() {
    $('#contactpersontable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg i ' + title + '" />');
    });
}

function initializeSearchContactPersonTableFooter() {
    contactpersontable.columns().every(function () {
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

function setRelationContactPersonAndCompany() {
    companytable.on('select', function (e) {
        contactpersontable.ajax.reload();

        contactPersonEditor
            .field('companyId')
            .def(companytable.row({ selected: true }).data().id);
    });
}


function SetStatusCreateButtonOnContactPersonTable() {
    var companytable = $('#companytable').DataTable();

   

    if (companytable.rows({ selected: true }).indexes().length === 0) {
        contactpersontable.buttons([0]).disable();
    }
    else {
        contactpersontable.buttons([0]).enable();
    }
}

function setContactPersonListenOnSelectCompany() {
    var companytable = $('#companytable').DataTable();
    companytable.on('select', function (e) {
        SetStatusCreateButtonOnContactPersonTable();
    });
}

function setContactPersonListenOnDeSelectCompany() {
    var companytable = $('#companytable').DataTable();
    companytable.on('deselect', function () {
        SetStatusCreateButtonOnContactPersonTable();
    });
}

function setPresubmitEventHandlerOnContactPersonEditor() {
    contactPersonEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var firstName = this.field('firstName');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!firstName.val()) {
                firstName.error('Fornavn skal angives');
            }
           
            var lastName = this.field('lastName');
            if (!lastName.val()) {
                lastName.error('Efternavn skal angives');
            }


            var email = this.field('email');
            if (email.val()) {
                var pattern = "[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
                var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
                var returnStr = email.val().match(pattern);
                if (returnStr != email.val()) {
                    email.error('Den email du har angivet er ikke gyldig.');
                }
                
            }



            // If any error was reported, cancel the submission so it can be corrected
            if (this.inError()) {
                return false;
            }
        }
    });
}
