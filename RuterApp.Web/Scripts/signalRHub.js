define([
], function(
) {
    return {
        hub: $.connection.ruterAppHub,
        start: function() {
            return $.connection.hub.start();
        }
    };
});