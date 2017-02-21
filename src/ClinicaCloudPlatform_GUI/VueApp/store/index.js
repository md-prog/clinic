import Vue from 'vue'
import Vuex from 'vuex'
import sampleModule from './modules/sample/store'
import userModule from './modules/user/store'
import organizationModule from './modules/organization/store'
import accessionModule from './modules/accession/store'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules:{
        sample: sampleModule,
        user: userModule,
        organization: organizationModule,
        accession: accessionModule
    },

    mutations:{
        TOGGLE_LOADING (state) {
            state.callingAPI = !state.callingAPI
        },
        TOGGLE_SEARCHING (state) {
            state.searching = (state.searching === '') ? 'loading' : ''
        },
    }

});

export default store;