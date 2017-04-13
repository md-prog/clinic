﻿import worklistData from './Worklist.vue.data.js'; //rename to worklist..
var urlencode = require('urlencode');

import axios from 'axios';
import WorklistSpecimens from './WorklistSpecimens.vue';
import AccessionInfo from '../entities/AccessionInfo.vue';
import WorklistCaseDetail from './WorklistCaseDetail.vue';

import customDataHelpersMixin from '../../mixins/customDataHelpers.js';

module.exports = {
    name: "Worklist",
    components: {
        WorklistSpecimens,
        AccessionInfo,
        WorklistCaseDetail
    },
    mixins: [customDataHelpersMixin],
    props: {
        organization: Object,
        clients: Array,
        labs: Array,
        patients: Array,
        doctors: Array
    },
    data: function () {
        return {
            state: worklistData.worklistState,
            worklist: worklistData.worklist
        };
    },
    methods: {
        applyDataTables: function(){
            var vm = this;
            this.$nextTick(function(){
                var table = $('#worklistTable').DataTable(
                    {
                        buttons: [

                            { extend: 'copy', className: 'btn-primary float-right mr-1 ml-1' },
                            'excel',
                            'pdf',
                            { extend: 'colvis', className: 'btn-primary float-right mr-1 ml-1', text: "Columns" },
                        ],
                        columnDefs: [
                            {
                                //"targets": 1,
                                //"data": "createdDate",
                                //"render": function ( data, type, full, meta ) {
                                //    return vm.$options.filters.localeDate(data);
                                //}
                            }
                        ]
                    }
                    );
                table.buttons().container()
                    .appendTo( $('.col-sm-6:eq(0)', table.table().container() ) );
            });
        },

        loadData: function(org, config){
            var vm = this;
            var worklistUrl = '/api/Worklist/' + org.nameKey + '/' + config.start + '/' + config.end + '/' + urlencode(JSON.stringify(config.options));
            
            axios.get(worklistUrl).then(function (worklistResponse) {                    
                vm.$set(vm, 'worklist', worklistResponse.data);
                vm.applyDataTables();
            }
            ).catch(err => {console.log(err)});
        }, 
        setWorklistConfig: function(org)
        {
            this.state.config.start = Date.now() -30;
            this.state.config.end = Date.now();
            this.state.config.options.includeCases = this.organizationUsesCases;
            this.state.config.options.includeSpecimens = this.organizationUsesSpecimens;
        }
    },
    created: function() {
        this.setWorklistConfig(this.organization);
        this.loadData(this.organization, this.state.config);
    }
};