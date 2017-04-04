<template>
    <div class="card">
        <div class="card-header card-header-primary">
            <span class="patientDetailsLabel">Patient/Subject Details</span>
            <div class="float-right text-white config-info">To prevent duplicate entries, please search before entering a new record.</div>
        </div>
        <div class="card-block">
            <div class="form-group">
                <!--v-if="typeof(this.patient) != 'undefined'">-->
                <label for="patientName" class="patientLabel labelAbove">Patient</label>
                <div class="row row-center">
                    <div v-bind:class="searchBoxWidth">
                        <multiselect id="patientName"
                                      :options="this.prop_patients"
                                      track-by="id"
                                      label="fullName"
                                      :option-height="104"
                                      :searchable="true"
                                      :custom-label="customPatientDropdownLabel"
                                      :show-labels="false"
                                      :internal-search="true"
                                      :close-on-select="true"
                                      :allow-empty="true"
                                      placeholder="Type to Search..."
                                      v-on:input="patientChanged"
                                      v-on:search-change="patientSearched = true"
                                      v-model="patientState.patient">
                            <span slot="noResult">No Patients Found.</span>
                            <template slot="option" scope="props">
                                <div :id="props.option.id">{{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}</div>
                            </template>
                        </multiselect>
                    </div>
                  <div class="col-1 col-auto px-0" v-show="this.allowEditSave || this.patientSearched">
                    <div class="tooltipSource">
                    <button class="btn-sm btn-info " v-on:click="addNewPatient">
                      <i class="fa fa-plus"></i>
                    </button>
                    <span class="tooltiptext">Add Patient</span>
                    </div>
                  </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-6 col-auto">
                        <label for="firstNameField" class="labelAbove">First Name</label>
                        <input id="firstNameField" type="text" v-model="patientState.patient.firstName" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                    <div class="form-group col-lg-6 col-auto">
                        <label for="lastNameField" class="labelAbove">Last Name</label>
                        <input id="lastNameField" type="text" v-model="patientState.patient.lastName" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                </div>
              <button class="btn btn-info" v-on:click="this.detailsCollapsed = !this.detailsCollapsed">Patient Details</button>
              <transition name="fade">
                <div class="row" v-show="!this.detailsCollapsed">
                    <div class="form-group col-lg-4 col-auto">
                        <label for="ssnField" class="labelAbove">SSN</label>
                        <input id="ssnField" type="text" v-model="patientState.patient.ssn" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                    <div class="form-group col-lg-4 col-auto">
                        <label for="dobField" class="labelAbove">DOB</label>
                        <div id="dobField" class="datefield text-nowrap">
                            <input id="month" type="text" maxlength="2" placeholder="MM" v-model.number="computedDobMonth" v-bind:disabled="!this.allowEditSave" />/
                            <input id="day" type="text" maxlength="2" placeholder="DD" v-model.number="computedDobDay" v-bind:disabled="!this.allowEditSave" /> /
                            <input id="year" type="text" maxlength="4" placeholder="YYYY" v-model.number="computedDobYear" v-bind:disabled="!this.allowEditSave" />
                        </div>
                    </div>
                    <div class="form-group col-lg-4 col-auto">
                        <label for="mrnField" class="labelAbove">MRN</label>
                        <input id="mrnField" type="text" v-model="patientState.mrn" class="form-control"
                               v-bind:disabled="!this.allowEditSave" />
                    </div>
                </div>
                </transition>
                <div class="row">
                    <div class="col-lg-6 col-auto">
                        <button class="btn btn-info w-100"
                                v-on:click="uploadDocument('PatientConsent')">
                            <i class="fa fa-paperclip"></i>
                            Attach Consent
                        </button>
                    </div>
                    <div class="col-lg-6 col-auto">
                        <button v-if="this.allowEditSave"
                                class="btn btn-info w-100"
                                v-on:click="savePatient">
                            <i class="fa fa-save"></i>
                            Save Patient
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script src="./Patient.vue.js">

</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style> <!--not pulled in with the js import from node package for some reason.  put this at a top-level?-->