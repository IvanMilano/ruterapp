define([
    'knockout'
], function (
    ko
) {
    var Model = function(model) {
        var self = this;
        self.navn = ko.observable(model.navn);
        self.linjeNavn = ko.observable(model.linjeNavn);
        self.retning = ko.observable(model.retning === "East" ? "Øst" : "Vest");
        self.holdeplaass = ko.observable(model.holdeplass);
        self.tidTilAnkomst = ko.observable(model.tidTilAnkomst);
        self.forsinkelse = ko.observable(model.forsinkelse);
    }
    return function RuterAppVM() {
        var self = this;
        self.ruter = ko.observableArray([]);

        var hub = $.connection.ruterAppHub;
        hub.client.displayHoldePlasser = function (vm) {
            var model = new Model({
                navn: vm.Navn,
                linjeNavn: vm.LinjeNavn,
                retning: vm.Retning,
                holdeplass: vm.Holdeplass,
                tidTilAnkomst: vm.TidTilAnkomst,
                forsinkelse: vm.Forsinkelse
            });
            self.ruter.push(model);
        };

        $.connection.hub.start().done(function () {
            console.log("singalr started");
        });
    }();
});