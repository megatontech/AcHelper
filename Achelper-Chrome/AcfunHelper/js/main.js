(function () {
    var head = document.getElementsByTagName('head')[0];
    if (head && window.location.href.lastIndexOf("acfun") > 0) {
        var scripthelper = document.createElement('script');
        scripthelper.type = 'text/javascript';
        scripthelper.src = chrome.extension.getURL('js/commentfilter.js');
        head.appendChild(scripthelper);
        var scriptpagehelper = document.createElement('script');
        scriptpagehelper.type = 'text/javascript';
        scriptpagehelper.src = chrome.extension.getURL('js/pagefilter.js');
        head.appendChild(scriptpagehelper);
        var styleHelper = document.createElement('link');
        styleHelper.rel = "stylesheet";
        styleHelper.href = chrome.extension.getURL('css/helper.css');
        head.appendChild(styleHelper);
    }
})();