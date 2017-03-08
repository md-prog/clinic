<template>
    <div class="container-fluid pl-0">
        <div class="card card-accent-primary card-compact">
            <div class="card-header card-compact"><span class="caseLabel">Case</span> # {{_case.id}} - {{_case.type}}</div>
            <div class="card-block card-compact">
                
            </div>
        </div>
    </div>

    </div>
</template>

<script>

    import caseState from './WorklistCaseDetail.vue.data.js';

    import customDataHelpersMixin from '../../assets/js/mixins/customDataHelpers.js';

    module.exports = {
        name: "WorklistCaseDetail",
        props:{
            organization: Object,
            _case: Object
        },
        components: {},
        mixins: [customDataHelpersMixin],
        data: function ()
        {
            return {
                //case: caseState.case,
                options: caseState.options
            };
        },
        methods:{}
    }
</script>