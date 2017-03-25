
//var loadInProgress = false;

//import { mapGetters, mapActions} from 'vuex';
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
        return {accessionState: accessionData.accessionState};
    },

    ///vue computed properties

    computed: {
        //loaded: function() { return this.accessionState.loaded;},
        //isNew: function() { return this.accessionState.isNew;},
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

    //end computed

    //vue watchers

    watch:{
        //loaded: function() {
        //    if (this.loaded)
        //    {
        //        var vm = this;
        //        vm.$nextTick(function() { this.finalizeView(); });
        //    }
        //},
        '$route': function () {
            var vm = this;
            //if(vm.loaded) //don't do this if still loading... not sure why needed
            vm.initView();
        },
    },

    //end watchers

    //vue lifecycle events

    created: function() {
        this.initView();
    },

    mounted: function() {
        //setupFormOverlays();
    },

    //end lifecycle events

    //vue methods

    methods:{

        initView: function(){
            var accId = 0
            var vm = this;

            vm.$set(vm.accessionState, 'loaded', false);
            vm.$set(vm.accessionState, 'currentAction', 'Loading');

            if (vm.$route.params.id == null)
                vm.newAccession();
            else
            {
                vm.$set(vm.accessionState, 'isNew', false);
                accId = this.$route.params.id;
            }

            vm.$nextTick(function() {$("#loadingModal").modal("show");});

            if(vm.accessionState.isNew || vm.accessionState.accession.id != accId)
            {
                vm.loadAll(this.$route.params.id, vm.$route.params.orgNameKey);
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
                vm.postSave(vm);
            vm.$set(vm.accessionState, 'loaded', true); 
            vm.$nextTick(function() { vm.finalizeView(); });
        },
            
        postSave: function(vm){                
            vm.setHistoryItems(vm);
        },

        setHistoryItems: function(vm){
            var accId = vm.accessionState.accession.id;
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
                accId, 'Accession # ' + accId, 
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

        getAccessionOrNew: function(id, orgNameKey)
        {
            if(this.accessionState.isNew)
                return {"data": {"accession": this.accessionState.accession}}; //use the default empty template
            else
                return axios.get('/api/Accessioning/' + id + '/' + orgNameKey)
        },

        loadAll: function(id, orgNameKey){
            var vm = this;
            axios.all([
                vm.getAccessionOrNew(id, orgNameKey),
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
                userFullName: vm.user.fullName,
                userHref: vm.user.href}).then(response=>{
                    vm.$set(vm.accessionState,'loaded', true);
                    vm.$set(this.accessionState,'isNew', false);
                    this.postSave(vm);
                });
        },

        newAccession: function(){
            var vm = this;
            vm.$set(vm.accessionState, 'currentAction', 'New');
            vm.$set(this.accessionState, 'accession', this.accessionState.accessionTemplate);
            vm.$set(this.accessionState,'isNew', true);
        },

        //debounce(
        //asyncGetClients: function(org){
        //    this.accessionState.isLoadingClientsAsync = true;
        //    axios.get('/api/Accessioning/Clients/' + org.nameKey).then( response => {
        //        Object.assign(this.accessionState.clients, response.data);
        //        this.accessionState.isLoadingClientsAsync = false;
        //    }).catch(err=> {console.log(err)});
        //},

        //client data

        //getClient: function(org, id){
        //    axios.get('/api/Accessioning/Clients/' + org.nameKey + '/' + id).then( response => {
        //        this.accessionState.clients.push(response.data);
        //    }).catch(err=> {console.log(err)});
        //},

    }
};