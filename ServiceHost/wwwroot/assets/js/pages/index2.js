$(function () {
    "use strict";  
    initSparkline();  
    MorrisArea();
});

function MorrisArea() {
    Morris.Area({
        element: 'area_chart',
        data: [{
                period: '2011',
                Project1: 0,
                Project2: 0,
                Project3: 15
            }, {
                period: '2012',
                Project1: 50,
                Project2: 15,
                Project3: 5
            }, {
                period: '2013',
                Project1: 10,
                Project2: 50,
                Project3: 23
            }, {
                period: '2014',
                Project1: 45,
                Project2: 12,
                Project3: 2
            }, {
                period: '2015',
                Project1: 20,
                Project2: 12,
                Project3: 55
            }, {
                period: '2016',
                Project1: 39,
                Project2: 67,
                Project3: 20
            }, {
                period: '2017',
                Project1: 20,
                Project2: 9,
                Project3: 5
            }

        ],
        lineColors: ['#868bef', '#19a1b7', '#febf0f'],
        xkey: 'period',
        ykeys: ['Project1', 'Project2', 'Project3'],
        labels: ['Project1', 'Project2', 'Project3'],
        pointSize: 0,
        lineWidth: 0,
        resize: true,
        fillOpacity: 0.8,
        behaveLikeLine: true,
        gridLineColor: '#e3e5e7',
        hideHover: 'auto'
    });
}

//======
function initSparkline() {
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });
}

//=====
$(window).on('scroll',function() {
    $('.card .sparkline').each(function(){
    var imagePos = $(this).offset().top;

    var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow+400) {
            $(this).addClass("pullUp");
        }
    });
});

