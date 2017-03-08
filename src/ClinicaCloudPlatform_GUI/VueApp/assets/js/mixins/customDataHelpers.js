import Vue from 'vue';

Vue.mixin({
    methods: {

        getSpecimenAttributesBySection: function (sectionName, specimenType) {
            var attr = new Array();
            var allAttr = this.organization.customData.specimenDefinitions.filter(
                function (s) { return s.type == specimenType; })[0].accessionAttributes; //.selectMany(d=> d.accessionAttributes);
            return allAttr.filter(function (a) { return a.section == sectionName });
            //var uniqueSet = filter(new Set(allAttr), a => a.section == sectionName);
            //return Array.from(uniqueSet);
        },

        ///apply organization custom data to new and existing specimens (additive)
        setSpecimenAttributes: function (specimen) {
            if (specimen.attributesAreSet)
                return;

            var vueVm = this;
            var specAttributes = vueVm.organization.customData.specimenDefinitions.filter(
                function (s) { return s.code == specimen.code; })[0].accessionAttributes;

            for(let attribute of specAttributes) {

                if (typeof specimen.customData === "undefined") {
                    vueVm.$set(specimen, "customData", {});
                }

                if (specimen.customData == null) {
                    vueVm.$set(specimen, "customData", {});
                }

                if (typeof specimen.customData.attributes === "undefined") {
                    vueVm.$set(specimen.customData, "attributes", []);
                }

                if (typeof specimen.customData.attributes.find(function (a) { return a.name == attribute.name; }) === "undefined") {
                    if (attribute.type == 'multiple-large' || attribute.type == 'multiple-small')
                        specimen.customData.attributes.push({ name: attribute.name, value: [{ id: "", name: "" }] });
                    else
                        specimen.customData.attributes.push({ name: attribute.name, value: { id: "", name: "" } });
                }

                vueVm.$set(specimen, "attributesAreSet", true);

            }
            this.$nextTick(function () { this.toolTips(); });
        },

        updateSpecimenAttributeFromMultiSelect: function (value, id) {
            var idParams = id.split('_');
            var specimenGuid = idParams[0];
            var attributeName = idParams[1];
            var attributeType = idParams[2];

            var multiple = attributeType == 'multiple-large' || attributeType == 'multiple-small';
            var specimen = this.specimens.find(function (s) { return s.guid == specimenGuid });

            this.updateSpecimenAttribute(specimen, attributeName, value, multiple);
        },

        updateSpecimenAttribute: function (specimen, attributeName, attributeValue, singleToMultiple) {
            var attr = specimen.customData.attributes.find(function (a) { return a.name == attributeName });
            if (singleToMultiple) {
                //var currentSet = new Set(Array.isArray(attr.value) ? attr.value : [].concat(attr.value));
                var newSet = new Set(Array.isArray(attributeValue) ? attributeValue : [].concat(attributeValue));
                //currentSet.forEach(function(v){
                //    var duplicateItem = Array.from(newSet).find(function(v1){return v1.id === v.id});
                //    if(typeof(duplicateItem) != 'undefined')
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
            var value = {id:"",name:""};
            
            if(typeof(specimen.customData.attributes) != 'undefined')
            {
                var attributeOnSpecimen = specimen.customData.attributes.find(function (a) { return a.name == attributeName });
                if(typeof(attributeOnSpecimen.value) != 'undefined')
                    value = attributeOnSpecimen.value;
            }
            if (!Array.isArray(value)){
                originallySingle =true;
                value = [value];
            }
            var newVal = [];
            value.forEach(function (val) {
                if (typeof (val) != 'object' || val == null)
                    val = { "id": val, "name": val };
                newVal.push(val);
            });
            if ((expectsSingle || originallySingle) && Array.isArray(newVal))
                newVal = newVal[0];
            return newVal;
        }
    },
    computed:{
        organizationSpecimenTypes: function () {
            return Array.from(new Set(this.organization.customData.specimenDefinitions.map(function (spec) { return spec.type }))); //set should de-dup .. maybe
        },
        organizationUsesCases: function() {
            return false; //todo
        },
        organizationUsesSpecimens: function(){
            return true; //todo
        }
    }
});