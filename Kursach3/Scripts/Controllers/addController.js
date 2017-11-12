app.controller('addController', function ($scope, $http) {

    $scope.addShow = true;

    //if ($location.absUrl().substr(38, $location.absUrl().length - 38) == '')
    //    $scope.addShow = true;
    //else if ($location.absUrl().substr(38, $location.absUrl().length - 38) == $("#you").val())
    //    $scope.addShow = true;
    //else
    //    $scope.addShow = false;

    $scope.modalShown = false;
    $scope.toggleModal = function () {
        $scope.modalShown = !$scope.modalShown;
    };
    
    $scope.hideModal = function () {
        $scope.modalShown = false;
    };

    $scope.creative = {
        Name: null,
        ChapterView: []
    };

    $scope.ChapterView = {
        Name: null,
        Text: null,
        Tags: []
    };

    $scope.tag = {
        Name: null
    };

    $scope.tags = [];
    $scope.Tags = [];

    $scope.addShown = function () {
        if ($location.absUrl().substr(38, $location.absUrl().length - 38) == '') {
            $scope.addShow = true;
        }
        else {
            if ($location.absUrl().substr(38, $location.absUrl().length - 38) == $("#you").val()) {
                $scope.addShow = true;
            }
        }
    }

    $scope.addTag = function () {
        if (this.tagText.length != 0) {
            $scope.tags.push({
                Name: this.tagText
            });

            $scope.Tags.push({
                Name: this.tagText
            });
            this.tagText = '';
        }
    };

    $scope.removeTag = function (tagId) {
        if ($scope.tags.length != 0) {
            $scope.tags.splice(tagId, 1);
        }
    }

    $scope.Chapters = [];


    $scope.addChapter = function () {

        $scope.chapterText = $('#summernote').summernote('code');

        if ($scope.ChapterView.Name.length != 0) {
            $scope.Chapters.push({
                Name: $scope.ChapterView.Name,
                Text: $scope.chapterText,
                Tags: $scope.Tags
            });

            $scope.ChapterView = {
                Name: null,
                Text: null
            };

            $('#summernote').summernote('code', '');

            $scope.tags = [];
            $scope.Tags = [];
        }
    };

    $scope.createCreative = function () {
        $scope.creative = {
            Name: $scope.creative.Name,
            Chapters: $scope.Chapters
        };
        console.log($scope.creative.Chapters[0].Text);
        $('#summernote').summernote('destroy');
        $http.post("/UserPage/Create/", $scope.creative).then(function () {
        });

        $scope.Chapters = [];
        $scope.creative = {
            Name: '',
            Chapters: []
        };
    };
   
});
