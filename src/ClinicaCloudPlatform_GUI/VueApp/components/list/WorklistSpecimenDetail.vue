<template>
    <div class="container-fluid pl-0">
        <div class="card card-accent-primary card-compact">
            <div class="card-header bg-gray-lightest font-weight-bold">
                Specimen # {{specimen.id}} - {{specimen.type.type}} {{specimen.transport == null || specimen.transport.name == null ? '' : '| ' + specimen.transport.name}}
                <div class="float-right" v-if="$route.name==='Specimen Catalog'">
                    {{'USD ' + currentSpecimenAttributeValue(specimen, 'cost', false) !== '' ? currentSpecimenAttributeValue(specimen, 'cost', false) : '40'}}
                    <button class="btn btn-info btn-sm">Purchase Specimen</button>
                </div>
            </div>

            <div class="card-block">
                <div class="row m-0" v-if="$route.name!=='Specimen Catalog'">
                    <div class="col-2 m-0 p-0">
                        <label class="label-black">Workflow Status:</label>
                    </div>
                    <div v-if="specimen.id % 2 === 0" class="col-3 m-0 p-0">
                        <div class="row">
                            <div class="col-12 text-warning">Received (0)</div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="progress">
                                    <div class="progress-bar bg-warning" style="width: 20%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div v-if="specimen.id % 2 !== 0" class="col-3 m-0 p-0">
                        <div class="row">
                            <div class="col-12 text-success">Archived (-1)</div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="progress">
                                    <div class="progress-bar bg-success" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-2 m-0 p-0"><div style="width:20px"></div></div>
                    <div class="col-5 m-0 p-0">
                        <div class="row">
                            <div class="col-auto">
                                <label class="label-black">Location: </label>
                            </div>
                            <div v-if="specimen.id % 2 === 0" class="col-auto">
                                Building 2 Refrigerator 5 Top Shelf
                            </div>
                            <div v-if="specimen.id % 2 !== 0" class="col-auto">
                                Logistics Irvine Station 2
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-auto">
                                <label class="label-black">Last Contact: </label>
                            </div>
                            <div v-if="specimen.id % 2 === 0" class="col-auto">
                                Mary Smith 3/14/2017 9:26
                            </div>
                            <div v-if="specimen.id % 2 !== 0" class="col-auto">
                                John Williams 3/12/2017 13:10
                            </div>
                        </div>
                    </div>
                </div>
                <div v-for="row in organization.customData.specimenAccessionSections.rows" class="row m-0">
                    <!--v-bind:class="col.class"-->
                    <div v-for="col in row.cols" v-bind:class="col.class + ' m-0 p-0'">
                        <div class="card card-compact card-no-outer-border">
                            <div class="card-header">{{col.sectionName}}</div>
                            <div class="card-block wrap-unset">
                                <div class="row m-0" v-for="att in getSpecimenAttributesBySection(col.sectionName, specimen.type.code)">
                                    <div class="col-auto mr-1"><label v-bind:for="'attValue' + specimen.id + att.name" class="label-black"><strong>{{att.label}}</strong>:</label></div>
                                    <div class="col-auto" v-bind:id="'attValue' + specimen.id + att.name">
                                        <div v-if="Array.isArray(currentSpecimenAttributeValue(specimen, att.name, false))" class="row m-0 p-0">
                                            <div v-for="value in currentSpecimenAttributeValue(specimen, att.name, false)" class="col-12 m-0 p-0">
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
</template>

<script src="./WorklistSpecimenDetail.vue.js">

</script>