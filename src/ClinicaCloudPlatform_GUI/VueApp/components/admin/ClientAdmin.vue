<template>
    <section class="content">
        <div class="center-block">
            <div class="col-auto">
                WIP (isn't it all?)
                <ul class="nav nav-tabs" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#organization" role="tab" aria-controls="organization">Organization</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#users" role="tab" aria-controls="users">Users</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane p-1 active" id="organization" role="tabpanel"><Organization></Organization></div>
                    <div class="tab-pane p-1" id="users" role="tabpanel">...</div>
                </div>
            </div>
        </div>
    </section>
</template>
<script>
    import Organization from './Organization.vue'
    import { mapGetters, mapActions} from 'vuex';
    module.exports = {
        name: 'ClientAdmin',
        components: {'Organization': Organization},
        computed: {
        },
        created: function() {

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
