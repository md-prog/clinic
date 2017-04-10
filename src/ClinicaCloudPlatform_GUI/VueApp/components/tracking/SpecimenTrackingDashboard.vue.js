import ScanLookup from '../tools/ScanLookup.vue';
import SpecimenStatus from '../plugins/dashboardCards/SpecimenStatus.vue';
import dashboardData from './SpecimenTrackingDashboard.vue.data.js';
import axios from 'axios';

module.exports = {
    name:'SpecimenTrackingDashboard',
    components: {
        ScanLookup,
        SpecimenStatus
    },
    props:{
        organization: Object,
        user: Object,
    },
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
            axios.get('api/Barcode/' + vm.organization.nameKey + '/' + specimenBarcodeValue).then(response =>
                vm.$set(vm.dashboardState, 'barcode', response.data)
                ).then(function(){ //temp
                    var guid = vm.dashboardState.barcode.customData.accessionGuid;
                    axios.get('/api/Accessioning/' + guid + '/' + vm.organization.nameKey).then(response=>
                        vm.$set(vm.dashboardState, 'currentSpecimen', response.data.specimens[0])
                        )
                }).catch(err => {console.log(err)});
        }
    }
};