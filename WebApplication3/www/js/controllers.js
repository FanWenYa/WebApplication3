var contrllerctrl = angular.module('contrllerctrl', []);

contrllerctrl.controller('indexctrl', function ($scope, $location, $rootScope) {
    $rootScope.loginout = true;
    $rootScope.login = false;       
    if (sessionStorage.uesekey == '') {
        $rootScope.loginout = true;
        $rootScope.login = false;
    }
    if (sessionStorage.uesekey == 'true') {
        $location.url('/data');
        $rootScope.name = sessionStorage.name;
        $rootScope.loginout = false;
        $rootScope.login = true;
        $rootScope.out = function () {
            $rootScope.loginout = true;
            $rootScope.login = false;
            sessionStorage.name = '';
            sessionStorage.uesekey = '';
            sessionStorage.statecode = "";
            $location.url('/login');
        };
    }

   
})

contrllerctrl.controller('loginctrl', function ($scope, $http, $location, $rootScope) {
    if (sessionStorage.uesekey == 'true') {
        $location.url('/data/mka');
    }
    $scope.user = '';
    $scope.password = '';
    $scope.logingets = function () {
        $http({
            method:'post',
            url: '/login.ashx',
            data:{ 'username': $scope.user, 'password': $scope.password }
        }).then(function (msg) {
            console.log(msg.data);
            var data = msg.data;
            if (data == "") {
                alert("用户密码错误");
            } else {
                alert("登陆成功");
                sessionStorage.uesekey = "true";
                sessionStorage.statecode = msg.data[0].statecode;
                sessionStorage.name = msg.data[0].username;
                sessionStorage.state = msg.data[0].state;
                $rootScope.name = sessionStorage.name;
                $rootScope.loginout = false;
                $rootScope.login = true;
                $location.url('/data/mka');
            }
        })
    }

})

contrllerctrl.controller('registerctrl', function ($scope, $http, $location, $rootScope) {

    if (sessionStorage.uesekey == 'true') {
        $location.url('/data/mka');
    }
    $scope.user = '';
    $scope.name = '';
    $scope.password = '';
    $scope.password2 = '';


    $scope.registerget = function () {

        if ($scope.user == "") {
            $scope.user_input = "请输入账户";
            $scope.users = true;
        }
        if ($scope.password == "") {
            $scope.password_input = "请输入密码";
            $scope.passwords = true;
        }
        if ($scope.password2 == "") {
            $scope.password2_input = "请再次确认密码";
            $scope.password2s = true;
        }
        if($scope.password != $scope.password2 && $scope.password != "" && $scope.password2 != ""){
            $scope.password_input  = $scope.password2_input = "两次输入的密码不同";
        }

        if ($scope.user != "" && $scope.password == $scope.password2) {
            $http({
                method: 'post',
                url: '/register.ashx',
                data: { 'username': $scope.user, 'password': $scope.password }
            }).then(function (msg) {
                console.log(msg.data);
                var data = msg.data;
                if (data == "") {
                    $scope.user_input= "注册的账户已存在" ;
                } else {
                    alert("登陆成功");
                    sessionStorage.uesekey = "true";
                    sessionStorage.statecode = msg.data[0].statecode;
                    sessionStorage.name = msg.data[0].username;
                    sessionStorage.state = msg.data[0].state;
                    $rootScope.name = sessionStorage.name;
                    $rootScope.loginout = false;
                    $rootScope.login = true;
                    $location.url('/data/mka');
                }
            })
        }
    }
})

contrllerctrl.controller('contentctrl', function ($location, $rootScope,$scope) {
    if (sessionStorage.uesekey == '') {
        $location.url('/login');
    }
    if (sessionStorage.uesekey == 'true') {
        $location.url('/data/mka');
    }
    if (sessionStorage.state == "超级管理员") {
        $rootScope.state1 = true;
        $scope.state = true;
    } else if (sessionStorage.state == "管理员") {
        $rootScope.state1 = true;
        $scope.state = false;
    } else if (sessionStorage.state == "普通用户") {
        $rootScope.state1 = false;
        $scope.state = false;
    }
})


contrllerctrl.controller('data-1', function ($scope, $location) {
    if (sessionStorage.vuesekey == '') {
        $location.url('/login');
    }
    if (sessionStorage.uesekey == 'true') {
        $scope.name = sessionStorage.name;
    }

})

contrllerctrl.controller('systemctrl', function ($scope, $http, $rootScope) {
 
    //首次加载时读取数据库系部信息
    if (sessionStorage.uesekey == 'true') {
        
        $http({
            method: 'post',
            url: '/Handler1.ashx',
            data: { 'statecode': sessionStorage.statecode, 'operation': '查询系部信息' }
        }).then(function (msg) {

            var systems = ['请选择系部'];
            for (var i = 0; i < msg.data.length; i++) {
                systems.push(msg.data[i].system);
            }
            var systems = Array.from(new Set(systems));
            $scope.systems = systems;
            $scope.system = $scope.system2 =  systems[0];
            $scope.classs = $scope.classs2 = ['请选择系部'];
            $scope.grades = $scope.grades2 = ['请选择系部'];
            $scope.class = $scope.sclass2 =  $scope.classs[0];
            $scope.grade = $scope.sgrade2 =  $scope.grades[0];
            //读取所有学生信息
            $http({
                method: 'post',
                url: '/Handler1.ashx',
                data: { 'operation': '查询所有学生信息' }
            }).then(function (msg) {
                $scope.students = msg.data;
            })
        })


        //根据系部信息查询系部的班级年级信息
        $scope.select_system = function () {
            if ($scope.system != null && $scope.system != '请选择系部') {
                $http({
                    method: 'post',
                    url: '/Handler1.ashx',
                    data: { 'operation': '根据系部信息查询班级年级信息', 'statecode': sessionStorage.statecode, 'system': $scope.system }
                }).then(function (msg) {
                    var classs = ['请选择班级'];
                    var grades = ['请选择年级'];
                    for (var i = 0; i < msg.data.length; i++) {
                        classs.push(msg.data[i].class);
                        grades.push(msg.data[i].grade);
                    }
                    var classs = Array.from(new Set(classs)),
                          grades = Array.from(new Set(grades));
                    console.log(classs, grades);
                    $scope.classs = classs;
                    $scope.grades = grades;
                    $scope.class = classs[0];
                    $scope.grade = grades[0];
                    //根据系部信息查询学生信息
                    $http({
                        method: "post",
                        url: '/Handler1.ashx',
                        data: { 'operation': '根据系部信息查询学生信息', 'system': $scope.system }
                    }).then(function (msg) {
                        console.log(msg.data);
                        $scope.students = msg.data;
                    })
                })
            }  
        }
        //根据系部班级年级信息查询学生信息
        $scope.select_students = function () {
            if ($scope.class != "" && $scope.grade != "" && $scope.class != "请选择班级" && $scope.grade != "请选择年级" &&  $scope.class != "请选择系部" &&  $scope.grade != "请选择系部") {
            console.log("我是要发送的班级信息：" + $scope.class);
            console.log("我是要发送的年级信息：" + $scope.grade);
            if ($scope.system != null && $scope.class != null && $scope.grade != null) {
            $http({
                method: 'post',
                url: '/Handler1.ashx',
                data: { 'operation': '根据系部班级年级信息查询学生信息', 'statecode': sessionStorage.statecode, 'classs': $scope.class, 'grades': $scope.grade }
            }).then(function (msg) {
                console.log("我是接收的学生信息：");
                console.log(msg.data);
                $scope.students = msg.data;
                
            })
            }
            } else if ($scope.class != "" && $scope.grade != "" && $scope.class != "请选择班级" && $scope.grade == "请选择年级" && $scope.class != "请选择系部" && $scope.grade != "请选择系部") {
                $http({
                    method: 'post',
                    url: '/Handler1.ashx',
                    data: { 'operation': '根据系部班级信息查询学生信息', 'statecode': sessionStorage.statecode, 'classs': $scope.class, }
                }).then(function (msg) {
                    $scope.students = msg.data;
                })
            } 
        }

        //
        $scope.select_system2 = function () {
            if ($scope.system2 != null && $scope.system2 != '请选择系部') {
                $http({
                    method: 'post',
                    url: '/Handler1.ashx',
                    data: { 'operation': '根据系部信息查询班级年级信息', 'statecode': sessionStorage.statecode, 'system': $scope.system2 }
                }).then(function (msg) {
                    var classs = ['请选择班级'];
                    var grades = ['请选择年级'];
                    for (var i = 0; i < msg.data.length; i++) {
                        classs.push(msg.data[i].class);
                        grades.push(msg.data[i].grade);
                    }
                    var classs = Array.from(new Set(classs)),
                          grades = Array.from(new Set(grades));
                    console.log(classs);
                    $scope.classs2 = classs;
                    $scope.grades2 = grades;
                    $scope.sclass2 = classs[0];
                    $scope.sgrade2 = grades[0];
                })
            }
        }
        //添加学生信息
        $scope.put = function () {


            var mydate = document.getElementById("mydate").value;
            if (mydate != "" && $scope.id2 != "" && $scope.sphone2 != "" && $scope.sid != "" && $scope.sname != "" && $scope.sclass2 != "" && $scope.sgrade2 != "" && $scope.ssystem2 != "" && $scope.sclass2 != "请选择班级" && $scope.sgrade2 != "请选择年级" && $scope.sgrade2 != "请选择系部" && $scope.ssystem2 != "请选择系部" && $scope.sclass2 != "请选择系部") {
                
                $scope.sbirth2 = mydate
                $http({
                method: 'post',             
                url: '/addstudent.ashx',
                data: { 'statecode': sessionStorage.statecode, 'sid': $scope.sid, 'sname': $scope.sname, 'sclass': $scope.sclass2, 'sgrade': $scope.sgrade2, 'ssystem': $scope.system2, 'id': $scope.id2, 'sphone': $scope.sphone2, 'sbirth': $scope.sbirth2 }
            }).then(function (msg) {
                if (msg.data == "添加成功") {
                    if ($scope.system != "请选择系部" && $scope.class != "请选择系部" && $scope.grade != "请选择系部") {
                        $http({
                            method: 'post',
                            url: '/Handler1.ashx',
                            data: { 'statecode': sessionStorage.statecode, 'classs': $scope.class, 'grades': $scope.grade },
                        }).then(function (msg) {
                            console.log("我是接收的学生信息：");
                            console.log(msg.data);
                            $scope.students = msg.data;
                        })
                    }
                    alert("添加成功");
                } else if (msg.data == "学号已存在") {
                    alert("学号已存在");
                } 
            })
            } else {
                alert("请填写学生信息");
            }
        }
        //
        $scope.insert = function () {
            $scope.insertstudent = true;
            $scope.modifystudent = false;
            $scope.sname = "";
            $scope.sclass = "";
            $scope.sgrade = "";
            $scope.ssystem = "";

        }
        //
        $scope.modify = function (sid, Sname, Sclass, Sgrade, Ssystem) {
            $scope.insertstudent = false;
            $scope.modifystudent = true;

            $scope.sname = Sname;
            $scope.sclass = Sclass;
            $scope.sgrade = Sgrade;
            $scope.ssystem = Ssystem;

            $scope.insertput = function () {
                $http({
                    method: 'post',
                    url: '/modifystudent.ashx',
                    data: { 'statecode': sessionStorage.statecode, 'sid': sid, 'sname': $scope.sname, 'sclass': $scope.sclass, 'sgrade': $scope.sgrade, 'ssystem': $scope.ssystem }
                }).then(function (msg) {
                    if (msg.data == "修改成功") {
                        if ($scope.system != null && $scope.class != null && $scope.grade != null) {
                            $http({
                                method: 'post',
                                url: '/Handler1.ashx',
                                params: { 'statecode': sessionStorage.statecode, 'classs': $scope.class, 'grades': $scope.grade },
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                            }).then(function (msg) {
                                console.log("我是接收的学生信息：");
                                console.log(msg.data);
                                $scope.students = msg.data;

                            })
                        }
                        alert("修改成功");
                    }
                })
            }
        }
        //
        $scope.delete = function (id) {
            $http({
                method: 'post',
                url: '/deletestudent.ashx',
                data: {'statecode': sessionStorage.statecode , 'sid': id }
            }).then(function (msg) {
                if (msg.data == "删除成功") {
                    if ($scope.system != null && $scope.class != null && $scope.grade != null) {
                        $http({
                            method: 'post',
                            url: '/Handler1.ashx',
                            params: { 'statecode': sessionStorage.statecode, 'classs': $scope.class, 'grades': $scope.grade },
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                        }).then(function (msg) {
                            console.log("我是接收的学生信息：");
                            console.log(msg.data);
                            $scope.students = msg.data;

                        })
                    }
                    alert("删除成功");
                }
            })
        }
    }
})

//用户权限
contrllerctrl.controller('jurisdictionctrl', function ($scope, $http) {
    if (sessionStorage.uesekey == 'true') {
        $http({
            method: 'post',
            url: '/jurisdiction.ashx',
            data: { 'statecode': sessionStorage.statecode }
        }).then(function (msg) {
            var state = [];
            for (var i = 0; i < msg.data.length; i++) {
                state.push(msg.data[i].state);
            }
            var state = Array.from(new Set(state));
            $scope.systems = state;
            $scope.jurisdiction = msg.data;
        })
    }
    //查询用户权限
    $scope.selectjurisdiction = function () {
        if ($scope.system != null) {
            $http({
                method: 'post',
                url: '/jurisdiction.ashx',
                data: { 'statecode': sessionStorage.statecode, 'state': $scope.system }
            }).then(function (msg) {
                $scope.Jurisdictions = msg.data;
            })
        }
    
    }
    //修改用户权限
    $scope.modify = function (username, state) {
        $scope.username = username;
        $scope.state = state;
        console.log();
        $scope.put = function () {
            $http({
                method: 'post',
                url: '/modifyjurisdiction.ashx',
                data: { 'statecode': sessionStorage.statecode, 'username': $scope.username, 'stateget': $scope.stateget }
            }).then(function (msg) {
                if (msg.data == "修改成功") {
                    alert("修改成功");
                    if ($scope.system != null) {
                        $http({
                            method: 'post',
                            url: '/jurisdiction.ashx',
                            data: { 'statecode': sessionStorage.statecode, 'state': $scope.system }
                        }).then(function (msg) {
                            $scope.Jurisdictions = msg.data;
                        })
                    }

                } else {
                    alert("修改失败");
                }
            })
        }
    }
    //删除用户
    $scope.delete = function (username) {
        $http({
            method: 'post',
            url: '/deleteusername.ashx',
            data: { 'statecode': sessionStorage.statecode , 'username': username}
        }).then(function (msg) {
            alert(msg.data);
            if ($scope.system != null) {
                $http({
                    method: 'post',
                    url: '/jurisdiction.ashx',
                    data: { 'statecode': sessionStorage.statecode, 'state': $scope.system }
                }).then(function (msg) {
                    $scope.Jurisdictions = msg.data;
                })
            }

        })
    }
    //刷新
    $scope.refresh = function () {
        $http({
            method: 'post',
            url: '/jurisdiction.ashx',
            data: { 'statecode': sessionStorage.statecode, 'state': $scope.system }
        }).then(function (msg) {
            $scope.Jurisdictions = msg.data;
        })
    }


})