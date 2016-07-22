//
// Cookie Manager
//

function setCookie(name, value, days) {
    var expires;

    if (days) {
        var date = new Date();
        date.setDate(date.getDate() + days);
        expires = "; expires=" + date.toUTCString();
    }
    else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function getCookie(name) {
    var arrCookies = document.cookie.split(';');

    for (var i = 0; i < arrCookies.length; i++) {
        cookieName = arrCookies[i].substr(0, arrCookies[i].indexOf("="));
        cookieVal = arrCookies[i].substr(arrCookies[i].indexOf("=") + 1);
        cookieName = cookieName.replace(/^\s+|\s+$/g, "");
        if (cookieName == name) {
            return unescape(cookieVal);
        }
    }
    return null;
}

function delCookie(name) {
    setCookie(name, "", -1);
}
