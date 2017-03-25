<template>

    <multiselect id="geneSelect"
                 track-by="id" label="name"
                 placeholder="Select one or more" :options="genes" :searchable="true"
                 :multiple="true" :allow-empty="true"
                 v-bind:value="prop_value"
                 v-on:changed="genesChanged">
    </multiselect>

</template>

<script>
    import Multiselect from 'vue-multiselect';
    import axios from 'axios';

    module.exports =
    {
        name: "CivicGeneSelection",
        components: {
            Multiselect
        },
        props: {
            prop_value: Array,
            prop_id: String,
            prop_genes: Array
        },
        data: function ()
        {
            return {
                genes: []
            };
        },
        created: function()
        {
            this.checkGenes();
        },
        methods:
        {
            genesRetrieved: function(genes){ //allow parent to cache genes //have to consider using a plugin vuex store or similar so a plugin can access global data
                this.$emit('genesRetrieved', genes);
            },
            genesChanged: function(newValue, id)
            {
                this.$emit('genesChanged', newValue, this.id);
            },
            checkGenes: function(){
                var vm = this;
                if(vm.prop_genes.length > 0)
                    vm.$set(vm, 'genes', vm.prop_genes);
                else if(vm.genes.length < 1)
                    vm.getGenes();
            },
            getGenes: function()
            {
                var vm = this;
                axios.get('https://civic.genome.wustl.edu/api/genes?count=300').then(function (response) {
                    var genes = response.data.records.map(function (g) {
                        return g.variants.map(function (v) {
                            return {id: v.id, name: g.name + ' - ' + v.name};
                        });
                    }).reduce(function (a, b) { return a.concat(b); })
                    vm.$set(vm, 'genes', genes);
                    vm.genesRetrieved(genes);
                });
            }
        }
    };
</script>