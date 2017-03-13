<template>

    <div class="app-root">
        <Navbar name="topNavBar" :user="this.user" :organization="this.organization"></Navbar>

        <div class="app-body">

            <Sidebar name="leftSidebar"></Sidebar>

            <main class="main">
                <section class="content-header">
                    <h1>
                        {{$route.name.toUpperCase() }}
                        <small>{{ $route.description }}</small>
                    </h1>
                    <nav class="breadcrumb">
                        <router-link exact to="/" class="breadcrumb-item"><i class="fa fa-home"></i>Home</router-link>
                        <span class="active breadcrumb-item">{{$route.name.toUpperCase() }}</span>
                    </nav>
                </section>
                <div class="container-fluid pt-lg-1 pt-md-1 pt-sm-0 main-fill">
                    <div v-if="this.organization != null" class="animated fadeIn">
                        <router-view v-if="this.organization.customData != null" :user="this.user" :organization="this.organization"></router-view>
                    </div>
                </div>
            </main>

            <SecondarySidebar name="rightSidebar" :user="this.user" :organization="this.organization" :historyItems="[]"></SecondarySidebar>
        </div>

        <AppFooter name="footer" :organization="this.organization"></AppFooter>

    </div>

</template>

<script>
    import { mapGetters, mapActions } from 'vuex';   
    import Sidebar from './main/Sidebar.vue';
    import SecondarySidebar from './main/SecondarySidebar.vue';
    import Navbar from './main/Navbar.vue';
    import AppFooter from './main/AppFooter.vue';

    import organizationStyleMixin from '../assets/js/mixins/organizationStyle.js';

    module.exports = {
        name: 'Main',
        components: {
            'Sidebar': Sidebar, 
            'Navbar': Navbar, 
            'SecondarySidebar': SecondarySidebar,
            'AppFooter': AppFooter
        },
        mixins: [organizationStyleMixin],
        methods: {
            postOrgLoadActions: function(vm){
                window.document.title = vm.organization.name + ' - ' + vm.$route.meta.title;
                this.setLogo(vm);
                this.setCSS(vm);
            },
            startOrgWatcher: function(vm){
                vm.$parent.$store.watch(
                    function(state){
                        return state.organization.loaded;
                    }, 
                    function() {if(vm.organizationLoaded)
                        vm.$nextTick(function() {vm.postOrgLoadActions(vm);})}
                    );
            }
        },
        watch:{
            '$route': function () {
                if(this.organizationLoaded)
                    this.postOrgLoadActions(this);
                else
                this.startOrgWatcher(this);
            },
        },
        created: function() {
            var vm = this;
            if(!this.userLoaded)
                this.$parent.$store.dispatch('user/getUser');
            if(!this.organizationLoaded){
                this.$parent.$store.dispatch('organization/loadOrganization');
            }
            this.startOrgWatcher(this);
        },
        computed: {
            ...mapGetters('user', ['user', 'userLoaded']),
            ...mapGetters('organization', ['organization', 'organizationLoaded'])
        },
        };

</script>

<style>
    .user-panel {
        height: 4em;
    }

    hr.visible-xs-block {
        width: 100%;
        background-color: rgba(0, 0, 0, 0.17);
        height: 1px;
        border-color: transparent;
    }
</style>
