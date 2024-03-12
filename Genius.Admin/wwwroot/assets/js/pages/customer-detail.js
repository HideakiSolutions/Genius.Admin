﻿document.getElementById("select-buyproduct").addEventListener("change", function (event) {

    
    getProduct(productId, "BUY");
    //getBook(productId);
    //getQuote("BUY", productId, product.minOrderSize);
});

document.getElementById("buy-sendOrder").addEventListener('click', function (e) {
    SendOrder("BUY");
});

document.getElementById("buy-quantity").addEventListener("change", function (event) {
    console.log(document.getElementById("buy-quantity").value);
    var quantity = document.getElementById("buy-quantity").value;
    var price = document.getElementById("buy-price").value;
    setTotalAmount("BUY", price, quantity);
});

document.getElementById("select-sellbalance").addEventListener("change", function (event) {
    document.getElementById("sell-balance").value = event.currentTarget[event.currentTarget.selectedIndex].value;
});

document.getElementById("select-buybalance").addEventListener("change", function (event) {
    var productId = document.getElementById("select-buyproduct").value;
    getBalance(event.currentTarget[event.currentTarget.selectedIndex].text);
});

function handle(balance) {
    console.log(balance);
}

function getProduct(product, side) {

    var url = "/Products/GetProduct?product=" + product;

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
        .then(product => {
            OnProduct(product);
            getBook(product.productId);
            getQuote(side, product.productId, product.minOrderSize);
        })
        .catch(e => {
            console.log(e);
        })
};

function OnProduct(product) {
    console.log(product);
};

function getBalance(currency) {

    var customer = document.getElementById("id").value;

    var url = "/wallets/GetBalance?customerId=" + customer + "&currencyId=" + currency;

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
            OnBalance(quote);
        })
        .catch(e => {
            console.log(e);
        })
};

function OnBalance(data) {

    if (data == null)
    {
        document.getElementById("buy-balance").value = "0.00000000";
    }
    else
    {
        //data[0].id
        //data[0].type
        //data[0].customerId
        //data[0].userId
        //data[0].status
        //data[0].currency
        //data[0].balance
        //data[0].available
        //data[0].hold
        //data[0].pending
        console.log(data[0].available);
        document.getElementById("buy-balance").value = data[0].available;
    }
};

function getBook(productId)
{

    var url = "/OfferBook/Quotation?productId=" + productId;

    const request =
    {
        productId: productId
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

function getQuote(side, product, size) {

    var url = "/Quote/askQuote?side=" + side + "&productId=" + product + "&size=" + size;

    const options =
    {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
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
        $("#sell-quantity").val(quote.size);
        $("#sell-total-amount").val(quote.amount);
    }

    if (side == "BUY")
    {
        $("#buy-price").val(quote.price);
        $("#buy-quantity").val(quote.size);
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

function setTotalAmount(side, price, quantity) {
    if (price > 0 && quantity > 0)
    {
        var totalAmount = price * quantity;
        if (side == "BUY") {
            $("#buy-total-amount").val(totalAmount);
        }
        else {
            $("#sell-total-amount").val(totalAmount);
        }
    }
};


function SendOrder(side) {

    var customer = document.getElementById("id").value;
    var product = document.getElementById("select-buyproduct")[document.getElementById("select-buyproduct").selectedIndex].value;
    var price = document.getElementById("buy-price").value;
    var quantity = document.getElementById("buy-quantity").value;


    var url = "/Orders/SendOrder";

    const request =
    {
        customerId: customer,
        productId: product,
        side: side,
        price: price,
        size: quantity,
        externalId: generateUUID(),
        depositMethod: "ACCOUNT"
    };

    const options =
    {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(request)
    };

    fetch(url, options)
        .then(data => {
            if (!data.ok) {
                throw Error(data.status);
            }
            return data.json();
        })
        .then(response => {
            OnOrder(response);
        })
        .catch(e => {
            console.log(e);
        })
};


function OnOrder(response) {
    alert("Order sent!");
};

//function alert(message, type) {
//    var wrapper = document.createElement('div')
//    wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'

//    alertPlaceholder.append(wrapper);
//};


function generateUUID() { // Public Domain/MIT
    var d = new Date().getTime();//Timestamp
    var d2 = ((typeof performance !== 'undefined') && performance.now && (performance.now() * 1000)) || 0;//Time in microseconds since page-load or 0 if unsupported
    return 'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx'.replace(/[x]/g, function (c) {
        var r = Math.random() * 16;//random number between 0 and 16
        if (d > 0) {//Use timestamp until depleted
            r = (d + r) % 16 | 0;
            d = Math.floor(d / 16);
        } else {//Use microseconds since page-load if supported
            r = (d2 + r) % 16 | 0;
            d2 = Math.floor(d2 / 16);
        }
        return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });
}