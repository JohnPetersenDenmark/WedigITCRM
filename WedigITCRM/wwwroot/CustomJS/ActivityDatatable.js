
function initializeActivityEditor() {
    activityEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Customer/EditActivity",
            dataType: 'json',
            data: function (d) {

                if (activityParentTableName.localeCompare("contactpersontable") == 0 ) {
                    var selected = contactpersontable.row({ selected: true });
                    if (selected.any()) {
                        d.contactPersonId = selected.data().id;
                    }
                }
                else {
                    if (activityParentTableName.localeCompare("companytable") == 0) {
                    var selected = companytable.row({ selected: true });
                    if (selected.any()) {
                        d.companyId = selected.data().id;
                        }
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
                title: "Opret aktivitet",
                submit: "createActivity",
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
            },
            datetime: {
                previous: 'Tilbage',
                next: 'Videre',
                months: ['Januar', 'Februar', 'Marts', 'April', 'Maj', 'Juni', 'Juli', 'August', 'September', 'Oktober', 'November', 'December'],
                weekdays: ['Sø', 'Ma', 'Ti', 'On', 'To', 'Fr', 'Lø'],
                hours: 'Time',
                minutes : 'Min',
                unknown: '-'
            }         
        },

        table: "#activitytable",

        fields:
            [
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Dato",
                    name: "date"
                   
                },
                {
                    label: "Emne",
                    name: "subject"
                },
                {
                    label: "Beskrivelse:",
                    name: "description"
                },
                {
                    label: "Adviser minutter. før",
                    name: "notifyOffset"
                },                             
                {
                    label: "companyId",
                    name: "companyId",
                    type: "hidden"
                }   
                ,
                {
                    label: "contactPersonId",
                    name: "contactPersonId",
                    type: "hidden"
                }   
            ]
    });
    return activityEditor;
}

function initializeActivityTable() {
     activitytable = $('#activitytable').DataTable(
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
                url: getActivitiesUrl,
                dataType: 'json',
                "data": function (d) {
                    if (activityParentTableName.localeCompare("contactpersontable") == 0) {
                        var selected = contactpersontable.row({ selected: true });
                        if (selected.any()) {
                            d.contactPersonId = selected.data().id;
                        }
                    }
                    else {
                        if (activityParentTableName.localeCompare("companytable") == 0) {
                            var selected = companytable.row({ selected: true });
                            if (selected.any()) {
                                d.companyId = selected.data().id;
                            }
                        }
                    }
                }
            },

            select: true,

            "language": {
                "emptyTable": "Der er ingen kontaktpersoner oprettet",
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
                    editor: activityEditor,
                    formButtons: [
                        'Opret',
                        {
                            text: 'Annuller',
                            action: function () { this.close(); },
                            className: 'primary'
                        }
                    ]
                },
                {
                    extend: "edit",
                    editor: activityEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: activityEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                }
            ],


            columns: [
                { "data": "id" },
                { "data": "date" },
                { "data": "subject" },
                { "data": "description" },
                { "data": "nameOfContactOrCompany" },
                { "data": "notifyOffset" },
                { "data": "lastEditedDate" },
                { "data": "createdDate" },
                { "data": "companyId" },
                { "data": "contactPersonId" }                                
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
                    "visible": true,
                    "searchable": true
                }
                ,
                {
                    "targets": 8,
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": 9,
                    "visible": false,
                    "searchable": false
                }

                
            ],


        });

    return activitytable;
}

function initializeActivityTableFooter() {
    $('#activitytable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg i ' + title + '" />');
    });
}

function initializeSearchActivityTableFooter() {
    activitytable.columns().every(function () {
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


function SetStatusCreateButtonOnActivityTable(parentTable) {
    var activityTable = $('#activitytable').DataTable();

    if (parentTable.rows({ selected: true }).indexes().length === 0) {
        activityTable.buttons([0]).disable();
    }
    else {
        activityTable.buttons([0]).enable();
    }
}

function setRelationActivityAndContactPerson() {
    contactpersontable.on('select', function (e) {
        activitytable.ajax.reload();

        activityEditor
            .field('contactPersonId')
            .def(contactpersontable.row({ selected: true }).data().id);
    });
}

function setRelationActivityAndCompany() {
    companytable.on('select', function (e) {
        activitytable.ajax.reload();

        activityEditor
            .field('companyId')
            .def(companytable.row({ selected: true }).data().id);
    });
}

function setListenOnSelectContactPerson()
    {
    var contactPersonTable = $('#contactpersontable').DataTable();
    contactPersonTable.on('select', function (e) {
        SetStatusCreateButtonOnActivityTable(contactPersonTable);
    });
}

function setListenOnDeSelectContactPerson()
    {
    var contactPersonTable = $('#contactpersontable').DataTable();
    contactPersonTable.on('deselect', function () {
        SetStatusCreateButtonOnActivityTable(contactPersonTable);
    });
}




function setListenOnSelectCompany1() {
    var companytable = $('#companytable').DataTable();
    companytable.on('select', function () {
        SetStatusCreateButtonOnActivityTable(companytable);
    });
}

function setListenOnDeSelectSelectCompany() {
    var companytable = $('#companytable').DataTable();
    companytable.on('deselect', function () {
        SetStatusCreateButtonOnActivityTable(companytable);
    });
}

function setPresubmitEventHandlerOnActivityEditor() {
    activityEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var date = this.field('date');            
            if (!date.val()) {
                date.error('Dato skal angives');
            }

            var subject = this.field('subject');
            if (!subject.val()) {
                subject.error('Emne skal angives');
            }

            var notifyOffset = this.field('notifyOffset');
            if (!notifyOffset.val()) {
                notifyOffset.error('Adviser skal angives');
            }

            var notifyOffset = this.field('notifyOffset');
            if (isNaN(notifyOffset.val()))
            {
                
                    notifyOffset.error('Adviser skal være numerisk');               

            }
            else {
                if (notifyOffset.val() < 0) {
                    notifyOffset.error('Adviser skal være numerisk og må ikke være negativ');
                }
            }
           
            // If any error was reported, cancel the submission so it can be corrected
            if (this.inError()) {
                return false;
            }
        }
    });
}

