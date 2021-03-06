﻿import axios from 'axios'

export const loadGlobalLookupData = ({ commit }, orgNameKey) => {
    axios.all([
        axios.get('/api/Client/' + orgNameKey),
        axios.get('/api/Lab/' + orgNameKey),
        axios.get('/api/Doctor/' + orgNameKey),
        axios.get('/api/Patient/' + orgNameKey),
    ]).then(axios.spread(function (clientResponse, labResponse, doctorResponse, patientResponse) {                    
        //vm.$set(vm.state, 'clients', clientResponse.data);
        //vm.$set(vm.state, 'labs', clientResponse.data);
        //vm.$set(vm.state, 'doctors', clientResponse.data);
        //vm.$set(vm.state, 'patients', clientResponse.data);
        commit("LOAD_CLIENTS", clientResponse.data);
        commit("LOAD_DOCTORS", doctorResponse.data);
        commit("LOAD_PATIENTS", patientResponse.data);
        commit("LOAD_LABS", labResponse.data);
        commit("LOADED", true);
    })).catch(err => {console.log(err)});
};