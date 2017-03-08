<template>
    <div class="container-fluid pl-0">
        <div class="card card-accent-primary card-compact">
            <div class="card-header card-compact">{{case.id}} - {{case.type}}</div>
            <div class="card-block card-compact">
                <div v-for="row in organization.customData.caseAccessionSections.rows" class="row m-0">
                    <!--v-bind:class="col.class"-->
                    <div v-for="col in row.cols" v-bind:class="col.class">
                        <div class="card card-compact card-no-outer-border">
                            <div class="card-header card-compact">{{col.sectionName}}</div>
                            <div class="card-block card-compact wrap-unset">
                                <div class="row m-0" v-for="att in getcaseAttributesBySection(col.sectionName, case.type)">
                                    <div class="col-sm-auto mr-1"><label v-bind:for="'attValue' + case.id + att.name" class="label-black"><strong>{{att.name}}</strong>:</label></div>
                                    <div class="col-sm-auto" v-bind:id="'attValue' + case.id + att.name">
                                        <div v-if="Array.isArray(currentcaseAttributeValue(case, att.name, false))" class="row m-0 p-0">
                                            <div v-for="value in currentcaseAttributeValue(case, att.name, false)" class="col-sm-12 m-0 p-0">
                                                {{value.name}}
                                            </div>
                                        </div>
                                        <div v-else class="m-0 p-0">
                                            {{currentcaseAttributeValue(case, att.name, false).name}}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
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
            case: Object
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