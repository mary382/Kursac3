app.directive("tagInput", function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            scope.inputWidth = 300;

            scope.$watch(attrs.ngModel, function (value) {
                if (value != undefined) {

                }
            });

            element.bind('keydown', function (event) {
                if (event.which == 9)
                    event.preventDefault();
            })
            element.bind('keyup', function (event) {
                var key = event.which;
                if (key == 9 || key == 13) {
                    event.preventDefault();
                    scope.$apply(attrs.newTag);
                }
            })
        }
    }
});