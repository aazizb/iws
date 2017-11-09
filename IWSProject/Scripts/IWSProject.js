<script type="text/javascript">
    function OnSelectedIndexChanged(s, e) {
        $.ajax({
            url: '@Url.Action("PackUnit", "PurchaseOrders")',
            type: "POST",
            data: { selectedItemIndex: s.GetValue() },
            success: function (data) {
                unit.SetText(data);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
            }
        });
    $.ajax({
        url: '@Url.Action("VatCode", "PurchaseOrders")',
            type: "POST",
            data: {selectedItemIndex: s.GetValue() },
            success: function (data) {
        Vat.SetText(data);
    },
            error: function (xhr, textStatus, errorThrown) {
        alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
    }
        });
        $.ajax({
        url: '@Url.Action("Price", "PurchaseOrders")',
            type: "POST",
            data: {selectedItemIndex: s.GetValue() },
            success: function (data) {
        price.SetText(data);
    },
            error: function (xhr, textStatus, errorThrown) {
        alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
    }
        });
        $.ajax({
        url: '@Url.Action("Currency", "PurchaseOrders")',
            type: "POST",
            data: {selectedItemIndex: s.GetValue() },
            success: function (data) {
        Currency.SetText(data);
    },
            error: function (xhr, textStatus, errorThrown) {
        alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
    }
        });
    }

    var expanded = false;
    var ndxMaster = 0;
    function OnRowClick(s, e) {
        expanded = true;
    ndxMaster = e.visibleIndex;
        s.StartEditRow(ndxMaster);
    }
    function OnEndCallback(s, e) {
        alert("end callback: " + ndxMaster)
        if (expanded == true) {
        expanded = false;
    s.ExpandDetailRow(ndxMaster);
        }
    }
    function OnBeginCallback(s, e) {
        e.customArgs["selectedIDs"] = selectedIDs;
    }
    function OnSelectionChanged(s, e) {
        s.GetSelectedFieldValues("id", GetSelectedFieldValuesCallback);
    }
    var selectedIDs = null;
    function GetSelectedFieldValuesCallback(values) {
        selectedIDs = values.join(';');
    }
    function OnSubmitClick(s, e) {
        callbackPanelPartialView.PerformCallback();
    }
    function OnMInit(s, e) {
        ASPxClientUtils.AttachEventToElement(
            s.GetMainElement(),
            "keydown",
            function (e) {
                switch (e.keyCode) {
                    case 13://ENTER
                        var isValidated = validated.GetValue();
                        if (s.IsEditing()) {
                            if (isValidated == false) {
                                s.UpdateEdit();
                            }
                            else {
                                s.CancelEdit();
                            }
                        }
                        break;
                    case 27://ESC
                        if (s.IsEditing()) {
                            s.CancelEdit();
                        }
                        break;
                    default:
                        break;
                }
            });
    }
    function OnDInit(s, e) {

        ASPxClientUtils.AttachEventToElement(
            s.GetMainElement(),
            "keydown",
            function (e) {
                switch (e.keyCode) {
                    case 13://ENTER
                        if (s.IsEditing()) {
                            s.UpdateEdit();
                            s.AddNewRow();
                        }
                        break;
                    case 27://ESC
                        if (s.IsEditing()) {
                            s.CancelEdit();
                        }
                        break;
                    default:
                        break;
                }
            });
    }

</script>