var BetsViewModel = (function () {

    var BetsViewModel = function () {
        var self = this;
        var apiUrl = "/api/bet"
        this.avaliableBets = ko.observableArray();
        this.updateBets = function (betId) {
            var data = {};
            if (betId) {
                data = { "Id": betId };
            }
            else {
                data = undefined;
            }
            
            jQuery.support.cors = true;
            $.ajax({
                url: apiUrl,
                cache: false,
                async: true,
                type: 'GET',
                data: data ,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    if (result && result.length) {
                        // Result is an array. Push items into collection.
                        for (var i = 0, j = result.length; i < j; i++)
                            self.avaliableBets.push(result[i]);
                    }

                    // Result is not an array - single item received.
                    if (result && result.length == undefined) {
                        self.avaliableBets.push(result);
                    }                    
                }
            });
        }

        this.showBetElement = function (elem) {
            if (elem.nodeType === 1) $(elem).hide().slideDown()
        }
        this.acceptBet = function (bet) {
            
            bet.TheManUserId = 1; // test. should be integrated with auth

            $.ajax({
                url: apiUrl + "/" + bet.Id,
                cache: false,
                async: true,
                type: 'PUT',
                data: JSON.stringify(bet),
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    alert(result);
                }
            });
        };

        var initializeHubs = function () { 
            var betsHub = $.connection.betNotificationsHub;            
            betsHub.client.newBetArrived = function (betId) {
                self.updateBets(betId);
            };

            // Start the connection.
            $.connection.hub.start().done(function () {
                // connection established
            });
        };

        // Initialize some data
        self.updateBets();

        initializeHubs();
    }

    return BetsViewModel;
})();