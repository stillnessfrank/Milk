(function ($) {
  
    //Notification handler
    abp.event.on('abp.notifications.received', function (userNotification) {
        abp.notifications.showUiNotifyForUserNotification(userNotification);
    });

    //serializeFormToObject plugin for jQuery
    $.fn.serializeFormToObject = function () {
        //serialize to array
        var data = $(this).serializeArray();
        //add also disabled items
        $(':disabled[name]', this).each(function () {
            data.push({ name: this.name, value: $(this).val() });
        });

        //add checkbox items
        $('input[type="checkbox"]', this).each(function () {
            if ($(this).is(':checked')) 
                data.push({ name: this.name, value: true });
            else
                data.push({ name: this.name, value: false });
        });

        //map to object
        var obj = {};
        data.map(function (x) { obj[x.name] = x.value; });

        return obj;
    };

    //Configure blockUI
    if ($.blockUI) {
        $.blockUI.defaults.baseZ = 2000;
    }

    $.validator.addMethod("checkOnly", function (value, element) {
        if (value != "") {
            var flag = false;
            var input = { "CustomFldId": element.name, "Value": value };
            _cutomTblService.getVerification(input,{ async: false }).done(function (data) {
                flag = data
            });
            if (flag ==true)
                return true;
            else
                return false;
        }
        else
            return true;
        //return this.optional(element) || /^90[2-5]\d\{2\}-\d{4}$/.test(value);
    }, "列表中已存在此项值");
    //自定义验证
    $.validator.addMethod("checksuffx", function (value, element, param) {
        if (param.length > 0) {
            var fileType = value.substring(value.lastIndexOf(".") + 1).toLowerCase();
            return this.optional(element) || $.inArray(fileType, param) != -1;
        }
        else
            return true;
    }, "后缀不符合");

    $.validator.addMethod("checkPicSize", function (value, element) {
        var fileSize = $(element).nextAll("[type=file]")[0].files[0].size;
        var maxSize = 104857600; //100M
        if (fileSize > maxSize) {
            return false;
        } else {
            return true;
        }
    }, "请上传大小在100M以内的文件");
})(jQuery);