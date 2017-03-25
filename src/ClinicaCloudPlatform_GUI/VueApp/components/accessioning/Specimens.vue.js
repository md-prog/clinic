
    import specimenData from './Specimens.vue.data.js';

    import CivicGeneSelectionPlugin from '../plugins/externaldata/CivicGeneSelection.vue';

    import Multiselect from 'vue-multiselect';
    import axios from 'axios';
    import debounce from 'lodash/debounce';

    import customDataHelpersMixin from '../../mixins/customDataHelpers.js';

const uuidV1 = require('uuid/v1');

module.exports =
{
    name: "Specimens",
    components: {
        Multiselect,
        CivicGeneSelectionPlugin
    },
    mixins: [
        customDataHelpersMixin
    ],
    props: {
        specimens: Array,
        organization: Object
    },
    data: function ()
    {
        return {
            specimensState: specimenData.specimensState,
            civicGenesCache: []
        };
    },
    computed:
        {
            currentSpecimen:{
                get: function(){
                    var vm = this;
                    var spec = null;
                    if(vm.specimensState.editingSpecimenGuid === '' || vm.specimensState.editingSpecimenGuid === null)
                        return spec;
                    spec = vm.specimens.find(function(s){
                        return s.guid === vm.specimensState.editingSpecimenGuid;
                    });
                    if(typeof spec !== 'undefined')
                    {
                        var cD = new Date(spec.collectionDate);
                        //function... filter?
                        spec.collectionDate = this.$options.filters.MMDDYYYYhhmm(spec.collectionDate);
                    }
                    return spec;
                },
                set: function(value)
                {
                    var vm = this;
                    var index = vm.specimens.findIndex(function(s){
                        return s.guid = value.guid;
                    });
                    value.collectionDate = new Date(value.collectionDate).toJSON();
                    vm.specimens.$set(index, value);
                }
            },
        },
    beforeMount: function() {

    },
    mounted: function(){
        this.toolTips();
    },

    methods:{

        //not working!
        toolTips: function() {this.$nextTick(function(){$('[data-toggle="tooltip"]').tooltip();});},

        //component event
        changed: function() {this.$emit('changed', this.specimens);},

        //have to consider using a plugin vuex store or similar so a plugin can access global data
        cacheCivicGenes: function(genes) {
            var vm = this;
            vm.$set(vm, 'civicGenesCache', genes);
        },

        currentSpecimenTypeTransportChanged: function(){
            var spec = this.currentSpecimen;
            var type = this.organizationSpecimenTypes.find(function(t){return t.code === spec.type.code;});
            var transport = this.getSpecimenTransports(type.code).find(function(t){return t.code === spec.transport.code;});
            if(transport === null)
                spec.code = type.code;
            else
                spec.code = type.code + '-' + transport.code;
        },

        addSpecimen: function(type){
            var newSpec = {
                guid: uuidV1(),
                id: -1,
                parentSpecimenGuid: '00000000-0000-0000-0000-000000000000',
                type: {type: type.type, code: type.code},
                code: type.code, //temp
                transport: {name: null, code: null},
                externalSpecimenID: null,
                customData: {},
                collectionDate: new Date((new Date()-1)).toJSON(),
                receivedDate: new Date().toJSON(),
                category: null
                //attributesAreSet: false
            }

            this.setSpecimenAttributes(newSpec);

            this.specimens.push(newSpec);

            this.$set(this.specimensState, 'editingSpecimenGuid', newSpec.guid);

            this.$nextTick(function() {
                this.setExpandedSpecimen(true);
            });
        },

        copySpecimenFromPrevious: function(specimen){

        },

        specimenClicked: function(specimen){
            var expand = false;
            if(specimen.guid === this.specimensState.editingSpecimenGuid){
                this.$set(this.specimensState, 'editingSpecimenGuid', '');
            }
            else{
                this.$set(this.specimensState, 'editingSpecimenGuid', specimen.guid);
                this.setSpecimenAttributes(specimen);
                expand = true;
            }
            this.$nextTick(function() {
                this.setExpandedSpecimen(expand);}
                );
        },

        setExpandedSpecimen: function(expandCurrent){
            var vm = this;
            this.specimens.forEach(function(s){
                var specCollapse = $('#collapse'+s.guid);
                var isShown = specCollapse._isShown;
                if(s == vm.currentSpecimen && expandCurrent && !isShown)
                    specCollapse.collapse('show');
                else if(isShown)
                    specCollapse.collapse('hide');
            });

            //do this while we're here
            $('.dateTimePicker').daterangepicker({
                "singleDatePicker": true,
                "timePicker": true,
                "timePicker24Hour": true,
                locale: {
                    format: 'MM/DD/YYYY h:mm'
                }
            });
        }

        //expandCurrentSpecimen: function(){
        //    $('#collapse'+this.currentSpecimen.guid).collapse('show');
        //},

        //collapseNonCurrentSpecimens: function() {
        //    var vm = this;
        //    this.specimens.forEach(function(s){
        //        if(vm.currentSpecimen === null || s.guid !== vm.currentSpecimen.guid)
        //            $('#collapse'+s.guid).collapse('hide');
        //    });
        //}

    }
};