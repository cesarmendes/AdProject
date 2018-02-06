import Vue from 'vue'
import Resource from 'vue-resource'

Vue.use(Resource);

new Vue({
    el: '#app',
    data: {
        titulo: 'Esse é o título',
        html: '<a href"#">Esse é um link</a>',
        registros: [
            { titulo: 'Título 1', descricao: 'Descrição 1', link: 'link1', valor: 15.123456 },
            { titulo: 'Título 1', descricao: 'Descrição 1', link: 'link1', valor: 25.123456 },
            { titulo: 'Título 1', descricao: 'Descrição 1', link: 'link1', valor: 35.123456 }
        ]
    },
    filters: {
        trataValor: function (valor) {
            return ('R$' + (valor).toFixed(2)).replace('.', ',');
        }

    }

});





