//window.HeaderOver = (over) => {

//    if (over == "mouseenter") {
//        $(this).addClass('on');
//        console.log("mouseenter");
//    }
//    else if (over == "mouseleave") {
//        if ($('#menu > ul > li > a').hasClass('active')) {
//            if ($(this).find('a').siblings('ul').length > 0) {
//                $(this).addClass('on')
//            } else {
//                $(this).removeClass('on')
//            }
//        } else {
//            $(this).removeClass('on')
//        }
//        console.log("mouseleave");
//    }
//    else if (over == "mouseover") {
//        var _ths = $(this),
//            _hasChild = _ths.siblings('ul');

//        if (e.type == 'mouseover' || e.type == 'focus') {
//            $('#menu > ul > li > a').removeClass('active').find('span').stop().animate({ 'width': '0' }, 200);
//            $('#menu > ul > li > ul').stop().slideUp(200);

//            _ths.addClass('active');
//            _ths.find('span').stop().animate({ 'width': '100%' }, 200);
//            _hasChild.stop().slideDown(400);
//        } else if (e.type == 'mouseout' || e.type == 'blur') {
//            if (_hasChild.length == 0) {
//                _ths.removeClass('active');
//                _ths.find('span').stop().animate({ 'width': 0 }, 200);
//            }
//        }
//        console.log("mouseover");
//    }
//    else if (over == "click") {
//        console.log("click");
//    }
//}

var _thsW = $(window).width(),
    _juice = false;
//console.log(_thsW);
$(function () {
    console.log("2022-");
    $('#test').on("click", function () {
        $('#header').prepend('<span class="sub_bg"></span>');
        console.log("click");
    });
    if (_thsW > 1024) { // pc size
        $(function () {
            $('#header').prepend('<span class="sub_bg"></span>');
            console.log($('#header').prepend('<span class="sub_bg"></span>'));
            $('#header').addClass('text');

            $('#header').on('mouseenter', function () {
                $(this).addClass('on')
            })
            $('#header').on('mouseleave', function () {
                console.log("2022-mouseleave");
                if ($('#menu > ul > li > a').hasClass('active')) {
                    if ($(this).find('a').siblings('ul').length > 0) {
                        $(this).addClass('on')
                    } else {
                        $(this).removeClass('on')
                    }
                } else {
                    $(this).removeClass('on')
                }
            })

            $('#menu > ul > li > a').prepend('<span></span>')
            $('#menu > ul > li > a').on('mouseover focus mouseout blur', function (e) {
                var _ths = $(this),
                    _hasChild = _ths.siblings('ul');

                if (e.type == 'mouseover' || e.type == 'focus') {
                    $('#menu > ul > li > a').removeClass('active').find('span').stop().animate({ 'width': '0' }, 200);
                    $('#menu > ul > li > ul').stop().slideUp(200);

                    _ths.addClass('active');
                    _ths.find('span').stop().animate({ 'width': '100%' }, 200);
                    _hasChild.stop().slideDown(400);
                } else if (e.type == 'mouseout' || e.type == 'blur') {
                    if (_hasChild.length == 0) {
                        _ths.removeClass('active');
                        _ths.find('span').stop().animate({ 'width': 0 }, 200);
                    }
                }
            });
            $('#menu > ul > li > ul').mouseleave(function () {
                $('#menu > ul > li > a').removeClass('active').find('span').stop().animate({ 'width': '0' }, 200);
                $('#menu > ul > li > ul').stop().slideUp(200);
            });

            $('#menu > ul > li').on('mouseenter mouseleave', function (e) {
                if (e.type == 'mouseenter') {
                    if ($(this).find('a').siblings('ul').length > 0) {
                        $('#header .sub_bg').stop().animate({ 'opacity': '1' }, 50);
                    } else {
                        $('#header .sub_bg').stop().animate({ 'opacity': '0' }, 50);
                    }
                } else if (e.type == 'mouseleave') {
                    $('#header .sub_bg').stop().animate({ 'opacity': '0' }, 50);

                    if ($('#menu > ul > li > a').hasClass('active')) {
                        if ($(this).find('a').siblings('ul').length > 0) {
                            $('#header .sub_bg').stop().animate({ 'opacity': '1' }, 50);
                        } else {
                            $('#header .sub_bg').stop().animate({ 'opacity': '0' }, 50);
                        }
                    } else {
                        $('#header .sub_bg').stop().animate({ 'opacity': '0' }, 50);
                    }

                }
            })

            // $('#menu > ul > li > a').on('focus blur', function () {
            //     if (e.type == 'focus') {
            //         if($(this).find('a').siblings('ul').length > 0){
            //             $('#header .sub_bg').stop().animate({ 'opacity': '1' }, 50);
            //         }
            //     } else if (e.type == 'blur') {
            //         $('#header .sub_bg').stop().animate({ 'opacity': '0' }, 50);
            //     }
            // })
        });
    } else { // mobile size
        // open menu btn
        // $('.menuToggle').click(function(){
        //     $(this).blur();
        //     $('.menu_effect').slideToggle(50);
        //     $('header').toggleClass('active');
        // });

        // // menu mobile
        // $('#header nav > ul > li > a').not('.both').click(function(e){
        //     if(_thsW > 1024){
        //         return true;
        //     }

        //     e.preventDefault();
        //     $('#header nav > ul > li').removeClass('on');
        //     $('#header nav > ul > li > ul').hide();
        //     $(this).siblings('ul').show();
        //     $(this).closest('li').addClass('on');
        // });

        // $('#header nav > ul > li > ul > li > a').click(function(e){
        //     var thsTxt = $(this).text();

        //     if(thsTxt == 'HISTORY'){
        //         console.log(thsTxt)
        //         if(_thsW > 1024){
        //             return true;
        //         }
        //         e.preventDefault();
        //     }
        // });

        // $('#header nav > ul > li > ul > li > a').click(function(e){
        //     $(this).closest('li').siblings('li').removeClass('on');
        //     $(this).closest('li').siblings('li').find('ul').slideUp(200);
        //     $(this).siblings('ul').slideToggle(200);
        //     $(this).closest('li').toggleClass('on');
        // });
    }
});
$(window).resize(function () {
    _thsW = $(window).width();
});

window.ContainerChange = function (page) {
    var cls = "";
    switch (page) {
        case 'history':
            cls = "";
            break;
        case 'trophy':
            cls = "shop";
            break;
        default:
            cls = "";
            break;
    }
    console.log(cls);
    $("#container").addClass(cls);
};