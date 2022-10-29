'use strict';

/* Controllers */

//https://github.com/bassjobsen/Bootstrap-3-Typeahead
//http://twitter.github.io/typeahead.js/
//http://tutorialzine.com/2013/07/50-must-have-plugins-for-extending-twitter-bootstrap/
//http://fk.github.io/select2-bootstrap-css/


//http://angular-ui.github.io/bootstrap/ -> https://github.com/angular-ui/bootstrap/tree/master/src/typeahead

var WhatsHappeningControllers = angular.module('WhatsHappeningControllers', []);

WhatsHappeningControllers.controller('EventSearchCtrl', ['$scope', '$routeParams', 'Location', '$http', 'Categories',
function ($scope, $routeParams, Location, $http, Categories) {
    $scope.dateOptions = {
        'year-format': "'yy'",
        'starting-day': 1
    };


    $scope.today = function () {
        $scope.dt = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.dt = null;
    };

    // Disable weekend selection
    $scope.disabled = function (date, mode) {
        return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
    };

    $scope.toggleMin = function () {
        $scope.minDate = $scope.minDate ? null : new Date();
    };
    $scope.toggleMin();

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.initDate = new Date('2016-15-20');
    $scope.formats = ['dd-MM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];


    $scope.categories = Categories.get();
    // Any function returning a promise object can be used to load values asynchronously
    $scope.getLocation = function (val) {
        return Location.get({ searchTerm: val }, function (location) { }).$promise.then(function (res) {
            var addresses = [];
            angular.forEach(res, function (item) {
                if (item.Value) {
                    addresses.push(item.Value);
                }
            });
            return addresses;
        });
    }
    //$scope.getLocation = function (val) {
    //    return $http.get('api/Location', {
    //        params: {
    //            searchTerm: val
    //        }
    //    }).then(function (res) {
    //        var addresses = [];
    //        angular.forEach(res.data, function (item) {
    //            addresses.push(item.Value);
    //        });
    //        return addresses;
    //    });
    //};
}]);

WhatsHappeningControllers.controller('EventSearchResultsCtrl', ['$scope', '$routeParams', 'SearchEvents',
function ($scope, $routeParams, SearchEvents) {
    console.log($routeParams);
    console.log($routeParams.date + " - " + $routeParams.cityId + " - " + $routeParams.city + " - " + $routeParams.categoryId);
    $scope.searchResults = SearchEvents.get({ date: $routeParams.date, cityId: $routeParams.cityId, city: $routeParams.city, categoryId: $routeParams.categoryId }, function (event) {
        //$scope.mainImageUrl = phone.images[0];
    });

}]);

WhatsHappeningControllers.controller('CreateEventCtrl', ['$scope', '$routeParams', 'Location', '$http', 'Categories',
function ($scope, $routeParams, Location, $http, Categories) {
    $scope.createEvent = "create event!";
}]);



WhatsHappeningControllers.controller('PhoneListCtrl', ['$scope', 'Phone',
  function ($scope, Phone) {
      $scope.phones = Phone.query();
      $scope.orderProp = 'age';
  }]);

WhatsHappeningControllers.controller('PhoneDetailCtrl', ['$scope', '$routeParams', 'Phone',
  function ($scope, $routeParams, Phone) {
      $scope.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
          $scope.mainImageUrl = phone.images[0];
      });

      $scope.setImage = function (imageUrl) {
          $scope.mainImageUrl = imageUrl;
      }
  }]);
