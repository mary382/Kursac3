app.controller('searchPageController', function ($scope, $location, $routeParams, $http) {

    $scope.search = {
        Row: $location.absUrl().substr(39, $location.absUrl().length - 39),
        Result: null
    };

    $http.post("/Home/SearchResult/", $scope.search).then(function (response) {
        if (response.data == '') $scope.search.Result = "Ничего не найдено";
        else {
            $scope.search.Result = "Result";
            $scope.users = response.data;
        };
    });

});