

function initializeUserEditorPassword() {
    userEditorPassword = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Admin/EditUser",
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
                title: "Opret bruger",
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

        table: "#usertable",

        fields:
            [
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Teknisk brugerNavn",
                    name: "name",
                    type: "hidden"
                },
                {
                    label: "Email",
                    name: "email"
                }
                ,
                {
                    label: "Brugernavn",
                    name: "companyUserName"
                }
                ,
                {
                    label: "Kodeord",
                    name: "password",
                    type: "password"
                }
                ,
                {
                    label: "Gentag kodeord",
                    name: "confirmPassword",
                    type: "password"
                }
            ]
    });


}



function initializeUserEditor() {
    userEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Admin/EditUser",
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

        table: "#usertable",

        fields:
            [
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Teknisk brugerNavn",
                    name: "name",
                    type: "hidden"
                },
                {
                    label: "Email",
                    name: "email"
                }
                ,
                {
                    label: "Brugernavn",
                    name: "companyUserName"                  
                },
                 {
                    label: "userId",
                     name: "userId",
                     type: "hidden"
                }
            ]
    });


}


function initializeUserTable() {

    usertable = $('#usertable').DataTable(
        {
            dom: "<'row'<'col-sm-3'B><'col-sm-3'l><'col-sm-3'i><'col-sm-3'p>>" + "<'row'<'col-sm-12't>>",
            paging: true,
            sort: true,
            searching: true,
            autoWidth: true,


            "ajax": {
                type: "GET",
                url: "/Admin/GetUsers",
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
                    editor: userEditorPassword,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "edit",
                    editor: userEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: userEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                }
            ],

            columns: [
                { "data": "id" },               
                { "data": "email" },
                { "data": "companyUserName" }               
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
                }
            ]
        });
}





function initializeUserTableFooter() {

    $('#usertable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchUserTableFooter() {
    usertable.columns().every(function () {
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

function setPostsubmitEventHandlerOnUserEditor() {
    userEditor.on('submitComplete', function (e, json, o, action) {
        var y = 1;
        companyUserName.error('Brugernavn skal angives');
    });
}

function setPresubmitEventHandlerOnUserEditor() {
    userEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var companyUserName = this.field('companyUserName');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!companyUserName.val()) {
                companyUserName.error('Brugernavn skal angives');
            }

            var email = this.field('email');
            if (!email.val()) {
                email.error('Email skal angives');
            }
            else {

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

function setPresubmitEventHandlerOnUserEditorPassword() {
    userEditorPassword.on('preSubmit', function (e, o, action) {
        if (action == 'create') {
            var companyUserName = this.field('companyUserName');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!companyUserName.val()) {
                companyUserName.error('Brugernavn skal angives');
            }

            var email = this.field('email');
            if (!email.val()) {
                email.error('Email skal angives');
            }
            else {

                var pattern = "[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
                var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
                var returnStr = email.val().match(pattern);
                if (returnStr != email.val()) {
                    email.error('Den email du har angivet er ikke gyldig.');
                }
            }

            var password = this.field('password');
            if (!password.val()) {
                password.error('Kodeord skal angives');
            }
          
            var confirmPassword = this.field('confirmPassword');
            if (!confirmPassword.val()) {
                confirmPassword.error('Gentaget kodeord skal angives');
            }
            else {
                if (confirmPassword.val() !== password.val()) {
                    confirmPassword.error('Kodeord og "Gentaget kodeord" er ikke ens');
                }
            }

            // If any error was reported, cancel the submission so it can be corrected
            if (this.inError()) {
                return false;
            }
        }
    });
}