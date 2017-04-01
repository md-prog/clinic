import ScanLookup from '../tools/ScanLookup.vue';
import SpecimenStatus from '../plugins/dashboardCards/SpecimenStatus.vue';
import dashboardData from './SpecimenTrackingDashboard.vue.data.js';

module.exports = {
    name:'SpecimenTrackingDashboard',
    components: {
        ScanLookup,
        SpecimenStatus
    },
    props:{
        prop_organization: Object,
        prop_user: Object,
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
                    vm.$set(this.dashboardState, 'currentSpecimen', this.lookupSpecimenByBarcode(value));
                    break;
                case 'lookup':
                default:
                    break;
            }
        },

        lookupSpecimenByBarcode: function(specimenBarcodeValue)
        {
            return new Object(); //todo api
        }
    }
};