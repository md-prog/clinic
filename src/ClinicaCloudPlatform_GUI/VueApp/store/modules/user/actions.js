import axios from 'axios'

export const getUser = ({ commit }) => {
    axios.get('/me').then( response  => {
        commit("GET_USER", response.data);
    }).catch( err => {
        console.log(err);
    });
}
export const updateCustomData = ({ commit }) => {
    axios.post('/api/User/UpdateCustomData', {
        Key: 'messages', 
        Value: '[{"date": "2012-04-23T18:25:43.511Z","source": "SystemNotifications","read": "frue","expires": "2017-04-23T18:25:43.511Z","message": "Sample message #1"},{"date": "2012-04-24T18:29:22.511Z","source": "SystemNotifications","read": "false","expires": "2017-04-24T18:29:22.511Z","message": "Sample message #2"}]'
    }).then( response  => {
        commit("UPDATE_CUSTOM_DATA", response.data);
    }).catch( err => {
        console.log(err);
    });
}