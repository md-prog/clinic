<template>

    <section class='content'>
        <div class="row"><div class="col-12"><h2>Coming Soon!</h2></div></div>
    </section>

</template>

<script>

    module.exports = {
        name: 'DashboardContainer',
        watch: {
            '$route': function () {
                window.document.title = vm.organization.name + ' - ' + vm.$route.meta.title;
            },
        },
    }
</script>
