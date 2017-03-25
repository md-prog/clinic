import Vue from 'vue'
import Vuex from 'vuex'
import userModule from './modules/user/store'
import organizationModule from './modules/organization/store'
import historyModule from './modules/history/store'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules: {
        user: userModule,
        organization: organizationModule,
        history: historyModule,
    },

    mutations: {
        TOGGLE_LOADING(state) {
            state.callingAPI = !state.callingAPI
        },
        TOGGLE_SEARCHING(state) {
            state.searching = (state.searching === '') ? 'loading' : ''
        },
    }

});

export default store;