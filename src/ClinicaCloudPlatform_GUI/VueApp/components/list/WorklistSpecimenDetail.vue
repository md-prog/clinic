<template>
    <div class="container-fluid pl-0">
        <div class="card card-accent-primary card-compact">
            <div class="card-header card-compact">{{specimen.id}} - {{specimen.type}}</div>
            <div class="card-block card-compact">
                <div v-for="row in organization.customData.specimenAccessionSections.rows" class="row m-0">
                    <!--v-bind:class="col.class"-->
                    <div v-for="col in row.cols" v-bind:class="col.class">
                        <div class="card card-compact card-no-outer-border">
                            <div class="card-header card-compact">{{col.sectionName}}</div>
                            <div class="card-block card-compact wrap-unset">
                                <div class="row m-0" v-for="att in getSpecimenAttributesBySection(col.sectionName, specimen.type)">
                                    <div class="col-sm-auto"><label for="attValue" class="label-black"><strong>{{att.name}}</strong>:</label></div>
                                    <div class="col-sm-auto ml-1" id="attValue">
                                        <div v-if="Array.isArray(currentSpecimenAttributeValue(specimen, att.name, false))" class="row m-0 p-0">
                                            <div v-for="value in currentSpecimenAttributeValue(specimen, att.name, false)" class="col-sm-12 m-0 p-0">
                                                {{value.name}}
                                            </div>
                                        </div>
                                        <div v-else class="m-0 p-0">
                                            {{currentSpecimenAttributeValue(specimen, att.name, false).name}}
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

    import specimenState from './WorklistSpecimenDetail.vue.data.js';

    import customDataHelpersMixin from '../../assets/js/mixins/customDataHelpers.js';

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
    }
</script>