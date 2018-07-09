var Loader = {
    //https://www.jqueryscript.net/loading/Elegant-Loading-Indicator-jQuery-Preloader.html
    AdicionaLoaderParaElemento : function ($elemento) {
        if (typeof $elemento !== "undefined") {
            $elemento.preloader();
        }
    },
    RemoveLoaderDeElemento : function ($elemento) {
        if (typeof $elemento !== "undefined") {
            $elemento.preloader('remove');
        }
    }
};