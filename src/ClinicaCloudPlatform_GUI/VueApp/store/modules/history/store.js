
import Vue from 'vue';

const organizationModule = {
    state: { 
        historyItems: []
    },
    namespaced: true,
    getters: {
        historyItems: state => state.historyItems
    },
}

export default organizationModule;