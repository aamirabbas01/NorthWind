/// <reference path="angular.js" />

var app = angular.module('app', []);
app.controller('customer', function ($scope, $http, $window) {
    var apiURL = '/api/Customers/';
    $scope.getCustomers = function () {
        $http.get(apiURL).then(function success(d) {
            $scope.records = d.data;
        },
            function error(response) {
                alert("Error Code : " + response.status);
            });
    }

    $scope.getCustomerById = function (id) {

        $http.get(apiURL + id).then(function (d) {
            $scope.customer = d.data;
        }, function (response) {
            alert("Error Code : " + response.status);
        });
    }

    $scope.addCustomer = function (customer) {
        $http({
            method: "POST",
            data: customer,
            url: apiURL
        }).then(function (response) {
            window.location.href = '/Customers';
        }, function (response) {
            alert("Error Code : " + response.status);
        });
    }

    $scope.updateCustomer = function (id, customer) {
        $http({
            method: "PUT",
            url: apiURL + id,
            data: customer
        }).then(function (response) {
            window.location.href = '/Customers';
        }, function (response) {
            alert("Error Code : " + response.status);
        });

    }

    $scope.deleteCustomer = function (id) {
        if ($window.confirm("Are you sure you want to delete?")) {
            $http({
                method: "DELETE",
                url: apiURL + id
            }).then(function (response) {
                window.location.href = '/Customers';
            }, function (response) {
                alert("Error Code : " + response.status);
            });
        }
    }


});
