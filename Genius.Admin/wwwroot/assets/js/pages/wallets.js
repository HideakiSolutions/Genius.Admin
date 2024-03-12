document.getElementById("save-withdrawalAddress").addEventListener('click', function (e) {
    CreateWithdrawalAddress();
});

document.getElementById("save-depositAddress").addEventListener('click', function (e) {
    CreateDepositAddress();
});

document.getElementById("create-withdrawal").addEventListener('click', function (e) {
    CreateWithdrawal();
});


function CreateWithdrawalAddress() {

    var customer = document.getElementById("id").value;
    var network = document.getElementById("select-withdrawal-network")[document.getElementById("select-withdrawal-network").selectedIndex].value;
    var currency = document.getElementById("select-withdrawal-currency")[document.getElementById("select-withdrawal-currency").selectedIndex].value;
    var address = document.getElementById("withdrawal-address").value;
    var destinationTag = document.getElementById("withdrawal-detinationTag").value;


    var url = "/Wallets/CreateWithdrawalAddress?customer=" + customer;

    const request =
    {
        network: network,
        currency: currency,
        address: address,
        destinationTag: destinationTag
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
            OnWithdrawalAddressCreated(response);
        })
        .catch(e => {
            console.log(e);
        })
};

function OnWithdrawalAddressCreated(response) {
    console.log(response);
};



function CreateDepositAddress() {

    var customer = document.getElementById("id").value;
    var network = document.getElementById("select-deposit-network")[document.getElementById("select-deposit-network").selectedIndex].value;
    var currency = document.getElementById("select-deposit-currency")[document.getElementById("select-deposit-currency").selectedIndex].value;


    var url = "/Wallets/CreateDepositAddress?customer=" + customer;

    const request =
    {
        network: network,
        currency: currency
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
            OnDepositAddressCreated(response);
        })
        .catch(e => {
            console.log(e);
        })
};

function OnDepositAddressCreated(response) {
    console.log(response);
};


function CreateWithdrawal() {
    var customer = document.getElementById("id").value;
    var currency = document.getElementById("select-withdrawal-currency")[document.getElementById("select-withdrawal-currency").selectedIndex].value;
    var address = document.getElementById("select-withdrawal-address")[document.getElementById("select-withdrawal-address").selectedIndex].value;
    var amount = document.getElementById("withdrawal-amount").value;
    var estimateFee = document.getElementById("withdrawal-estimate-fee").value;

    var url = "/Wallets/CreateWithdrawal?customer=" + customer;

    const request =
    {
        customer: customer,
        currency: currency,
        withdrawAddressId: address,
        amount: amount,
        estimateFee: estimateFee
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
            OnWithdrawalCreated(response);
        })
        .catch(e => {
            console.log(e);
        })
};

function OnWithdrawalCreated(response) {
    console.log(response);
}