$(document).ready(function () {
    var x = 0;
    var s = "";

    console.log("Hello Pluralsight");

    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });


    var $loginToogle = $("#loginToggle");
    var $popupForm = $(".popupForm");

    $loginToogle.on("click", function () {
        $popupForm.fadeToggle(500);
    });
});


