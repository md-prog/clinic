    import accessionDetailState from './WorklistAccessionDetail.vue.data.js';

    import customDataHelpersMixin from '../../assets/js/mixins/customDataHelpers.js';
    import worklistLookupMixin from '../../assets/js/mixins/worklistLookup.js';

    module.exports = {
        name: "WorklistAccessionDetail",
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
        data: function ()
        {
            return {
                //accession: accessionState.accession,
                options: accessionDetailState.options
            };
        },
        methods:{}
    };