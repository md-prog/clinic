<template>
    <div id="accessioningMain" class="container-fluid p-lg-1 p-md-0 p-sm-0">
        <div id="loadingModal" tabindex="-1" class="modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-info" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        Stand By
                    </div>
                    <div class="modal-body text-center">
                        <h4>
                            <i class="fa fa-spinner fa-spin"></i> {{accessionState.currentAction}}
                            <span class="accessionLabel">Accession</span>
                            <span v-if="accessionState.currentAction != 'New'"> ID {{$route.params.id}}</span>
                        </h4>
                    </div>
                    <div class="modal-footer"></div>
                </div>
            </div>
        </div>
        <div v-if="accessionState.loaded">
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-auto">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card card-inverse card-primary">
                                <div class="card-block">
                                    <div v-if="accessionState.isNew" class="row">
                                        <div class="col-sm-12">
                                            <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                            <div class="text-uppercase font-weight-bold font-xs">New <span class="accessionLabel">Accession</span></div>
                                        </div>
                                    </div>
                                    <div v-else class="row">
                                        <div class="col-sm-12">
                                            <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                            <div class="text-uppercase font-weight-bold font-xs"><span class="accessionLabel">Accession</span> ID {{accessionState.accession.id}}</div>
                                            {{accessionState.accession.createdDate | prettyDate}}
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="dropdown w-100 mt-1">
                                                <button v-bind:enabled="validateSave()"
                                                        class="btn btn-info dropdown-toggle w-100"
                                                        type="button"
                                                        id="saveAccessionDropdown"
                                                        data-toggle="dropdown"
                                                        aria-haspopup="true"
                                                        aria-expanded="false">
                                                    <i class="fa fa-print font-2xl float-left"></i>
                                                    Save
                                                </button>
                                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="saveAccessionDropdown">
                                                    <div class="dropdown-item-info" v-on:click="saveAccession">Save and Launch</div>
                                                    <div class="dropdown-item-info" v-on:click="saveAccession">Save and Hold</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="dropdown w-100 mt-1">
                                                <button class="btn btn-info dropdown-toggle w-100"
                                                        type="button"
                                                        id="printDropdown"
                                                        data-toggle="dropdown"
                                                        aria-haspopup="true"
                                                        aria-expanded="false">
                                                    <i class="fa fa-save font-2xl float-left"></i>
                                                    Print
                                                </button>
                                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="printDropdown">
                                                    <div class="dropdown-item-info" v-on:click="printAccession">Print <span class="accessionLabel">Accession</span></div>
                                                    <div class="dropdown-item-info" v-on:click="printLabels">Print Labels</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-sm-auto">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <span class="clientDetailsLabel">Accession Details</span>
                        </div>
                        <div class="card-block">
                            <div class="form-group">
                                <label for="clientName" class="clientLabel labelAbove">Client</label>
                                <multiselect v-if="accessionState.loaded" id="clientName"
                                             :options="accessionState.clients" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Type to Search..."
                                             v-model="client">
                                </multiselect>
                                <label for="facilityName" class="facilityLabel labelAbove">Facility</label>
                                <multiselect v-if="accessionState.loaded" id="facilityName"
                                             :options="this.facilities" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             v-model="facility"                                             
                                             placeholder="Select..."><!--v-on:select="faciltyChanged"
                                                                        v-bind:value="facility"
                                                                         :loading="this.accessionState.isLoadingClientsAsync"-->
                                </multiselect>
                            </div>
                            <div class="form-group">
                                <label for="labName" class="labLabel labelAbove">Received At</label>
                                <multiselect v-if="accessionState.loaded" id="labName"
                                             :options="accessionState.labs" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Type to Search..."
                                             v-model="lab">
                                </multiselect>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-sm-auto">
                    <Patient v-if="accessionState.loaded && organization.href != null"
                             :prop_patientId="accessionState.isNew ? 0 : accessionState.accession.patientId"
                             :prop_mrn="accessionState.isNew ? '' : accessionState.accession.mrn"
                             :prop_organization="this.organization"
                             :prop_user="this.user"
                             :prop_patients="this.accessionState.patients"
                             v-on:new="patient_changed"
                             v-on:changed="patient_changed" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <Specimens v-if="accessionState.loaded" :specimens="accessionState.accession.specimens"
                               :organization="organization"
                               v-on:changed="specimens_changed">
                    </Specimens>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

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

                //tried this in patient component beforeMount - try again later
                $('#dobField').daterangepicker({
                    "singleDatePicker": true,
                    "timePicker": false,
                    locale: {
                        format: 'M/D/YYYY'
                    }
                });

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
                    vm.$set(vm.accessionState, 'loaded', true);
                    vm.$nextTick(function() { vm.finalizeView(); });
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
                        vm.$nextTick(function() {$("#loadingModal").modal("hide");});
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

</script>
<style>

</style>
