﻿document.getElementById("select-withdrawal-network").addEventListener("change", function (event) {
    //event.currentTarget[event.currentTarget.selectedIndex].value
    if (event.currentTarget.selectedIndex > 0 && document.getElementById("select-withdrawal-currency").selectedIndex > 0)
    {
        GetWithdrawalEstimateFee();
    }
    

});

document.getElementById("select-withdrawal-currency").addEventListener("change", function (event) {
    
    if (document.getElementById("select-withdrawal-network").selectedIndex > 0 && event.currentTarget.selectedIndex > 0) {
        GetWithdrawalEstimateFee();
    }
});


function GetWithdrawalEstimateFee() {

    var network = document.getElementById("select-withdrawal-network")[document.getElementById("select-withdrawal-network").selectedIndex].value;
    var currency = document.getElementById("select-withdrawal-currency")[document.getElementById("select-withdrawal-currency").selectedIndex].value;

    var url = "/Tokens/GetWithdrawalEstimateFee?network=" + network + "&currency=" + currency;

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
        .then(response => {
            OnWithdrawalEstimateFee(response);
        })
        .catch(e => {
            console.log(e);
        })
};

function OnWithdrawalEstimateFee(response) {
    $("#withdrawal-estimate-fee").val(response.fee); 
};