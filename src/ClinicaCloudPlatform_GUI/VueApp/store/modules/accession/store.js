import { loadAccession, newAccession } from './actions'

const accessionModule = {
    state: { 
        loaded: false,
        isNew: false,
        accession:{
            "id": 0,
            "clients": [
                {
                    "id": 0,
                    "name": ''
                },
            ],
            "client":{
                "id": 0,
                "name": ''
            },
            "facilities": [
              {
                  "id": 0,
                  "name": ''
              }
            ],
            "facility": {
                "id": 0, 
                "name": ''
            },
            "patients": [
              {
                  "id": 0,
                  "lastName": '',
                  "firstName": '',
                  "dob": '01/01/1900',
                  "ssn": '000-00-000'
              }
            ],
            "patient":{
                "id": 0, 
                "lastName": '', 
                "firstName": '',
                "ssn": '000-00-000', 
                "dob": '01/01/1900'},
            "mrn": '',
            "specimens": [
              {
                  "id": 0,
                  "externalID": '',
                  "customData": '{}'
              }
            ],
            "cases": [
              {
                  "id": 0,
                  "caseNumber": '',
                  "processingLab": '',
                  "analysisLab": '',
                  "professionalLab": '',
                  "customData": '{}',
                  "panels": [
                    {
                        "panelName": '',
                        "customData": '{}'
                    }
                  ],
                  "tests": [
                    {
                        "testName": '',
                        "customData": '{}'
                    }
                  ]
              }
            ]
        }
    },
    namespaced: true,
    mutations: {
        LOAD_ACCESSION: (state, payload) => {
            Object.assign(state.accession, payload);
            state.loaded = true;
        },
        NEW_ACCESSION: (state) => {
            state.isNew = true;
        }
    },

    actions: { //don't forget to import from ./actions       
        loadAccession,
        newAccession
    },

    getters: {
        accession: state => state.accession,
        accessionLoaded: state => state.loaded,
        isNewAccession: state => state.isNew
    },
}

export default accessionModule;