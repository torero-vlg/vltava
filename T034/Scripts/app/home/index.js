define(['layout', 'lightbox'], function (layout) {

    return {
        Initialize: function () {
            jQuery('a[rel*=lightbox_about]').lightBox();
            jQuery('a[rel*=lightbox_230217]').lightBox();
            jQuery('a[rel*=lightbox_2016]').lightBox();
            jQuery('a[rel*=octoberfest2018]').lightBox();
        }
    }
});
