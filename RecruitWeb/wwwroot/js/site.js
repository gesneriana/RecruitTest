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
                location.href = '/app/index.html';
            }
        }
        return response
    })
});