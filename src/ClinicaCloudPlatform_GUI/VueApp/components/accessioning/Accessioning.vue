<template>
    <div id="accessioningMain" class="container-fluid pt-2">
        <div id="loadingModal" tabindex="-1" class="modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-info" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        Loading
                    </div>
                    <div class="modal-body text-center">
                        <h4><i class="fa fa-spinner fa-spin"></i> Loading <span class="accessionLabel">Accession</span> ID {{$route.params.id}}</h4>
                    </div>
                    <div class="modal-footer"></div>
                </div>
            </div>
        </div>
        <div v-if="accessionState.loaded || accessionState.isNew" class="animated fadeIn">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <span v-if="accessionState.isNew" class="font-weight-bold font-size-larger">New <span class="accessionLabel">Accession</span></span>
                            <span v-else class="font-weight-bold font-size-larger"><span class="accessionLabel">Accession</span> {{accessionState.accession.id}}</span>
                        </div>
                        <div class="card-block">
                            <span class="config-info">
                                Labels on this screen can be overridden by organization CSS.<br />
                                Each section can also be hidden by JSON, but defaults must often be specified (e.g. default client).
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <span class="clientDetailsLabel">Client/Source Details</span>
                        </div>
                        <div class="card-block">
                            <fieldset class="form-group">
                                <label for="clientName" class="clientLabel">Client</label>
                                <multiselect id="clientName" v-model="accessionState.accession.client"
                                             :options="accessionState.clients" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Select..."
                                             @search-change="asyncGetClients(organization)"
                                             :loading="accessionState.isLoadingClientsAsync">
                                </multiselect>
                                <label for="clientName" class="facilityLabel">Facility</label>
                                <multiselect id="facilityName" v-model="accessionState.accession.facility"
                                             :options="accessionState.accession.client.facilities" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Select...">
                                </multiselect>
                            </fieldset>
                            <label>{{accessionState.accession.client.name}}</label>
                            <label>{{accessionState.accession.client.id}}</label>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <span class="patientDetailsLabel">Patient/Subject Details</span>
                        </div>
                        <div class="card-block">
                            <div class="form-group">
                                <label for="patientName" class="patientLabel">Patient</label>
                                <span class="config-info-top">To prevent duplicate entries, please search before entering a new record.</span>
                                <multiselect id="patientName" v-model="accessionState.accession.patient"
                                             :options="accessionState.patients" track-by="id" label="lastName" :option-height="104"
                                             :searchable="true" :close-on-select="true" :custom-label="customPatientDropdownLabel" :show-labels="false"
                                             placeholder="Select..."
                                             @search-change="asyncGetPatients(organization)"
                                             :loading="accessionState.isLoadingPatientsAsync">
                                    <template slot="option" scope="props">
                                        <div>{{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}</div>
                                    </template>
                                </multiselect>
                                <div class="row">
                                    <div class="form-group col-sm-6">
                                        <label for="firstNameField">First Name</label>
                                        <input id="firstNameField" type="text" v-model="accessionState.accession.patient.firstName" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>
                                    <div class="form-group col-sm-6">
                                        <label for="lastNameField">Last Name</label>
                                        <input id="lastNameField" type="text" v-model="accessionState.accession.patient.lastName" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-4">
                                        <label for="ssnField">SSN</label>
                                        <input id="ssnField" type="text" v-model="accessionState.accession.patient.ssn" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>
                                    <div class="form-group col-sm-4">
                                        <label for="dobField">DOB</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                            <input id="dobField" type="datetime" v-model="accessionState.accession.patient.dob" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                        </div>
                                    </div>
                                    <div class="form-group col-sm-4">
                                        <label for="mrnField">MRN</label>
                                        <input id="mrnField" type="text" v-model="accessionState.accession.mrn" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <span class="specimensLabel">Specimens</span>
                        </div>
                        <div class="card-block">
                            <div class="col-sm-12">
                                <table id="specimenList" role="grid" class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Barcode</th>
                                            <th>Type</th>
                                            <th>Transport</th>
                                            <th>Collection Date</th>
                                            <th>Detail</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="specimen in accessionState.accession.specimens">
                                            <td>{{specimen.externalSpecimenID}}</td>
                                            <td>TODO</td>
                                            <td>{{specimen.type}}</td>
                                            <td>{{specimen.transport}}</td>
                                            <td>{{specimen.collectionDate}}</td>
                                            <td>
                                                <a v-bind:href="'#collapse'+specimen.id" data-toggle="collapse" data-parent="specimenAccordion"
                                                   v-on:click="setSpecimenAttributes(specimen)">Click</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="card-footer">
                            <button class="btn btn-primary float-right" @clicked="addSpecimen"><i class="fa fa-plus-circle"></i> Add Specimen</button>
                        </div>
                    </div>

                    <div class="panel-group card" id="specimenAccordian">
                        <div v-for="specimen in accessionState.accession.specimens" class="panel panel-default">
                            <div v-bind:id="'collapse'+specimen.id" class="panel-collapse collapse in">
                                <div class="panel-heading card-header">
                                    <div class="panel-title">
                                        <span class="specimenLabel">Specimen</span> {{specimen.externalSpecimenID}} Details
                                        <div id="copySpecimenAttributes" class="btn-group float-sm-right" data-toggle="buttons">
                                            <label class="btn btn-primary btn-sm">
                                                <input type="checkbox" autocomplete="off" name="true" /> Same as previous
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div v-if="specimen.attributesAreSet" class="panel-body card-block">
                                    <!---this section will become a component tuit suite-->
                                    <div v-for="row in organization.customData.specimenAccessionSections.rows" class="row">
                                        <div v-for="col in row.cols" v-bind:class="col.class">
                                            <div class="card">
                                                <div class="card-header">
                                                    {{col.sectionName}}
                                                </div>
                                                <div class="card-block">
                                                    <div v-for="att in getSpecimenAttributesBySection(col.sectionName, specimen.type)" class="form-group">
                                                        <label for="attributeInput">{{att.label}}</label>
                                                        <div v-if='att.type=="single-small"' id="attributeInput" class="btn-group" data-toggle="buttons">
                                                            <label v-for="option in att.options" class="btn btn-primary-deselected">
                                                                <input type="radio" autocomplete="off" name="option" v-bind:id="option.id"
                                                                       v-bind:checked="optionName = currentSpecimenAttributeValue(specimen, att.name, true)"
                                                                       v-on:click="updateSpecimenAttribute(specimen, att.name, option.id, false)" />
                                                                {{option.name}}
                                                            </label>
                                                        </div>
                                                        <div v-if="att.type=='multiple-small'" id="attributeInput" class="btn-group" data-toggle="buttons">
                                                            <label v-for="option in att.options" class="btn btn-primary-deselected">
                                                                <input type="checkbox" autocomplete="off" name="option" v-bind:id="option.id"
                                                                       v-bind:checked="currentSpecimenAttributeValue(specimen, att.name, false).includes(optionName)"
                                                                       v-on:click="updateSpecimenAttribute(specimen, att.name, option.id, true)" />
                                                                {{option.name}}
                                                            </label>
                                                        </div>
                                                        <multiselect v-if="att.type=='single-large'"
                                                                     v-bind:id="specimen.id+'_'+att.name+'_'+att.type"
                                                                     deselect-label="Can't remove this value" track-by="id" label="name"
                                                                     placeholder="Select one" :options="att.options" :searchable="false" :allow-empty="false"
                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, true)"
                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                        </multiselect><!--"-->
                                                        <multiselect v-if="att.type=='multiple-large'"
                                                                     v-bind:id="specimen.id+'_'+att.name+'_'+att.type"
                                                                     deselect-label="Can't remove this value" track-by="id" label="name"
                                                                     placeholder="Select one or more" :options="att.options" :searchable="true"
                                                                     :multiple="true" :allow-empty="false"
                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, false)"
                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                        </multiselect><!---->
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
        </div>
    </div>
</template>
<script>

    var modalActive = false;

    //import { mapGetters, mapActions} from 'vuex';
    import axios from 'axios'
    import Multiselect from 'vue-multiselect';
    import accessionData from './Accessioning.vue.data.js';
    import filter from '../../assets/js/setFilter.js';
    import objectMerge from 'object-merge';

    //require('../../assets/js/selectMany.js');

    module.exports = {
        name: "Accessioning",
        //template: "accessioningMain",
        components: {
            Multiselect
        },
        props: {
            user: Object,
            organization: Object
        },
        data: function ()
        {
            return {accessionState: accessionData.accessionState};
        },
        methods:{

            loadAccession: function(id, orgNameKey){
                axios.get('/api/Accessioning/Get/' + id + '/' + orgNameKey).then( response  =>
                {
                    //var tempAccession = Object.assign({},this.accessionState.accession, response.data); //this should do a non-destructive assignment - wrong
                    //this.accessionState.accession = tempAccession;
                    this.$set(this.accessionState, "accession", objectMerge(this.accessionState.accession, response.data));
                    this.accessionState.loaded = true;
                    this.accessionState.patientsSearched = false;
                    this.accessionState.accession.patient.dob = moment(this.accessionState.accession.patient.dob).format('M/D/YYYY'); //hack
                }
                    ).catch(err => {console.log(err)});
            },

            newAccession: function(){},

            asyncGetClients: function(org){
                this.accessionState.isLoadingClientsAsync = true;
                axios.get('/api/Accessioning/Clients/' + org.nameKey).then( response => {
                    Object.assign(this.accessionState.clients, response.data);
                    this.accessionState.isLoadingClientsAsync = false;
                }).catch(err=> {console.log(err)});
            },

            asyncGetPatients: function(org){
                this.accessionState.isLoadingPatientAsync = true;
                this.accessionState.patientsSearched = true;
                axios.get('/api/Accessioning/Patients/' + org.nameKey).then( response => {
                    Object.assign(this.accessionState.patients, response.data);
                    this.accessionState.isLoadingPatientsAsync = false;
                }).catch(err=> {console.log(err)});
            },

            addSpecimen: function(){},

            getSpecimenAttributesBySection: function(sectionName, specimenType){
                var attr = new Array();
                var allAttr = this.organization.customData.specimenDefinitions.filter(
                    function(s) {return s.type == specimenType;} )[0].accessionAttributes; //.selectMany(d=> d.accessionAttributes);
                return allAttr.filter(function(a) {return a.section == sectionName});
                //var uniqueSet = filter(new Set(allAttr), a => a.section == sectionName);
                //return Array.from(uniqueSet);
            },

            ///apply organization custom data to new and existing specimens (additive)
            setSpecimenAttributes: function(specimen)
            {
                if(specimen.attributesAreSet)
                    return;

                var vueVm = this;
                var specAttributes = vueVm.organization.customData.specimenDefinitions.filter(
                    function(s) {return s.code == specimen.code;} )[0].accessionAttributes;

                for(let attribute of specAttributes){

                    if(typeof specimen.customData === "undefined"){
                        vueVm.$set(specimen, "customData", {});
                    }

                    if(specimen.customData == null){
                        vueVm.$set(specimen, "customData", {});
                    }

                    if(typeof specimen.customData.attributes === "undefined"){
                        vueVm.$set(specimen.customData, "attributes", []);
                    }

                    if(typeof specimen.customData.attributes.find(function(a) {return a.name == attribute.name;})  === "undefined"){
                        if(attribute.type=='multiple-large' || attribute.type == 'multiple-small')
                            specimen.customData.attributes.push({name: attribute.name, value: []});
                        else
                            specimen.customData.attributes.push({name:attribute.name, value: ""});
                    }

                    vueVm.$set(specimen, "attributesAreSet", true);
                }
            },

            updateSpecimenAttributeFromMultiSelect: function (value, id){
                var idParams = id.split('_');
                var specimenId = idParams[0];
                var attributeName = idParams[1];
                var attributeType = idParams[2];

                var multiple = attributeType == 'multiple-large' || attributeType == 'multiple-small';
                var specimen = this.accessionState.accession.specimens.find(function(s){return s.id == specimenId});

                this.updateSpecimenAttribute(specimen, attributeName, value, multiple);
            },

            updateSpecimenAttribute: function(specimen, attributeName, attributeValue, singleToMultiple){
                var attr = specimen.customData.attributes.find(function(a) {return a.name == attributeName});
                if(singleToMultiple)
                {
                    var currentSet = new Set(Array.isArray(attr.value ? attr.value : [].concat(attr.value)));
                    var newSet = new Set(Array.isArray(attributeValue ? attributeValue : [].concat(attributeValue)));
                    attributeValue = Array.from(new Set([...currentSet, ...newSet]));
                }
                this.$set(attr, "value", attributeValue); //being safe
            },

            currentSpecimenAttributeValue: function(specimen, attributeName, expectsSingle){
                var attributeOnSpecimen = specimen.customData.attributes.find(function(a) {return a.name == attributeName});
                var value = attributeOnSpecimen.value;
                if(expectsSingle && Array.isArray(value))
                    value = value[0];
                return value;
            },

            dateFormat: function(date) {return this.$options.filters.prettyDate(date)},

            customPatientDropdownLabel: function ({id, firstName, lastName, dob, ssn}) {
                return 'Name: ' + firstName + ' ' + lastName + ', DOB: ' + this.dateFormat(dob) + ', SSN: ' + ssn},
    },
    computed: {
        loaded: function() { return this.accessionState.loaded;} //for the watcher below
        //isNew: function() {return this.accessionState.isNew},
    },
    created: function() {
        if (typeof this.$route.params.id === 'undefined')
            this.newAccession();
        else if(!this.accessionState.loaded|| this.accessionState.accession.id != this.$route.params.id){
            modalActive = true;
            this.loadAccession(this.$route.params.id, this.$route.params.orgNameKey);
        }
    },
    watch:{
            loaded: function() {
                if (this.loaded)
                {
                    this.$nextTick(function() { hideModal(); });
                }
            }
    },
    mounted: function() {
        setupFormOverlays();
    }
    };

    function setupFormOverlays(){
        if(modalActive)
            $("#loadingModal").modal("show");
        else
            postModalActions()
    };

    function hideModal()
    {
        $("#loadingModal").modal("hide");
        postModalActions();
    }

    function postModalActions()
    {
        setDatePickers();

        //$('#specimenList').DataTable( {
        //    responsive: true,
        //    paging:false,
        //    searching: false,
        //    info:false
        //} );
    }

    function setDatePickers()
    {
        $('#dobField').daterangepicker({
            "singleDatePicker": true,
            "timePicker": false,
            locale: {
                format: 'MM/DD/YYYY h:mm A'
            }
        });
    }

</script>
<style>
</style>
