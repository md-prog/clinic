<template>
    <div class="container-fluid m-0 p-0">
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <ScanLookup v-on:scan="scanLookup"></ScanLookup>
            </div>
            <div class="col-sm-3">Dashboard config here</div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                Left Features here
            </div>
            <div class="col-sm-9">
                <div class="row">
                </div>
                <div class="row"></div>
                <div class="row"></div>
                <div class="row"></div>
            </div>
        </div>
    </div>
</template>

<script>
    import ScanLookup from '../tools/ScanLookup.vue';

    module.exports = {
        name:'SpecimenTrackingDashboard',
        components: {
            ScanLookup
        },
        props:{
            organization: Object,
            user: Object,
        },
        methods:{
            scanLookup: function(action, value)
            {

            }
        }
    };
</script>