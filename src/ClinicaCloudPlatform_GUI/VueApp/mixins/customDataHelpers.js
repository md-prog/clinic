import Vue from 'vue';
const uuidV1 = require('uuid/v1');

Vue.mixin({
    methods: {
        
        getSpecimenTransports: function(typeCode){
            var type = this.organization.customData.specimenDefinitions.filter(
                function (s) { return s.code === typeCode; })[0];
            return type.transports;
        },

        getSpecimenAttributesBySection: function (sectionName, specimenTypeCode) {
            var attr = new Array();
            var allAttr = this.organization.customData.specimenDefinitions.filter(
                function (s) { return s.code === specimenTypeCode; })[0].accessionAttributes; //.selectMany(d=> d.accessionAttributes);
            return allAttr.filter(function (a) { return a.section === sectionName });
            //var uniqueSet = filter(new Set(allAttr), a => a.section === sectionName);
            //return Array.from(uniqueSet);
        },

        ///apply organization custom data to new and existing specimens (additive)
        setSpecimenAttributes: function (specimen) {
            if (specimen.attributesAreSet)
                return;

            var vueVm = this;
            var specAttributes = vueVm.organization.customData.specimenDefinitions.filter(
                function (s) { return s.code === specimen.type.code; })[0].accessionAttributes;

            for(let attribute of specAttributes) {

                if (typeof specimen.customData === "undefined") {
                    vueVm.$set(specimen, "customData", {});
                }

                if (specimen.customData === null) {
                    vueVm.$set(specimen, "customData", {});
                }

                if (typeof specimen.customData.attributes === "undefined") {
                    vueVm.$set(specimen.customData, "attributes", []);
                }

                if (typeof specimen.customData.attributes.find(function (a) { return a.name === attribute.name; }) === "undefined") {
                    if (attribute.type === 'multiple-large' || attribute.type === 'multiple-small' || attribute.type==='civic-gene-api')
                        specimen.customData.attributes.push({ name: attribute.name, value: [{ id: "", name: "" }] });
                    else
                        specimen.customData.attributes.push({ name: attribute.name, value: { id: "", name: "" } });
                }

                vueVm.$set(specimen, "attributesAreSet", true);

            }
            this.$nextTick(function () { this.toolTips(); });
        },

        updateSpecimenAttributeFromText: function(event){
            var idParams = event.target.id.split('_');
            var specimenGuid = idParams[0];
            var attributeName = idParams[1];
            var attributeType = idParams[2];
            this.updateSpecimenAttribute(this.currentSpecimen, attributeName, event.target.value, false);
        },

        updateSpecimenAttributeFromMultiSelect: function (value, id) {
            var idParams = id.split('_');
            var specimenGuid = idParams[0];
            var attributeName = idParams[1];
            var attributeType = idParams[2];

            var multiple = attributeType === 'multiple-large' || attributeType === 'multiple-small' || attributeType === 'civic-gene-api';
            var specimen = this.currentSpecimen; //this.specimens.find(function (s) { return s.guid === specimenGuid });

            this.updateSpecimenAttribute(specimen, attributeName, value, multiple);
        },

        updateSpecimenAttribute: function (specimen, attributeName, attributeValue, singleToMultiple) {
            var attr = specimen.customData.attributes.find(function (a) { return a.name === attributeName });
            if (singleToMultiple) {
                //var currentSet = new Set(Array.isArray(attr.value) ? attr.value : [].concat(attr.value));
                var newSet = new Set(Array.isArray(attributeValue) ? attributeValue : [].concat(attributeValue));
                //currentSet.forEach(function(v){
                //    var duplicateItem = Array.from(newSet).find(function(v1){return v1.id === v.id});
                //    if(typeof(duplicateItem) !== 'undefined')
                //        newSet.delete(duplicateItem);
                //});
                //attributeValue = Array.from(new Set([...currentSet, ...newSet]));
                attributeValue = Array.from(newSet);
            }
            this.$set(attr, "value", attributeValue); //being safe

            this.changed();
        },

        currentSpecimenAttributeValue: function (specimen, attributeName, expectsSingle) {
            
            var originallySingle = false;
            var value = null;
            
            if(typeof specimen.customData.attributes !== 'undefined')
            {
                var attributeOnSpecimen = specimen.customData.attributes.find(function (a) { return a.name === attributeName });
                if(typeof attributeOnSpecimen !== 'undefined' && typeof attributeOnSpecimen.value !== 'undefined')
                    value = attributeOnSpecimen.value;
            }
            if (!Array.isArray(value)){
                originallySingle =true;
                value = [value];
            }
            var newVal = [];
            value.forEach(function (val) {
                if (val !== null && typeof(val) === 'object')
                {
                    newVal.push(val);
                }
            });
            if ((expectsSingle || originallySingle) && newVal.length > 0)
                newVal = newVal[0];
            else if(newVal.length === 1 && newVal[0].id === '') //the default value, which isn't needed for multi-select types
                newVal = [];

            return newVal;
        },

        /*
        *
        *   PATIENT CUSTOM DATA SECTION
        *
        */
        
        getPatientDemographicDetails: function () {
            return this.organization.customData.patientAttributes[0].patientDemographicDetails;
        },

        setPatientDemographics: function (patient) {
            if (patient.detailsAreSet)
                return;

            var vueVm = this;
            var patientDetails = vueVm.organization.customData.patientAttributes[0].patientDemographicDetails;

            for(let detail of patientDetails) {

                if (typeof patient.customData === "undefined") {
                    vueVm.$set(patient, "customData", {});
                }

                if (patient.customData === null) {
                    vueVm.$set(patient, "customData", {});
                }

                if (typeof patient.customData.details === "undefined") {
                    vueVm.$set(patient.customData, "details", []);
                }

                if (typeof patient.customData.details.find(function (a) { return a.name === detail.name; }) === "undefined") {
                    if (detail.type === 'multiple-large' || detail.type === 'multiple-small')
                        patient.customData.details.push({ name: detail.name, value: [{ id: "", name: "" }] });
                    else
                        patient.customData.details.push({ name: detail.name, value: { id: "", name: "" } });
                }

                vueVm.$set(patient, "detailsAreSet", true);

            }
            this.$nextTick(function () { this.toolTips(); });
        },

        updatePatientDetails: function(value, id) {
            var idParams = id.split('_');
            var detailName = idParams[0];
            var detailType = idParams[1];

            var multiple = detailType === 'multiple-large' || detailType === 'multiple-small';

            this.updatePatientDetailValue(detailName, value, multiple);
        },

        currentPatientDetailValue: function(detailName, expectsSingle){
            var originallySingle = false;
            var value = null;
            
            if(typeof this.patientState.patient.customData.details !== 'undefined')
            {
                var detail = this.patientState.patient.customData.details.find(function (a) { return a.name === detailName });
                if(typeof detail !== 'undefined' && typeof detail.value !== 'undefined')
                    value = detail.value;
            }
            if (!Array.isArray(value)){
                originallySingle =true;
                value = [value];
            }
            var newVal = [];
            value.forEach(function (val) {
                if (val !== null && typeof(val) === 'object')
                {
                    newVal.push(val);
                }
            });
            if ((expectsSingle || originallySingle) && newVal.length > 0)
                newVal = newVal[0];
            else if(newVal.length === 1 && newVal[0].id === '') //the default value, which isn't needed for multi-select types
                newVal = [];

            return newVal;
        },

        updatePatientDetailValue: function (detailName, value, singleToMultiple) {
            var detail = this.patientState.patient.customData.details.find(function (d) { return d.name === detailName });
            if (singleToMultiple) {
                var newSet = new Set(Array.isArray(value) ? value : [].concat(value));
                value = Array.from(newSet);
            }
            this.$set(detail, "value", value);
        }

    },
    computed:{
        organizationSpecimenTypes: function () {
            return Array.from(new Set(this.organization.customData.specimenDefinitions.map(function (spec) {
                return {type: spec.type, code: spec.code}; 
            }))); //set should de-dup .. maybe
        },
        organizationUsesCases: function() {
            return false; //todo
        },
        organizationUsesSpecimens: function(){
            return true; //todo
        }
    }
});