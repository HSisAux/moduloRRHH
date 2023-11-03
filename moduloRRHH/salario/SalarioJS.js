
$(function () {
    SetAutoComplete();
});


function SetAutoComplete() {
    $("#txtEmpleado").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: 'wsSalario.asmx/BuscarEmpleado',
                data: "{'prefix':'" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; chartset=utf-8",
                success: function (data) {
                    //alert(data.d);
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split('-')[0],
                            val: item.split('-')[1]
                        }
                    }))
                },
                error: function (response) {
                    alert(response.reponseText + '  >:c');
                },
                failure: function (response) {
                    alert(response.responseText + ' :c');
                }
            });
        },
        select: function (event, ui) {
            $("#txtNoEmpleado").val(ui.item.val);
        },
        minLength: 1
    });
}

//On UpdatePanel Refresh.
var prm = Sys.WebForms.PageRequestManager.getInstance();
if (prm != null) {
    prm.add_endRequest(function (sender, e) {
        if (sender._postBackSettings.panelsToUpdate != null) {
            SetAutoComplete();
        }
    });
};




