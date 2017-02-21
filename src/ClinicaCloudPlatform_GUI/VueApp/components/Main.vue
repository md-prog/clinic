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

                        <!--<a class="dropdown-item" data-toggle="tab" href="#tasks" role="tab">
                            <i class="icon-list"></i>Tasks
                            <span class="tag" v-bind:class="{'tag-success': user.hasTasks, 'tag-default': !user.hasTasks}">
                                {{ user.taskCount }}
                            </span>
                        </a>-->

                        <div class="dropdown-header text-center">
                            <strong>Settings</strong>
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
            <div class="sidebar">
                <nav class="sidebar-nav open">
                    <form>
                        <div class="form-group p-h mb-0">
                            <input type="text" name="search" id="search" class="search form-control" data-toggle="hideseek" placeholder="Search Menus" data-list=".search-nav">
                            <!--<span class="input-group-btn">
                                <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                    <i class="fa fa-search"></i>
                                </button>
                            </span>-->
                        </div>
                    </form>
                    <!-- Sidebar Menu -->
                    <ul class="nav search-nav">
                        <li class="nav-title">
                            Dashboards
                        </li>
                        <li class="nav-item open" v-on:click="toggleMenu">
                            <router-link exact to="/" class="nav-link active">
                                <i class="icon-speedometer"></i> Dashboard #1<span class="tag tag-info">NEW</span>
                            </router-link>
                            </li>
                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/dashboard2" class="nav-link"><i class="icon-grid" /><span class="page">Dashboard #2</span></router-link></li>

                        <li class="nav-title">
                            Worklists
                        </li>
                        <li class="nav-title">
                            Samples
                        </li>
                        
                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/accessioning/4/clinica" class="nav-link"><i class="icon-loop"></i> <span class="page">Accessioning</span></router-link></li>

                        <li class="nav-title">
                            Settings/Admin
                        </li>
                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/admin/clientadmin" class="nav-link"><i class="icon-wrench"></i><span class="page">Client Admin</span></router-link></li>                        

                        <!--<li class="active pageLink" v-on:click="toggleMenu"><router-link exact to="/"><i class="fa fa-desktop"></i><span class="page">Dashboard</span></router-link></li>-->
                        <li class="nav-title">
                            Etc
                        </li>
                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/tables" class="nav-link"><i class="icon-grid" /><span class="page">Tables</span></router-link></li>

                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/tasks" class="nav-link"><i class="icon-list"></i><span class="page">Tasks</span></router-link></li>
                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/setting" class="nav-link"><i class="icon-settings"></i><span class="page">Settings</span></router-link></li>

                        <li class="nav-item" v-on:click="toggleMenu"><router-link exact to="/404" class="nav-link"><i class="icon-loop"></i> <span class="page">404</span></router-link></li>

                    </ul>
                </nav>
            </div>



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
                <div class="container-fluid pt-2">
                    <div class="animated fadeIn">
                        <!-- Content Header (Page header) -->
                        <router-view :user="this.user" :organization="this.organization"></router-view>
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
                                    <strong><router-link exact :to="{name: 'Mailbox', params: {type: 'notifications'}}">View all notifications</router-link></strong>
                                </a>

                            </div>
                        </div>
                    </div>
                    <!--<div class="tab-pane p-1" id="tasks" role="tabpanel">
                        <div class="header"><strong>You have {{ user.taskCount }} tasks(s)</strong></div>
                        TODO: filters on v-for to break up tasks into periods like "Today"
                        <div v-if="user.hasTasks">
                            <div class="callout callout-info m-0 py-1">
                                <div class="callout m-0 py-h text-muted text-center bg-faded text-uppercase">
                                    <small>
                                        <b>Today</b>
                                    </small>
                                </div>
                                <div>
                                    Meeting with
                                    <strong>Lucas</strong>
                                </div>
                                <small class="text-muted mr-1"><i class="icon-calendar"></i>&nbsp; 1 - 3pm</small>
                                <small class="text-muted"><i class="icon-location-pin"></i>&nbsp; Palo Alto, CA</small>
                            </div>
                        </div>
                    </div>-->
                </div>
            </aside>
        </div>

        <!-- Main Footer -->
        <footer class="app-footer">
            <div class="copyright"><strong>Copyright &copy; {{year}} <a href="javascript:;">{{organization.name}}</a>.</strong> All rights reserved.</div>
            <div class="powered-by">Powered By Clinica Cloud Platform</div>
        </footer>
    </div>
</template>

<script>
    import { mapGetters, mapActions } from 'vuex';
    import moment from 'moment'    

    module.exports = {
        name: 'Main',
        methods: {
            changeloading: function () {
                this.store.dispatch('TOGGLE_SEARCHING');
            },
            toggleMenu: function (event) {
                // remove active from li
                window.$('li.pageLink').removeClass('active');
                // Add it to the item that was clicked
                event.toElement.parentElement.className = 'pageLink active';
            }
        },
        //store: function () {
        //    return this.$parent.$store;
        //},
        //state: function () {
        //    return this.store.state;
        //},
        created: function() {
            if(!this.$parent.$store.state.user.userLoaded)
                this.$parent.$store.dispatch('user/getUser')
            if(!this.$parent.$store.state.organizationLoaded)
                this.$parent.$store.dispatch('organization/loadOrganization');
            //this.user.getUser();
        },
        computed: {
            year: function()
            {
                return moment().format('YYYY');
            },
         ...mapGetters('user', ['user', 'userLoaded']),
         ...mapGetters('organization', ['organization', 'organizationLoaded'])
    },
    }

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
