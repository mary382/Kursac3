app.service("userPageService", function ($http, $location) {

    this.getUser = function (scope) {

        if ($location.absUrl().substr(38, $location.absUrl().length - 38) == '')
            $http.get("/UserPage/GetMe/").then(function (response) {
                scope.user = response.data;
            });

        else {
            $http.post("/UserPage/GetUser/", { userId: $location.absUrl().substr(38, $location.absUrl().length - 38) }).then(function (response) {
                scope.user = response.data;
            });
        }
    };

    this.getUserCreatives = function (scope) {

        if ($location.absUrl().substr(38, $location.absUrl().length - 38) == '')
            $http.get("/UserPage/GetMyCreatives/").then(function (response) {
                scope.creatives = response.data;
            });

        else {
            $http.post("/UserPage/GetUserCreatives/", { userId: $location.absUrl().substr(38, $location.absUrl().length - 38) }).then(function (response) {
                scope.creatives = response.data;
            });
        }
    };


});