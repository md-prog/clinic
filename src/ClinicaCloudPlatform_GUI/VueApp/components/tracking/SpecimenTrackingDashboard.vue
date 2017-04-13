<template>
    <div class="container-fluid align-content-center">
        <div class="row">
            <div class="col-lg-3 col-12"></div>
            <div class="col-lg-6 col-12">
                <ScanLookup v-on:scanLookup="scanLookup"></ScanLookup>
            </div>
            <div class="col-lg-3 col-12">Dashboard config here</div>
        </div>
        <div class="row mt-1">
            <div class="col-auto p-1">
                <div class="row">
                    <div class="col-12">
                        <SpecimenStatus v-if="dashboardPlugins.indexOf('SpecimenStatus') >= 0 && typeof dashboardState.currentSpecimen !== 'undefined'"
                                        :specimen="dashboardState.currentSpecimen">
                        </SpecimenStatus>
                    </div>
                </div>
                <div class="row"></div>
                <div class="row"></div>
                <div class="row"></div>
            </div>
            <div class="col-auto p-1">
                <div class="row pull-right">
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
            <div class="col-auto p-1">
                <div class="row"></div>
                <div class="row"></div>
                <div class="row"></div>
                <div class="row"></div>
            </div>
        </div>
    </div>
</template>

<script src="./SpecimenTrackingDashboard.vue.js">

</script>