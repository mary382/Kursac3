app.service("homePageService", function ($http) {

    this.getPopularCreatives = function (scope) {

        scope.users = [];
        scope.user = {
            Id: null,
            Login: null,
            Creatives: []
        };

        scope.creative = {
            Id: null,
            Name: null,
            Rank: null,
            Count: null,
            CreateData: null,
            RedactData: null,
            UserId: null
        };

        $http.get("/Home/GetPopularCreatives/").then(function (response) {
            scope.users = response.data;
        });
    };

    this.getNewCreatives = function (scope) {
        
        scope.users = [];
        scope.user = {
            Id: null,
            Login: null,
            Creatives: []
        };

        scope.creative = {
            Id: null,
            Name: null,
            Rank: null,
            Count: null,
            CreateData: null,
            RedactData: null,
            UserId: null
        };

        $http.get("/Home/GetNewCreatives/").then(function (response) {
            scope.users = response.data;
        });
    };



});