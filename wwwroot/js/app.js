(function (path) {
    document.__proto__.nz = {
        openMenu: function (erm) {
            $(erm).addClass("menu-open");
            return this;
        },
        activeMenu: function (erm) {
            $(erm).addClass("active");
            return this;
        }
    }

    var obj = {
        requests: function (url, type, callbackfn = () => { return; }, async = true) {
            $.ajax({
                url: url,
                type: type,
                dataType: 'json',
                async: async,
                success: function (response) {
                    callbackfn(response);
                },
                error: function () { },
                failure: function () { }
            });
            return this;
        },
        renDerLanguage: function (path) {
            var path = path.split('/');
            path = `~/language/th-en/${path[path.length - 1].toLowerCase()}.json`;
            this.requests('/Language/language', 'POST', function (res) {
                //สร้าง Object จาก Class
                var objtranslate = new Translate();
                if (res == "0") {
                    objtranslate.data("/language/th-en/menu.json", "th", objtranslate.translateLG);
                    objtranslate.data(path, "th", objtranslate.translateLG);
                } else {
                    objtranslate.data("/language/th-en/menu.json", "en", objtranslate.translateLG);
                    objtranslate.data(path, "en", objtranslate.translateLG);
                }
            })
            return this;
        },
        renDerUserName: function () {
            this.requests('/User/GetUserName', 'POST', function (res) {
                document.getElementById('username').innerText = res;
            });
            return this;
        },
        initializeSelect2: function () {
            //Initialize Select2 Elements
            $('.select2bs4').select2({
                theme: 'bootstrap4'
            });
            return this;
        }
    }

    obj.renDerLanguage(path).renDerUserName().initializeSelect2();
}(document.location.pathname));