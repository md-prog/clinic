import "babel-polyfill";
import Vue from 'vue';
import App from './components/App.vue';
import store from './store/index.js';
import VueRouter from 'vue-router';
import routes from './routes';

require('./assets/scss/app.scss');
require('./assets/css/app.css'); //migrate to scss

require('./assets/js/bootstrap.min.js');
//require("font-awesome-webpack");
require('./assets/js/admin_gui.js');

import Pace from 'pace-progress';

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
    }
})

const app = new Vue({
    store: store, 
    router: router,
    ...App
});

export { app, store };