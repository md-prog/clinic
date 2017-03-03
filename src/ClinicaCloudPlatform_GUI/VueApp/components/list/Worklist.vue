<template>
    <div id="worklistTableWrapper" class="table-responsive">
        <table id="worklistTable" class="nowrap table table-bordered table-condensed table-hover">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Created</th>
                    <th>Client</th>
                    <th>Specimens</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="row in worklist">
                    <td>
                        <router-link :to="{ name: 'Edit Accession', params: { id: row.id, orgNameKey: organization.nameKey }}">
                            Edit <span class="accessionLabel">Accession</span> {{row.id}}
                        </router-link>
                    </td>
                    <td>{{row.createdDate}}</td>
                    <td>{{lookup('client', row.clientId)}}</td>
                    <td>
                        <WorklistSpecimens :organization="organization" :specimens="row.specimens">
                        </WorklistSpecimens>
                    </td>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import worklistData from './Worklist.vue.data.js'; //rename to worklist..
    var urlencode = require('urlencode');

    import axios from 'axios';
    import WorklistSpecimens from './WorklistSpecimens.vue';

    module.exports = {
        name: "Worklist",
        components: {
            WorklistSpecimens
        },
        props: {
            organization: Object
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
                                    "targets": 1,
                                    "data": "createdDate",
                                    "render": function ( data, type, full, meta ) {
                                        return vm.$options.filters.localeDate(data);
                                    }
                                }
                            ]
                        }
                        );
                    table.buttons().container()
                        .appendTo( $('.col-sm-6:eq(0)', table.table().container() ) );
                });
            },
            lookup: function(type, value){
                switch(type){
                    case "client":
                    default:
                        var client = this.state.clients.find(function(c) {return c.id == value;});
                        if(typeof(client)!='undefined')
                            return client.name;
                        else
                            return 'Unknown';
                        break;
                }
            },
            loadData: function(org, config){
                var vm = this;
                var worklistUrl = '/api/Worklist/' + org.nameKey + '/' + config.start + '/' + config.end + '/' + urlencode(JSON.stringify(config.options));

                axios.all([
                    axios.get(worklistUrl),
                    axios.get('/api/Client/' + org.nameKey)
                ]).then(axios.spread(function (worklistResponse, clientResponse) {
                    vm.$set(vm.state, 'clients', clientResponse.data);
                    vm.$set(vm, 'worklist', worklistResponse.data)
                    //apply after last data load
                    vm.applyDataTables();
                }
                    )).catch(err => {console.log(err)});
            },
        },
        created: function() {
            this.loadData(this.organization, this.state.config);
        }
    }
</script>
<style type="text/css">
    table.nowrap th {
        white-space: nowrap !important;
    }

    table.nowrap td {
        white-space: nowrap !important;
    }

    table td {
        vertical-align: top;
    }

    .dataTables_wrapper .row {
        margin-top: 0px !important;
    }
</style>