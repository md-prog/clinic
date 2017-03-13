import Vue from 'vue';
import axios from 'axios'

Vue.mixin({
    data: function() {
        return{
            genes: []
        };
    },
    methods:{
        getGenes: function()
        {
            var vm = this;
            axios.get('https://civic.genome.wustl.edu/api/genes?count=300').then(function (response) {
                vm.$set(vm, 'genes', response.data.records.map(function (g) {
                    return g.variants.map(function (v) {
                        return {id: v.id, name: g.name + ' - ' + v.name};
                    })
                }).reduce(function (a, b) { return a.concat(b); }));
            });
        }
    }
});