app.controller('tagsController', function ($scope, $http) {

    $http.get("/Home/GetTags/").then(function (response) {
        $scope.tags = response.data;
    });

});