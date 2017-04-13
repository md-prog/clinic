import ScanLookup from '../tools/ScanLookup.vue';
import SpecimenStatus from '../plugins/dashboardCards/SpecimenStatus.vue';
import dashboardData from './SpecimenTrackingDashboard.vue.data.js';
import axios from 'axios';
import entityLookupMixin from '../../mixins/entityLookup.js';

module.exports = {
    name:'SpecimenTrackingDashboard',
    components: {
        ScanLookup,
        SpecimenStatus
    },
    props:{
        organization: Object,
        user: Object,
        clients: Array,
        labs: Array,
        patients: Array,
        doctors: Array
    },
    mixins: [entityLookupMixin],
    data:function()
    {
        return{
            dashboardState: dashboardData.dashboardState
        }
    },
    computed:{
        dashboardPlugins:{
            get: function()
            {
                return ['SpecimenStatus']; //todo org-->user custom data parse
            }
        }
    },
    methods:{
        scanLookup: function(action, value)
        {
            var vm = this;
            switch(action)
            {
                case 'scan':
                    vm.lookupSpecimenByBarcode(vm, value);
                    break;
                case 'lookup':
                default:
                    break;
            }
        },

        lookupSpecimenByBarcode: function(vm, specimenBarcodeValue)
        {
            axios.get('/api/Barcode/' + specimenBarcodeValue + '/' + vm.organization.nameKey).then(response =>
                vm.$set(vm.dashboardState, 'barcode', response.data)
                ).then(function() { //temp
                    var guid = vm.dashboardState.barcode.customData.accessionGuid;
                    axios.get('/api/Accessioning/' + guid + '/' + vm.organization.nameKey).then(function(response){
                        vm.setAccession(vm, response.data.accession);
                        vm.setCurrentLab(vm, response.data.accession);
                        vm.setCurrentClient(vm, response.data.accession);
                        vm.setCurrentPatient(vm, response.data.accession);
                        vm.setCurrentSpecimen(vm, response.data.accession);
                    }).catch(err => {console.log(err)})
                })
        },

        setAccession: function(vm, accession)
        {
            vm.$set(vm.dashboardState, 'accession', accession);
        },

        setCurrentSpecimen: function(vm, accession)
        {
            if(accession.specimens.length > 0)
            {
                vm.$set(vm.dashboardState, 'currentSpecimen', 
                    accession.specimens.find(function(s) {
                        return (typeof vm.dashboardState.barcode.customData.specimenGuids ==='undefined' || vm.dashboardState.barcode.customData.specimenGuids.length===0) ? true : s.guid === vm.dashboardState.barcode.customData.specimenGuids[0];
                    }));
            }
        },

        setCurrentLab: function(vm, accession)
        {
            vm.currentLab = vm.lookup('lab', accession.orderingLabId, vm.labs);
        },

        setCurrentClient: function(vm, accession){
            vm.currentClient = vm.lookup('client', accession.clientId, vm.clients);
        },

        setCurrentPatient: function(vm, accession)
        {
            vm.currentPatient = vm.lookup('patient', accession.patientId, vm.patients);
        }
    }
};