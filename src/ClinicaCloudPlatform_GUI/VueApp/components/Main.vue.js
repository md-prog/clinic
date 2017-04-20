import { mapGetters, mapActions } from 'vuex';
import Sidebar from './main/Sidebar.vue';
import SecondarySidebar from './main/SecondarySidebar.vue';
import Navbar from './main/Navbar.vue';
import AppFooter from './main/AppFooter.vue';
import organizationStyleMixin from '../mixins/organizationStyle.js';

module.exports = {
    name: 'Main',
    components: {
        'Sidebar': Sidebar,
        'Navbar': Navbar,
        'SecondarySidebar': SecondarySidebar,
        'AppFooter': AppFooter
    },
    //data: function(){
    //    state:
    //        {

    //        }
    //},
    mixins: [organizationStyleMixin],
    methods: {
        postOrgLoadActions: function(vm){
            if(!vm.lookupDataLoaded)
                vm.$parent.$store.dispatch({type: 'lookupData/loadGlobalLookupData', orgNameKey: vm.organization.nameKey});
            window.document.title = vm.organization.name + ' - ' + vm.$route.meta.title;
            vm.setLogo(vm);
            vm.setCSS(vm);
        },
        startOrgWatcher: function(vm){
            vm.$parent.$store.watch(
                function(state){
                    return state.organization.loaded;
                },
                function() {if(vm.organizationLoaded)
                    vm.$nextTick(function() {vm.postOrgLoadActions(vm);})}
                );
        },
        setHistoryItem: function(view, id, title, headline, content, date)
        {
            var vm = this;
            var itemIndex = vm.historyItems.findIndex(function(h) {return h.id === id && h.view === view});
            var item = {view: view, id: id, title: title, headline: headline, content: content, timeStamp: date};
            if(itemIndex > -1)
                vm.$set(vm.historyItems, itemIndex, item);
            else
                vm.historyItems.push(item);
        },


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
        if(!vm.userLoaded)
            vm.$parent.$store.dispatch('user/getUser');
        if(!vm.organizationLoaded){
            vm.$parent.$store.dispatch('organization/loadOrganization');            
        }
        vm.startOrgWatcher(vm);
    },
    computed: {
        ...mapGetters('user', ['user', 'userLoaded']),
        ...mapGetters('organization', ['organization', 'organizationLoaded']),
        ...mapGetters('history', ['historyItems']),
        ...mapGetters('lookupData', ['clients', 'patients', 'doctors','labs','lookupDataLoaded'])
        },
};
