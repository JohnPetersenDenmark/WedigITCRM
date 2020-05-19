
function initializeContactEditor() {
    contactEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/Contact/EditContact",
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

        table: "#contacttable",

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
                    label: "Privat",
                    name: "isPerson",
                    type: "select"
                },
                {
                    label: "Land",
                    name: "countryCode",
                    type: "select"
                },
                {
                    label: "Valuta",
                    name: "currencyCode",
                    type: "select"
                },
                {
                    label: "Email",
                    name: "email"
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
                    label: "Postnummer",
                    name: "foreignZip"
                },
                {
                    label: "By",
                    name: "foreignCity"
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

    return contactEditor;
}


function initializecontactTable() {

    contacttable = $('#contacttable').DataTable(
        {
            //dom: "Bript",
            //dom: "<'row'<'col-sm-12'Brlpit>>"  ,
            dom: "<'row'<'col-sm-2'B><'col-sm-2'l><'col-sm-2'i><'col-sm-3'p>>" + "<'row'<'col-sm-12't>>",
            paging: true,
            sort: true,
            searching: true,
            autoWidth: true,


            "ajax": {
                type: "GET",
                url: "/Contact/getContacts",
                "data": function (d) {
                    d.customerCategory = selectedCustomerCategory;
                    return (d);
                },
                dataType: 'json',
                "dataSrc": function (json) {
                    var dummy = selectedCustomerCategory;


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
                    editor: contactEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "edit",
                    editor: contactEditor,
                    formButtons: [
                        'Gem',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                },
                {
                    extend: "remove",
                    editor: contactEditor,
                    formButtons: [
                        'Udfør',
                        { text: 'Annuller', action: function () { this.close(); } }
                    ]
                }
            ],



            columns: [
                { "data": "id" },
                { "data": "name" },
                { "data": "isPerson" },
                { "data": "email" },
                { "data": "cvrNumber" },
                { "data": "street" },
                { "data": "zip" },
                { "data": "city" },
                { "data": "countryCode" },
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
                    contactEditor.field('zip').update(optionsA);

                    optionsIsPrivate = ["Ja", "Nej"];
                    contactEditor.field('isPerson').update(optionsIsPrivate);

                });

                $.getJSON("/Customer/getCurrencies", {
                    term: "-1"
                },
                    function (data) {

                        var option = {};
                        for (var prop in data) {
                            if (data.hasOwnProperty(prop)) {
                                //option.value = prop;
                                //option.label = data[prop];

                                option.value = prop;
                                option.label = prop;
                                optionsCurrency.push(option);
                                option = {};
                            }
                        }
                    }
                ).done(function () {
                    contactEditor.field('currencyCode').update(optionsCurrency);

                });

                $.getJSON("/Customer/getCountries", {
                    term: "-1"
                },
                    function (data) {

                        var option = {};
                        for (var prop in data) {
                            if (data.hasOwnProperty(prop)) {
                                option.value = prop;
                                option.label = data[prop];
                                optionsCountries.push(option);
                                option = {};
                            }
                        }
                    }
                ).done(function () {
                    contactEditor.field('countryCode').update(optionsCountries);

                });
            }
        });
    return contacttable;
}



function setContactZipDependency() {
    contactEditor.dependent('zip', function (val, data, callback) {
        data = JSON.stringify(data.values);
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: '/Customer/getCityByZipCode',
            dataType: 'json',
            data: data,
            success: function (json) {
                contactEditor.field('city').set(json.city);
                contactEditor.field('postalCodeId').set(json.postalCodeId);
                callback(true);
            }
        });
    });
}

function setContactCountryCodeDependency() {
    contactEditor.dependent('countryCode', function (val, data, callback) {
        data = JSON.stringify(data.values);
        if (val == "DK") {
            $("div.DTE_Field_Name_zip ").show();
            $("div.DTE_Field_Name_city ").show();

            $("div.DTE_Field_Name_foreignZip ").hide();
            $("div.DTE_Field_Name_foreignCity ").hide();
        }
        else {
            $("div.DTE_Field_Name_zip ").hide();
            $("div.DTE_Field_Name_city ").hide();

            $("div.DTE_Field_Name_foreignZip ").show();
            $("div.DTE_Field_Name_foreignCity ").show();
        }

        callback(true);

    });
}

function initializecontactTableFooter() {

    $('#contacttable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style="width: 100%" placeholder="Søg' + '" />');
    });
}

function initializeSearchcontactTableFooter() {
    contacttable.columns().every(function () {
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

function setPostSubmitEventHandlerOncontactEditor() {
    contactEditor.on('postSubmit', function (e, json, data, action) {

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


function setPresubmitEventHandlerOnContactEditor() {
    contactEditor.on('preSubmit', function (e, o, action) {
        if (action == 'edit' || action == 'create') {
            var name = this.field('name');

            // Only validate user input values - different values indicate that
            // the end user has not entered a value
            // if (!firstName.isMultiValue()) {
            if (!name.val()) {
                name.error('Kundenavn skal angives');
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


function setPostsubmitEventHandlerOncontactEditor() {
    contactEditor.on('postSubmit', function (e, json, data, action) {
        var x = 1;
    })
}


var allowInput = true;
var intervalId = setTimeout(function () { getCompanySuggestions(); }, 2000);
var KeyUpValue = "";

function initializeTypeAheadInputCompanyName() {



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
                intervalId = setTimeout(function () { getCompanySuggestions(); }, 500);
            }
        }
    });


}


function getCompanySuggestions() {
    if (KeyUpValue == "") {
        return;
    }
    document.getElementById("DTE_Field_name").disabled = true;
    var myUrl = "/home/searchInVirkByCompanyName?Term=" + KeyUpValue;

    $.ajax({
        method: "GET",
        url: myUrl,
        dataType: "json",
        success: function (data) {
            if ($('#popUpDiv').length) {
                $('#popUpDiv').html("");
            }
            else {
                var txt1 = '<div id="popUpDiv"></div>';


                $("#DTE_Field_name").parent().append(txt1);
            }

            var htmlStr = '<div class="DTE_Form_Buttons" data-dte-e="form_buttons"><button class="btn closepopup">Luk</button><div>';
            $('#popUpDiv').append(htmlStr);

            suggestData = data;

            jQuery.each(data, function (i, val) {
                var suggestElement = '<div id="' + i + '"' + ' class="suggestion">' + val.label + '</div>';
                $('#popUpDiv').append(suggestElement);
            });

            var htmlStr = '<div class="DTE_Form_Buttons" data-dte-e="form_buttons"><button class="btn closepopup" >Luk</button><div>';
            $('#popUpDiv').append(htmlStr);


            $('.closepopup').bind("click", function () {
                $("#popUpDiv").hide();
            });

            $('.suggestion').bind("click", function () {
                var selectedSuggestId = $(this).attr('id');
                initializePopUpNew(selectedSuggestId);
                $("#popUpDiv").hide();
            });

            $("#popUpDiv").show();
            $("#DTE_Field_name").prop("disabled", false);
            document.getElementById("DTE_Field_name").focus();
        },
        error: function (request, status, error) {
            var jsonErrorObj = request.responseJSON
            var errorText = jsonErrorObj.Detail;
            var errorTitle = jsonErrorObj.Title;
            var errorInstance = jsonErrorObj.Instance;
            location.href = "/home/ShowErrorForJSON?errorinstance=" + errorInstance;
        }
    });

}

function initializePopUpNew(selectedSuggestId) {
    $("#DTE_Field_name").val(suggestData[selectedSuggestId].label);
    $("#DTE_Field_cvrNumber").val(suggestData[selectedSuggestId].cvrNumber);
    $("#DTE_Field_street").val(suggestData[selectedSuggestId].street + " " + suggestData[selectedSuggestId].houseNumber);
    $("#DTE_Field_postalCodeId").val(suggestData[selectedSuggestId].zipId);
    $("#DTE_Field_zip").val(suggestData[selectedSuggestId].zip);
    $("#DTE_Field_city").val(suggestData[selectedSuggestId].city);
    $("#DTE_Field_phoneNumber").val(suggestData[selectedSuggestId].phoneNumber);
    $("#DTE_Field_homePage").val(suggestData[selectedSuggestId].homePage);
}

function initializeTypeAheadInputCompanyCVR() {



    $(function () {
        $("#DTE_Field_cvrNumber").prop("disabled", false);
    });


    $(document).on('keydown', '#DTE_Field_cvrNumber', function () {
        KeyDownValue = $("#DTE_Field_cvrNumber").val();
    });

    $(document).on('keyup', '#DTE_Field_cvrNumber', function () {
        KeyUpValue = $("#DTE_Field_cvrNumber").val();
        if (KeyUpValue != KeyDownValue) {
            var localKeyUpValue = KeyUpValue;
            if (KeyUpValue != "") {
                clearTimeout(intervalId);
                intervalId = setTimeout(function () { getCompanySuggestionsCVR(); }, 500);
            }
        }
    });


}

function getCompanySuggestionsCVR() {
    if (KeyUpValue == "") {
        return;
    }
    document.getElementById("DTE_Field_cvrNumber").disabled = true;
    var myUrl = "/home/searchInVirkByCVR?Term=" + KeyUpValue;


    $.ajax({
        method: "GET",
        url: myUrl,
        dataType: "json",
        success: function (data) {
            if ($('#popUpDiv').length) {
                $('#popUpDiv').html("");
            }
            else {
                var txt1 = '<div id="popUpDiv"></div>';        // Create text with HTML


                $("#DTE_Field_cvrNumber").parent().append(txt1);   // Append new elements
            }

            var htmlStr = '<div class="DTE_Form_Buttons" data-dte-e="form_buttons"><button class="btn closepopup">Luk</button><div>';
            $('#popUpDiv').append(htmlStr);

            suggestData = data;

            jQuery.each(data, function (i, val) {
                var suggestElement = '<div id="' + i + '"' + ' class="suggestion">' + val.label + '</div>';
                $('#popUpDiv').append(suggestElement);
            });

            var htmlStr = '<div class="DTE_Form_Buttons" data-dte-e="form_buttons"><button class="btn closepopup">Luk</button><div>';
            $('#popUpDiv').append(htmlStr);

            $('.closepopup').bind("click", function () {
                $("#popUpDiv").hide();
            });

            $('.suggestion').bind("click", function () {
                var selectedSuggestId = $(this).attr('id');
                initializePopUpNew(selectedSuggestId);
                $("#popUpDiv").hide();
            });

            $("#popUpDiv").show();
            $("#DTE_Field_cvrNumber").prop("disabled", false);
            document.getElementById("DTE_Field_cvrNumber").focus();

        },
        error: function (request, status, error) {
            var jsonErrorObj = request.responseJSON
            var errorText = jsonErrorObj.Detail;
            var errorTitle = jsonErrorObj.Title;
            var errorInstance = jsonErrorObj.Instance;
            location.href = "/home/ShowErrorForJSON?errorinstance=" + errorInstance;
        }
    });

}