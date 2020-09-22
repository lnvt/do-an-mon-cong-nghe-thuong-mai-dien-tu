$(function () {
    $('.noidungcanhbao').slideUp();
    $('.canhbao h3').click(function(event) {
        console.log('Đã click!');
        $('.noidungcanhbao').slideToggle();
        $(this).toggleClass('xanh');
    });
});