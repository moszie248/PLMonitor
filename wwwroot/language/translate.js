//Syntex create Class javascript ES5
var Translate = (function () {
    //constructor
    function Translate() {}

    //Method
    Translate.prototype.data = function (url, lang, callbackfn) {
        try {
            $.ajax({
                url: url,
                type: 'get',
                dataType: 'json',
                data: '',
                async: false,
                success: function (response) {
                    if (typeof (response) == "object") {
                        callbackfn(response[lang]);
                    } else {
                        var obj = JSON.parse(response);
                        callbackfn(obj[lang]);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {},
                failure: function (fail) {}
            });
        } catch (error) {
            console.log(error)
        }
    };

    //Method
    Translate.prototype.translateLG = function (data) {
        try {
            var getkey = Object.keys(data);
            var getvalue = Object.values(data);

            for (var i = 0; i < getkey.length; i++) {
                var erm = document.querySelectorAll("." + getkey[i])[0];
                var tagName = erm.tagName.toUpperCase();

                if (tagName == "INPUT") {
                    if (erm.placeholder != "") {
                        erm.attributes.placeholder.value = getvalue[i];
                    } else {
                        erm.value = getvalue[i];
                    }
                } else {
                    erm.innerText = getvalue[i];
                }
            }
        } catch (error) {
            console.log(error)
        }
    }

    return Translate;
}());