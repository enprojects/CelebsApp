var app = angular.module('app');

app.controller('mainController', ['$scope', 'celebServise', '$modal', function (scope, celebServise, $modal) {

    scope.celebs = [];

    scope.init = function () {

        celebServise.getCelebs()
            .then(function (result) {
                scope.celebs = result.data;
            });

    };

    scope.init();

    scope.addCeleb = function () {

        scope.crudOperation(null, scope.init);
    }

    scope.crudOperation = function (celeb) {
        $modal.open({
            templateUrl: '/HtmlTemplets/DialogHtml1.html',
            windowClass: 'modal', // windowClass - additional CSS class(es) to be added to a modal window template
            controller: function ($scope, $modalInstance, celeb, celebServise) {
                $scope.celeb = celeb || {};
                $scope.callback = scope.init;


                if (!celeb) {
                    $scope.isHide = true;

                }

                $scope.createCeleb = function () {

                    celebServise.createCeleb($scope.celeb)
                                  .then(function (result) {

                                      if (result.data) {
                                          if (!result.data.Success) {
                                              alert('Celeb has been inserted ..')
                                          }

                                      }

                                      $scope.callback();
                                      $modalInstance.close();
                                  });
                }

                $scope.deleteCeleb = function () {

                    celebServise.deleteCeleb($scope.celeb)

                            .then(function (result) {
                                if (result && result.data) {
                                    if (result.data.Success) {
                                        $scope.callback();
                                        $modalInstance.close();
                                    } else {
                                        alert('Record has not changed')
                                    }

                                } else {
                                    alert('Fatal Error')
                                }
                            });

                }

                $scope.updateCeleb = function () {

                    celebServise.updateCeleb($scope.celeb)

                        .then(function (result) {
                            if (result && result.data) {
                                if (result.data.Success) {
                                    $scope.callback();
                                    $modalInstance.close();
                                } else {
                                    alert('Record has not changed')
                                }

                            } else {
                                alert('Fatal Error')
                            }
                        });
                }
                $scope.cancel = function () {
                    $modalInstance.dismiss('cancel');
                };
            },
            resolve: {
                celeb: function () {
                    return celeb;
                }
            }
        });


    }

}]);
