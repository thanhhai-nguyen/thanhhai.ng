var c;
var firstTime = 0;
var startStateMenu = function () {
    c = sessionStorage.getItem("StateMenu");
    if (c == null) {
        c = 1;
    }
    else {
        c = parseInt(c);
    }
}
var menuToggle = function () {
    $('#mini-logo').css('width', '55px');
    $('#menu-toggle').css('left', '55px');
    $('#normal-logo').hide();
    $('#main-body-left').hide();
    $('#main-body-left-mini').show();
    $('#main-body-left-mini').css('width', '55px');
    $('#main-body-left').css('width', '55px');
    $('#main-body-right').css('left', '55px');
    leftWidth = 55;
    c = 1;
    sessionStorage.setItem("StateMenu", 0);
}
var menuShow = function () {
    $('#mini-logo').css('width', '220px');
    $('#menu-toggle').css('left', '0');
    $('#main-body-left-mini').css('width', '220px');
    $('#main-body-left-mini').hide();
    $('#normal-logo').show();
    $('#main-body-left').show();
    $('#main-body-left').css('width', '220px');
    $('#main-body-right').css('left', '0');
    leftWidth = 220;
    c = 0;
    sessionStorage.setItem("StateMenu", 1);
}
var changeStateMenu = function () {
    var rightWidth, leftWidth;
    if (c === 0) {
        menuToggle();
    }
    else if (c === 1) {
        menuShow();
    }
    rightWidth = 1345 - leftWidth;
    $('#main-body-right').css('width', rightWidth + 'px');

};
$('#menu-toggle').click(function () {
    changeStateMenu();
});
$('.closebtn').click(function () {
    $(this).parent().hide();
});
$(function () {
    $('#main-body-left').css('height', ($('#main-body-right').outerHeight() + 50) + 'px');
    $('#main-body-left-mini').css('height', ($('#main-body-right').outerHeight() + 50) + 'px');
    startStateMenu();
    changeStateMenu();
    $('#main-body-left, #main-body-left-mini, #normal-logo, #mini-logo, #main-body-right').css('transition', '0.2s all');
});