
function initializenoteEditor() {
    noteEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Note/PostedNote",
            dataType: 'json',
            data: function (d) {
                if (d.action == "create") {
                    var ownData = {};
                    for (var prop in d.data[0]) {
                        if (d.data[0].hasOwnProperty(prop)) {
                            if (prop == "files-many-count") {
                                ownData["fileCount"] = d.data[0][prop];
                            }
                            else {
                                ownData[prop] = d.data[0][prop];
                            }
                        }
                    }
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
                title: "Opret notat",
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

        table: "#notetable",

        fields:
            [
                {
                    label: "identity",
                    name: "id"
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
                    label: "Kommentarer",
                    name: "comment"
                },
                {
                    label: "Dokumenter",
                    name: "files[].id",
                    type: "uploadMany",
                    display: function (fileId, counter) {
                        var htmlStr = '<table cellpadding="10">';
                        var htmlStr = htmlStr + '<tr>';
                        var htmlStr = htmlStr + '<td>';
                        var htmlStr = htmlStr + '<img src="' + noteEditor.file('files', fileId).web_path + '" height="42" width="42" />';
                        var htmlStr = htmlStr + '</td>';
                        var htmlStr = htmlStr + '</tr>';
                        var htmlStr = htmlStr + '<tr>';
                        var htmlStr = htmlStr + '<td>';
                        var htmlStr = htmlStr + '<a href="/note/openAttachment?Id=' + fileId + '"  target ="_blank" >Åben</a>';
                        var htmlStr = htmlStr + '</td>';
                        var htmlStr = htmlStr + '</tr>';
                        var htmlStr = htmlStr + '<tr>';
                        var htmlStr = htmlStr + '<td>';
                        var htmlStr = htmlStr + '<a href="/note/downloadAttachment?Id=' + fileId + '"  target ="_blank" >Hent</a>';
                        var htmlStr = htmlStr + '</td>';
                        var htmlStr = htmlStr + '</tr>';
                        var htmlStr = htmlStr + '<tr>';
                        var htmlStr = htmlStr + '<td>';
                        var htmlStr = htmlStr + '<a href="/note/NoteDelete?Id=' + fileId + '" >Slet</a>';
                        var htmlStr = htmlStr + '</td>';
                        var htmlStr = htmlStr + '</tr>';
                        var htmlStr = htmlStr + '</table>';
                        var htmlStr = htmlStr + '<hr />';
                        return htmlStr;
                    },
                    noFileText: 'Ingen dokumenter',
                    dragDrop: true,
                    clearText: 'Fjern',
                    uploadText: "Vælg dokumenter",
                    dragDropText: "Træk dokumenter hertil"
                },
                {
                    label: "companyId",
                    name: "companyId"
                }
            ]
    });


}


function initializenotetable() {

    notetable = $('#notetable').DataTable(
        {
            dom: "<'row'<'col-sm-2'B><'col-sm-2'l><'col-sm-2'i><'col-sm-3'p>>" + "<'row'<'col-sm-12't>>",
            paging: true,
            sort: true,
            searching: true,
            autoWidth: true,


            "ajax": {
                type: "GET",
                url: getNotesUrl,
                dataType: 'json',
                "data": function (d) {

                    if (noteParentTableName.localeCompare("companytable") == 0) {
                        var selected = companytable.row({ selected: true });
                        if (selected.any()) {
                            d.companyId = selected.data().id;
                        }
                    }                  
                }
            },
            select: {
                style: 'single'
            },

            "language": {
                "emptyTable": "Der er ingen notater oprettet",
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
                    editor: noteEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "edit",
                    editor: noteEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: noteEditor,
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
                { "data": "comment" },
                {
                    "data": "files",
                    render: function (d) {
                        return d.length ?
                            d.length + ' dokument(er)' :
                            'Ingen dokumenter';
                    },
                    title: "Dokumenter"
                },
                { "data": "companyId" }
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
                }
            ]
        });
}





function initializenotetableFooter() {

    $('#notetable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchnotetableFooter() {
    notetable.columns().every(function () {
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


function setPostSubmitEventHandlerOnNoteEditor() {
    noteEditor.on('postSubmit', function (e, json, data, action) {

        for (var prop in json) {
            if (prop == "Status") {
                if (json.Status == 500) {
                    var errorText = json.Detail;
                    var errorTitle = json.Title;
                    var errorInstance = json.Instance;
                    location.href = "/home/ShowErrorForJSON?errorinstance=" + errorInstance;
                }
            }
        }


    });
}



function setPresubmitEventHandlerOnnoteEditor() {
    noteEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var subject = this.field('subject');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!subject.val()) {
                subject.error('Emne skal angives');
            }



            // ... additional validation rules

            // If any error was reported, cancel the submission so it can be corrected
            if (this.inError()) {
                return false;
            }
        }
    });
}

function setRelationNoteAndCompany() {
    companytable.on('select', function (e) {
        notetable.ajax.reload();

        noteEditor
            .field('companyId')
            .def(companytable.row({ selected: true }).data().id);
    });
}

function SetStatusCreateButtonOnNoteTable(parentTable) {
    var activityTable = $('#notetable').DataTable();

    if (parentTable.rows({ selected: true }).indexes().length === 0) {
        activityTable.buttons([0]).disable();
    }
    else {
        activityTable.buttons([0]).enable();
    }
}

function setListenOnSelectCompany() {
    var companytable = $('#companytable').DataTable();
    companytable.on('select', function () {
        SetStatusCreateButtonOnNoteTable(companytable);
    });
}

function setListenOnDeSelectCompany() {
    var companytable = $('#companytable').DataTable();
    companytable.on('deselect', function () {
        SetStatusCreateButtonOnNoteTable(companytable);
    });
}
