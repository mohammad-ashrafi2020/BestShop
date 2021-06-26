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