app.controller("popularCreativeController", function ($scope, homePageService) {

    homePageService.getPopularCreatives($scope);

});