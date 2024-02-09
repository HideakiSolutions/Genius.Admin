document.getElementById("select-sellbalance").addEventListener("change", function (event) {
    console.log(event);
    document.getElementById("sell-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
    getQuote("SELL", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
});

document.getElementById("select-buybalance").addEventListener("change", function (event) {
    console.log(event);
    document.getElementById("sell-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
    getQuote("BUY", event.currentTarget[event.currentTarget.selectedIndex].text, event.currentTarget[event.currentTarget.selectedIndex].value);
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
