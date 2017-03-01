<template>
    <div class="card">
        <div class="card-header card-header-primary">
            <span class="patientDetailsLabel">Patient/Subject Details</span>
        </div>
        <div class="card-block">
            <div class="form-group">
                <!--v-if="typeof(this.patient) != 'undefined'">-->
                <label for="patientName" class="patientLabel">Patient</label>
                <div class="float-right"><small>To prevent duplicate entries, please search before entering a new record.</small></div>
                <multiselect v-if="patientState.patient.id !=0" id="patientName"
                             :options="patientState.patients"
                             track-by="id"
                             label="lastName"
                             :option-height="104"
                             :searchable="true"
                             :custom-label="customPatientDropdownLabel"
                             :show-labels="false"                             
                             :internal-search="true"
                             :clear-on-select="true"
                             :close-on-select="true"
                             :allow-empty="false"
                             :options-limit="100"
                             :limit="5"
                             :limit-text="limitText"
                             placeholder="Type to Search..."
                             v-on:input="patientChanged"
                             v-on:search-change="patientSearched"
                             v-model="patientState.patient">
                    <span slot="noResult">No Patients Found.  <button class="btn btn-primary btn-sm" v-on:click="newPatient">New Patient</button></span>
                    <template slot="option" scope="props">
                        <div :id="props.option.id">{{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}</div>
                    </template>
                </multiselect>
                <div class="row">
                    <div class="form-group col-lg-6 col-sm-auto">
                        <label for="firstNameField">First Name</label>
                        <input id="firstNameField" type="text" v-model="patientState.patient.firstName" class="form-control" v-bind:disabled="!patientState.patientsSearched" />
                    </div>
                    <div class="form-group col-lg-6 col-sm-auto">
                        <label for="lastNameField">Last Name</label>
                        <input id="lastNameField" type="text" v-model="patientState.patient.lastName" class="form-control" v-bind:disabled="!patientState.patientsSearched" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-4 col-sm-auto">
                        <label for="ssnField">SSN</label>
                        <input id="ssnField" type="text" v-model="patientState.patient.ssn" class="form-control" v-bind:disabled="!patientState.patientsSearched" />
                    </div>
                    <div class="form-group col-lg-4 col-sm-auto">
                        <label for="dobField">DOB</label>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                            <input id="dobField" type="datetime" v-model="patientState.patient.dob" class="form-control" v-bind:disabled="!patientState.patientsSearched" />
                        </div>
                    </div>
                    <div class="form-group col-lg-4 col-sm-auto">
                        <label for="mrnField">MRN</label>
                        <input id="mrnField" type="text" v-model="mrn" class="form-control" v-bind:disabled="!patientState.patientsSearched" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12"><button v-if="patientState.patientsSearched" class="btn btn-primary float-right"><i class="fa fa-save"></i> Save Patient</button></div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

    import patientData from './Patient.vue.data.js';
    import Multiselect from 'vue-multiselect';
    import axios from 'axios';
    import debounce from 'lodash/debounce';

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
            patientId: Number,
            mrn: String,
            organization: Object
        },
        methods: {
            customPatientDropdownLabel: function ({id, firstName, lastName, dob, ssn}) {
                return 'Name: ' + firstName + ' ' + lastName + ', DOB: ' + this.dateFormat(dob) + ', SSN: ' + ssn},

    dateFormat: function(date) {return this.$options.filters.prettyDate(date)},

    limitText: function(count) {
        return `and ${count} additional Patients`;
    },

    patientSearched: function (searchQuery, id) {        
        //if(searchQuery.length > 1)
        //    this.getPatients(this.organization, searchQuery);
        this.patientState.patientsSearched = true;
    },

    patientChanged: function (value, dropDownId) {
        this.patientId = value.id;
        this.$emit('changed', value.id);
        //this.$set(this.accessionState.accession, 'patientId', value.id);
    },

    newPatient: function () {
        this.patientState.patient = {
            "id": -1,
            "guid": uuidV1(),
            "lastName": '',
            "firstName": '',
            "dob": '01/01/1900',
            "ssn": '000-00-000'
        };
        this.patientId = -1;
        this.$emit('new', -1);
    },

    getPatients: //debounce(
        function (org) {
            this.patientState.isLoading = true;
            axios.get('/api/Patient/' + org.nameKey).then(response => {
                
                this.$set(this.patientState, 'patients', response.data);

                var vm = this;
                var currentPatientInList = this.patientState.patients.find(function(p){return p.id == vm.patientState.patient.ID});
                
                if(this.patientState.patient.id != 0 && typeof(currentPatientInList) === 'undefined')
                    this.patientState.patients.push(this.patientState.patient);
                
                this.patientState.isLoading = false;
            }).catch(err=> { console.log(err) });
        }, //500),

    getPatient: function (org, id) {
        this.patientState.isLoading = true;
        axios.get('/api/Patient/' + org.nameKey + '/' + id).then(response => {
            Object.assign(this.patientState.patient, response.data);
            this.patientState.patients.push(response.data);
            this.patientState.isLoading = false;
        }).catch(err=> { console.log(err) });
    },

    },
    created: function()
    {        
        if(this.patientId > 0){
            this.getPatient(this.organization, this.patientId);
        }
        else
            this.newPatient();

        this.getPatients(this.organization);

    }
    };

</script>