<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header card-header-primary">
                        <span class="specimensLabel">Specimens</span><div class="dropdown float-right">
                            <button class="btn btn-primary btn-sm dropdown-toggle"
                                    id="addSpecBtn" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fa fa-plus-circle"></i> Add Specimen
                            </button>
                            <div class="dropdown-menu" aria-labelledby="addSpecBtn">
                                <div class="dropdown-item" v-for="type in getSpecimenTypes()" v-on:click="addSpecimen(type)">{{type}}</div>
                            </div>
                        </div>
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
                                    <tr v-for="specimen in specimens">
                                        <td>{{specimen.externalSpecimenID}}</td>
                                        <td>TODO</td>
                                        <td>{{specimen.type}}</td>
                                        <td>{{specimen.transport}}</td>
                                        <td>{{specimen.collectionDate}}</td>
                                        <td>
                                            <a v-bind:href="'#collapse'+specimen.guid" data-toggle="collapse" data-parent="specimenAccordion"
                                               v-on:click="setSpecimenAttributes(specimen)">Click to View/Edit</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="panel-group card" id="specimenAccordian">
                    <div v-for="specimen in specimens" class="panel panel-default">
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
                                    <div v-for="col in row.cols" v-bind:class="col.class" class="col-sm-auto">
                                        <div class="card">
                                            <div class="card-header card-header-primary">
                                                {{col.sectionName}}
                                            </div>
                                            <div class="card-block">
                                                <div v-for="att in getSpecimenAttributesBySection(col.sectionName, specimen.type)" class="form-group">
                                                    <label for="attributeInput">{{att.label}}</label>
                                                    <div class="input-group">
                                                        <div v-if='att.type=="single-small"' id="attributeInput" class="btn-group pl-1" data-toggle="buttons">
                                                            <label v-for="option in att.options"
                                                                   v-bind:class="option.id == currentSpecimenAttributeValue(specimen, att.name, true).id ? 'btn btn-radio active' : 'btn btn-radio'"
                                                                   v-on:click="updateSpecimenAttribute(specimen, att.name, option, true)">
                                                                <input type="radio" autocomplete="off" name="option" v-bind:id="option.id"
                                                                       v-bind:checked="option.id == currentSpecimenAttributeValue(specimen, att.name, true).id"
                                                                       v-on:change="updateSpecimenAttribute(specimen, att.name, option, false)" />
                                                                {{option.name}}
                                                            </label>
                                                        </div>
                                                        <div v-if="att.type=='multiple-small'" id="attributeInput" class="btn-group pl-1" data-toggle="buttons">
                                                            <label v-for="option in att.options" class="btn btn-radio"
                                                                   v-bind:class="currentSpecimenAttributeValue(specimen, att.name, false).find(function(v) {option.id == v.id}) ? 'btn btn-radio active' : 'btn btn-radio'"
                                                                   v-on:click="updateSpecimenAttribute(specimen, att.name, option, true)">
                                                                <input type="checkbox" autocomplete="off" name="option" v-bind:id="option.id"
                                                                       v-bind:checked="currentSpecimenAttributeValue(specimen, att.name, false).find(function(v) {option.id == v.id})"
                                                                       v-on:change="updateSpecimenAttribute(specimen, att.name, option, true)" />
                                                                {{option.name}}
                                                            </label>
                                                        </div>
                                                        <multiselect v-if="att.type=='single-large'"
                                                                     v-bind:id="specimen.guid+'_'+att.name+'_'+att.type"
                                                                     deselect-label="Can't remove this value"
                                                                     track-by="id" label="name"
                                                                     placeholder="Select one" :options="att.options" :searchable="false" :allow-empty="false"
                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, true)"
                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                        </multiselect><!--"-->
                                                        <multiselect v-if="att.type=='multiple-large'"
                                                                     v-bind:id="specimen.guid+'_'+att.name+'_'+att.type"
                                                                     track-by="id" label="name"
                                                                     placeholder="Select one or more" :options="att.options" :searchable="true"
                                                                     :multiple="true" :allow-empty="false"
                                                                     v-bind:value="currentSpecimenAttributeValue(specimen, att.name, false)"
                                                                     v-on:input="updateSpecimenAttributeFromMultiSelect">
                                                        </multiselect><!---->
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

    const uuidV1 = require('uuid/v1');

    module.exports =
    {
        name: "Specimens",
        components: {
            Multiselect
        },
        mixins: [customDataHelpersMixin],
        props: {
            specimens: Array,
            organization: Object
        },
        data: function ()
        {
            return {specimenState: specimenData.specimenState};
        },
        beforeMount: function() {this.$nextTick(function() { this.toolTips(); });},
        methods:{

            toolTips: function() {$('[data-toggle="tooltip"]').tooltip();}, //ugh

            changed: function() {this.$emit('changed', this.specimens);},

            addSpecimen: function(type){
                var newSpec = {
                    guid: uuidV1(),
                    id: -1,
                    parentSpecimenID: 0,
                    type: type,
                    transport: "",
                    externalSpecimenID: "",
                    customData: {},
                    collectionDate: '01/01/1900',
                    receivedDate: '01/01/1900',
                    attributesAreSet: false
                }

                this.setSpecimenAttributes(newSpec);

                this.specimens.push(newSpec);

                this.$nextTick(function() {$('#collapse'+newSpec.guid).collapse('show');});
            },


        }
    }
</script>