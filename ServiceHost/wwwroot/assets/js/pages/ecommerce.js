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
        lineColors: ['#86f0ff', '#a17fdf', '#ffcf4e'],
        xkey: 'period',
        ykeys: ['Project1', 'Project2', 'Project3'],
        labels: ['Project1', 'Project2', 'Project3'],
        pointSize: 2,
        lineWidth: 1,
        resize: true,
        fillOpacity: 0.5,
        behaveLikeLine: true,
        gridLineColor: '#e3e5e7',
        hideHover: 'auto'
    });
}
//=====
function initSparkline() {
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });
}
//=====
$(function () {
    $('#world-map-markers').vectorMap({
        map : 'world_mill_en',
        scaleColors : ['#ea6c9c', '#ea6c9c'],
        normalizeFunction : 'polynomial',
        hoverOpacity : 0.7,
        hoverColor : false,
        regionStyle : {
            initial : {
                fill : '#e0e0e0'
            }
        },
         markerStyle: {
            initial: {
                r: 15,
                'fill': '#ffd560',
                'fill-opacity': 0.9,
                'stroke': '#fff',
                'stroke-width' : 5,
                'stroke-opacity': 0.5
            },

            hover: {
                'stroke': '#fff',
                'fill-opacity': 1,
                'stroke-width': 5
            }
        },
        backgroundColor : 'transparent',
        markers: [
            { latLng: [37.09,-95.71], name: 'America' },
            { latLng: [51.16,10.45], name: 'Germany' },
            { latLng: [-25.27, 133.77], name: 'Australia' },
            { latLng: [56.13,-106.34], name: 'Canada' },
            { latLng: [20.59,78.96], name: 'India' },
            { latLng: [55.37,-3.43], name: 'United Kingdom' },
        ]
    });
});