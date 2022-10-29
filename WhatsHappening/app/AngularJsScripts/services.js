'use strict';

/* Services */

var WhatsHappeningServices = angular.module('WhatsHappeningServices', ['ngResource']);

WhatsHappeningServices.factory('Phone', ['$resource',
  function ($resource) {
      return $resource('app/phones/:phoneId.json', {}, {
          query: { method: 'GET', params: { phoneId: 'phones' }, isArray: true }
      });
  }]);

//WhatsHappeningServices.factory('Location', function ($resource) {
//    return $resource('api/Location/:searchTerm', {}, {
//            query: { method: 'GET', isArray: true }
//        });
//    });

//DateTimeOffset? date, Guid? cityId, string city, Guid? categoryId)

WhatsHappeningServices.factory('SearchEvents', ['$resource',
  function ($resource) {
      return $resource('api/Event?date=:date&cityId=:cityId&city=:city&categoryId=:categoryId', {}, {
          get: { method: 'GET', params: { date: 'date', cityId: 'cityId', city: 'city', categoryId: 'categoryId' }, isArray: true }
      });
  }]);

WhatsHappeningServices.factory('Location', ['$resource',
  function ($resource) {
      return $resource('api/Location?searchTerm=:searchTerm', {}, {
          get: { method: 'GET', params: { searchTerm: 'searchTerm' }, isArray: true }
      });
  }]);

WhatsHappeningServices.factory('Categories', ['$resource',
  function ($resource) {
      return $resource('api/Categories', {}, {
          get: { method: 'GET', params: {}, isArray: true }
      });
  }]);


//WhatsHappeningServices.factory('Location', function ($http) {
//    return {
//        getLocations: function () {
//            return $http.get('api/Location?searchTerm=searchTerm');
//        },
//        addPerson: function (person) {
//            return $http.post(url, person);
//        },
//        deletePerson: function (person) {
//            return $http.delete(url + person.Id);
//        },
//        updatePerson: function (person) {
//            return $http.put(url + person.Id, person);
//        }
//    };
//});
