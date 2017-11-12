app.controller("newCreativeController", function ($scope, homePageService) {

    homePageService.getNewCreatives($scope);

});