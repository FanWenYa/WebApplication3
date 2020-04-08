var app = angular.module('myApp', ['ui.router', 'contrllerctrl']);

app.config(["$stateProvider", function ($stateProvider) {

    $stateProvider
       .state("index", {
            url: '',
            templateUrl: 'htmls/nav/nav.html'
       })
    .state("index.login", {
        url: '/login',
        templateUrl: 'common/login.html',
        controller: 'loginctrl'
       
    })
    .state("index.register", {
        url: '/register',
        templateUrl: 'common/register.html',
        controller: 'registerctrl'
    })
    .state("index.data", {
        url: '/data',
        templateUrl: 'htmls/Personal_information/data.html',
        controller: 'contentctrl'
    })
    .state("index.data.mka", {
        url: '/mka',
        templateUrl: 'htmls/Personal_information/data-1.html',
        controller: 'data-1'
    })
   .state("index.data.mkb", {
        url: '/mkb',
        templateUrl: 'htmls/Personal_information/class-information.html',
        controller: 'systemctrl'
   })
    .state("index.data.mkc", {
        url: '/mkc',
        templateUrl: 'htmls/Personal_information/authority-management.html',
        controller: 'jurisdictionctrl'
    })


}])

app.config(["$httpProvider", function ($httpProvider) {
    //更改 Content-Type
    $httpProvider.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded;charset=utf-8";
    $httpProvider.defaults.headers.post["Accept"] = "*/*";
    $httpProvider.defaults.transformRequest = function (data) {
        //把JSON数据转换成字符串形式
        if (data !== undefined) {
            return $.param(data);
        }
        return data;
    };
}])