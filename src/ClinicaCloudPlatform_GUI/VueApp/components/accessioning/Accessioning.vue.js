import axios from 'axios'
import Multiselect from 'vue-multiselect';
import accessionData from './Accessioning.vue.data.js';
import filter from '../../assets/js/setFilter.js';
import objectMerge from 'object-merge';
import debounce from 'lodash/debounce';

import Patient from './Patient.vue';
import Specimens from './Specimens.vue';

const uuidV1 = require('uuid/v1');

module.exports = {
    name: "Accessioning",

    components: {
        Multiselect,
        Patient,
        Specimens
    },

    props: {
        user: Object,
        organization: Object
    },

    data: function ()
    {
        return {
            accessionState: accessionData.accessionState
        };
    },

    computed: {
        client: {
            get: function(){
                var cId = this.accessionState.accession.clientId;
                return this.accessionState.clients.find(function (c) {return c.id == cId;});
            },
            set: function(value){
                this.$set(this.accessionState.accession, 'clientId', value.id);
                //facility depends on client, choose the first one
                this.$set(this.accessionState.accession, 'facilityId', value.facilities[0].id);
            }
        },
        facility: {
            get: function(){
                var fId = this.accessionState.accession.facilityId;
                return this.facilities.find(function (f) {return f.id == fId;});
            },
            set: function(value){
                this.$set(this.accessionState.accession, 'facilityId', value.id);
            }
        },
        lab: {
            get: function(){
                var lId = this.accessionState.accession.orderingLabId;
                return  this.accessionState.labs.find(function (l) {return l.id == lId;});
            },
            set: function(value)
            {
                this.$set(this.accessionState.accession, 'orderingLabId', value.id);
            }
        },
        patient: {
            get: function(){
                var pId = this.accessionState.accession.patientId;
                return  this.accessionState.patients.find(function (p) {return p.id == pId;});
            }
        },

        facilities: function() {
            var facilities = [{id:0, name:""}];
            var cId = this.accessionState.accession.clientId;
            var cli = this.accessionState.clients.find(function (c) {return c.id == cId;});
            if(typeof(cli)!='undefined')
                facilities = cli.facilities;
            return facilities;
        },
    },

    watch:{
        '$route': function () {
            var vm = this;
            vm.initView();
        },
    },

    created: function() {
        this.initView();
    },

    mounted: function() {
        
    },

    methods:{

        initView: function(){
            var accGuid = null;
            var vm = this;

            vm.$set(vm.accessionState, 'loaded', false);
            vm.$set(vm.accessionState, 'currentAction', 'Loading');

            if (vm.$route.params.guid == null)
                vm.newAccession();
            else
            {
                vm.$set(vm.accessionState, 'isNew', false);
                accGuid = vm.$route.params.guid;
            }

            vm.$nextTick(function() {$("#loadingModal").modal("show");});

            if(vm.accessionState.isNew || vm.accessionState.accession.guid != accGuid)
            {
                vm.loadAll(vm.$route.params.guid, vm.$route.params.orgNameKey);
            }
            else
            {
                vm.$set(vm.accessionState, 'loaded', true);
                vm.$nextTick(function() { vm.finalizeView(); });
            }
        },

        finalizeView: function(){ //see watcher on loaded property

            $("#loadingModal").modal("hide");

            $('.dateOnlyPicker').daterangepicker({
                "singleDatePicker": true,
                "timePicker": false,
                locale: {
                    format: 'M/D/YYYY'
                }
            });

            $('.dateTimePicker').daterangepicker({
                "singleDatePicker": true,
                "timePicker": true,
            });

        },

        afterLoad: function(vm){
            if(!vm.accessionState.isNew)
                vm.setHistoryItems(vm);
            vm.$set(vm.accessionState, 'loaded', true); 
            vm.$nextTick(function() { vm.finalizeView(); });
            vm.getBarcodes(vm.organization.nameKey);
        },
            
        postSave: function(vm, response){    
            response.data.specimensInfo.forEach(function(s){
                var spec = vm.accessionState.accession.specimens.find(function(s1){
                    return s1.guid === s.guid;
                });
                vm.$set(spec, 'barcodeNumber', s.barcodeNumber);
            });            
            vm.setHistoryItems(vm);
            vm.$set(vm.accessionState,'loaded', true);
            vm.$set(vm.accessionState,'isNew', false);
            vm.$nextTick(function() { vm.finalizeView(); });
        },

        setHistoryItems: function(vm){
            var accId = vm.accessionState.accession.id;
            var accGuid = vm.accessionState.accession.guid;
            var accTimestamp = vm.accessionState.accession.createdDate;
            var subject = vm.patient.lastName;
            var specimens = vm.accessionState.accession.specimens.map(function(s) {return s.type.type});
            var countedSpecimens = [];

            specimens.forEach(function(s){
                typeof countedSpecimens.find(function(c){
                    return c.string === s}) === 'undefined' ? countedSpecimens.push({string:s, count:1}) : countedSpecimens.find(function(c){
                        return c.string === s}).count++;
            });
            specimens = countedSpecimens.map(function(c) {return c.count + ' ' + vm.$options.filters.pluralize(c.count, c.string)});

            vm.$emit('viewEditItem', 
                vm.$route.meta.title, 
                accGuid, 
                'Accession # ' + accId, 
                subject, 
                specimens.join(', '), 
                accTimestamp);
        },

        //todo validation

        validateSave: function()
        {
            return true;
        },

        //todo printing

        printAccession: function (){},

        printLabels: function (){},

        //component event handlers

        patient_changed: function(patientId, doReload)
        {
            this.$set(this.accessionState.accession, 'patientId', patientId);
            if(doReload)
                this.loadPatients(this.organization);
        },

        specimens_changed: function(specimens)
        {
            this.$set(this.accessionState.accession, 'specimens', specimens);
        },

        //general

        dateFormat: function(date) {
            return this.$options.filters.prettyDate(date)
        },

        //data

        getAccessionOrNew: function(guid, orgNameKey)
        {
            var vm = this;            
            if(vm.accessionState.isNew)
            {
                guid = uuidV1();
                vm.$set(this.accessionState.accession, 'guid', guid);
                return {"data": {"accession": vm.accessionState.accession}}; //use the default empty template
            }
            else
                return axios.get('/api/Accessioning/' + guid + '/' + orgNameKey)
           
        },

        getBarcodes: function(orgNameKey){
            var vm = this;
            axios.post('/api/Barcode/lookup', {orgNameKey: orgNameKey, accessionGuid: vm.accessionState.accession.guid})
            .then(response =>
                vm.$set(vm.accessionState, 'barcodes', response.data)
            ).catch(err => {console.log(err)});;
        },

        loadAll: function(guid, orgNameKey){
            var vm = this;
            axios.all([
                vm.getAccessionOrNew(guid, orgNameKey),
                axios.get('/api/Client/' + orgNameKey),
                axios.get('/api/Patient/' + orgNameKey),
                axios.get('/api/Lab/' + orgNameKey),               
            ]).then(axios.spread(function (accResponse, clientResponse, patientResponse, labResponse) {
                vm.$set(vm.accessionState, 'accession', accResponse.data.accession);
                vm.$set(vm.accessionState, 'clients', clientResponse.data);
                vm.$set(vm.accessionState, 'patients', patientResponse.data);
                vm.$set(vm.accessionState, 'labs', labResponse.data);
                vm.afterLoad(vm);
            }
                )).catch(err => {console.log(err)});
        },

        loadPatients: function(orgNameKey){
            var vm = this;
            axios.get('/api/Patient/' + orgNameKey).then(function(response)
            {
                vm.$set(vm.accessionState, 'patients', response.data);
            }).catch(err=>{console.log(err)});
        },

        saveAccession: function(){
            var vm = this;

            vm.$set(vm.accessionState, 'currentAction', 'Saving');

            vm.$set(vm.accessionState,'loaded', false);
            vm.$nextTick(function() {$("#loadingModal").modal("show");});

            axios.post('/api/accessioning', {
                accession: vm.accessionState.accession,
                orgCustomData: vm.organization.customData,
                orgNameKey: vm.organization.nameKey,
                userFullName: vm.user.fullName,
                userHref: vm.user.href}).then(response=>{
                    this.postSave(vm, response);
                }).catch(err => {console.log(err)});;
        },

        newAccession: function(){
            var vm = this;
            vm.$set(vm.accessionState, 'currentAction', 'New');
            vm.$set(this.accessionState, 'accession', this.accessionState.accessionTemplate);
            vm.$set(this.accessionState,'isNew', true);
        },

    }
};