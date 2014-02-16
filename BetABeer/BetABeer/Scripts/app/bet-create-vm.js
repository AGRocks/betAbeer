
var CreateBetViewModel = (function () {
    var CreateBetViewModel = function (avaliableSports, avaliableBetOptions) {
        var url = "api/bets"
        var self = this;

        this.betOptions = ko.observableArray(["Beer", "Lunch", "Bug"]);
        this.description = ko.observable("Enter description.");
        this.title = ko.observable("Enter title.");
        this.sportArts = ko.observableArray(avaliableSports);

        this.selectedBetOption = ko.observable();
        this.selectedSportArt = ko.observable();

        this.saveBet = function () {
            var data = {
                Title: self.title,
                Description: self.description,
                SelectedBetOption: self.selectedBetOption,
                SelecredSportArt: self.selectedSportArt
            };

            $.ajax({
                url: url,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                data: JSON.stringify(data),
                succsess: function (result) {
                    // TODO: handle response.
                    // Push SignalR notification that it was added.
                }
            });
        }
        
    }
})();