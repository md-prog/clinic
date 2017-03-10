<template>
    <div class="container-fluid pl-0 pr-0">
        <div class="card card-accent-primary card-compact">
            <div class="card-header card-compact">                
                <router-link class="page-link bg-gray-light" :to="{ name: 'Edit Accession', params: { id: accession.id, orgNameKey: organization.nameKey }}">
                    <i class="fa fa-edit"></i> Edit <span class="accessionLabel">Accession</span> # {{accession.id}} - {{accession.createdDate | localeDate}}
                </router-link>                 
            </div>
            <div class="card-block card-compact">
                <div class="row m-0">
                    <!--v-bind:class="col.class"-->
                    <div class="col-sm-6 m-0 p-0">
                        <div class="card card-compact card-no-outer-border">
                            <div class="card-header">General</div>
                            <div class="card-block wrap-unset">
                                <div class="row m-0">
                                    <div class="col-sm-auto mr-1">
                                        <label v-bind:for="'accLab' + accession.id + accession.orderingLabId" class="label-black">
                                            <strong>Ordered At</strong>:
                                        </label>
                                    </div>
                                    <div class="col-sm-auto" v-bind:id="'accLab' + accession.id + accession.orderingLabId">
                                        <div class="m-0 p-0">
                                            {{lookup('lab',accession.orderingLabId,this.labs).name}}
                                        </div>
                                    </div>
                                </div>
                                <div class="row m-0">
                                    <div class="col-sm-auto mr-1">
                                        <label v-bind:for="'accClient' + accession.id + accession.clientId" class="label-black">
                                            <strong><span class="clientLabel">Client</span></strong>:
                                        </label>
                                    </div>
                                    <div class="col-sm-auto" v-bind:id="'accClient' + accession.id + accession.clientId">
                                        <div class="m-0 p-0">
                                            {{lookup('client',accession.clientId,this.labs).name}}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 m-0 p-0">
                        <div class="card card-compact card-no-outer-border">
                            <div class="card-header">Specimens/Cases</div>
                            <div class="card-block wrap-unset">
                                <div class="row m-0">
                                    <div class="col-sm-auto mr-1">
                                        <label v-bind:for="'accSpecimenCount' + accession.id" class="label-black">
                                            <strong><span class="specimensLabel">Specimens</span></strong>:
                                        </label>
                                    </div>
                                    <div class="col-sm-auto" v-bind:id="'accSpecimenCount' + accession.id">
                                        <div class="m-0 p-0">
                                            {{accession.specimens.length}}
                                        </div>
                                    </div>
                                </div>
                                <div class="row m-0">
                                    <div class="col-sm-auto mr-1">
                                        <label v-bind:for="'accCaseCount' + accession.id" class="label-black">
                                            <strong><span class="casesLabel">Cases</span></strong>:
                                        </label>
                                    </div>
                                    <div class="col-sm-auto" v-bind:id="'accCaseCount' + accession.id">
                                        <div class="m-0 p-0">
                                            N/A
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
    }
</script>