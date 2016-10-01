function saveHideUser(uid, reason) {
    var storage = window.localStorage;
    storage["uid." + uid + "hide"] = reason;
    //保存屏蔽用户及原因
}
function saveWatchUser(uid, reason) {
    var storage = window.localStorage;
    storage["uid." + uid + "watch"] = reason;
    //保存关注用户及原因
}
function saveHideUserID(uid) {
    var storage = window.localStorage;
    storage["uid." + uid + "hide"] = "hide";
    checkUserHiddenList();
    //保存屏蔽用户
}
function saveWatchUserID(uid) {
    var storage = window.localStorage;
    storage["uid." + uid + "watch"] = "watch";
    checkUserWatchList();
    //保存关注用户
}
function exportList() {
    var storage = window.localStorage;
    //导出列表
}
function importList() {
    var storage = window.localStorage;
    //导入列表
}
function addHideButton() {
    $(".author-comment ").each(function () {
        if ($(this).find("a").hasClass("name")) {
            var uid = $(this).find("a").attr("data-uid");
            $(this).append("<button class='oper' style='-moz-box-shadow:inset 0px 1px 0px 0px #ffffff;	-webkit-box-shadow:inset 0px 1px 0px 0px #ffffff;	box-shadow:inset 0px 1px 0px 0px #ffffff;	background-color:#ededed;	-webkit-border-top-left-radius:6px;	-moz-border-radius-topleft:6px;	border-top-left-radius:6px;	-webkit-border-top-right-radius:6px;	-moz-border-radius-topright:6px;	border-top-right-radius:6px;	-webkit-border-bottom-right-radius:6px;	-moz-border-radius-bottomright:6px;	border-bottom-right-radius:6px;	-webkit-border-bottom-left-radius:6px;	-moz-border-radius-bottomleft:6px;	border-bottom-left-radius:6px;	text-indent:0;	border:1px solid #dcdcdc;	display:inline-block;	color:#777777;	font-family:Arial;	font-size:11px;	font-weight:bold;	font-style:normal;	height:20px;	line-height:20px;	width:100px;	text-decoration:none;	text-align:center;	text-shadow:1px 1px 0px #ffffff;cursor: pointer;' onclick='saveHideUserID(" + uid + ")' href='#' >屏蔽这个大傻逼</button>");
        }
    });
}
function addWatchButton() {
    $(".author-comment ").each(function () {
        if ($(this).find("a").hasClass("name")) {
            var uid = $(this).find("a").attr("data-uid");
            $(this).append("<button  class='oper' style='-moz-box-shadow:inset 0px 1px 0px 0px #ffffff;	-webkit-box-shadow:inset 0px 1px 0px 0px #ffffff;	box-shadow:inset 0px 1px 0px 0px #ffffff;	background-color:#ededed;	-webkit-border-top-left-radius:6px;	-moz-border-radius-topleft:6px;	border-top-left-radius:6px;	-webkit-border-top-right-radius:6px;	-moz-border-radius-topright:6px;	border-top-right-radius:6px;	-webkit-border-bottom-right-radius:6px;	-moz-border-radius-bottomright:6px;	border-bottom-right-radius:6px;	-webkit-border-bottom-left-radius:6px;	-moz-border-radius-bottomleft:6px;	border-bottom-left-radius:6px;	text-indent:0;	border:1px solid #dcdcdc;	display:inline-block;	color:#777777;	font-family:Arial;	font-size:11px;	font-weight:bold;	font-style:normal;	height:20px;	line-height:20px;	width:100px;	text-decoration:none;	text-align:center;	text-shadow:1px 1px 0px #ffffff;cursor: pointer;'  onclick='saveWatchUserID(" + uid + ")' href='#' >关注这个大神</button>");
        }
    });
}
function checkUserHiddenList() {
    var storage = window.localStorage;
    //遍历并检查本地存储中是否有此用户，如果有则调用hideUser删评论
    $(".author-comment a ").each(
        function () {
            if ($(this).hasClass("name")) {
                if (checkUserHidden($(this).attr("data-uid"))) {
                    //调用方法隐藏此用户的评论
                    $(this).parent().next().empty();
                    //调用方法隐藏此用户的头像
                    $(this).parent().parent().prev().empty();
                    //调用方法隐藏此用户的ID
                    $(this).empty();
                    //调用方法隐藏操作按钮
                    $(this).parent().find(".oper").remove();
                    //调用方法添加提示
                    $(this).parent().find(".index-comment").append("<label style='color:red;'>白痴,已屏蔽！</label>");
                }
            }
        }
    );
}
function checkUserWatchList() {
    var storage = window.localStorage;
    //遍历并检查本地存储中是否有此用户，如果有则调用高亮评论
    $(".author-comment a ").each(
        function () {
            if ($(this).hasClass("name")) {
                if (checkUserWatch($(this).attr("data-uid"))) {
                    //调用方法高亮此用户的评论
                    $(this).parent().next().css("background-color", "blanchedalmond");
                }
            }
        }
    );
}
function checkUserHidden(uid) {
    var storage = window.localStorage;
    var isHidden = false;
    for (var i = 0; i < storage.length; i++) {
        if (storage.key(i) == "uid." + uid + "hide") {
            isHidden = true;
        }
        else { }
    }
    return isHidden;
}
function checkUserWatch(uid) {
    var storage = window.localStorage;
    var isWatch = false;
    for (var i = 0; i < storage.length; i++) {
        if (storage.key(i) == "uid." + uid + "watch") {
            isWatch = true;
        }
        else { }
    }
    return isWatch;
}
setTimeout(addHideButton, 3000);
setTimeout(addWatchButton, 3000);
setTimeout(checkUserHiddenList, 4000);
setTimeout(checkUserWatchList, 4000);
