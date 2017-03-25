<template>
    <div class="row">
        <div v-for="specimen in specimens" class="col-sm-12">
            <WorklistSpecimenDetail :organization="organization" :specimen="specimen"></WorklistSpecimenDetail>                        
        </div>
    </div>
</template>

<script src="./WorklistSpecimens.vue.js">
</script>