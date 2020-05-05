function OpenWindow(url) {

    var width = window.innerWidth * 0.7;
    var height = window.innerHeight * 0.7;
    var left = window.innerWidth * .15 + window.screenX;
    var top = window.innerHeight * 0.15;
    return window.open(url, "", "width=" + width + ",height=" + height + ",left=" + left + ", top=" + top);

}