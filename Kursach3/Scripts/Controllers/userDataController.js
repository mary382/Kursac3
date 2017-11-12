app.controller("userDataController", function ($scope, userPageService) {

    $scope.authorizedId = $("#you").val();

    userPageService.getUser($scope);

});