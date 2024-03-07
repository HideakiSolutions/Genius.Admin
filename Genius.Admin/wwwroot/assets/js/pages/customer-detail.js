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

    var url = "/OfferBook/Quotation?product=" + product;

    const request =
    {
        productId: product
    };

    const options =
    {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
    };

    fetch(url, options)
        .then(data => {
            if (!data.ok) {
                throw Error(data.status);
            }
            return data.json();
        })
        .then(quote => {
            OnBook(quote);
        })
        .catch(e => {
            console.log(e);
        })
};

function getQuote(side, product, qtty) {

    var url = "/Quote/askQuote";

    const request =
    {
        productId: product, size: qtty, side: side
    };

    const options =
    {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(request)
    };

    fetch(url, options)
        .then(data =>
        {
            if (!data.ok)
            {
                throw Error(data.status);
            }
            return data.json();
        })
        .then(quote =>
        {
            OnQuote(quote, side);
        })
        .catch(e =>
        {
            console.log(e);
        })
};

function OnQuote(quote, side) {
    if (side == "SELL")
    {
        $("#sell-price").val(quote.price);
        $("#sell-total-amount").val(quote.amount);
    }

    if (side == "BUY")
    {
        $("#buy-price").val(quote.price);
        $("#buy-total-amount").val(quote.amount);

    }
};
function OnBook(data) {

    if (data == null)
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
        if (data.bids.length > 0)
        {
            var row = $("#buy-side-table tr:last-child").clone(true);
            $("#buy-side-table tr").not($("#buy-side-table")).remove();
            $.each(data.bids, function ()
            {
                var quote = this;
                $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>" + quote[0] + "</h5 ><p class='text-muted mb-0 font-size-12'>" + quote[1] + "</p></div>");
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

        if (data.asks.length > 0)
        {
            var row = $("#sell-side-table tr:last-child").removeAttr("style").clone(true);
            $("#sell-side-table tr").not($("#sell-side-table")).remove();
            $.each(data.asks, function ()
            {
                var quote = this;
                $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>" + quote[0] + "</h5 ><p class='text-muted mb-0 font-size-12'>" + quote[1] + "</p></div>");
                $("#sell-side-table").append(row);
                row = $("#sell-side-table tr:last-child").clone(true);
            });
        }
        else
        {
            var row = $("#sell-side-table tr:last-child").clone(true);
            $("#sell-side-table tr").not($("#sell-side-table")).remove();
            $("td", row).eq(0).html("<div class='text-end'><h5 class='font-size-14 text-muted mb-0'>0.00000000</h5 ><p class='text-muted mb-0 font-size-12'>0</p></div>");
        }

    }
};

