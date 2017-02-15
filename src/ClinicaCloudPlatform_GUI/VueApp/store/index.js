import Vue from 'vue'
import Vuex from 'vuex'
import sampleModule from './modules/sample/store'
import userModule from './modules/user/store'

Vue.use(Vuex)

const store = new Vuex.Store({
    modules:{
        sample: sampleModule,
        user: userModule
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