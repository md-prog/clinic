<template>
    <div class="container-fluid pl-0 pr-0">
        <div class="card card-accent-primary card-compact">
            <div class="card-header card-compact">
                <router-link v-if="$route.name!=='Specimen Catalog'" class="page-link bg-gray-light font-weight-bold" :to="{ name: 'Edit Accession', params: { id: accession.id, orgNameKey: organization.nameKey }}">
                    <i class="fa fa-edit"></i> Edit <span class="accessionLabel">Accession</span> # {{accession.id}} - {{accession.createdDate | localeDate}}
                </router-link>
                <div v-else class="font-weight-bold">
                    Samples Received on {{accession.createdDate | localeDate}}
                </div>
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
                                        <label v-bind:for="'accClient' + accession.id + accession.clientId" class="label-black">
                                            <strong><span class="clientLabel">Institution</span></strong>:
                                        </label>
                                    </div>
                                    <div class="col-sm-auto" v-bind:id="'accClient' + accession.id + accession.clientId">
                                        <div class="m-0 p-0">
                                            {{lookup('client',accession.clientId,this.labs).name}}
                                        </div>
                                    </div>
                                </div>
                                <div class="row m-0">
                                    <div class="col-sm-auto mr-1">
                                        <label v-if="$route.name!=='Specimen Catalog'" v-bind:for="'accLab' + accession.id + accession.orderingLabId" class="label-black">
                                            <strong>Received At</strong>:
                                        </label>
                                        <label v-else v-bind:for="'accLab' + accession.id + accession.orderingLabId" class="label-black">
                                            <strong>Location</strong>:
                                        </label>
                                    </div>
                                    <div class="col-sm-auto" v-bind:id="'accLab' + accession.id + accession.orderingLabId">
                                        <div class="m-0 p-0">
                                            {{lookup('lab',accession.orderingLabId,this.labs).name}}
                                            <small v-if="$route.name==='Specimen Catalog'">(San Diego, CA)</small>
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

<script src="./AccessionInfo.vue.js">
   
</script>