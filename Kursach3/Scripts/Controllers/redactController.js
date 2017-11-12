app.controller('redactController', function ($scope, $location, $routeParams, $http) {

    console.log($location.absUrl().substr(47, $location.absUrl().length - 47));

    $scope.creative = {
        Id: $location.absUrl().substr(47, $location.absUrl().length - 47),
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
    $scope.chapterSelect = {
        Id: null,
        Name: null,
        Text: null,
        Position: null,
        Tags: []
    };

    $http.post("/Creative/GetCreative/", $scope.creative).then(function (response) {
        $scope.creative = response.data;
        if ($scope.creative && $scope.creative.Chapters && $scope.creative.Chapters.length > 0)
        $scope.changeChapter($scope.creative.Chapters[0]);
    });

    $scope.changeChapter = function (chapter) {
        $scope.chapterSelect = chapter;
        $('#summernote').summernote('code', chapter.Text);
    };

    $scope.saveChapter = function (chapterId) {
        $scope.redactChapter = {
            Id: chapterId,
            Name: $scope.chapterSelect.Name,
            Text: $('#summernote').summernote('code')
        };

        $http.post("/Creative/RedactChapter/", $scope.redactChapter).then(function () {
        });
    };

});