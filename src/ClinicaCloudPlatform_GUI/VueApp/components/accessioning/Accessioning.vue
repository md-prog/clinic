<template>
    <div id="accessioningMain" class="container-fluid p-lg-1 p-md-0 p-sm-0">
        <div id="loadingModal" tabindex="-1" class="modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-info" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        Stand By
                    </div>
                    <div class="modal-body text-center">
                        <h4>
                            <i class="fa fa-spinner fa-spin"></i> {{accessionState.currentAction}}
                            <span class="accessionLabel">Accession</span>
                            <span v-if="accessionState.currentAction != 'New'"> ID {{$route.params.id}}</span>
                        </h4>
                    </div>
                    <div class="modal-footer"></div>
                </div>
            </div>
        </div>
        <div v-if="accessionState.loaded">
            <div class="row">
                <div class="col-xl-2 col-sm-3">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card card-inverse card-primary">
                                <div class="card-block">
                                    <div v-if="accessionState.isNew" class="row">
                                        <div class="col-sm-12">
                                            <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                            <div class="text-uppercase font-weight-bold font-xs">New <span class="accessionLabel">Accession</span></div>
                                        </div>
                                    </div>
                                    <div v-else class="row">
                                        <div class="col-sm-12">
                                            <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                            <div class="text-uppercase font-weight-bold font-xs"><span class="accessionLabel">Accession</span> ID {{accessionState.accession.id}}</div>
                                            {{accessionState.accession.createdDate | prettyDate}}
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="dropdown w-100 mt-1">
                                                <button v-bind:enabled="validateSave()"
                                                        class="btn btn-info dropdown-toggle w-100"
                                                        type="button"
                                                        id="saveAccessionDropdown"
                                                        data-toggle="dropdown"
                                                        aria-haspopup="true"
                                                        aria-expanded="false">
                                                    <i class="fa fa-save font-2xl float-left"></i>
                                                    Save
                                                </button>
                                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="saveAccessionDropdown">
                                                    <div class="dropdown-item-info" v-on:click="saveAccession">Save and Launch</div>
                                                    <div class="dropdown-item-info" v-on:click="saveAccession">Save and Hold</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="dropdown w-100 mt-1">
                                                <button class="btn btn-info dropdown-toggle w-100"
                                                        type="button"
                                                        id="printDropdown"
                                                        data-toggle="dropdown"
                                                        aria-haspopup="true"
                                                        aria-expanded="false">
                                                    <i class="fa fa-print font-2xl float-left"></i>
                                                    Print
                                                </button>
                                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="printDropdown">
                                                    <div class="dropdown-item-info" v-on:click="printAccession">Print <span class="accessionLabel">Accession</span></div>
                                                    <div class="dropdown-item-info" v-on:click="printLabels">Print Labels</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-5 col-sm-9">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <span class="clientDetailsLabel">Accession Details</span>
                        </div>
                        <div class="card-block">
                            <div class="form-group">
                                <label for="clientName" class="clientLabel labelAbove">Institution</label>
                                <multiselect v-if="accessionState.loaded" id="clientName"
                                             :options="accessionState.clients" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Type to Search..."
                                             v-model="client">
                                </multiselect>
                                <label for="facilityName" class="facilityLabel labelAbove">Facility</label>
                                <multiselect v-if="accessionState.loaded" id="facilityName"
                                             :options="this.facilities" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             v-model="facility"                                             
                                             placeholder="Select..."><!--v-on:select="faciltyChanged"
                                                                        v-bind:value="facility"
                                                                         :loading="this.accessionState.isLoadingClientsAsync"-->
                                </multiselect>
                            </div>
                            <div class="form-group">
                                <label for="labName" class="labLabel labelAbove">Received At</label>
                                <multiselect v-if="accessionState.loaded" id="labName"
                                             :options="accessionState.labs" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Type to Search..."
                                             v-model="lab">
                                </multiselect>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-5 col-sm-12">
                    <Patient v-if="accessionState.loaded && organization.href != null"
                             :prop_patientId="accessionState.isNew ? 0 : accessionState.accession.patientId"
                             :prop_mrn="accessionState.isNew ? '' : accessionState.accession.mrn"
                             :prop_organization="this.organization"
                             :prop_user="this.user"
                             :prop_patients="this.accessionState.patients"
                             v-on:new="patient_changed"
                             v-on:changed="patient_changed" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <Specimens v-if="accessionState.loaded" :specimens="accessionState.accession.specimens"
                               :organization="organization"
                               v-on:changed="specimens_changed">
                    </Specimens>
                </div>
            </div>
        </div>
    </div>
</template>
<script src="./Accessioning.vue.js">

</script>
<style>

</style>
