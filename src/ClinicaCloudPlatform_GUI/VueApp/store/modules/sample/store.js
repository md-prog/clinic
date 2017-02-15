import { fetchInitialMessages, fetchNextMessage } from './actions'
import minBy from 'lodash/minBy';

const sampleModule = {
    state: { messages: [], lastFetchedMessageDate: -1 },
    namespaced: true,
    mutations: {
        FETCH_NEXT_MESSAGE: (state, payload) => {
            state.messages = state.messages.concat(payload);
            state.lastFetchedMessageDate = minBy(state.messages, 'date').date;
        }
        ,
        FETCH_INITIAL_MESSAGES: (state, payload) => {
            Object.assign(state, payload);
        }
    },

    actions: {
        fetchInitialMessages,
        fetchNextMessage
    },

    getters: {
        messages: state => state.messages,
        lastFetchedMessageDate: state => state.lastFetchedMessageDate
    },
}

export default sampleModule;