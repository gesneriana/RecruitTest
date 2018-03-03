// Write your JavaScript code.
lay('#version').html('-v' + laydate.v);

//执行一个laydate实例
laydate.render({
    elem: '#signUserData-birthday' //指定元素
});

//读Cookie
function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
    return "";
}
//设置cookie的值
function setCookie(cname, cvalue, exHours) {
    var d = new Date();
    d.setTime(d.getTime() + (exHours * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + escape(cvalue) + "; " + expires;
    console.log(document.cookie);
}

// 使用表单数据传输参数
Vue.http.options.emulateJSON = true;

// Vue请求拦截器, 可以在请求开始前和请求后做一些额外的事情
Vue.http.interceptors.push(function (request, next) {
    // 请求发送前的处理逻辑

    // ...设置请求头的token
    var token = getCookie("token");
    if (token.length > 0) {
        request.headers.set('token', token);
        request.headers.set('token_type', getCookie("token_type"));
    }

    next(function (response) {
        // ...
        // 请求发送后的处理逻辑
        // ...
        // 根据请求的状态，response参数会返回给successCallback或errorCallback
        if (response.status >= 400) {
            if (response.body.ShowMsgBox) {
                alert(response.body.ErrorMessage);  // 显示错误信息, 也可以弹出模态框显示
            }
            if (response.body.ErrorType == 'TokenError') {
                setCookie("token", ''); // 清除token, 重新加载
                location.reload();
            }
        }
        return response
    })
});

// 当前html页面的Vue实例
var vm = new Vue({
    el: '#app',
    data: {
        signUserData:
        {
            nickname: '',
            pwd: '',
            uname: '',
            company_address: '',
            company_code: '',
            company_contact: '',
            company_name: '',
            birthday: '',
            email: '',
            nickname: '',
            phone: '',
            auth_role: 'user',
            repwd: ''
        },
        hasToken: false,
        bodyContent: 'init',
        uname: '',  // 登录表单的用户名
        pwd: '' //登录表单的密码
    },


    // 初始化的函数, 相当于ready
    mounted: function () {
        if (getCookie("token").length > 0) {
            // 有token, 但是可能过期, 隐藏登陆和注册按钮
            this.$data.hasToken = true;
            this.testToken();   // 验证token是否有效
        } else {
            // 没有token, 显示登录的模板
            this.$data.bodyContent = "login";
        }
    },

    // vue监听的方法
    methods: {
        // 登录api, 获取token
        getJwtToken: function () {
            this.$http({
                method: 'post',
                url: '/api/account/login',
                body: { uname: this.uname, pwd: this.pwd },
                timeout: 3000,
            }).then(function (response) {
                if (response.status == 200) {
                    this.hasToken = true;
                    setCookie("token", response.body.token, response.body.expires_in);
                    setCookie("token_type", response.body.token_type, response.body.expires_in);
                    this.$data.bodyContent = 'init';
                    if (response.body.auth_role == 'company') {
                        this.signUserData.auth_role = 'company';
                        location.href = '/app/admin.html';
                    }
                } else {
                    alert(response);
                }
            });
        },
        // 验证token是否有效的方法
        testToken: function () {
            this.$http({
                method: 'post',
                url: '/api/account/CheckToken',
                timeout: 3000,
            }).then(function (response) {
                if (response.body == 'company') {
                    this.signUserData.auth_role = 'company';
                    location.href = '/app/admin.html';
                }
                console.info(response.body);
            });
        },
        // 注销
        signUp: function () {
            setCookie("token", '');
            this.bodyContent = 'login';
        },
        // 打开注册界面
        signIn: function () {
            this.bodyContent = 'SignInUser';
        },
        // 打开登录界面
        userLogin: function () {
            this.bodyContent = 'login';
        },
        // 注册
        registerUser: function () {
            if (this.signUserData.nickname.length < 2 || this.signUserData.nickname.length > 20) {
                this.signUserData.nickname = '';
                return;
            }
            this.signUserData.nickname = $.trim(this.signUserData.nickname);

            this.signUserData.pwd = $.trim(this.signUserData.pwd);
            if (this.signUserData.pwd.length < 6) {
                this.signUserData.pwd = '';
                return;
            }
            if (this.signUserData.pwd != this.signUserData.repwd) {
                console.log("密码不正确");
                this.signUserData.repwd = '';
                return;
            }

            var email = this.signUserData.email;
            if (!email.match(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/)) {
                this.signUserData.email = '';
                return;
            }

            if (this.signUserData.phone.length != 11) {
                this.signUserData.phone = '';
                return;
            }
            if (this.signUserData.auth_role == 'user') {
                if (this.signUserData.uname.length < 2 || this.signUserData.uname.length > 20) {
                    this.signUserData.uname = '';
                    return;
                }
                this.signUserData.uname = $.trim(this.signUserData.uname);
                if (this.signUserData.birthday.length == 0) {
                    return;
                }
            } else if (this.signUserData.auth_role == 'company') {
                if (this.signUserData.company_code.length == 0) {
                    return;
                }
                if (this.signUserData.company_address.length == 0) {
                    return;
                }
                if (this.signUserData.company_name.length == 0) {
                    return;
                }
                if (this.signUserData.company_contact.length == 0) {
                    return;
                }
            }
            // 开始提交到后台注册.
            this.$http({
                method: 'post',
                url: '/api/account/RegisterUser',
                body: { user: this.signUserData },
                timeout: 3000,
            }).then(function (response) {
                if (response.status == 200) {
                    alert("注册成功");
                    this.$data.bodyContent = 'login';
                } else {
                    alert(response);
                }
            });
        }
    }
});