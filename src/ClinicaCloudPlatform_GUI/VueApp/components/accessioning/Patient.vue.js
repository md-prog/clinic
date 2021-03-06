﻿import patientData from './Patient.vue.data.js';
    import Multiselect from 'vue-multiselect';
    import axios from 'axios';
//import debounce from 'lodash/debounce';

import customDataHelpersMixin from '../../mixins/customDataHelpers.js';

const uuidV1 = require('uuid/v1');

module.exports = {
    name: "Patient",
    components: {
        Multiselect
    },
    data: function ()
    {
        return {
            patientState: patientData.patientState,
            allowEditSave: false,
            detailsCollapsed: true
        };
    },
    props: {
        prop_patientId: Number,
        prop_mrn: String,
        user: Object,
        organization: Object,
        prop_patients: Array
    },
    computed: {
        computedDobDay:{
            get: function(){
                var vm = this;
                if(vm.prop_patientId < 1)
                    return '';
                return new Date(vm.patientState.patient.dob).getDate();
            },
            set: function(value){
                var vm = this;
                var tempDob = new Date(vm.patientState.patient.dob);
                tempDob.setDate(value);
                vm.$set(vm.patientState.patient, 'dob', tempDob);
            }
        },

        computedDobMonth:{
            get: function(){
                var vm = this;
                if(vm.prop_patientId < 1)
                    return '';
                return new Date(vm.patientState.patient.dob).getMonth() + 1;
            },
            set: function(value){
                var vm = this;
                var tempDob = new Date(vm.patientState.patient.dob);
                tempDob.setMonth(value - 1);
                vm.$set(vm.patientState.patient, 'dob', tempDob);
            }
        },

        computedDobYear:{
            get: function(){
                var vm = this;
                if(vm.prop_patientId < 1)
                    return '';
                return new Date(vm.patientState.patient.dob).getFullYear();
            },
            set: function(value){
                var vm = this;
                var tempDob = new Date(vm.patientState.patient.dob);
                tempDob.setFullYear(value);
                vm.$set(vm.patientState.patient, 'dob', tempDob);
            }
        },

        patientSearched: {
            get: function(){
                return this.patientState.patientsSearched;
            },
            set: function(value){
                this.patientState.patientsSearched = value;
            }
        },

        searchBoxWidth: function () {
            return this.allowEditSave || this.patientSearched ? 'col-11' : 'col-12';
        },

        expandPanelArrow: function () {
            return this.detailsCollapsed ? 'fa-chevron-down' : 'fa-chevron-up';
        }

        //computedProp_patients:
        //{
        //    get: function() {
        //        var vm = this;
        //        return vm.prop_patients.map(function(p) {
        //            var patient_ext = {dobString: vm.getDobString(p.dob)};
        //            return Object.assign(p, patient_ext);
        //        });
        //    }
        //}
    },
    created: function()
    {
        if(this.prop_patientId > 0){
            this.setPatient(this.organization, this.prop_patientId, this.prop_mrn);
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
        toolTips: function() {this.$nextTick(function(){$('[data-toggle="tooltip"]').tooltip();});},

        customPatientDropdownLabel: function (patient) {
            if(patient.id == -1)
                return "Type to Search";
            else
                return 'Name: ' + patient.firstName + ' ' + patient.lastName + ', DOB: ' + this.dateFormat(patient.dob) + ', SSN: ' + patient.ssn;
        },

        dateFormat: function(date) {
            return this.$options.filters.MMDDYYYY(date)
        },

        limitText: function(count) {
            return `and ${count} additional Patients`;
        },

        patientChanged: function (value, dropDownId, doReload) {
            this.allowEditSave = true;
            this.patientSearched = true;
            this.setPatientDemographics(this.patientState.patient);
            this.$emit('changed', value.id, doReload);
        },

        //getDobString: function(dob){
        //    var dobDt = new Date(dob);
        //    return (dobDt.getMonth() + 1) + '/' + dobDt.getDay() + '/' + dobDt.getFullYear();
        //},

        toggleDetailsVisibility: function() {
            this.detailsCollapsed = !this.detailsCollapsed;
        },

        addNewPatient: function() {
            this.allowEditSave = true;
            if(this.patientState === null || (this.patientState.patient != null && this.patientState.patient.id !== -1)) {
                this.newPatient();
            }
        },

        newPatient: function () {
            this.patientState.patient = {
                "id": -1,
                "guid": uuidV1(),
                "lastName": '',
                "firstName": '',
                "fullName": '',
                "dob": '',
                //"dobString": '',
                "ssn": ''
            };
            this.patientState.mrn = "";
            this.setPatientDemographics(this.patientState.patient);
            this.$emit('new', -1);
        },

        setPatient: function(org, patientId, mrn)
        {
            var currentPatient = this.prop_patients.find(function(p){return p.id == patientId});
            if(currentPatient != null){
                this.$set(this.patientState, 'patient', currentPatient);
                //done in compute - this.$set(this.patientState.patient, 'dobString', this.getDobString(this.patientState.patient.dob));
                this.$set(this.patientState, 'mrn', mrn);
                this.setPatientDemographics(currentPatient);
            }
            else
                this.newPatient();
        },

        savePatient: function()
        {
            var vm = this;
            //vm.$set(vm.patientState.patient, 'dob', new Date(vm.patientState.patient.dobString).toJSON());
            //vm.$delete(vm.patientState.patient, 'dobString');
            axios.post('/api/patient', {
                patient: vm.patientState.patient,
                orgCustomData: vm.organization.customData,
                userFullName: vm.user.fullName,
                userHref: vm.user.href}).then(response=>{
                    vm.$set(vm.patientState.patient, 'id', response.data.id);
                    vm.$set(vm.patientState.patient, 'guid', response.data.guid);
                    this.patientChanged(vm.patientState.patient, response.data.id, true);
                });
        }

    },

};