import axios from 'axios'

export const loadAccession = ({ commit }, p) => {
    //axios.get('/api/Accessioning/Get/',{ params: { id:p.id, orgNameKey: p.orgNameKey }}).then( response  => {
    axios.get('/api/Accessioning/Get/' + p.id + '/' + p.orgNameKey).then( response  => {
        commit("LOAD_ACCESSION", response.data);
    }).catch( err => {
        console.log(err);
    });
};

export const newAccession = ({ commit }, p) => {
    commit("NEW_ACCESSION");
    //todo: api calls to get lists, etc
};