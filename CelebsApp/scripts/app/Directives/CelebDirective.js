var app = angular.module('app');

app.directive('ngCelebs', [function () {

    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/HtmlTemplets/Celebs.html',
        scope: {
            celebs: '=',
            callback: '&'
        },
        link: function (scope, element, attrs) {

            scope.cb = function (celeb) {
                var callback = scope.callback();

                if (callback) {
                    callback(celeb)
                }
            }
        }
    }

}]);