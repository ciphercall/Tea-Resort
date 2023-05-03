var myApp = angular.module('myApp', []);
myApp.controller('NewsFeed', ['$scope', '$http', function ($scope, $http) {
    $scope.NewsData = function () {
        $http({
            url: "/search.asmx/ShowNewsFeed",
            dataType: 'json',
            method: 'POST',
            data: '',
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            debugger;
            $scope.NewsList = response.d;
        })
           .error(function (error) {
               alert(error);
           });
    }
}]);
