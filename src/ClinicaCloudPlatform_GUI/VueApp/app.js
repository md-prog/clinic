import "babel-polyfill";
import Vue from 'vue';
import App from './components/App.vue';
import store from './store/index.js';
import VueRouter from 'vue-router';
import Vue2Filters from 'vue2-filters';

import routes from './routes';

import Pace from 'pace-progress';
import Chart from 'chart.js';

require('./assets/scss/app.scss');

require('./assets/js/admin_gui.js');

require('./assets/img/favicon.ico');

import { domain, count, prettyDate, localeDate, MMDDYYYY, MMDDYYYYhhmm, localeDateOrTimeToday, pluralize, truncate } from './filters';
Vue.filter('count', count);
Vue.filter('domain', domain);
Vue.filter('prettyDate', prettyDate);
Vue.filter('MMDDYYYY', MMDDYYYY);
Vue.filter('MMDDYYYYhhmm', MMDDYYYYhhmm);
Vue.filter('localeDate', localeDate);
Vue.filter('pluralize', pluralize);
Vue.filter('truncate', truncate);
Vue.filter('localeDateOrTimeToday', localeDateOrTimeToday);

// Routing logic

Vue.use(VueRouter);

var router = new VueRouter({
    routes: routes,
    mode: 'history',
    scrollBehavior: function (to, from, savedPosition) {
        return savedPosition || { x: 0, y: 0 }
    },
    linkActiveClass: ''
});

Vue.use(Vue2Filters);

//router.afterEach(route => {
//    document.title = route.meta.title;
//});

const app = new Vue({
    store: store, 
    router: router,
    ...App
});

export { app, store };