'use strict';

/* App Module */

var WhatsHappeningApp = angular.module('WhatsHappeningApp', [
  'ngRoute',
  'ui.router',
  'WhatsHappeningAnimations',

  'WhatsHappeningControllers',
  'WhatsHappeningFilters',
  'WhatsHappeningServices',

  'ui.bootstrap',
  'ui.select2'
]);

WhatsHappeningApp.config(['$routeProvider', '$stateProvider', '$urlRouterProvider',
function ($routeProvider, $stateProvider, $urlRouterProvider) {

    $stateProvider
        .state('event-search-definition', {
            url: "/searchResults",
            templateUrl: "app/Partials/event-search-definition.html",
            controller: 'EventSearchCtrl'
        });

    $routeProvider.
      when('/phones', {
          templateUrl: 'app/Partials/phone-list.html',
          controller: 'PhoneListCtrl'
      }).
      when('/phones/:phoneId', {
          templateUrl: 'app/Partials/phone-detail.html',
          controller: 'PhoneDetailCtrl'
      }).
      when('/events', {
          templateUrl: 'app/Partials/event-search.html',
          controller: 'EventSearchCtrl'
      }).
      when('/searchResults/date/:date/cityId/:cityId/city/:city/categoryId/:categoryId', {
          templateUrl: 'app/Partials/event-search-Results.html',
          controller: 'EventSearchResultsCtrl'
      }).
      when('/createEvent', {
          templateUrl: 'app/Partials/create-event.html',
          controller: 'CreateEventCtrl'
      }).
      otherwise({
          redirectTo: '/events'
      });


}]);
