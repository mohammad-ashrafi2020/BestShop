$(function () {
    "use strict";  
    initSparkline();
    initDonutChart();
    getMorris('line', 'line_chart');
});


function getMorris(type, element) {
    
    if (type === 'line') {
        Morris.Line({
            element: element,
            data: [{
                'period': '2017 Q5',
                'Technology': 2310,
                'Lifestyle': 458,
                'Sports': 951
            }, {
                    'period': '2017 Q5',
                    'Technology': 2310,
                    'Lifestyle': 458,
                    'Sports': 951
                }, {
                    'period': '2016 Q4',
                    'Technology': 960,
                    'Lifestyle': 1260,
                    'Sports': 89
                }, {
                    'period': '2015 Q3',
                    'Technology': 898,
                    'Lifestyle': 145,
                    'Sports': 329
                }, {
                    'period': '2014 Q2',
                    'Technology': 564,
                    'Lifestyle': 230,
                    'Sports': 911
                },{
                    'period': '2013 Q1',
                    'Technology': 918,
                    'Lifestyle': 600,
                    'Sports': 813
                }],
            xkey: 'period',
            ykeys: ['Technology', 'Lifestyle', 'Sports'],
            labels: ['Technology', 'Lifestyle', 'Sports'],
            lineColors: ['#12a682', '#f58787', '#00adef'],
            lineWidth: 2,
            gridLineColor: '#e3e5e7',
        });
    }
}
//=======
function initSparkline() {
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });
}
//======
function initDonutChart() {
    Morris.Donut({
        element: 'donut_chart',
        data: [{
            label: 'Chrome',
            value: 30
        }, {
            label: 'Firefox',
            value: 25
        }, {
            label: 'Safari',
            value: 20
        }, {
            label: 'Opera',
            value: 10        
        }, {
            label: 'IE',
            value: 10
        },{
            label: 'Other',
            value: 5
        }],
        colors: ['#00adef', '#fcb711', '#12a682', '#f58787', '#708090', '#ec3b57 '],
        formatter: function (y) {
            return y + '%'
        }
    });
}
//======
var data = [], totalPoints = 110;
function getRandomData() {
    if (data.length > 0) data = data.slice(1);

    while (data.length < totalPoints) {
        var prev = data.length > 0 ? data[data.length - 1] : 50, y = prev + Math.random() * 10 - 5;
        if (y < 0) { y = 0; } else if (y > 100) { y = 100; }

        data.push(y);
    }

    var res = [];
    for (var i = 0; i < data.length; ++i) {
        res.push([i, data[i]]);
    }

    return res;
}

//========
$(window).scroll(function() {
    $('.card .sparkline').each(function(){
    var imagePos = $(this).offset().top;

    var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow+400) {
            $(this).addClass("pullUp");
        }
    });
});
//=========
$(".dial1").knob();
$({animatedVal: 0}).animate({animatedVal: 66}, {
    duration: 3000,
    easing: "swing", 
    step: function() { 
        $(".dial1").val(Math.ceil(this.animatedVal)).trigger("change"); 
    }
});
$(".dial2").knob();
$({animatedVal: 0}).animate({animatedVal: 26}, {
    duration: 3800,
    easing: "swing", 
    step: function() { 
        $(".dial2").val(Math.ceil(this.animatedVal)).trigger("change"); 
    }
});
$(".dial3").knob();
$({animatedVal: 0}).animate({animatedVal: 76}, {
    duration: 3200,
    easing: "swing", 
    step: function() { 
        $(".dial3").val(Math.ceil(this.animatedVal)).trigger("change"); 
    }
});
$(".dial4").knob();
$({animatedVal: 0}).animate({animatedVal: 88}, {
    duration: 3500,
    easing: "swing", 
    step: function() { 
        $(".dial4").val(Math.ceil(this.animatedVal)).trigger("change"); 
    }
});