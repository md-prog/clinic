import { loadAccession } from './actions'
const accessionModule = {
    state: { 
        loaded: false,
        accession:{
            "accessionID": 0,
            "clientCode": "",
            "clients": [
            {
                "id": 0,
                "name": ""
            },
            ],
            "client":{},
            "facilities": [
              {
                  "id": 0,
                  "name": ""
              }
            ],
            "facilityName": "",
            "patients": [
              {
                  "id": 0,
                  "lastName": "",
                  "firstName": "",
                  "DOB": "",
                  "SSN": ""
              }
            ],
            "patientId":0,
            "patientLast": "",
            "patientFirst": "",
            "patientDOB": "",
            "patientSSN": "",
            "mrn": "",
            "specimens": [
              {
                  "id": 0,
                  "externalID": "",
                  "customData": null
              }
            ],
            "cases": [
              {
                  "id": 0,
                  "caseNumber": "",
                  "processingLab": "",
                  "analysisLab": "",
                  "professionalLab": "",
                  "customData": null,
                  "panels": [
                    {
                        "panelName": "",
                        "customData": null
                    }
                  ],
                  "tests": [
                    {
                        "testName": null,
                        "customData": null
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
        }
    },

    actions: {
        loadAccession
    },

    getters: {
        accession: state => state.accession,
        loaded: state => state.loaded
    },
}

export default accessionModule;