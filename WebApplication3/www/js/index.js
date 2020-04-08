function nav_custom(name, classname) {
    $('.' + name + 'li').click(function () {
        $('.' + name + 'li').find('a').removeClass(classname);
        $(this).find('a').addClass(classname);
    })
}
$(function () {
    nav_custom('main-hot-nav ', 'main-hot-nav-selected');
    nav_custom('main-selected-nav ', 'main-hot-nav-selected');
    $('.main-modular-buttom1 li p').click(function () {
        $('.main-modular-buttom1 li').find('p').removeClass('main-modular-buttom-click');
        $('.main-modular-buttom1 li').find('ul').removeClass('main-modular-selected');
        $(this).addClass('main-modular-buttom-click');
        $(this).parent().find('ul').addClass('main-modular-selected');

    })
})
