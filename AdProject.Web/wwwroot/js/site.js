var vue = require("vue");
var vue_resource = require("vue-resource");

vue.use(vue_resource);

new vue({
    el: '#test',
    mounted: function ()
    {
        alert('testando');
    }
});

