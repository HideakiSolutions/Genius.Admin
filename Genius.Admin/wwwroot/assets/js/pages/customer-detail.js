document.getElementById("select-sellbalance").addEventListener("change", function (event) {
    console.log(event);
    document.getElementById("sell-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
    getBook("SELL", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
    getQuote("SELL", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
});

document.getElementById("select-buybalance").addEventListener("change", function (event) {
    console.log(event);
    document.getElementById("buy-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
    getBook("BUY", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
    getQuote("BUY", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
});

function handle(balance) {
    console.log(balance);
}

function getBook(side, product, quantity)
{
    var url = "/Quote/Quotation";
    $.get(url, { product: product }, function (quote)
    {
        if (quote == null)
        {
            var row = $("#buy-side-table tr:last-child").clone(true);
            $("#buy-price").val("0.00");
            $("#buy-side-table tr").not($("#buy-side-table")).remove();
            $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>0.00000000</h5 ><p class='text-muted mb-0 font-size-12'>0</p></div>");

            row = $("#sell-side-table tr:last-child").clone(true);
            $("#sell-price").val("0.00");
            $("#sell-side-table tr").not($("#sell-side-table")).remove();
            $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>0.00000000</h5 ><p class='text-muted mb-0 font-size-12'>0</p></div>");
        }
        else
        {
            var totalAmount = quote.asks[0][0] * quantity;
            if (side == "SELL") {
                $("#sell-price").val(quote.asks[0][0]);
                $("#sell-total-amount").val(totalAmount);
            } else {
                $("#buy-price").val(quote.asks[0][0]);
                $("#buy-total-amount").val(totalAmount);

            }

            var model = quote;

            //var row = $("#buy-side-table tr:last-child").removeAttr("style").clone(true);
            if (model.bids.length > 0) {
                var row = $("#buy-side-table tr:last-child").clone(true);
                $("#buy-side-table tr").not($("#buy-side-table")).remove();
                $.each(model.bids, function () {
                    var quote = this;
                    $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>" + quote[0] + "</h5 ><p class='text-muted mb-0 font-size-12'>" + quote[1] + "</p></div>");
                    //$("td", row).eq(1).html(quote[0]);
                    $("#buy-side-table").append(row);
                    row = $("#buy-side-table tr:last-child").clone(true);
                });
            }
            else
            {
                var row = $("#buy-side-table tr:last-child").clone(true);
                $("#buy-side-table tr").not($("#buy-side-table")).remove();
                $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>" + quote[0] + "</h5 ><p class='text-muted mb-0 font-size-12'>" + quote[1] + "</p></div>");
                $("#buy-side-table").append(row);
            }

            if (model.asks.length > 0) {
                var row = $("#sell-side-table tr:last-child").removeAttr("style").clone(true);
                $("#sell-side-table tr").not($("#sell-side-table")).remove();
                $.each(model.asks, function () {
                    var quote = this;
                    //$("td", row).eq(0).html(quote[0]);
                    $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>" + quote[0] + "</h5 ><p class='text-muted mb-0 font-size-12'>" + quote[1] + "</p></div>");
                    $("#sell-side-table").append(row);
                    row = $("#sell-side-table tr:last-child").clone(true);
                });
            }
            else {
                var row = $("#sell-side-table tr:last-child").clone(true);
                $("#sell-side-table tr").not($("#sell-side-table")).remove();
                $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>0.00000000</h5 ><p class='text-muted mb-0 font-size-12'>0</p></div>");
            }

        }
    });
}

function getQuote(side, product, qtty) {
    //var request = new { productId = product, size = 10, side = side };
    var request = '{'
           + '"productId" : "' + product + '", '
           + '"size" : "' + qtty + '", '
           + '"side" : "' + side + '"'
           + '}';

    $.ajax({
        type: "POST",
        url: "https://sandbox.geniusbit.io/orders/askQuote",
        data: request,
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
