document.getElementById("select-sellbalance").addEventListener("change", function (event) {
    console.log(event);
    document.getElementById("sell-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
    getQuote("SELL", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
    getQuotes("SELL", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
});

document.getElementById("select-buybalance").addEventListener("change", function (event) {
    console.log(event);
    document.getElementById("sell-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
    getQuote("BUY", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
    getQuotes("BUY", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
});

function handle(balance) {
    console.log(balance);
}

function getQuote(side, product, quantity)
{
    var url = "/Quote/Quotation";
    $.get(url, { product: product }, function (quote)
    {
        if (quote == null) {
            $("#sell-price").val("0.00");
        }
        else {
            var totalAmount = quote.asks[0][0] * quantity;
            if (side == "SELL") {
                $("#sell-price").val(quote.asks[0][0]);
                $("#sell-total-amount").val(totalAmount);
            } else {
                $("#buy-price").val(quote.asks[0][0]);
                $("#buy-total-amount").val(totalAmount);
            }


        }
    });
}

function GetQuotes(side, product, qtty) {
    $.ajax({
        type: "GET",
        url: "/Quote/Quotation",
        data: '{ product: ' + product + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
}

function OnSuccess(response) {
    var model = response;
    var row = $("#buy-side-table tr:last-child").removeAttr("style").clone(true);
    $("#buy-side-table tr").not($("#buy-side-table tr:first-child")).remove();
    $.each(model.Quotes.bids, function () {
        var quote = this;
        $("td", row).eq(0).html(quote[0]);
        //$("td", row).eq(1).html(quote[0]);
        $("#buy-side-table").append(row);
        row = $("#buy-side-table tr:last-child").clone(true);
    });

    //$(".Pager").ASPSnippets_Pager({
    //    ActiveCssClass: "current",
    //    PagerCssClass: "pager",
    //    PageIndex: model.PageIndex,
    //    PageSize: model.PageSize,
    //    RecordCount: model.RecordCount
    //});
};
