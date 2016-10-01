//variables
var ac_black = [];
var storage = window.localStorage;
var ac_blackEnable = true;
//init
setInterval(function () {
    Init();
    addControls();
}, 2000);
//functions
function addControls() {
    $("body").append('<a href="#" onclick="EnableFilter();" class="EnableFilter">💖</a>');
    $("body").append('<a href="#" onclick="DisableFilter();" class="DisableFilter">💔</a>');
    $("body").append('<a href="#" onclick="ConfigFilter();" class="ConfigFilter">💘</a>');
}
function Init() {
    if (storage && storage.ac_black) { ac_black = storage.ac_black.split(','); ac_blackEnable = storage.ac_blackEnable == "true"; }
    if (ac_blackEnable) {
        $('.block-video').each(function () {
            for (var aaa = 0; aaa < ac_black.length; aaa++) {
                if ($(this).find('figcaption a').html().indexOf(ac_black[aaa]) >= 0) {
                    $(this).find('.block-img img').attr('src', $('#footer .footer-avatar-ac img').attr('src'));
                    $(this).find('a').removeAttr("href");
                    $(this).find('figcaption a').text("");
                }
            }
        });
    }
}
function EnableFilter() {
    ac_blackEnable = true;
    if (storage) { storage.ac_blackEnable = ac_blackEnable; }
    location.reload();
}
function DisableFilter() {
    ac_blackEnable = false;
    if (storage) { storage.ac_blackEnable = ac_blackEnable; }
    location.reload();
}
function ConfigFilter() {
    var name = prompt("输 ⚣ 入 :", "陈一发");
    if (name != null && name != "") {
        ac_black.push(name);
    }
    if (storage) { storage.ac_black = ac_black; storage.ac_blackEnable = ac_blackEnable; }
}