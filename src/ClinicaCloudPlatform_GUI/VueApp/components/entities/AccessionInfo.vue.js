
import accessionInfoState from './AccessionInfo.vue.data.js';

import customDataHelpersMixin from '../../mixins/customDataHelpers.js';
import worklistLookupMixin from '../../mixins/worklistLookup.js';

module.exports = {
    name: "AccessionInfo",
    props:{
        organization: Object,
        accession: Object,
        clients: Array,
        labs: Array,
        patients: Array,
        doctors: Array
    },
    components: {},
    mixins: [customDataHelpersMixin, worklistLookupMixin],
    methods:{
        loadLookupData: function(){
            axios.all([
                axios.get('/api/Client/' + org.nameKey),
                axios.get('/api/Lab/' + org.nameKey),
                axios.get('/api/Doctor/' + org.nameKey),
                axios.get('/api/Patient/' + org.nameKey),
            ]).then(axios.spread(function (clientResponse, labResponse, doctorResponse, patientResponse) {
                vm.$set(vm.state, 'clients', clientResponse.data);
                vm.$set(vm.state, 'labs', clientResponse.data);
                vm.$set(vm.state, 'doctors', clientResponse.data);
                vm.$set(vm.state, 'patients', clientResponse.data);
            }
            )).catch(err => {console.log(err)});
        }
    }
}