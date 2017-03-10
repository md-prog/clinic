<template>
    <div class="card">
        <div class="card-header card-header-primary">
            <span class="patientDetailsLabel">Patient/Subject Details</span>
            <div class="float-right text-white"><small>To prevent duplicate entries, please search before entering a new record.</small></div>
        </div>
        <div class="card-block">
            <div class="form-group">
                <!--v-if="typeof(this.patient) != 'undefined'">-->
                <label for="patientName" class="patientLabel labelAbove">Patient</label>               
                <multiselect id="patientName"
                             :options="this.computedProp_patients"
                             track-by="id"
                             label="fullName"
                             :option-height="104"
                             :searchable="true"
                             :custom-label="customPatientDropdownLabel"
                             :show-labels="false"
                             :internal-search="true"
                             :clear-on-select="true"
                             :close-on-select="true"
                             :allow-empty="false"
                             placeholder="Type to Search..."
                             v-on:input="patientChanged"
                             v-on:search-change="patientSearched"
                             v-model="patientState.patient">
                    <span slot="noResult">No Patients Found.  <button class="btn btn-info btn-sm" v-on:click="newPatient">New Patient</button></span>
                    <template slot="option" scope="props">
                        <div :id="props.option.id">{{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}</div>
                    </template>
                </multiselect>
                <div class="row">
                    <div class="form-group col-lg-6 col-sm-auto">
                        <label for="firstNameField" class="labelAbove">First Name</label>
                        <input id="firstNameField" type="text" v-model="patientState.patient.firstName" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                    <div class="form-group col-lg-6 col-sm-auto">
                        <label for="lastNameField" class="labelAbove">Last Name</label>
                        <input id="lastNameField" type="text" v-model="patientState.patient.lastName" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-4 col-sm-auto">
                        <label for="ssnField" class="labelAbove">SSN</label>
                        <input id="ssnField" type="text" v-model="patientState.patient.ssn" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                    <div class="form-group col-lg-4 col-sm-auto">
                        <label for="dobField" class="labelAbove">DOB</label>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                            <input id="dobField" type="text" v-model="patientState.patient.dobString" class="form-control"
                                   v-bind:disabled="!this.allowEditSave" />
                        </div>
                    </div>
                    <div class="form-group col-lg-4 col-sm-auto">
                        <label for="mrnField" class="labelAbove">MRN</label>
                        <input id="mrnField" type="text" v-model="patientState.mrn" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <button
                                class="btn btn-info float-left"
                                v-on:click="uploadDocument('PatientConsent')">
                            <i class="fa fa-paperclip"></i>
                            Attach Consent
                        </button>
                    </div>
                    <div class="col-sm-6">
                    <button v-if="this.allowEditSave" 
                            class="btn btn-info float-right"
                            v-on:click="savePatient">
                        <i class="fa fa-save"></i> 
                        Save Patient</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

    import patientData from './Patient.vue.data.js';
    import Multiselect from 'vue-multiselect';
    import axios from 'axios';
    //import debounce from 'lodash/debounce';

    const uuidV1 = require('uuid/v1');

    module.exports = {
        name: "Patient",
        components: {
            Multiselect
        },
        data: function ()
        {
            return {patientState: patientData.patientState};
        },
        props: {
            prop_patientId: Number,
            prop_mrn: String,
            prop_user: Object,
            prop_organization: Object,
            prop_patients: Array
        },
        computed: {
            computedProp_patients: //moved to controller
            {
                get: function() {
                    var vm = this;
                    return vm.prop_patients.map(function(p) { 
                        var patient_ext = {dobString: vm.getDobString(p.dob)};
                        return Object.assign(p, patient_ext);
                    });
                }
            }
        },
        created: function()
        {
            if(this.prop_patientId > 0){
                this.setPatient(this.prop_organization, this.prop_patientId, this.prop_mrn);
            }
            else
                this.newPatient();

        },
        beforeMount: function()
        {
            //$('#dobField').daterangepicker({
            //    "singleDatePicker": true,
            //    "timePicker": false,
            //    locale: {
            //        format: 'MM/DD/YYYY'
            //    }
            //});
        },
        methods: {
            customPatientDropdownLabel: function (patient) {
                if(patient.id == -1)
                    return "Type to Search";
                else
                    return 'Name: ' + patient.firstName + ' ' + patient.lastName + ', DOB: ' + this.dateFormat(patient.dob) + ', SSN: ' + patient.ssn;
            },

            allowEditSave:function(){
                return patientState.patientsSearched;
            },

            dateFormat: function(date) {return this.$options.filters.prettyDate(date)},

            limitText: function(count) {
                return `and ${count} additional Patients`;
            },

            patientSearched: function (searchQuery, id) {
                this.patientState.patientsSearched = true;
            },

            patientChanged: function (value, dropDownId, doReload) {
                this.$emit('changed', value.id, doReload);
            },

            getDobString: function(dob){            
                var dobDt = new Date(dob);
                return (dobDt.getMonth() + 1) + '/' + dobDt.getDay() + '/' + dobDt.getFullYear();
            },

            newPatient: function () {
                this.patientState.patient = {
                    "id": -1,
                    "guid": uuidV1(),
                    "lastName": '',
                    "firstName": '',
                    "fullName": '',
                    "dob": '',
                    "dobString": '',
                    "ssn": ''
                };
                this.patientState.mrn = "";
                this.$emit('new', -1);
            },

            setPatient: function(org, patientId, mrn)
            {
                var currentPatient = this.computedProp_patients.find(function(p){return p.id == patientId});
                if(currentPatient != null){
                    this.$set(this.patientState, 'patient', currentPatient);                    
                    //done in compute - this.$set(this.patientState.patient, 'dobString', this.getDobString(this.patientState.patient.dob));
                    this.$set(this.patientState, 'mrn', mrn);
                }
                else
                    this.newPatient();
            },

            savePatient: function()
            {   
                var vm = this;
                vm.$set(vm.patientState.patient, 'dob', new Date(vm.patientState.patient.dobString).toJSON());  
                //vm.$delete(vm.patientState.patient, 'dobString');
                axios.post('/api/patient', {
                    patient: vm.patientState.patient,                   
                    orgCustomData: vm.prop_organization.customData,
                    userFullName: vm.prop_user.fullName,
                    userHref: vm.prop_user.href}).then(response=>{
                        vm.$set(vm.patientState.patient, 'id', response.data.id);
                        vm.$set(vm.patientState.patient, 'guid', response.data.guid);
                        this.patientChanged(vm.patientState.patient, response.data.id, true);
                    });
            }

        },

    };

</script>