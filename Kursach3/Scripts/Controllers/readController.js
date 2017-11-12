app.controller('readController',function ($scope, $location, $routeParams, $http, $sce) {

    $scope.authorizedId = $("#you").val();

    $scope.creative = {
        Id: $location.absUrl().substr(49, $location.absUrl().length - 49),
        Name: null,
        Chapters: [],
        UserId: null
    };

    $scope.Chapters = [];
    
    $scope.Chapter = {
        Id: null,
        Name: null,
        Text: null,
        Position: null,
        Tags: []
    };

    $scope.Tags = [];

    $scope.Tag = {
        Id: null,
        Name: null,
        ChapterId: null
    };

    $scope.tustedHtml = function (html) {
       return $sce.trustAsHtml(html);
    }


    $http.post("/Creative/GetCreative/", $scope.creative).then(function (response) {
        $scope.creative = response.data;
     
    });
    

});