var app = angular.module('app');

app.factory('celebServise', ['$http', function (http) {
    var httpRequestMgr = function (action, method, data) {
        return http({
            method: method || 'GET',
            url: '/api/ApiCelebs/' + action,
            data: data
        });
    }


    var getCelebs = function () {

        return httpRequestMgr('GetSCelebsData');
    }

    var updateCeleb = function (celeb) {
        return httpRequestMgr('Edit', 'POST', celeb);
    }

    var deleteCeleb = function (celeb) {
        return httpRequestMgr('Delete', 'POST', celeb);
    }

    var createCeleb = function (celeb) {
        return httpRequestMgr('Create', 'POST', celeb);
    }
    return {
        getCelebs: getCelebs,
        updateCeleb: updateCeleb,
        deleteCeleb: deleteCeleb,
        createCeleb: createCeleb
    }
}])