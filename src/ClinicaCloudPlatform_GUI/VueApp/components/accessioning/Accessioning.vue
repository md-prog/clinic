<template>
    <div id="accessioningMain" class="container-fluid pt-2">

        <div id="loadingModal" tabindex="-1" class="modal fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
        <div v-if="accessionState.loaded || accessionState.isNew" class="animated fadeIn">
            <form id="accessionForm"></form>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="card">
                        <div class="card-block">
                            <h3 v-if="accessionState.isNew"> New <span class="accessionLabel">Accession</span></h3>
                            <h3 v-else>Edit <span class="accessionLabel">Accession</span> ID {{accessionState.accession.id}}</h3>
                            <span class="config-info">Labels on this screen can be overridden by organization CSS.<br />Each section can also be hidden by JSON, but defaults must often be specified (e.g. default client).</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <span class="clientDetailsLabel">Client/Source Details</span>
                        </div>
                        <div class="card-block">
                            <fieldset class="form-group">
                                <label for="clientName" class="clientNameLabel">Client Name</label>
                                <select v-if="1==2" id="clientName" class="form-control select2-single" v-model="accessionState.accession.client">
                                    <option v-for="client in accessionState.clients" v-bind:value="{name: client.name, id: client.id}">{{client.name}}</option>
                                </select>
                                <multiselect v-model="accessionState.accession.client"
                                             :options="accessionState.clients" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Select Client"
                                             @search-change="asyncGetClients(organization)"
                                             :loading="accessionState.isLoadingClientsAsync">
                                </multiselect>
                            </fieldset>
                            <label>{{accessionState.accession.client.name}}</label>
                            <label>{{accessionState.accession.client.id}}</label>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <span class="patientDetailsLabel">Patient/Subject Details</span>
                        </div>
                        <div class="card-block">
                            <div class="form-group">
                                <label for="patientName" class="patientLabel">Patient Search</label>
                                <span class="config-info-top">To prevent duplicate entries, please search before entering a new record.</span>
                                <select v-if="1==2" id="patientName" class="form-control select2-single require2" v-model="accessionState.accession.patient">
                                    <option value="" v-for="patient in accessionState.patients"
                                            v-bind:value="{lastName: patient.lastName, firstName: patient.firstName, dob: patient.dob, ssn: patient.ssn}">
                                        {{'Name: ' + patient.firstName + ' ' + patient.lastName + ', DOB: ' + dateFormat(patient.dob) + ', SSN: ' + patient.ssn}}
                                    </option>
                                </select>
                                <multiselect v-model="accessionState.accession.patient"
                                             :options="accessionState.patients" track-by="id" label="lastName" :option-height="104"
                                             :searchable="true" :close-on-select="true" :custom-label="customPatientDropdownLabel" :show-labels="false"
                                             placeholder="Select Patient" @search-change="this.patientSearched">
                                    <template slot="option" scope="props">
                                        <div>{{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}</div>
                                    </template>
                                </multiselect>
                                <label for="firstNameField">First Name</label>
                                <input id="firstNameField" type="text" v-model="accessionState.accession.patient.firstName" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                <label for="lastNameField">Last Name</label>
                                <input id="lastNameField" type="text" v-model="accessionState.accession.patient.lastName" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                <label for="ssnField">SSN</label>
                                <input id="ssnField" type="text" v-model="accessionState.accession.patient.ssn" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                <label for="dobField">DOB</label>
                                <input id="dobField" type="datetime" v-model="accessionState.accession.patient.dob" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                            </div>
                        </div>
                    </div>
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

    module.exports = {
        name: "Accessioning",
        //template: "accessioningMain",
        components: {
            Multiselect
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
            dateFormat: function(date) {return this.$options.filters.prettyDate(date)},
            customPatientDropdownLabel: function ({id, firstName, lastName, dob, ssn}) {
                return 'Name: ' + firstName + ' ' + lastName + ', DOB: ' + this.dateFormat(dob) + ', SSN: ' + ssn},
            loadAccession: function(id, orgNameKey){
                axios.get('/api/Accessioning/Get/' + id + '/' + orgNameKey).then( response  =>
                {
                    this.accessionState.accession = response.data;
                    this.accessionState.loaded = true;
                    this.accessionState.patientsSearched = false;
                    this.accessionState.accession.patient.dob = moment(this.accessionState.accession.patient.dob).format('M/D/YYYY'); //hack
                }
                    ).catch(err => {console.log(err)});
            },
            patientSearched: function() {this.accessionState.patientsSearched = true;},
            newAccession: function(){},
            asyncGetClients: function(org){
                this.accessionState.isLoadingClientsAsync = true;
                axios.get('api/Accessioning/Clients/' + org.orgNameKey).then( response => {
                    this.accessionState.clients = response;
                    this.accessionState.isLoadingClientsAsync = false;
                }).catch(err=> {console.log(err)});
            }

            //...mapActions('accession', ['loadAccession', 'newAccession'])
        },
        computed: {
            loaded: function() {return this.accessionState.loaded;}, //for the watcher below
            //isNew: function() {return this.accessionState.isNew},
            userProp: function () {
                if ( this.user != null ) {
                    return this.user;
                }

                return '{id: 0, fullName: "unknown"}';
            },
            orgProp: function () {
                if ( this.organization != null ) {
                    return this.organization;
                }

                return '{id: 0, orgKey: "unknown", name: "unknown"}';
            },
            //set: function(acc){
            //    //this.$parent.$store.dispatch('accession/setAccession', acc);
            //},
            //state: function(){return this.$parent.$store.state;},
            //...mapGetters('accession', ['accession', 'accessionLoaded', 'isNewAccession']),
            //...mapGetters('organization', ['organization']),
            //...mapGetters('user', ['user']),
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
                    this.$nextTick(function() { hideModal(); });
                }
            }
        },
        mounted: function() {
            setupFormOverlays();
        }
    };

    function setupFormOverlays(){
        if(modalActive)
            $("#loadingModal").modal("show");
        else
            setDatePickers();
    };

    function hideModal()
    {
        $("#loadingModal").modal("hide");
        setDatePickers();
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
