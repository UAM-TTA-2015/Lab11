angular.module('uamtta').controller('MainCtrl', function ($scope, $http, $rootScope) {
    
    $scope.budgets = [];    
    
    $scope.getBudgets = function(){
      $http
        .get('http://localhost:49974/api/budgets/')
        .success(function(data, status, headers, config) {
            $scope.budgets = data;
        })
        .error(function(data, status, headers, config) {
            console.log(data);
        });
    };
    
     $scope.clearBudgets = function(){
        $scope.budgets = [];
    };
    	
});
