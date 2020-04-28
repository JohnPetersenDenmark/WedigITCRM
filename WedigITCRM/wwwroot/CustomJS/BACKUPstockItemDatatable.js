

function initializeStockItemEditor() {
    stockItemEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/StockItem/EditStockItem",
            dataType: 'json',
            data: function (d) {
                if (d.action == "create") {
                    var ownData = d.data[0];
                    ownData.action = d.action;
                    return JSON.stringify(ownData);
                }
                if (d.action == "edit") {
                    var mineData = selectedStockItemRowData;
                    var nyVendorId = mineData["vendorId"];
                    for (var prop in d.data) {
                        if (d.data.hasOwnProperty(prop)) {
                            d.data[prop].action = d.action;
                            d.data[prop].vendorId = nyVendorId;
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
                title: "Opret vare",
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

        table: "#stockitemtable",

        fields:
            [
                {
                    label: "identity",
                    name: "id",
                    type: "hidden"
                },
                {
                    label: "Varenavn",
                    name: "itemName"
                },
                {
                    label: "Varenummer",
                    name: "itemNumber"
                },
                {
                    label: "Antal på lager",
                    name: "numberInStock"
                },
                {
                    label: "Min. antal på lager",
                    name: "reorderNumberInStock"
                },
                {
                    label: "Lokation",
                    name: "location"
                },
                {
                    label: "Varegruppe",
                    name: "category"
                },
                {
                    label: "vendorName",
                    name: "vendorName"
                },
                {
                    label: "vendorId",
                    name: "vendorId",
                    type: "hidden"
                },
                {
                    label: "Lev. varenummer",
                    name: "vendorItemNumber"
                },
                {
                    label: "Kostpris",
                    name: "costPrice"
                },
                {
                    label: "Lagerværdi",
                    name: "stockValue",
                    type: "readonly"
                },
                {
                    label: "Salgspris",
                    name: "salesPrice"
                },
                {
                    label: "På lager igen",
                    name: "inStockAgainDate",
                    type: "datetime",
                    format: 'DD-MM-YYYY'
                },
                {
                    label: "Udløbsdato",
                    name: "expirationdate",
                    type: "datetime",
                    format: 'DD-MM-YYYY'
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
}


function initializeStockitemtable() {

    stockitemtable = $('#stockitemtable').DataTable(
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
                url: "/StockItem/getStockItems",
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
                "emptyTable": "Der er ikke oprettet nogle varer",
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
                    editor: stockItemEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "edit",
                    editor: stockItemEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: stockItemEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                }
            ],



            columns: [
                { "data": "id" },
                { "data": "itemName" },
                { "data": "itemNumber" },
                { "data": "numberInStock" },
                { "data": "reorderNumberInStock" },
                { "data": "location" },
                { "data": "category" },
                { "data": "vendorName" },
                { "data": "vendorId" },
                { "data": "vendorItemNumber" },
                { "data": "costPrice" },
                { "data": "stockValue" },
                { "data": "salesPrice" },
                { "data": "inStockAgainDate" },
                { "data": "expirationdate" },
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
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 8,
                    "visible": false,
                    "searchable": true
                },
                {
                    "targets": 9,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 10,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 11,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 12,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 13,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 14,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 15,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 16,
                    "visible": true,
                    "searchable": true
                }
            ]
        });
}


function initializeStockitemtableFooter() {

    $('#stockitemtable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchStockitemtableFooter() {
    stockitemtable.columns().every(function () {
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


function activateInLineEdit() {

    $('#stockitemtable').on('click', 'tbody td', function (e) {

        var selectedColumn = this._DT_CellIndex.column;
        // No edit on: stockValue, lastEditedDate, and createdDate
        if (selectedColumn != 11 && selectedColumn != 15 && selectedColumn != 16) {
            stockItemEditor.inline(this, {
                submitOnBlur: true,
                submit: 'allIfChanged'
            });
        }
    });
}



function setPresubmitEventHandlerOnStockItemEditor() {
    stockItemEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var itemName = this.field('itemName');

            if (!itemName.val()) {
                itemName.error('Varebeskrivelse skal angives');
            }

            var itemNumber = this.field('itemNumber');

            if (!itemNumber.val()) {
                itemNumber.error('Varenummer skal angives');
            }
            if (this.inError()) {
                return false;
            }

        }
    });
}

var selectedStockItemRowData;

function activateSelectOnStockItemTable() {
    stockitemtable.on('select', function (e, d) {
        selectedStockItemRowData = stockitemtable.row({ selected: true }).data();
    });
}



var allowInput = true;
var vendorIntervalId = setTimeout(function () { getVendorSuggestions(); }, 2000);
var VendorNameKeyUpValue = "";

function initializeTypeAheadInputStockItemVendorName() {



    $(function () {
        $("#DTE_Field_vendorName").prop("disabled", false);
    });


    $(document).on('keydown', '#DTE_Field_vendorName', function () {
        KeyDownValue = $("#DTE_Field_vendorName").val();
    });

    $(document).on('keyup', '#DTE_Field_vendorName', function (event) {

        VendorNameKeyUpValue = $("#DTE_Field_vendorName").val();
        if (VendorNameKeyUpValue != KeyDownValue) {
            var localKeyUpValue = VendorNameKeyUpValue;
            if (VendorNameKeyUpValue != "") {
                clearTimeout(vendorIntervalId);
                vendorIntervalId = setTimeout(function () { getVendorSuggestions(); }, 500);

            }
        }
    });


}


function getVendorSuggestions() {
    if (VendorNameKeyUpValue == "") {
        return;
    }

    document.getElementById("DTE_Field_vendorName").disabled = true;
    var myUrl = "/vendor/searchVendorByName?term=" + VendorNameKeyUpValue;

    var jqxhr = $.get(myUrl, function (data) {
        if ($('#popUpDiv').length) {
            $('#popUpDiv').html("");
        }
        else {
            var txt1 = '<div id="popUpDiv"></div>';        // Create text with HTML


            $("#DTE_Field_vendorName").parent().append(txt1);   // Append new elements
        }

        vendorSuggestData = data;

        jQuery.each(data, function (i, val) {
            var suggestElement = '<div id="' + i + '"' + ' class="suggestion">' + val.name + '</div>';
            $('#popUpDiv').append(suggestElement);
        });

        $('.suggestion').bind("click", function (event) {

            var selectedSuggestId = $(this).attr('id');
            initializeVendorPopUp(selectedSuggestId);
            $("#popUpDiv").hide();
            document.getElementById("DTE_Field_vendorName").focus();
        });

        $("#popUpDiv").show();
        $("#DTE_Field_vendorName").prop("disabled", false);
        document.getElementById("DTE_Field_vendorName").focus();

    })

        .fail(function () {
            $("#DTE_Field_vendorName").prop("disabled", false);
            if ($('#popUpDiv').length) {
                $('#popUpDiv').html("");
                $("#popUpDiv").hide();
            }
        });
}

function initializeVendorPopUp(selectedSuggestId) {

    $("#DTE_Field_vendorName").val(vendorSuggestData[selectedSuggestId].name);


    //  if (!InlineEditing) {
    $("#DTE_Field_vendorId").val(vendorSuggestData[selectedSuggestId].id);
    //  }
    //  else {

    if (!isNullOrUndefined(selectedStockItemRowData)) {
        selectedStockItemRowData["vendorId"] = vendorSuggestData[selectedSuggestId].id;
    }


    // }



}

