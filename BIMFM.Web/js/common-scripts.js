$(function () {
    loadresponsiveView();
    sidebarToggle();
    sidebardropdownmenu();
    // custom scrollbar
    $("#sidebar").niceScroll({ styler: "fb", cursorcolor: "#e8403f", cursorwidth: '3', cursorborderradius: '10px', background: '#404040', cursorborder: '' });
    $("html").niceScroll({ styler: "fb", cursorcolor: "#e8403f", cursorwidth: '6', cursorborderradius: '10px', background: '#404040', cursorborder: '', zindex: '1000' });

    //tool tips
    $('.tooltips').tooltip();

});
//responsiveView
function loadresponsiveView() {
    $(window).on('load', responsiveView);
    $(window).on('resize', responsiveView);
}
function responsiveView() {
    var wSize = $(window).width();
    if (wSize <= 768) {
        $('#container').addClass('sidebar-close');
        $('#sidebar > ul').hide();
        //设计宽度


    }

    if (wSize > 768) {
        $('#container').removeClass('sidebar-close');
        $('#sidebar > ul').show();
    }

}
//sidebarToggle
function sidebarToggle() {
    $('.logofa').click(function () {
        if ($('#sidebar > ul').is(":visible") === true) {
            $('#main-content').css({
                'margin-left': '0px'
            });
            $('#sidebar').css({
                'margin-left': '-230px'
            });
            $('#sidebar > ul').hide();
            $("#container").addClass("sidebar-closed");
        } else {
            $('#main-content').css({
                'margin-left': '230px'
            });
            $('#sidebar > ul').show();
            $('#sidebar').css({
                'margin-left': '0'
            });
            $("#container").removeClass("sidebar-closed");
        }

        if (typeof(myLayout) != "undefined")
            myLayout.resizeAll();
        if (typeof (RoomList) != "undefined")
            RoomList.api().draw();
        if (typeof (EqList) != "undefined")
            EqList.api().draw();
        if (typeof (chart1) != "undefined")
            chart1.reflow();
        if (typeof (chart6) != "undefined")
            chart6.reflow();

    });
}
//sidebar dropdown menu
function sidebardropdownmenu() {
    //var CURRENT_URL = window.location.href.split('#')[0].split('?')[0].replace("http://" + window.location.host, "");
    //var $sidebarmenu = $('#sidebar-menu').find('a[href="' + CURRENT_URL + '"]')
    //$sidebarmenu.parent('li').addClass('active');
    //$sidebarmenu.parent().parent().parent("li").addClass('active');


    $('#sidebar .sub-menu > a').click(function () {
        var last = $('.sub-menu.open', $('#sidebar'));
        last.removeClass("open");
        $('.arrow', last).removeClass("open");
        $('.sub', last).slideUp(200);
        var sub = jQuery(this).next();
        if (sub.is(":visible")) {
            $('.arrow', $(this)).removeClass("open");
            $(this).parent().removeClass("open");
            sub.slideUp(200);
        } else {
            $('.arrow', $(this)).addClass("open");
            $(this).parent().addClass("open");
            sub.slideDown(200);
        }
    });
}




