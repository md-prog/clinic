<template>
    <div class="app-root">
        <!--<div class="pace  pace-inactive">
            <div class="pace-progress" data-progress-text="100%" data-progress="99" style="transform: translate3d(100%, 0px, 0px);">
                <div class="pace-progress-inner"></div>
            </div>
            <div class="pace-activity"></div>
        </div>-->
        <header class="app-header navbar">
            <button class="navbar-toggler mobile-sidebar-toggler hidden-lg-up" type="button">☰</button>
            <a class="navbar-brand" href="#"></a>
            <ul class="nav navbar-nav hidden-md-down">
                <li class="nav-item">
                    <a class="nav-link navbar-toggler sidebar-toggler" href="#">☰</a>
                </li>
            </ul>
            <ul class="nav navbar-nav ml-auto">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle nav-link" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                        <span>{{user.fullName}}</span>
                        <!--without the below span and v-if, vue doesn't render user.fullName above on first load.  hiding it for now.-->
                        <span style="display:none;" class="hidden-md-down small" v-for="(item, index) in user.groups.items">
                            {{item.name}}<span v-if="index != (user.groups.items.length - 1)">,</span>
                        </span>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right">

                        <div class="dropdown-header text-center">
                            <strong>Account</strong>
                        </div>

                        <router-link exact :to="{name: 'Mailbox', params: {type: 'messages'}}" class="dropdown-item">
                            <i class="icon-envelope-letter"></i> Messages
                            <span class="tag" v-bind:class="{'tag-success': user.hasMessages, 'tag-default': !user.hasMessages}">
                                {{ user.messageCount }}
                            </span>
                        </router-link>

                        <router-link exact :to="{name: 'Mailbox', params: {type: 'notifications'}}" class="dropdown-item">
                            <i class="icon-bell"></i> Notifications
                            <span class="tag" v-bind:class="{'tag-success': user.hasNotifications, 'tag-default': !user.hasNotifications}">
                                {{ user.notificationCount }}
                            </span>
                        </router-link>

                        <a class="dropdown-item" href="/login"><i class="fa fa-lock" />Logout</a>

                        <div class="dropdown-header text-center">
                            <strong>Setting</strong>
                        </div>

                        <a class="dropdown-item" href="#"><i class="icon-envelope-letter"></i> Messages<span class="tag tag-default">{{ user.messageCount }}</span></a>
                        <a class="dropdown-item" href="#"><i class="icon-envelope-letter"></i> Messages<span class="tag tag-default">{{ user.messageCount }}</span></a>
                        <a class="dropdown-item" href="#"><i class="icon-envelope-letter"></i> Messages<span class="tag tag-default">{{ user.messageCount }}</span></a>

                    </div>
                </li>
                <li class="nav-item hidden-md-down">
                    <a class="nav-link navbar-toggler aside-menu-toggler" href="#">☰</a>
                </li>
            </ul>
        </header>

        <div class="app-body">

            <Sidebar name="rightSidebar"></Sidebar>

            <!-- Main content -->
            <main class="main">
                <section class="content-header">
                    <h1>
                        {{$route.name.toUpperCase() }}
                        <small>{{ $route.meta.description }}</small>
                    </h1>
                    <nav class="breadcrumb">
                        <router-link exact to="/" class="breadcrumb-item"><i class="fa fa-home"></i>Home</router-link>
                        <span class="active breadcrumb-item">{{$route.name.toUpperCase() }}</span>
                    </nav>
                </section>
                <div class="container-fluid pt-lg-1 pt-md-1 pt-sm-0 main-fill">
                    <div v-if="this.organization != null" class="animated fadeIn">
                        <!-- Content Header (Page header) -->
                        <router-view v-if="this.organization.customData != null" :user="this.user" :organization="this.organization"></router-view>
                    </div>
                </div>
            </main>
            <!--right menu-->
            <aside class="aside-menu">
                <ul class="nav nav-tabs" role="tablist">
                    <!-- Messages-->
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#messages" role="tab">
                            <i class="icon-envelope-letter"></i>
                            <span class="label label-success">{{ user.messageCount }}</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#notifications" role="tab">
                            <i class="icon-bell"></i>
                            <span class="label label-success">{{ user.notificationCount }}</span>
                        </a>
                    </li>
                    <!--<li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#tasks" role="tab">
                            <i class="icon-list" />
                            <span class="label label-success">{{ user.taskCount }}</span>
                        </a>
                    </li>-->
                </ul>
                <!--Right menu tabs-->
                <div class="tab-content">
                    <div class="tab-pane p-1 active" id="messages" role="tabpanel">
                        <div class="header">
                            <strong>You have {{ user.messageCount }} message(s)</strong>
                        </div>
                        <div v-if="user.hasMessages">
                            <div v-for="message in user.customData.messages">
                                <div class="message">
                                    <router-link exact class="dropdown-item" :to="{name: 'Mailbox', params: {type: 'messages'}}">
                                        <div>
                                            <small class="text-muted">{{message.from}}</small>
                                            <small class="text-muted float-right mt-q">
                                                {{message.timeStamp | prettyDate}}
                                            </small>
                                        </div>
                                        <div class="text-truncate font-weight-bold">{{message.subject}}</div>
                                        <div class="text-muted">{{message.text | truncate}}</div>
                                    </router-link>
                                </div>
                                <hr />
                            </div>
                            <a href="#" class="dropdown-item text-center">
                                <strong><router-link exact :to="{name: 'Mailbox', params: {type: 'messages'}}">View all messages</router-link></strong>
                            </a>
                        </div>

                    </div>
                    <div class="tab-pane p-1" id="notifications" role="tabpanel">
                        <div class="header"><strong>You have {{ user.notificationCount }} notification(s)</strong></div>
                        <div v-if="user.hasNotifications">

                            <div v-for="notification in user.customData.notifications">
                                <div class="message">
                                    <router-link exact class="dropdown-item" :to="{name: 'Mailbox', params: {type: 'notifications'}}">
                                        <div>
                                            <small class="text-muted">{{notification.from}}</small>
                                            <small class="text-muted float-right mt-q">
                                                {{notification.timeStamp | prettyDate}}
                                            </small>
                                        </div>
                                        <div class="text-truncate font-weight-bold">{{notification.subject}}</div>
                                        <div class="text-muted">{{notification.text | truncate}}</div>
                                    </router-link>
                                </div>
                                <hr />

                                <a href="#" class="dropdown-item text-center">
                                    <strong>
                                        <router-link exact :to="{name: 'Mailbox', params: {type: 'notifications'}}">
                                            View all notifications
                                        </router-link>
                                    </strong>
                                </a>

                            </div>
                        </div>
                    </div>
                </div>
            </aside>
        </div>

        <!-- Main Footer -->
        <footer class="app-footer">
            <div class="copyright">Copyright &copy; {{year}} <strong><a href="javascript:;">{{organization.name}}</a></strong>.  All rights reserved.</div>
            <div class="powered-by">Powered By Clinica Cloud Platform</div>
        </footer>
    </div>
</template>

<script>
    import { mapGetters, mapActions } from 'vuex';
    import moment from 'moment';
    import Sidebar from './main/Sidebar.vue';

    module.exports = {
        name: 'Main',
        components: {'Sidebar': Sidebar},
        methods: {
            changeloading: function () {
                this.store.dispatch('TOGGLE_SEARCHING');
            },
            toggleMenu: function (event) {
                // remove active from li
                window.$('li.pageLink').removeClass('active');
                // Add it to the item that was clicked
                event.toElement.parentElement.className = 'pageLink active';
            },
            postOrgLoadActions: function(vm){
                window.document.title = vm.organization.name + ' - ' + vm.$route.meta.title;
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
            if(!this.organizationLoaded)
                this.$parent.$store.dispatch('organization/loadOrganization');
            this.startOrgWatcher(this);
        },
        //watch:{
        //    organization: function() {
        //        if (this.organization.organizationLoaded)
        //        {
        //            var vm = this;
        //            vm.$nextTick(function() { vm.postLoadActions(vm); });
        //        }
        //    },
        //},
        computed: {
            year: function()
            {
                return moment().format('YYYY');
            },
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
