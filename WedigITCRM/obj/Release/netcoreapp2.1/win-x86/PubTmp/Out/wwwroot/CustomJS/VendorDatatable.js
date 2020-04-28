﻿
function initializeVendorEditor() {
    vendorEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Vendor/EditVendor",
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
                title: "Opret leverandør",
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

        table: "#vendortable",

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
                },
                {
                    label: "CVR",
                    name: "cvrNumber"
                },
                {
                    label: "Adresse",
                    name: "street"
                },
                {
                    label: "postalCodeId:",
                    name: "postalCodeId",
                    type: "hidden"
                },
                {
                    label: "Postnummer",
                    name: "zip",
                    type: "select"
                },
                {
                    label: "By",
                    name: "city"
                },
                {
                    label: "Telefonnummer",
                    name: "phoneNumber"
                },
                {
                    label: "Hjemmeside",
                    name: "homePage"
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


function initializeVendorTable() {

    vendortable = $('#vendortable').DataTable(
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
                url: "/Vendor/getVendors",
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
                    editor: vendorEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuler', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "edit",
                    editor: vendorEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuler', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: vendorEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuler', action: function () { this.close(); } }
                    ]
                }
            ],



            columns: [
                { "data": "id" },
                { "data": "name" },
                { "data": "cvrNumber" },
                { "data": "street" },
                { "data": "zip" },
                { "data": "city" },
                { "data": "phoneNumber" },
                { "data": "homePage" },
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
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 9,
                    "visible": true,
                    "searchable": true
                }
            ],

            initComplete: function (settings, json) {
                $.getJSON("/Customer/getZipCodes", {
                    term: "-1"
                },
                    function (data) {

                        var option = {};
                        for (var prop in data) {
                            if (data.hasOwnProperty(prop)) {
                                //option.value = prop;
                                option.label = data[prop];
                                optionsA.push(option);
                                option = {};
                            }
                        }
                    }
                ).done(function () {
                    var i = 1;
                    vendorEditor.field('zip').update(optionsA);
                });
            }
        });
   
}



function setVendorZipDependency() {
    vendorEditor.dependent('zip', function (val, data, callback) {
        data = JSON.stringify(data.values);
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: '/Customer/getCityByZipCode',
            dataType: 'json',
            data: data,
            success: function (json) {
                vendorEditor.field('city').set(json.city);
                vendorEditor.field('postalCodeId').set(json.postalCodeId);
                callback(true);
            }
        });
    });
}

function initializeVendorTableFooter() {

    $('#vendortable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchVendorTableFooter() {
    vendortable.columns().every(function () {
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

function setPresubmitEventHandlerOnVendorEditor() {
    vendorEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var name = this.field('name');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!name.val()) {
                name.error('Firmanavn skal angives');
            }


            // ... additional validation rules

            // If any error was reported, cancel the submission so it can be corrected
            if (this.inError()) {
                return false;
            }

        }
    });
}

var allowInput = true;
var intervalId = setTimeout(function () { getSuggestions(); }, 2000);
var KeyUpValue = "";

function initializeVendorTypeAheadInput() {



    $(function () {
        $("#DTE_Field_name").prop("disabled", false);
    });


    $(document).on('keydown', '#DTE_Field_name', function () {
        KeyDownValue = $("#DTE_Field_name").val();
    });

    $(document).on('keyup', '#DTE_Field_name', function () {
        KeyUpValue = $("#DTE_Field_name").val();
        if (KeyUpValue != KeyDownValue) {
            var localKeyUpValue = KeyUpValue;
            if (KeyUpValue != "") {
                clearTimeout(intervalId);
                intervalId = setTimeout(function () { getVendorSuggestions(); }, 500);
            }
        }
    });


}


function getVendorSuggestions() {
    if (KeyUpValue == "") {
        return;
    }
    document.getElementById("DTE_Field_name").disabled = true;
    var myUrl = "/home/searchInVirkByCompanyName?Term=" + KeyUpValue;

    var jqxhr = $.get(myUrl, function (data) {
        if ($('#popUpDiv').length) {
            $('#popUpDiv').html("");
        }
        else {
            var txt1 = '<div id="popUpDiv"></div>';        // Create text with HTML


            $("#DTE_Field_name").parent().append(txt1);   // Append new elements
        }

        suggestData = data;

        jQuery.each(data, function (i, val) {
            var suggestElement = '<div id="' + i + '"' + ' class="suggestion">' + val.label + '</div>';
            $('#popUpDiv').append(suggestElement);
        });

        $('.suggestion').bind("click", function () {
            var selectedSuggestId = $(this).attr('id');
            initializePopUpNew(selectedSuggestId);
            $("#popUpDiv").hide();
        });

        $("#popUpDiv").show();
        $("#DTE_Field_name").prop("disabled", false);
        document.getElementById("DTE_Field_name").focus();

    })

        .fail(function () {
            $("#DTE_Field_name").prop("disabled", false);
            if ($('#popUpDiv').length) {
                $('#popUpDiv').html("");
                $("#popUpDiv").hide();
            }
        });
}

function writeSelectedVendorToForm(selectedSuggestId) {
    $("#DTE_Field_name").val(suggestData[selectedSuggestId].label);
    $("#DTE_Field_cvrNumber").val(suggestData[selectedSuggestId].cvrNumber);
    $("#DTE_Field_street").val(suggestData[selectedSuggestId].street + " " + suggestData[selectedSuggestId].houseNumber);
    $("#DTE_Field_postalCodeId").val(suggestData[selectedSuggestId].zipId);
    $("#DTE_Field_zip").val(suggestData[selectedSuggestId].zip);
    $("#DTE_Field_city").val(suggestData[selectedSuggestId].city);
    $("#DTE_Field_phoneNumber").val(suggestData[selectedSuggestId].phoneNumber);
    $("#DTE_Field_homePage").val(suggestData[selectedSuggestId].homePage);
}
