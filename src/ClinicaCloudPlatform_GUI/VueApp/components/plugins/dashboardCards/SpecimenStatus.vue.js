import specimenStatusData from './SpecimenStatus.vue.data.js';

module.exports = {
    name: 'SpecimenStatus',
    props: {
        specimen: Object,
        specimens: Array,
        organization: Object
    },
    data: function ()
    {
        return {
            specimenHistory: specimenStatusData.specimenHistory,
            currentWorkflow: specimenStatusData.currentWorkflow
        };
    },
    computed:
        {
            specimenGroups: {
                get: function()
                {
                    var vm = this;
                    var groups = [];
                    vm.specimens.forEach(function(s)
                    {
                        var group = groups.find(g=>g.groupGuid === s.customData.groupGuid);
                        if(typeof group === 'undefined')
                            groups.push({groupGuid: s.customData.groupGuid, specimens: [s], primarySpecimen: s});
                        else if(group.groupGuid === s.customData.groupGuid)
                            group.specimens.push(s);
                    });
                    return groups;
                }
            }
        },
    methods:
        {
            getDueDate: function(tatHours, started)
            {
                var startDate = new Date(started);
                var retVal = new Date();
                retVal.setDate(startDate.getDate() + (tatHours / 24));
                return retVal;
            },
            getWorkflowOnTimeStatus: function(due)
            {
                var dueDate = new Date(due).getDate();
                var today = new Date().getDate();
                var dayDifference = dueDate - today;
                if((dayDifference) >= 1)
                    return 'bg-success';
                else if((dayDifference > 0))
                    return 'bg-warning';
                else
                    return 'bg-danger';
            },
            getWorkflowPercent: function(steps, currentStep)
            {
                var retVal = 0;
                var count = steps.length;
                var stepValue = steps.indexOf(currentStep) + 1;
                if(stepValue > 0)
                    retVal = (stepValue / count) * 100;
                return retVal;
            }
        }
};