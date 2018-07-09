function getFamilyList(v) {
    var IdGrupo = $("#groupDropDown").val();
    $.ajax({
        url: '/Grupos/GetFamilyList/' + IdGrupo,
        type: 'POST',
        datatype: 'application/json',
        contentType: 'application/json',
        data: {},
        success: function (result) {
            $("#familyDropDown").html("");
            $("#familyDropDown").append
                ($('<option></option>').val(null).html("---Selecione uma Familia---"));
            if (result !== null)
                $.each($.parseJSON(result), function (i, family) { $("#familyDropDown").append($('<option></option>').val(family.IdFamilia).html(family.NomeFamilia)); });
            $("#familyDropDown").val(v).change();
        }/*,
                error: function () { alert("Something went wrong..") },*/
    });
}

function getConcelhosList(v) {
    var IdDistrito = $("#distritoDropDown").val();
    $.ajax({
        url: '/Distritos/GetConcelhosList/' + IdDistrito,
        type: 'POST',
        datatype: 'application/json',
        contentType: 'application/json',
        data: {},
        success: function (result) {
            $("#concelhoDropDown").html("");
            $("#concelhoDropDown").append
                ($('<option></option>').val(null).html("---Selecione um Concelho---"));
            if (result !== null)
                $.each($.parseJSON(result), function (i, concelho) { $("#concelhoDropDown").append($('<option></option>').val(concelho.IdConcelho).html(concelho.NomeConcelho)); });
            $("#concelhoDropDown").val(v).change();
        }/*,
                error: function () { alert("Something went wrong..") },*/
    });
}