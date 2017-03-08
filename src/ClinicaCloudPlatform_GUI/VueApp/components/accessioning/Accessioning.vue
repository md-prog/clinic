<template>
    <div id="accessioningMain" class="container-fluid p-lg-1 p-md-0 p-sm-0">
        <div id="loadingModal" tabindex="-1" class="modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-info" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        Loading
                    </div>
                    <div class="modal-body text-center">
                        <h4><i class="fa fa-spinner fa-spin"></i> Loading <span class="accessionLabel">Accession</span> ID {{$route.params.id}}</h4>
                    </div>
                    <div class="modal-footer"></div>
                </div>
            </div>
        </div>
        <div v-if="loaded || isNew">
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-auto">
                    <div class="row">
                        <div class="col-sm-12">
                            <div v-if="isNew" class="card card-inverse card-primary">
                                <div class="card-block">
                                    <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                    <div class="text-uppercase font-weight-bold font-xs">New <span class="accessionLabel">Accession</span></div>
                                </div>
                            </div>
                            <div v-else class="card card-inverse card-primary pb-1">
                                <div class="card-block">
                                    <!--<div class="row p-0 m-0">
                                        <div class="col-sm-3">
                                            <div class="row p-0 m-0">
                                                <div class="col-sm-12"><i class="icon-chemistry font-2xl"></i></div>
                                            </div>
                                            <div class="row p-0 m-o">
                                                <div class="col-sm-12">
                                                    <div class="dropdown">
                                                        <button class="btn btn-success dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fa fa-save"></i>
                                                        </button>
                                                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                            <div class="dropdown-item" v-on:click="saveAccession">Save and Launch</div>
                                                            <div class="dropdown-item" v-on:click="saveAccession">Save and Hold</div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col=sm-9">
                                            <div class="text-uppercase font-weight-bold font-xs"><span class="accessionLabel">Accession</span> ID { {accessionState.accession.id} }</div>
                                            { {accessionState.accession.createdDate | prettyDate} }
                                        </div>
                                    </div>-->
                                    <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                    <div class="text-uppercase font-weight-bold font-xs"><span class="accessionLabel">Accession</span> ID {{accessionState.accession.id}}</div>
                                    {{accessionState.accession.createdDate | prettyDate}}
                                    <div class="dropdown bottom-right-0 mt-1">
                                            <button class="btn btn-sm btn-success dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <i class="fa fa-save"></i>
                                            </button>
                                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                <div class="dropdown-item" v-on:click="saveAccession">Save and Launch</div>
                                                <div class="dropdown-item" v-on:click="saveAccession">Save and Hold</div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card card-inverse card-primary">
                                <div class="card-block">
                                    <i class="fa fa-print font-2xl mr-1 float-left"></i>
                                    <div>
                                        <div class="font-sm text-white" v-on:click="printTravelDoc">Print Accession</div>
                                        <div class="font-sm text-white" v-on:click="printLabels">Print Labels</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--<div class="row">
                        <div class="col-sm-12">
                            <button type="button" class="btn btn-warning float-right" v-on:click="saveAccession"><i class="fa fa-save"></i> Save and Launch</button>
                        </div>
                        <div class="col-sm-auto">
                            <button type="button" class="btn btn-primary"><i class="fa fa-save" v-on:click="saveAccession"></i> Save</button>
                        </div>
                    </div>-->
                </div>
                <div class="col-lg-5 col-sm-auto">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <span class="clientDetailsLabel">Client/Source Details</span>
                        </div>
                        <div class="card-block">
                            <fieldset class="form-group">
                                <label for="clientName" class="clientLabel">Client</label>
                                <multiselect id="clientName"
                                             :options="accessionState.clients" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Type to Search..."
                                             v-on:select="clientChanged"
                                             v-bind:value="client">
                                </multiselect>
                                <label for="facilityName" class="facilityLabel">Facility</label>
                                <multiselect id="facilityName"
                                             :options="this.facilities" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             v-on:select="faciltyChanged"
                                             v-bind:value="facility"
                                             :loading="this.accessionState.isLoadingClientsAsync"
                                             placeholder="Select...">
                                </multiselect>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-sm-auto">
                    <Patient v-if="this.loaded && this.organization.href != null"
                             :patientId="accessionState.accession.patientId"
                             :mrn="accessionState.accession.mrn"
                             :organization="this.organization"
                             v-on:new="patient_changed"
                             v-on:changed="patient_changed" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <Specimens :specimens="accessionState.accession.specimens"
                               :organization="organization"
                               v-on:changed="specimens_changed">
                    </Specimens>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

    var modalActive = false;

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
    //require('../../assets/js/selectMany.js');

    module.exports = {
        name: "Accessioning",
        //template: "accessioningMain",
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
        methods:{

            //component event handlers

            patient_changed: function(patientId)
            {
                this.$set(this.accessionState.accession, 'patientId', patientId);
            },

            specimens_changed: function(specimens)
            {
                this.$set(this.accessionState.accession, 'specimens', specimens);
            },

            //state

            clientChanged: function(value, dropDownId){
                this.$set(this.accessionState.accession, 'clientId', value.id);
                this.$set(this.accessionState.accession, 'facilityId', value.facilities[0].id);
            },
            faciltyChanged: function(value, dropDownId){
                this.$set(this.accessionState.accession, 'facilityId', value.id);
            },

            //general

            dateFormat: function(date) {return this.$options.filters.prettyDate(date)},

            //accession data

            loadAccession: function(id, orgNameKey){
                var vm = this;
                axios.all([
                    axios.get('/api/Accessioning/' + id + '/' + orgNameKey),
                    axios.get('/api/Client/' + orgNameKey)
                ]).then(axios.spread(function (accResponse, clientResponse) {
                    Object.assign(vm.accessionState.accession, accResponse.data.accession);
                    Object.assign(vm.accessionState.clients, clientResponse.data);
                    vm.$set(vm.accessionState, 'loaded', true);
                }
                    )).catch(err => {console.log(err)});
            },

            saveAccession: function(){
                //this.$set(this.accessionState.accession, 'facility', this.accessionState.client.);
                axios.post('/api/accessioning', {
                    accession: this.accessionState.accession,
                    orgCustomData: this.organization.customData,
                    userFullName: this.user.fullName,
                    userHref: this.user.href});
            },

            newAccession: function(){this.$set(this.accessionState,'isNew', true);},
            //debounce(
            asyncGetClients: function(org){
                this.accessionState.isLoadingClientsAsync = true;
                axios.get('/api/Accessioning/Clients/' + org.nameKey).then( response => {
                    Object.assign(this.accessionState.clients, response.data);
                    this.accessionState.isLoadingClientsAsync = false;
                }).catch(err=> {console.log(err)});
            },

            //client data

            getClient: function(org, id){
                axios.get('/api/Accessioning/Clients/' + org.nameKey + '/' + id).then( response => {
                    this.accessionState.clients.push(response.data);
                }).catch(err=> {console.log(err)});
            },

        },
        computed: {
            loaded: function() { return this.accessionState.loaded;},
            isNew: function() { return this.accessionState.isNew;},
            //patient: function() {
            //    var pId = this.accessionState.accession.patientId;
            //    var pat = this.accessionState.patients.find(function (p) {return p.id == pId;});
            //    return pat;
            //},
            client: function () {
                var cId = this.accessionState.accession.clientId;
                var cli = this.accessionState.clients.find(function (c) {return c.id == cId;});
                return cli;
            },
            facility: function () {
                var fId = this.accessionState.accession.facilityId;
                return this.facilities.find(function (f) {return f.id == fId;});
            },
            facilities: function() {
                var facilities = [{id:0, name:""}];
                var cId = this.accessionState.accession.clientId;
                var cli = this.accessionState.clients.find(function (c) {return c.id == cId;});
                if(typeof(cli)!='undefined')
                    facilities = cli.facilities;
                return facilities;
            }
        },
        created: function() {
            if (typeof this.$route.params.id === 'undefined')
                this.newAccession();
            else if(!this.accessionState.loaded|| this.accessionState.accession.id != this.$route.params.id){
                modalActive = true;
                this.loadAccession(this.$route.params.id, this.$route.params.orgNameKey);
            }
        },
        watch:{
            loaded: function() {
                if (this.loaded)
                {
                    var vm = this;
                    vm.$nextTick(function() { postLoadActions(vm); });
                }
            },
        },
        mounted: function() {
            setupFormOverlays();
        }
    };

    function postLoadActions(vm)
    {
        hideModal();
        //$("#clientName").value = vm.client;
    }

    function setupFormOverlays(){
        if(modalActive)
            $("#loadingModal").modal("show");
        else
            postModalActions()
    };

    function hideModal()
    {
        $("#loadingModal").modal("hide");
        postModalActions();
    }

    function postModalActions()
    {
        setDatePickers();

        //$('#specimenList').DataTable( {
        //    responsive: true,
        //    paging:false,
        //    searching: false,
        //    info:false
        //} );
    }

    function setDatePickers()
    {
        $('#dobField').daterangepicker({
            "singleDatePicker": true,
            "timePicker": false,
            locale: {
                format: 'MM/DD/YYYY h:mm A'
            }
        });
    }

</script>
<style>
</style>
