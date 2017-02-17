﻿import "babel-polyfill";
import Vue from 'vue';
import App from './components/App.vue';
import store from './store/index.js';
import VueRouter from 'vue-router';
import routes from './routes';

import Pace from 'pace-progress';
import Chart from 'chart.js';

require('./assets/scss/app.scss');
require('hideseek')
require('./assets/js/bootstrap.min.js');
require('./assets/js/admin_gui.js');
//require('./assets/js/plugins/daterangepicker/daterangepicker.js');
require('bootstrap-daterangepicker')
require('select2');
require('datatables.net');
require('./assets/js/plugins/datatables/integration/dataTables.bootstrap4.js');

require('./assets/img/favicon.ico');

import { domain, count, prettyDate, pluralize, truncate } from './filters'
Vue.filter('count', count)
Vue.filter('domain', domain)
Vue.filter('prettyDate', prettyDate)
Vue.filter('pluralize', pluralize)
Vue.filter('truncate', truncate)

// Routing logic

Vue.use(VueRouter)

var router = new VueRouter({
    routes: routes,
    mode: 'history',
    scrollBehavior: function (to, from, savedPosition) {
        return savedPosition || { x: 0, y: 0 }
    },
    linkActiveClass: ''
})

const app = new Vue({
    store: store, 
    router: router,
    ...App
});

export { app, store };