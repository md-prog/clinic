import axios from 'axios'

export const fetchInitialMessages = ({ commit }) => {
    axios.get('/api/Messages/Get').then( response  => {
        commit("FETCH_INITIAL_MESSAGES", response.data);
    }).catch( err => {
        console.log(err);
    });
}

export const fetchNextMessage = ({ commit }, lastFetchedMessageDate) => {
    axios.get('/api/Messages/FetchNextMessage/'+ lastFetchedMessageDate).then( response  => {
        commit("FETCH_NEXT_MESSAGE", response.data);
    }).catch( err => {
        console.log(err);
    });
}