<template>
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <span class="specimensLabel">Specimens</span><div class="dropdown float-right">
                        <button class="btn btn-info btn-sm dropdown-toggle"
                                id="addSpecBtn" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fa fa-plus-circle"></i> Add Specimen
                        </button>
                        <div class="dropdown-menu" aria-labelledby="addSpecBtn">
                            <div class="dropdown-item" v-for="spec in organizationSpecimenTypes" v-on:click="addSpecimen(spec)">{{spec.type}}</div>
                        </div>
                    </div>
                </div>
                <div v-if="specimens.length > 0" class="card-block">
                    <div class="table-responsive">
                        <table id="specimenList" role="grid" class="table table-striped table-condensed table-gray">
                            <thead>
                                <tr>
                                    <th>Edit</th>
                                    <th>#</th>
                                    <th>ID</th>
                                    <th>Barcode</th>
                                    <th>Type</th>
                                    <th>Transport</th>
                                    <th>Collection Date</th>
                                    <th>Quantity</th>
                                    <!--<th>Received Date</th>-->
                                </tr>
                            </thead>
                            <tbody v-for="specimen in specimens">
                                <!--hopefully multiple tbodies won't be an issue - allowed in the html spec-->
                                <tr>
                                    <td>
                                        <button class="btn btn-info btn-sm"
                                                v-on:click="specimenClicked(specimen)">
                                            {{specimen === currentSpecimen ? 'Done' : 'Click to View/Edit'}}
                                        </button>
                                    </td>
                                    <td>{{specimen.id}}</td>

                                    <td v-if="specimen === currentSpecimen">
                                        <input type="text" v-model="specimen.externalSpecimenID" />
                                    </td>
                                    <td v-else>{{specimen.externalSpecimenID}}</td>

                                    <td v-if="specimen === currentSpecimen">
                                        <input type="text" placeholder="[Auto-generated if empty]" />
                                    </td>
                                    <td v-else></td>

                                    <td v-if="specimen === currentSpecimen">
                                        <multiselect placeholder="Select Type"
                                                     track-by="code"
                                                     label="type"
                                                     v-bind:options="organizationSpecimenTypes"
                                                     :searchable="false"
                                                     :multiple="false"
                                                     :allow-empty="false"
                                                     :selectLabel="''"
                                                     :selectedLabel="''"
                                                     :deselectLabel="''"
                                                     v-on:input="currentSpecimenTypeTransportChanged()"
                                                     v-model="specimen.type">
                                        </multiselect>
                                    </td>
                                    <td v-else>{{specimen.type.type}}</td>

                                    <td v-if="specimen === currentSpecimen">
                                        <multiselect placeholder="Select Transport"
                                                     track-by="code"
                                                     label="name"
                                                     :options="getSpecimenTransports(specimen.type.code)"
                                                     :searchable="false"
                                                     :multiple="false"
                                                     :allow-empty="false"
                                                     :selectLabel="''"
                                                     :selectedLabel="''"
                                                     :deselectLabel="''"
                                                     v-on:input="currentSpecimenTypeTransportChanged()"
                                                     v-model="specimen.transport">
                                        </multiselect>
                                    </td>
                                    <td v-else>{{specimen.transport.name}}</td>

                                    <td v-if="specimen === currentSpecimen">
                                        <!--NOTE v-model is computed property here, in case anything weird...-->
                                        <input type="text" v-model.lazy="currentSpecimen.collectionDate" class="dateTimePicker" />
                                    </td>
                                    <td v-else>{{specimen.collectionDate | localeDate}}</td>

                                    <td v-if="specimen === currentSpecimen">
                                        <input type="number" value="2" />
                                    </td>
                                    <td v-else><button class="btn btn-info btn-sm">2 like this - show all</button></td>
                                </tr>
                                <tr v-if="specimen === currentSpecimen">
                                    <td colspan="9" class="bg-faded">
                                        <div class="ml-1 mb-1 text-center">
                                            <span class="specimenLabel">Specimen</span>:
                                            {{specimen.id === -1 ? '(NEW)' : '# ' + specimen.id}}
                                            | {{(specimen.externalSpecimenID === "" || specimen.externalSpecimenID === null) ? '(No ID Set)' : specimen.externalSpecimenID}}
                                            | Code: {{specimen.code}}
                                        </div>
                                        <div v-bind:id="'collapse'+specimen.guid" class="row collapse m-0 p-0" role="tabpanel" v-bind:aria-labelledby="'heading'+specimen.guid">
                                            <div v-if="specimen.attributesAreSet" class="col-sm-12">
                                                <div v-for="row in organization.customData.specimenAccessionSections.rows" class="row">
                                                    <div v-for="col in row.cols" v-bind:class="col.class">
                                                        <div class="card">
                                                            <div class="card-header card-header-primary">
                                                                {{col.sectionName}}
                                                            </div>
                                                            <div class="card-block">
                                                                <div v-for="att in getSpecimenAttributesBySection(col.sectionName, specimen.type.code)" class="form-group">
                                                                    <!--could use a computed getter/setter property, and v-model, but, complicated by array and 'section'-->
                                                                    <label v-bind:for="specimen.guid+'_'+att.name+'_'+att.type" class="labelAbove">{{att.label}}</label>
                                                                    <div class="input-group">

                                                                        <input v-if="att.type==='smallText'" type="text" v-bind:id="specimen.guid+'_'+att.name+'_'+att.type" v-bind:value="att.value" v-on:change="updateSpecimenAttributeFromText" />

                                                                        <input v-if="att.type==='integer'" type="number" v-bind:id="specimen.guid+'_'+att.name+'_'+att.type" v-bind.number:value="att.value" v-on:change="updateSpecimenAttributeFromText" />

                                                                        <div v-if="att.type==='single-small'" v-bind:id="specimen.guid+'_'+att.name+'_'+att.type" class="btn-group pl-1" data-toggle="buttons">
                                                                            <label v-for="option in att.options"
                                                                                   v-bind:class="option.id === currentSpecimenAttributeValue(specimen, att.name, true).id ? 'btn btn- btn-radio active' : 'btn btn-radio'"
                                                                                   v-on:click="updateSpecimenAttribute(specimen, att.name, option, true)">
                                                                                <input type="radio" autocomplete="off" name="option" v-bind:id="option.id"
                                                                                       v-bind:checked="option.id === currentSpecimenAttributeValue(specimen, att.name, true).id"
                                                                                       v-on:change="updateSpecimenAttribute(specimen, att.name, option, false)" />
                                                                                {{option.name}}
                                                                            </label>
                                                                        </div>

                                                                        <div v-if="att.type==='multiple-small'" v-bind:id="specimen.guid+'_'+att.name+'_'+att.type" class="btn-group pl-1" data-toggle="buttons">
                                                                            <label v-for="option in att.options" class="btn btn-radio"
                                                                                   v-bind:class="currentSpecimenAttributeValue(specimen, att.name, false).find(function(v) {option.id === v.id}) ? 'btn btn-radio active' : 'btn btn-radio'"
                                                                                   v-on:click="updateSpecimenAttribute(specimen, att.name, option, true)">
                                                                                <input type="checkbox" autocomplete="off" name="option" v-bind:id="option.id"
                                                                                       v-bind:checked="currentSpecimenAttributeValue(specimen, att.name, false).find(function(v) {option.id === v.id})"
                                                                                       v-on:change="updateSpecimenAttribute(specimen, att.name, option, true)" />
                                                                                {{option.name}}
                                                                            </label>
                                                                        </div>

                                                                        <multiselect v-if="att.type==='single-large'"
                                                                                     v-bind:id="specimen.guid+'_'+att.name+'_'+att.type"
                                                                                     deselect-label="Can't remove this value"
                                                                                     track-by="id" label="name"
                                                                                     placeholder="Select one" :options="att.options" :searchable="false" :allow-empty="true"
                                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, true)"
                                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                                        </multiselect><!--"-->

                                                                        <multiselect v-if="att.type==='multiple-large'"
                                                                                     v-bind:id="specimen.guid+'_'+att.name+'_'+att.type"
                                                                                     track-by="id" label="name"
                                                                                     placeholder="Select one or more" :options="att.options" :searchable="true"
                                                                                     :multiple="true" :allow-empty="true"
                                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, false)"
                                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                                        </multiselect>

                                                                        <multiselect v-if="att.type==='civic-gene-api'"
                                                                                     v-bind:id="specimen.guid+'_'+att.name+'_multiple-large'"
                                                                                     track-by="id" label="name"
                                                                                     placeholder="Select one or more" :options="genes" :searchable="true"
                                                                                     :multiple="true" :allow-empty="true"
                                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, false)"
                                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                                        </multiselect>

                                                                        <span v-if="att.informationTooltip != null" class="input-group-addon-clean-small-icon"
                                                                              data-toggle="tooltip" data-placement="top" v-bind:title="att.informationToolTip">
                                                                            <a v-if="att.informationSource != null" v-bind:href="att.informationSource" target="_new">
                                                                                <i class="fa fa-info"></i>
                                                                            </a>
                                                                            <i v-else class="fa fa-info"></i>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

    import specimenData from './Specimens.vue.data.js';
    import Multiselect from 'vue-multiselect';
    import axios from 'axios';
    import debounce from 'lodash/debounce';

    import customDataHelpersMixin from '../../assets/js/mixins/customDataHelpers.js';

    //hack for now
    import civicGenomeAPIMixin from '../../assets/js/mixins/civicGenomeAPI.js';

    const uuidV1 = require('uuid/v1');

    module.exports =
    {
        name: "Specimens",
        components: {
            Multiselect
        },
        mixins: [
            customDataHelpersMixin,
            civicGenomeAPIMixin
        ],
        props: {
            specimens: Array,
            organization: Object
        },
        data: function ()
        {
            return {specimensState: specimenData.specimensState};
        },
        created: function()
        {
            if(this.genes.length < 1)
                this.getGenes();
        },
        computed:
            {
                currentSpecimen:{
                    get: function(){
                        var vm = this;
                        var spec = null;
                        if(vm.specimensState.editingSpecimenGuid === '' || vm.specimensState.editingSpecimenGuid === null)
                            return spec;
                        spec = vm.specimens.find(function(s){
                            return s.guid === vm.specimensState.editingSpecimenGuid;
                        });
                        if(typeof spec !== 'undefined')
                        {
                            var cD = new Date(spec.collectionDate);
                            //function... filter?
                            spec.collectionDate = this.$options.filters.MMDDYYYYhhmm(spec.collectionDate);
                        }
                        return spec;
                    },
                    set: function(value)
                    {
                        var vm = this;
                        var index = vm.specimens.findIndex(function(s){
                            return s.guid = value.guid;
                        });
                        value.collectionDate = new Date(value.collectionDate).toJSON();
                        vm.specimens.$set(index, value);
                    }
                },
                //currentSpecimenType:{
                //    get: function() {
                //        var vm = this;
                //        if(vm.currentSpecimen === null)
                //            return null;
                //        return {type: vm.currentSpecimen.type, code: vm.currentSpecimen.code};
                //    },
                //    set: function(value)
                //    {
                //        var vm = this;
                //        if(vmcurrentSpecimen === null)
                //            return;
                //        vm.$set(vm.currentSpecimen, 'type', value.type);
                //        vm.$set(vm.currentSpecimen, 'code', value.code);
                //    }
                //}
            },
        beforeMount: function() {

        },
        mounted: function(){
            //console.log(this.genes);
            this.toolTips();
        },

        methods:{

            //not working!
            toolTips: function() {this.$nextTick(function(){$('[data-toggle="tooltip"]').tooltip();});},

            //component event
            changed: function() {this.$emit('changed', this.specimens);},

            currentSpecimenTypeTransportChanged: function(){
                var spec = this.currentSpecimen;
                var type = this.organizationSpecimenTypes.find(function(t){return t.code === spec.type.code;});
                var transport = this.getSpecimenTransports(type.code).find(function(t){return t.code === spec.transport.code;});
                if(transport === null)
                    spec.code = type.code;
                else
                    spec.code = type.code + '-' + transport.code;
            },

            addSpecimen: function(type){
                var newSpec = {
                    guid: uuidV1(),
                    id: -1,
                    parentSpecimenGuid: '00000000-0000-0000-0000-000000000000',
                    type: {type: type.type, code: type.code},
                    code: type.code, //temp
                    transport: {name: null, code: null},
                    externalSpecimenID: null,
                    customData: {},
                    collectionDate: new Date((new Date()-1)).toJSON(),
                    receivedDate: new Date().toJSON(),
                    category: null
                    //attributesAreSet: false
                }

                this.setSpecimenAttributes(newSpec);

                this.specimens.push(newSpec);

                this.$set(this.specimensState, 'editingSpecimenGuid', newSpec.guid);

                this.$nextTick(function() {
                    this.setExpandedSpecimen(true);
                });
            },

            copySpecimenFromPrevious: function(specimen){

            },

            specimenClicked: function(specimen){
                var expand = false;
                if(specimen.guid === this.specimensState.editingSpecimenGuid){
                    this.$set(this.specimensState, 'editingSpecimenGuid', '');
                }
                else{
                    this.$set(this.specimensState, 'editingSpecimenGuid', specimen.guid);
                    this.setSpecimenAttributes(specimen);
                    expand = true;
                }
                this.$nextTick(function() {
                    this.setExpandedSpecimen(expand);}
                    );
            },

            setExpandedSpecimen: function(expandCurrent){
                var vm = this;
                this.specimens.forEach(function(s){
                    var specCollapse = $('#collapse'+s.guid);
                    var isShown = specCollapse._isShown;
                    if(s == vm.currentSpecimen && expandCurrent && !isShown)
                        specCollapse.collapse('show');
                    else if(isShown)
                        specCollapse.collapse('hide');
                });

                //do this while we're here
                $('.dateTimePicker').daterangepicker({
                    "singleDatePicker": true,
                    "timePicker": true,
                    "timePicker24Hour": true,
                    locale: {
                        format: 'MM/DD/YYYY h:mm'
                    }
                });
            }

            //expandCurrentSpecimen: function(){
            //    $('#collapse'+this.currentSpecimen.guid).collapse('show');
            //},

            //collapseNonCurrentSpecimens: function() {
            //    var vm = this;
            //    this.specimens.forEach(function(s){
            //        if(vm.currentSpecimen === null || s.guid !== vm.currentSpecimen.guid)
            //            $('#collapse'+s.guid).collapse('hide');
            //    });
            //}

        }
    }
</script>