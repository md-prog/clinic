<template>
    <div class="container-fluid pt-2">
        <div v-if="!loaded" class="row">
            <div class="col-lg-12 text-center">
                <div class="card">
                    <div class="card-block">
                        <h3><i class="fa fa-spinner fa-spin"></i>Loading <span class="accessionLabel">Accession</span> ID {{$route.params.id}}</h3>
                    </div>
                </div>
            </div>
        </div>
        <div v-else class="animated fadeIn">
            <form id="accessionForm"></form>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="card">
                        <div class="card-block">
                            <h3>Edit <span class="accessionLabel">Accession</span> ID {{accession.id}}</h3>
                            <span class="config-info">Labels on this screen can be overridden by organization CSS.<br />Each section can also be hidden by JSON, but defaults must often be specified (e.g. default client).</span>
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
                                <label for="clientName" class="clientNameLabel">Client Name</label>
                                <select id="clientName" class="form-control select2-single" v-model="accession.client.id">
                                    <option v-for="client in accession.clients" v-bind:value="accession.client.id" v-bind:name="accession.client.name">{{client.name}}</option>
                                </select>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <span class="clientDetailsLabel">Client/Source Details</span>
                        </div>
                        <div class="card-block">
                            <fieldset class="form-group">
                                <label for="clientName" class="clientNameLabel">Client Name</label>
                                <select id="clientName" class="form-control select2-single" v-model="accession.client.id">
                                    <option v-for="client in accession.clients" v-bind:value="accession.client.id" v-bind:name="accession.client.name">{{client.name}}</option>
                                </select>
                            </fieldset>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</template>
<script>
    import { mapGetters, mapActions} from 'vuex';
    module.exports = {
        name: 'Accessioning',
        components: {},
        computed: {
            set: function(acc){
                //this.$parent.$store.dispatch('accession/setAccession', acc);
            },
            ...mapGetters('organization', ['organization']),
            ...mapGetters('user', ['user']),
            ...mapGetters('accession', ['accession', 'loaded']),
        },
            created: function() {
                if(!(typeof this.$route.params.id === 'undefined')) //check if this is new or edit accession
                    this.$parent.$store.dispatch('accession/loadAccession',
                        {id: this.$route.params.id, orgNameKey: this.$route.params.orgNameKey}); //temporarily include orgNameKey in route, later change to //this.$parent.$store.state.organization.nameKey);
            },
    mounted: function() {
        //setupFormOverlays();
    }
    };

    //var setupFormOverlays = function (){

    //    $('#select2').select2();

    //    $('input[name="demo"]').daterangepicker({
    //        "singleDatePicker": true,
    //        "timePicker": true,
    //        "startDate": "07/01/2015",
    //        "endDate": "07/15/2015",
    //        locale: {
    //            format: 'MM/DD/YYYY h:mm A'
    //        }
    //    });
    //}

</script>
<style>
</style>
