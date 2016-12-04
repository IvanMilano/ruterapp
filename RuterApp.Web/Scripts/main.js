require.config({
    // relative url from where modules will load
    baseUrl: "/Scripts/",
    paths: {
        "knockout"          : "knockout-3.4.0",
        "domready"          : "domready"
    }
});

//require([
//    "signalRHub"
//], function(
//    signalRHub
//) {
//    signalRHub.start().done(function() {
//        console.log("singalr started");
//    });
//});