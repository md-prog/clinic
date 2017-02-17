<template>
    <section class="content">
        <div class="center-block">
            <div class="col-auto">
                <div class="card">
                    <div class="card-header">WIP (isn't it all?)
                        {{user.fullName}} - {{organization.name}}
                        <div class="card-actions">
                            <a href="https://github.com/digitalBush/jquery.maskedinput">
                                <small class="text-muted">docs</small>
                            </a>
                        </div>
                    </div>
                    <div class="card-block">
                        <fieldset class="form-group">
                            <label>Multiple Select / Tags</label>
                            <select id="select2" class="form-control select2-multiple" multiple="">
                                <option>Option 1</option>
                                <option selected="">Option 2</option>
                                <option>Option 3</option>
                                <option>Option 4</option>
                                <option>Option 5</option>
                            </select>
                        </fieldset>
                    </div>
                    <div>
                        <input id="demo" name="demo" class="demo" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>
<script>
    import { mapGetters, mapActions} from 'vuex';
    module.exports = {
        name: 'ClientAdmin',
        computed: {
            set: function(org){
                this.setOrganization(org);
            },
            ...mapGetters('organization', ['organization']),
            ...mapGetters('user', ['user']),
        },
            created: function() {
                this.$parent.$store.dispatch('organization/loadOrganization');
            },
            mounted: function() {
                setupFormOverlays();
            }
    };

    var setupFormOverlays = function (){

        $('#select2').select2();

        $('input[name="demo"]').daterangepicker({
            "singleDatePicker": true,
            "timePicker": true,
            "startDate": "07/01/2015",
            "endDate": "07/15/2015",
            locale: {
                format: 'MM/DD/YYYY h:mm A'
            }
        });
    }

</script>
<style>
</style>
