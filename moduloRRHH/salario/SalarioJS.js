
$(document).ready(function () {


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

$('#txtMLLV').on('input', function (e) {
    $.ajax({
        url: 'wsSalario.asmx/BuscarEmpleado',
        data: "{'prefix':'" + $(this).val() + "'}",
        dataType: "json",
        type: "POST",
        async:false,
        contentType: "application/json; chartset=utf-8",
        success: function (data) {
            $('#dlNombres').empty();
            //alert(data.d);
            //response($.map(data.d, function (item) {
            //    return {
            //        label: item.split('-')[0],
            //        val: item.split('-')[1]
            //    }
            ////}))
            for (var i = 0; i < data.d.length ; i++) {
                var data = data.d[i].split('-');
                $('#dlNombres').append("<option value='" + data[1] + "'>" + data[0] + "</option>");
            }
            //console.log(data.d);
        },
        error: function (response) {
            alert(response.reponseText + '  >:c');
        },
        failure: function (response) {
            alert(response.responseText + ' :c');
        }
    });


    console.log($(this).val())
})



});
