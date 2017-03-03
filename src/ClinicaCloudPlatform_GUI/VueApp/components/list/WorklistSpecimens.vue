<template>
    <div class="row">
        <div v-for="specimen in specimens" class="col-sm-12">
            <WorklistSpecimenDetail :organization="organization" :specimen="specimen"></WorklistSpecimenDetail>                        
        </div>
    </div>
</template>

<script>

    import specimensState from './WorklistSpecimens.vue.data.js';

    import WorklistSpecimenDetail from './WorklistSpecimenDetail.vue';

    module.exports = {
        name: "WorklistSpecimens",
        props:{
            organization: Object,
            specimens: Array
        },
        components: {
            WorklistSpecimenDetail
        }
    }
</script>