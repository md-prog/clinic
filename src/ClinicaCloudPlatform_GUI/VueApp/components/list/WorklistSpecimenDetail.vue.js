
import specimenState from './WorklistSpecimenDetail.vue.data.js';

import customDataHelpersMixin from '../../mixins/customDataHelpers.js';

module.exports = {
    name: "WorklistSpecimenDetail",
    props:{
        organization: Object,
        specimen: Object
    },
    components: {},
    mixins: [customDataHelpersMixin],
    data: function ()
    {
        return {
            //specimen: specimenState.specimen,
            options: specimenState.options
        };
    },
    methods:{}
};