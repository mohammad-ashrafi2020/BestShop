$(function () {
    getMorris('line', 'line_chart');
    getMorris('bar', 'bar_chart');
    getMorris('area', 'area_chart');
    getMorris('donut', 'donut_chart');
});


function getMorris(type, element) {
    if (type === 'line') {
        Morris.Line({
            element: element,
            data: [{
                'period': '2017 Q3',
                'licensed': 1021,
                'sorned': 660
            }, {
                    'period': '2017 Q3',
                    'licensed': 1021,
                    'sorned': 629
                }, {
                    'period': '2016 Q1',
                    'licensed': 960,
                    'sorned': 618
                }, {
                    'period': '2015 Q4',
                    'licensed': 900,
                    'sorned': 661
                }, {
                    'period': '2014 Q4',
                    'licensed': 890,
                    'sorned': 792
                }, {
                    'period': '2013 Q1',
                    'licensed': 935,
                    'sorned': 681
                }, {
                    'period': '2012 Q4',
                    'licensed': 978,
                    'sorned': 725
                }, {
                    'period': '2011 Q4',
                    'licensed': 936,
                    'sorned': 625
                }, {
                    'period': '2010 Q2',
                    'licensed': 918,
                    'sorned': 600
                }],
            xkey: 'period',
            ykeys: ['licensed', 'sorned'],
            labels: ['Licensed', 'Off the road'],
            lineColors: ['rgb(125, 210, 61)', 'rgb(55, 150, 225)'],
            lineWidth: 3
        });
    } else if (type === 'bar') {
        Morris.Bar({
            element: element,
            data: [{
                x: '2017 Q1',
                y: 3,
                z: 2,
                a: 3
            }, {
                x: '2017 Q2',
                y: 2,
                z: 3,
                a: 1
            }, {
                x: '2017 Q3',
                y: 3,
                z: 2,
                a: 4
            }, {
                x: '2017 Q4',
                y: 2,
                z: 4,
                a: 3
            }],

            xkey: 'x',
            ykeys: ['y', 'z', 'a'],
            labels: ['Y', 'Z', 'A'],
            barColors: ['#747ace', '#4fcdff', '#fcb25d'],
        });
    } else if (type === 'area') {
        Morris.Area({
            element: element,
            data: [{
                period: '2016 Q3',
                iphone: 2666,
                ipad: 1969,
                itouch: 2647
            }, {
                    period: '2017 Q2',
                    iphone: 2778,
                    ipad: 2294,
                    itouch: 2441
                }, {
                    period: '2016 Q3',
                    iphone: 2291,
                    ipad: 1969,
                    itouch: 2501
                }, {
                    period: '2015 Q3',
                    iphone: 2361,
                    ipad: 3795,
                    itouch: 1588
                }, {
                    period: '2014 Q4',
                    iphone: 2300,
                    ipad: 3215,
                    itouch: 5175
                },{
                    period: '2013 Q4',
                    iphone: 3767,
                    ipad: 3597,
                    itouch: 5689
                }, {
                    period: '2012 Q1',
                    iphone: 2354,
                    ipad: 1914,
                    itouch: 2293
                }, {
                    period: '2011 Q2',
                    iphone: 2300,
                    ipad: 2394,
                    itouch: 2140
                }],
            xkey: 'period',
            ykeys: ['iphone', 'ipad', 'itouch'],
            labels: ['iPhone', 'iPad', 'iPod Touch'],
            pointSize: 1,
            hideHover: 'auto',
            lineColors: ['#5058ab', '#139fc0', '#02cc9a']
        });
    } else if (type === 'donut') {
        Morris.Donut({
            element: element,
            data: [{
                label: 'Jam',
                value: 25
            }, {
                    label: 'Frosted',
                    value: 40
                }, {
                    label: 'Custard',
                    value: 15
                },{
                    label: 'Jelly',
                    value: 20
                }, {
                    label: 'Sugar',
                    value: 10
                }],
            colors: ['#d4155b','#feb83f','#8ec742','#0573be','#693196'],
            formatter: function (y) {
                return y + '%'
            }
        });
    }
}