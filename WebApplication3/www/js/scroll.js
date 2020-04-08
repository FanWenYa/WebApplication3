$(window).resize(function () {
    var bodywidth = $(document.body).outerWidth(true);
    if (bodywidth < 1500) {
        bodywidth = 1500;
    }
    $('.scroll-box').css({
        width: bodywidth
    });
    $('.scroll-box-img').css({
        'width': bodywidth * 4,
        'margin-left': -bodywidth
    });
    $('.scroll-box .scroll-box-img img').css({
        'width': bodywidth
    });
    var Imgheight = $('.scroll-box .scroll-box-img img').height();
    $('.scroll-box').css({
        height: Imgheight
    });
});
$(document).ready(function () {
    var bodywidth = $(document.body).outerWidth(true);
    if (bodywidth < 1500) {
        bodywidth = 1500;
    }
    $('.scroll-box').css({
        width: bodywidth
    });
    $('.scroll-box-img').css({
        'width': bodywidth * 4,
        'margin-left': -bodywidth
    });
    $('.scroll-box .scroll-box-img img').css({
        'width': bodywidth
    });
    var Imgheight = $('.scroll-box .scroll-box-img img').height();
    $('.scroll-box').css({
        height: Imgheight
    });
});


//boxname父级元素classname  speed滚动速度 interval滚动时间
function Scroll(boxname, speed, interval) {
    //boxname父级元素classname  speed滚动速度 interval滚动时间
    //children返回被选元素的所有直接子元素
    //box为滚动模块的父级
    var box = $('.' + boxname),
        //boximg为滚动模块里图片模块的父级
        boximg = box.children(".scroll-box-img"),
        //img为滚动模块图片模块的子级
        img = boximg.children("img"),
        //btnbox为滚动模块里小圆点控件的父级
        btnbox = box.children('.button-box'),
        //btn为滚动模块里小圆点控件的子级
        btn = btnbox.children('span'),
        //btnrg为滚动模块里向右滚动控件
        btnrg = box.children('.scroll-box-btnrg'),
        //btnlf为滚动模块里向左滚动控件
        btnlf = box.children('.scroll-box-btnlf'),
        //width为每张图片的宽度
        width = img.width(),
        //变量i
        i = 0,
        //小圆点控件子级的数量
        l = btn.length,
        IsOver = false;
    $(function () {
        width = img.width();
    })
    $(window).resize(function () {
        width = img.width();
    })
    //轮播
    function scroll() {
        //boximg向左滚动一个图片的宽度
        boximg.animate({ left: -width }, speed, function () {
            //获取boximg的子级元素img的第一项添加到boximg子级的末尾   ??:first 子元素的第一个元素 appendTo 向所选元素末尾添加
            boximg.children("img:first").appendTo(boximg)
            //boximg的left回到0
            boximg.css({ left: 0 })
        })
        //i的变量 用于控制小圆点控件的Class
        i += 1;
        //判断i的值是否超出btn的数量
        if (i >= l) {
            //如果超出i变量重置
            i = 0;
        }
        //向btn的第i个添加类名为buttons1的类 清除i以外的所以buttons1的类
        btnbox.children('span').eq(i).addClass('buttons1').siblings('.buttons1').removeClass('buttons1');
    }
    //计时器 实现滚动效果 当鼠标移入时停止计时器  移出时启动计时器
    var t;
    t = setInterval(scroll, interval)

    box.hover(function () {
        //当鼠标移入时停止计时器 
        clearInterval(t);
    }, function () {
        //移出时启动计时器
        t = setInterval(scroll, interval)
    })
    //轮播
    //按钮控制想左滚动
    btnrg.click(function () {
        //boximg向左滚动一个图片的宽度
        boximg.animate({ left: -width }, speed, function () {
            //获取boximg的子级元素img的第一项添加到boximg子级的末尾   ??:first 子元素的第一个元素 appendTo 向所选元素末尾添加
            boximg.children("img:first").appendTo($(".scroll-box .scroll-box-img"))
            //boximg的left回到0
            boximg.css({ left: 0 })
        })
        //i的变量 用于控制小圆点控件的Class
        i += 1;
        //判断i的值是否超出btn的数量
        if (i >= l) {
            //如果超出i变量重置
            i = 0;
        }
        //向btn的第i个添加类名为buttons1的类 清除i以外的所以buttons1的类
        btnbox.children('span').eq(i).addClass('buttons1').siblings('.buttons1').removeClass('buttons1');
    })
    //按钮控制想左滚动
    //按钮控制想右滚动
    btnlf.click(function () {
        //boximg向右滚动一个图片的宽度
        boximg.animate({ left: width }, speed, function () {
            //获取boximg的子级元素img的最后一项添加到boximg子级的开头   ??:last 子元素的最后一个元素 prependTo 向所选元素开头添加
            boximg.children("img:last").prependTo($(".scroll-box .scroll-box-img"));
            //boximg的left回到0
            boximg.css({ left: 0 })
        })
        //i的变量 用于控制小圆点控件的Class
        i -= 1;
        //判断i的值是否小于0
        if (i < 0) {
            //如果小于i的值等于l - 1  当i<0时 选中的小圆点子级从负一项变成最后一项 实现循环
            i = l - 1;
        }
        //向btn的第i个添加类名为buttons1的类 清除i以外的所有buttons1的类
        btnbox.children('span').eq(i).addClass('buttons1').siblings('.buttons1').removeClass('buttons1');
    })
    //按钮控制想右滚动
    //小圆圈点击控件
    btnbox.children('span').click(function () {
        //获取所选元素相对于其同胞元素的 index 位置  index(??) 获得选中元素相对于其同胞元素的 index 位置
        var index = btn.index(this);
        //所选元素添加名为buttons1的类 清楚所选元素外其他同级元素的buttons1类
        $(this).addClass('buttons1').siblings('.buttons1').removeClass('buttons1');
        //如果所选元素的位置大于等于当前元素的位置时
        if (index >= i) {
            if (IsOver) return;
            //变量di所选元素与当前元素相差的个数
            var dif = index - i,
                //变量left所选元素与当前元素相差的距离
                left = -dif * width;
            //向左移动所选元素与当前元素的距离
            boximg.animate({ left: left }, speed, function () {
                //left回到O
                boximg.css("left", 0);
                //获取boximg的子级img的前几个元素添加到boximg子级的后面
                boximg.children("img:lt(" + dif + ")").appendTo('.scroll-box-img');
            });
            IsOver = false;
        }
            //如果所选元素的位置小于当前元素的位置
        else {
            if (IsOver) return;
            IsOver = true;
            //变量j计算出所选元素之前的个数
            var j = l - (i - index);
            //向左移动所选元素与当前元素的距离
            boximg.css("left", (index - i) * width);
            //获取boximg的子级img的前几个元素添加到boximg子级的后面
            boximg.children("img:lt(" + j + ")").appendTo('.scroll-box-img');
            //left回到O
            boximg.animate({ left: 0 }, speed, function () {
            });
            IsOver = false;
        }
        //i的值变成所选元素位置的值
        i = index;
    })
    //小圆圈点击控件
}

$(function () {       //读取轮播事件
    //类名 速度 时间
    Scroll('scroll-box', 600, 6000);
});