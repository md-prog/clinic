<template>
    <div id="accessioningMain" class="container-fluid p-lg-1 p-md-0 p-sm-0">
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
        <div v-if="loaded || isNew">
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-auto">
                    <div class="row">
                        <div class="col-sm-12">
                            <div v-if="isNew" class="card card-inverse card-primary">
                                <div class="card-block">
                                    <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                    <div class="text-uppercase font-weight-bold font-xs">New <span class="accessionLabel">Accession</span></div>
                                </div>
                            </div>
                            <div v-else class="card card-inverse card-primary">
                                <div class="card-block">
                                    <i class="icon-chemistry font-2xl mr-1 float-left"></i>
                                    <div class="text-uppercase font-weight-bold font-xs"><span class="accessionLabel">Accession</span> ID {{accessionState.accession.id}}</div>
                                    {{accessionState.accession.createdDate | prettyDate}}
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card card-inverse card-primary">
                                <div class="card-block card-compact">
                                    <i class="fa fa-print font-2xl mr-1 float-left"></i>
                                    <ul>
                                        <li>
                                            <a href="#printTravelDoc">Print Accession</a>
                                        </li>
                                        <li>
                                            <a href="#printLabels">Print Labels</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-auto">
                            <button type="button" class="btn btn-warning" v-on:click="saveAccession"><i class="fa fa-save"></i> Save and Launch</button>
                        </div>
                        <!--<div class="col-sm-auto">
                            <button type="button" class="btn btn-primary"><i class="fa fa-save" v-on:click="saveAccession"></i> Save</button>
                        </div>-->
                    </div>
                </div>
                <div class="col-lg-5 col-sm-auto">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <span class="clientDetailsLabel">Client/Source Details</span>
                        </div>
                        <div class="card-block">
                            <fieldset class="form-group">
                                <label for="clientName" class="clientLabel">Client</label>
                                <multiselect id="clientName"
                                             :options="accessionState.clients" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             placeholder="Type to Search..."
                                             v-on:select="clientChanged"
                                             v-bind:value="client">
                                </multiselect>
                                <label for="facilityName" class="facilityLabel">Facility</label>
                                <multiselect id="facilityName"
                                             :options="this.facilities" track-by="id" label="name"
                                             :searchable="true" :close-on-select="true"
                                             v-on:select="faciltyChanged"
                                             v-bind:value="facility"
                                             :loading="this.accessionState.isLoadingClientsAsync"
                                             placeholder="Select...">
                                </multiselect>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-sm-auto">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <span class="patientDetailsLabel">Patient/Subject Details</span>
                        </div>
                        <div class="card-block">
                            <div class="form-group">
                                <!--v-if="typeof(this.patient) != 'undefined'">-->
                                <label for="patientName" class="patientLabel">Patient</label>
                                <div class="float-right"><small>To prevent duplicate entries, please search before entering a new record.</small></div>
                                <multiselect id="patientName"
                                             :options="accessionState.patients" track-by="id" label="lastName" :option-height="104"
                                             :searchable="true" :close-on-select="true" :custom-label="customPatientDropdownLabel" :show-labels="false"
                                             placeholder="Type to Search..."
                                             v-on:select="patientChanged"
                                             v-bind:value="patient">
                                    <!--v-on:search-change="asyncGetPatients(organization)"
                                    :loading="this.accessionState.isLoadingPatientsAsync"-->
                                    <template slot="option" scope="props">
                                        <div>{{props.option.lastName}}, {{props.option.firstName}}<br />DOB: {{props.option.dob | prettyDate}}<br />SSN: {{props.option.ssn}}</div>
                                    </template>
                                </multiselect>
                                <div class="row">
                                    <div class="form-group col-lg-6 col-sm-auto">
                                        <label for="firstNameField">First Name</label>
                                        <input id="firstNameField" type="text" v-model="patient.firstName" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>
                                    <div class="form-group col-lg-6 col-sm-auto">
                                        <label for="lastNameField">Last Name</label>
                                        <input id="lastNameField" type="text" v-model="this.patient.lastName" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-lg-4 col-sm-auto">
                                        <label for="ssnField">SSN</label>
                                        <input id="ssnField" type="text" v-model="this.patient.ssn" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                    </div>
                                    <div class="form-group col-lg-4 col-sm-auto">
                                        <label for="dobField">DOB</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                            <input id="dobField" type="datetime" v-model="this.patient.dob" class="form-control" v-bind:disabled="!accessionState.patientsSearched" />
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-4 col-sm-auto">
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
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <span class="specimensLabel">Specimens</span>
                        </div>
                        <div class="card-block">
                            <div class="table-responsive">
                                <table id="specimenList" role="grid" class="table table-striped table-condensed">
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
                                                <a v-bind:href="'#collapse'+specimen.guid" data-toggle="collapse" data-parent="specimenAccordion"
                                                   v-on:click="setSpecimenAttributes(specimen)">Click</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>
                        <div class="card-footer">
                            <button class="btn btn-primary float-right" @v-on:click="addSpecimen"><i class="fa fa-plus-circle"></i> Add Specimen</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel-group card" id="specimenAccordian">
                        <div v-for="specimen in accessionState.accession.specimens" class="panel panel-default">
                            <div v-bind:id="'collapse'+specimen.guid" class="panel-collapse collapse in">
                                <div class="panel-heading card-header card-header-primary">
                                    <div class="panel-title">
                                        <span class="specimenLabel">Specimen</span> {{specimen.externalSpecimenID}} Details
                                        <div id="copySpecimenAttributes" class="btn-group float-right" data-toggle="buttons">
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
                                                <div class="card-header card-header-primary">
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
                                                                     v-bind:id="specimen.guid+'_'+att.name+'_'+att.type"
                                                                     deselect-label="Can't remove this value" track-by="id" label="name"
                                                                     placeholder="Select one" :options="att.options" :searchable="false" :allow-empty="false"
                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, true)"
                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                        </multiselect><!--"-->
                                                        <multiselect v-if="att.type=='multiple-large'"
                                                                     v-bind:id="specimen.guid+'_'+att.name+'_'+att.type"
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
    import debounce from 'lodash/debounce';

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
                var vm = this;
                axios.all([
                    axios.get('/api/Accessioning/' + id + '/' + orgNameKey),
                    axios.get('/api/Accessioning/Clients/' + orgNameKey),
                    axios.get('/api/Accessioning/Patients/' + orgNameKey)
                ]).then(axios.spread(function (accResponse, clientResponse, patientResponse) {
                    //...  this callback will be executed only when both requests are complete.
                    //console.log('User', userResponse.data);
                    //console.log('Repositories', reposResponse.data);
                    //}));
                    //axios.get('/api/Accessioning/' + id + '/' + orgNameKey).then( response  =>
                    //{
                    //var tempAccession = Object.assign({},this.accessionState.accession, response.data); //this should do a non-destructive assignment - wrong
                    //this.accessionState.accession = tempAccession;
                    //this.$set(this.accessionState, "accession", objectMerge(this.accessionState.accession, response.data.accession));
                    //this.$set(this.accessionState, "client", objectMerge(this.accessionState.client, response.data.client));
                    //this.$set(this.accessionState, "patient", objectMerge(this.accessionState.patient, response.data.patient));
                    //this.$set(this.accessionState, "facility", objectMerge(this.accessionState.facility, response.data.facility));
                    //this.$set(this.accessionState.patient, 'dob', moment(this.accessionState.patient.dob).format('M/D/YYYY')); //hack
                    //objectMerge(this.accessionState.accession, response.data.accession);
                    //this.accessionState.accession = response.data.accession;
                    Object.assign(vm.accessionState.accession, accResponse.data.accession);
                    Object.assign(vm.accessionState.clients, clientResponse.data);
                    Object.assign(vm.accessionState.patients, patientResponse.data);
                    //vm.getPatient(accResponse.data.accession.patientId, orgNameKey);
                    //vm.getClient(accResponse.data.accession.clientId, orgNameKey);
                    vm.$set(vm.accessionState, 'loaded', true);
                    vm.$set(vm.accessionState, 'patientsSearched', false);
                }
                    )).catch(err => {console.log(err)});
            },

            saveAccession: function(){
                //this.$set(this.accessionState.accession, 'facility', this.accessionState.client.);
                axios.post('/api/accessioning', {
                    accession: this.accessionState.accession,
                    orgCustomData: this.organization.customData,
                    userFullName: this.user.fullName,
                    userHref: this.user.href});
            },

            newAccession: function(){this.$set(this.accessionState,'isNew', true);},
            //debounce(
            asyncGetClients: function(org){
                this.accessionState.isLoadingClientsAsync = true;
                axios.get('/api/Accessioning/Clients/' + org.nameKey).then( response => {
                    Object.assign(this.accessionState.clients, response.data);
                    this.accessionState.isLoadingClientsAsync = false;
                }).catch(err=> {console.log(err)});
            },
            //, 500),
            //debounce(
            asyncGetPatients: function(org){
                this.accessionState.isLoadingPatientAsync = true;
                this.accessionState.patientsSearched = true;
                axios.get('/api/Accessioning/Patients/' + org.nameKey).then( response => {
                    Object.assign(this.accessionState.patients, response.data);
                    this.accessionState.isLoadingPatientsAsync = false;
                }).catch(err=> {console.log(err)});
            },
            //, 500),

            getPatient: function(org, id){
                axios.get('/api/Accessioning/Patients/' + org.nameKey + '/' + id).then( response => {
                    this.accessionState.patients.push(response.data);
                }).catch(err=> {console.log(err)});
            },

            getClient: function(org, id){
                axios.get('/api/Accessioning/Clients/' + org.nameKey + '/' + id).then( response => {
                    this.accessionState.clients.push(response.data);
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
                var specimenGuid = idParams[0];
                var attributeName = idParams[1];
                var attributeType = idParams[2];

                var multiple = attributeType == 'multiple-large' || attributeType == 'multiple-small';
                var specimen = this.accessionState.accession.specimens.find(function(s){return s.guid == specimenGuid});

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

    clientChanged: function(value, dropDownId){
        this.$set(this.accessionState.accession, 'clientId', value.id);
        this.$set(this.accessionState.accession, 'facilityId', value.facilities[0].id);
    },
    faciltyChanged: function(value, dropDownId){
        this.$set(this.accessionState.accession, 'facilityId', value.id);
    },
    patientChanged: function(value, dropDownId){
        this.$set(this.accessionState.accession, 'patientId', value.id);
    }
    },
    computed: {
            loaded: function() { return this.accessionState.loaded;},
            isNew: function() { return this.accessionState.isNew;},
            patient: function() {
                var pId = this.accessionState.accession.patientId;
                var pat = this.accessionState.patients.find(function (p) {return p.id == pId;});
                return pat;
            },
            client: function () {
                var cId = this.accessionState.accession.clientId;
                var cli = this.accessionState.clients.find(function (c) {return c.id == cId;});
                return cli;
            },
            facility: function () {
                var fId = this.accessionState.accession.facilityId;
                return this.facilities.find(function (f) {return f.id == fId;});
            },
            facilities: function() {
                var facilities = [{id:0, name:""}];
                var cId = this.accessionState.accession.clientId;
                var cli = this.accessionState.clients.find(function (c) {return c.id == cId;});
                if(typeof(cli)!='undefined')
                    facilities = cli.facilities;
                return facilities;
            }
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
                    var vm = this;
                    this.$nextTick(function() { postLoadActions(vm); });
                }
            },
    },
    mounted: function() {
        setupFormOverlays();
    }
    };

    function postLoadActions(vm)
    {
        hideModal();
        //$("#clientName").value = vm.client;
    }

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
