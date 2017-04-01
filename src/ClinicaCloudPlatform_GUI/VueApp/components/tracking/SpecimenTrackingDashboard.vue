<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-3 col-12"></div>
            <div class="col-lg-6 col-12">
                <ScanLookup v-on:scanLookup="scanLookup"></ScanLookup>
            </div>
            <div class="col-lg-3 col-12">Dashboard config here</div>
        </div>
        <div class="row mt-1">
            <div class="col-lg-2 col-md-3 col-12">
                Left here
            </div>
            <div class="col-lg-5 col-md-5 col-12">
                <div class="row">
                    <div class="col-12">
                        <SpecimenStatus 
                            v-if="dashboardPlugins.indexOf('SpecimenStatus') >= 0 && typeof dashboardState.currentSpecimen !== 'undefined'" 
                            :specimen="dashboardState.currentSpecimen">
                        </SpecimenStatus>
                    </div>
                </div>
                <div class="row"></div>
                <div class="row"></div>
                <div class="row"></div>
            </div>
            <div class="col-lg-5 col-md-4 col-12">
                Right here
            </div>
        </div>
    </div>
</template>

<script src="./SpecimenTrackingDashboard.vue.js">

</script>