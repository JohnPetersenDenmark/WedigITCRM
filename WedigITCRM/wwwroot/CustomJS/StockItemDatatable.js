function initializeStockItemCategoryEditor1() {
    stockItemCategoryEditor = new $.fn.dataTable.Editor({
        idSrc: 'id',
        "ajax": {
            type: "POST",
            "url": "/StockItem/EditStockItem",
            dataType: 'json',
            data: function (d) {

                if (d.action == "edit") {
                    var mineData = selectedStockItemRowData;
                    for (var prop in d.data) {
                        if (d.data.hasOwnProperty(prop)) {
                            mineData.action = d.action;
                            mineData.Id = prop;

                            mineData.category1Id = d.data[prop].category1Id;
                            mineData.category2Id = d.data[prop].category2Id;
                            mineData.category3Id = d.data[prop].category3Id;

                            return JSON.stringify(mineData);
                        }
                    }
                    return ({});
                }
            },

            contentType: "application/json",
        },

        i18n: {         
            edit: {
                button: "Rediger kategorier",
                title: "Rediger"              
            }
       },

        table: "#stockitemtable",

        fields:
            [
                {
                    label: "",
                    name: "felt"
                },
                {
                    label: "Kategori 1",
                    name: "category1",
                    type: "select"
                },
                {
                    label: "Kategori 2",
                    name: "category2",
                    type: "select"

                },
                {
                    label: "Kategori 3",
                    name: "category3",
                    type: "select"

                },
                {
                    label: "category1Id",
                    name: "category1Id",
                    type: "hidden"

                },
                {
                    label: "category2Id",
                    name: "category2Id",
                    type: "hidden"
                },
                {
                    label: "category3Id",
                    name: "category3Id",
                    type: "hidden"
                }
            ]
    });
}



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
                button: "Rediger vare",
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
                    label: "Leverandør",
                    name: "vendorName"
                },
                {
                    label: "Leverandørkode",
                    name: "vendorId",
                    type: "readonly"
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
                    name: "inStockAgainDate"
                },
                {
                    label: "Udløbsdato",
                    name: "expirationdate"
                }
            ]
    });
}


function initializeStockitemtable() {

    stockitemtable = $('#stockitemtable').DataTable(
        { 
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
                        {
                            text: 'Annuller', action: function ()
                            {
                                this.close();
                            }
                        }
                    ]
                },
                {
                    extend: "edit",
                    editor: stockItemCategoryEditor                 
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
                { "data": "category1" },
                { "data": "category2" },
                { "data": "category3" },
                { "data": "numberInStock" },
                { "data": "reorderNumberInStock" },
                { "data": "location" },
                { "data": "vendorName" },
                { "data": "vendorId" },
                { "data": "vendorItemNumber" },
                { "data": "costPrice" },
                { "data": "stockValue" },
                { "data": "salesPrice" },
                { "data": "inStockAgainDate" },
                { "data": "expirationdate" },
                { "data": "lastEditedDate" },
                { "data": "createdDate" },
                { "data": "category1Id" },
                { "data": "category2Id" },
                { "data": "category3Id" }
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
                    "searchable": false
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
                },
                {
                    "targets": 17,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 18,
                    "visible": true,
                    "searchable": true
                },
                {
                    "targets": 19,
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": 20,
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": 21,
                    "visible": false,
                    "searchable": false
                },
            ],
            initComplete: function (settings, json) {

                $.getJSON("/StockItemCategories/getAllCategory1s", {
                    term: "-1"
                },
                    function (data) {
                        optionsCategory1 = [];
                        var option = {};

                        option.label = "Vælg";
                        option.value = "0";
                        optionsCategory1.push(option);
                        option = {};

                        for (var i = 0; i < data.length; i++) {
                            option.label = data[i].name;
                            option.value = data[i].id;
                            optionsCategory1.push(option);
                            option = {};
                        }
                    },
                ).done(function () {
                    stockItemCategoryEditor.field('category1').update(optionsCategory1);
                });
            }
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

function initializeCategoryFieldsChangeEvents1() { 
        setCategory1Dependency();
        setCategory2Dependency();
        setCategory3Dependency(); 
}

function setCategory1Dependency() {
    stockItemCategoryEditor.dependent('category1', function (val, data, callback) {

        if (category1AvoidDependentFirstCall) {
            category1AvoidDependentFirstCall = false;
            callback(true);
            return;
        }

        if (val == null) {
            $("#DTE_Field_category2").val("0");
            $("#DTE_Field_category3").val("0");
            callback(true);
            return;
        }

        var DataToPost = JSON.stringify({ Category1Id: val.toString(), Category1: "noget" });
        $.ajax({
            type: "POST",
            contentType: "application/json",
            async: false,
            url: '/StockItemCategories/getCategory1Ajax',
            dataType: 'json',
            data: DataToPost,
            success: function (json) {
                stockItemCategoryEditor.field('category1Id').set(json.category1Id);
                getCategory2ByCategory1(val);              
                callback(true);
            },
            error: function (request, status, error) {
                var jsonErrorObj = request.responseJSON
                var errorText = jsonErrorObj.Detail;
                var errorTitle = jsonErrorObj.Title;
                var errorInstance = jsonErrorObj.Instance;
                location.href = "/home/ShowErrorForJSON?errorinstance=" + errorInstance;
            }
        });

    });
}

function setCategory2Dependency() {
    stockItemCategoryEditor.dependent('category2', function (val, data, callback) {


        if (category2AvoidDependentFirstCall) {
            category2AvoidDependentFirstCall = false;
            callback(true);
            return;
        }

        if (val == null) {
            $("#DTE_Field_category3").val("0");
            return (true);
        }
        var DataToPost = JSON.stringify({ Category2Id: val.toString(), Category2: "noget" });
        $.ajax({
            type: "POST",
            contentType: "application/json",
            async: false,
            url: '/StockItemCategories/getCategory2Ajax',
            dataType: 'json',
            data: DataToPost,
            success: function (json) {              
                getCategory3ByCategory2(val);
                stockItemCategoryEditor.field('category2Id').set(json.category2Id);              
                callback(true);
            },
            error: function (request, status, error) {
                var jsonErrorObj = request.responseJSON
                var errorText = jsonErrorObj.Detail;
                var errorTitle = jsonErrorObj.Title;
                var errorInstance = jsonErrorObj.Instance;
                location.href = "/home/ShowErrorForJSON?errorinstance=" + errorInstance;
            }
        });

    });
}

function setCategory3Dependency() {
    stockItemCategoryEditor.dependent('category3', function (val, data, callback) {

        if (category3AvoidDependentFirstCall) {
            category3AvoidDependentFirstCall = false;
            callback(true);
            return;
        }

        if (val == null) {
            return (true);
        }
        var DataToPost = JSON.stringify({ Category3Id: val.toString(), Category3: "noget" });
        $.ajax({
            type: "POST",
            contentType: "application/json",
            async: false,
            url: '/StockItemCategories/getCategory3Ajax',
            dataType: 'json',
            data: DataToPost,
            success: function (json) {
                stockItemCategoryEditor.field('category3Id').set(json.category3Id);
                callback(true);
            },
            error: function (request, status, error) {
                var jsonErrorObj = request.responseJSON
                var errorText = jsonErrorObj.Detail;
                var errorTitle = jsonErrorObj.Title;
                var errorInstance = jsonErrorObj.Instance;
                location.href = "/home/ShowErrorForJSON?errorinstance=" + errorInstance;
            }
        });

    });
}

function getCategory2ByCategory1(category1Id) {

    var DataToPost = JSON.stringify({ Category1Id: category1Id.toString(), Category1: "noget" });

    var selectedValue = $('#DTE_Field_category2 :selected').val();

    $.ajax({
        type: "POST",
        contentType: "application/json",
        async: false,
        url: '/StockItemCategories/getAllCategory2s',
        dataType: 'json',
        data: DataToPost,
        success: function (data) {
            optionsCategory2 = [];
            var option = {};
            option.label = "Vælg";
            option.value = "0";
            optionsCategory2.push(option);
            option = {};
            for (var i = 0; i < data.length; i++) {
                option.label = data[i].name;
                option.value = data[i].id;
                optionsCategory2.push(option);
                option = {};
            }
            stockItemCategoryEditor.field('category2').update(optionsCategory2);
           // $("#DTE_Field_category2").val(selectedValue);
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

function getCategory3ByCategory2(category2Id) {

    var DataToPost = JSON.stringify({ Category2Id: category2Id.toString(), Category2: "noget" });

    var selectedValue = $('#DTE_Field_category3 :selected').val();

    $.ajax({
        type: "POST",
        contentType: "application/json",
        async: false,
        url: '/StockItemCategories/getAllCategory3ByCategory2s',
        dataType: 'json',
        data: DataToPost,
        success: function (data) {
            optionsCategory3 = [];
            var option = {};
            option.label = "Vælg";
            option.value = "0";
            optionsCategory3.push(option);
            option = {};
            for (var i = 0; i < data.length; i++) {
                option.label = data[i].name;
                option.value = data[i].id;
                optionsCategory3.push(option);
                option = {};
            }
            stockItemCategoryEditor.field('category3').update(optionsCategory3);
            //$("#DTE_Field_category3").val(selectedValue);
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


function setPostSubmitEventHandlerOnStockItemEditor() {
    stockItemEditor.on('postSubmit', function (e, json, data, action) {

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

function setPostSubmitEventHandlerOnStockItemCategoryEditor() {
    stockItemCategoryEditor.on('postSubmit', function (e, json, data, action) {

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

        var htmlStr = '<div class="DTE_Form_Buttons" data-dte-e="form_buttons"><button class="btn closepopup">Luk</button><div>';
        $('#popUpDiv').append(htmlStr);

        vendorSuggestData = data;

        jQuery.each(data, function (i, val) {
            var suggestElement = '<div id="' + i + '"' + ' class="suggestion">' + val.name + '</div>';
            $('#popUpDiv').append(suggestElement);
        });

        var htmlStr = '<div class="DTE_Form_Buttons" data-dte-e="form_buttons"><button class="btn closepopup">Luk</button><div>';
        $('#popUpDiv').append(htmlStr);

        $('.closepopup').bind("click", function () {
            $("#popUpDiv").hide();
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

  
    $("#DTE_Field_vendorId").val(vendorSuggestData[selectedSuggestId].id);
 

    selectedStockItemRowData["vendorId"] = vendorSuggestData[selectedSuggestId].id;


}

