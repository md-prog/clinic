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

        dateFormat: function(date) {
            return this.$options.filters.MMDDYYYY(date)
        },

        limitText: function(count) {
            return `and ${count} additional Patients`;
        },

        patientSearched: function (searchQuery, id) {
            this.patientState.patientsSearched = true;
        },

        patientChanged: function (value, dropDownId, doReload) {
            this.$emit('changed', value.id, doReload);
        },

        //getDobString: function(dob){
        //    var dobDt = new Date(dob);
        //    return (dobDt.getMonth() + 1) + '/' + dobDt.getDay() + '/' + dobDt.getFullYear();
        //},

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
            this.$emit('new', -1);
        },

        setPatient: function(org, patientId, mrn)
        {
            var currentPatient = this.prop_patients.find(function(p){return p.id == patientId});
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
            //vm.$set(vm.patientState.patient, 'dob', new Date(vm.patientState.patient.dobString).toJSON());
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