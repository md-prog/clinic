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
                    <div :id="props.option.id">
                      {{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}
                    </div>
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
            <div class="form-group" v-if="this.allowEditSave">
              <div class="label labelAbove cursor-pointer" v-on:click="toggleDetailsVisibility">
                <label class="labelCollapisblePanel cursor-pointer">Patient Details</label>
                <i class="fa" v-bind:class="expandPanelArrow"></i>
              </div>
              <transition name="collapse-transition">
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

                  <!--Demographic Section -->
                  <div v-for="att in getPatientDemographicDetails()" class="form-group col-lg-12 col-auto">
                    <label v-bind:for="att.name+'_'+att.type" class="labelAbove">{{att.label}}</label>
                    <div class="input-group">

                      <div v-if="att.type==='single-small'" v-bind:id="att.name+'_'+att.type" class="btn-group pl-1" data-toggle="buttons">
                        <label v-for="option in att.options"
                               v-bind:class="option.id === currentPatientDetailValue(att.name, true).id ? 'btn btn- btn-radio active' : 'btn btn-radio'"
                               v-on:click="updatePatientDetailValue(att.name, option, true)">
                          <input type="radio" autocomplete="off" name="option" v-bind:id="option.id"
                                 v-bind:checked="option.id === currentPatientDetailValue(att.name, true).id"
                                 v-on:change="updatePatientDetailValue(att.name, option, false)" />
                          {{option.name}}
                        </label>
                      </div>

                      <div v-if="att.type==='multiple-small'" v-bind:id="att.name+'_'+att.type" class="btn-group pl-1" data-toggle="buttons">
                        <label v-for="option in att.options" class="btn btn-radio"
                               v-bind:class="currentPatientDetailValue(att.name, false).find(function(v) {option.id === v.id}) ? 'btn btn-radio active' : 'btn btn-radio'"
                               v-on:click="updatePatientDetailValue(att.name, option, true)">
                          <input type="checkbox" autocomplete="off" name="option" v-bind:id="option.id"
                                 v-bind:checked="currentPatientDetailValue(att.name, false).find(function(v) {option.id === v.id})"
                                 v-on:change="updatePatientDetailValue(att.name, option, true)" />
                          {{option.name}}
                        </label>
                      </div>

                      <multiselect v-if="att.type==='single-large'"
                                   v-bind:id="att.name+'_'+att.type"
                                   deselect-label="Can't remove this value"
                                   track-by="id" label="name"
                                   placeholder="Select one" :options="att.options" :searchable="false" :allow-empty="true"
                                   v-bind:value="currentPatientDetailValue(att.name, true)"
                                   v-on:input="updatePatientDetails">
                      </multiselect>


                      <multiselect v-if="att.type==='multiple-large'"
                                   v-bind:id="att.name+'_'+att.type"
                                   track-by="id" label="name"
                                   placeholder="Select one or more" :options="att.options" :searchable="true"
                                   :multiple="true" :allow-empty="true"
                                   v-bind:value="currentPatientDetailValue(att.name, false)"
                                   v-on:input="updatePatientDetails">
                      </multiselect>

                      <span v-if="att.informationTooltip != null" class="input-group-addon-clean-small-icon"
                            data-toggle="tooltip" data-placement="top" v-bind:title="att.informationTooltip">
                        <a v-if="att.informationSource != null" v-bind:href="att.informationSource" target="_new">
                          <i class="fa fa-info"></i>
                        </a>
                        <i v-else="" class="fa fa-info"></i>
                      </span>
                    </div>
                  </div>
                </div>
              </transition>
            </div>
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