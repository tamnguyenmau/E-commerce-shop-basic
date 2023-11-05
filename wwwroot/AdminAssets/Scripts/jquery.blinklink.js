(function ($) {
    jQuery.fn.blinklink = function (settings) {
        var config = {
            colorOne    : "red",
            colorTwo    : "green",
            colorThree  : "blue",
            colorLast   : ""
        };
        if (settings) jQuery.extend(config, settings);
        this.each(function () {
            // Nội dung xử lý
            //Lưu giá trị màu ban đầu
            var color = $(this).css("color");
            $(this).attr("data-color", color);

            //Xử lý nhấp nháy khi rê chuột lên
            $(this).mouseenter(function () {
                var myLink = $(this);
                setTimeout(function () {
                    myLink.css("color", config.colorOne);
                }, 200);

                setTimeout(function () {
                    myLink.css("color", config.colorTwo);
                }, 400);

                setTimeout(function () {
                    myLink.css("color", config.colorThree);
                }, 600);

                setTimeout(function () {
                    if (config.colorLast == "") {
                        myLink.css("color", color);
                    }
                    else {
                        myLink.css("color", config.colorLast);
                    }
                }, 800);
            });
        });
        return this;
    };
})(jQuery);
//Demo sử dụng Plugin --> Nên đặt tại những trang cần sử dụng plugin này
$(function () {
    $(".blink-link").blinklink({
        colorOne    : "red",
        colorTwo    : "green",
        colorThree  : "blue"
    })
});