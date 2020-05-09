
var MyAjax = function () {
    this.XHR = null;
};


MyAjax.prototype.get = function (url, sendData, callBackFunction, responseType = 'json') {

    this.XHR = this.GetNewXHR();
    this.XHR.onreadystatechange = function () {
        if (this.readyState == 4) {
            if (this.status >= 200 && this.status < 300) {
                callBackFunction(this.response);
            }
            else {
                showError(this.status);
            }
        }

    }

    this.XHR.responseType = responseType;
    this.XHR.open("Get", url + getQueryString(sendData), true)
    this.XHR.send();
}

MyAjax.prototype.post = function (url, sendData, callBackFunction, responseType = 'json') {

    this.XHR = this.GetNewXHR();
    this.XHR.onreadystatechange = function () {
        if (this.readyState == 4) {
            if (this.status >= 200 && this.status < 300) {
                callBackFunction(this.response);
            }
            else {
                showError(this.status);
            }
        }

    }


    this.XHR.responseType = responseType;
    this.XHR.open("Post", url, true)
    this.XHR.send(getFormData(sendData));
}

function showError(status) {
    var errorMessage = "خطا";
    if (status >= 400 && status < 500) {
        errorMessage = " خطای سمت مشتری ";
    }
    if (status >= 500) {
        errorMessage = "خطای سمت سرور";
    }

    alert(status);
}

function getQueryString(ob) {

    if (ob == null)
        return "";
    var str = "?"
    for (var prop in ob) {
        if (str == "?")
            str += prop + "=" + ob[prop];
        else
            str += "&" + prop + "=" + ob[prop]
    }
    return str;
}

function getFormData(ob) {

    if (ob == null)
        return null;

    var form = new FormData();
    for (var prop in ob) {
        form.append(prop, ob[prop]);
    }
    return form;
}

MyAjax.prototype.GetNewXHR = function () {

    var xhr = new XMLHttpRequest();
    xhr.onloadstart = function () {
        imgLoading.style.display = "block";
    }
    xhr.onloadend = function () {
        imgLoading.style.display = "none";
    }

    return xhr;

}


var AJX = new MyAjax();
