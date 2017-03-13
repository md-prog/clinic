import { loadOrganization, saveOrganization } from './actions';
import Vue from 'vue';

const organizationModule = {
    state: { 
        loaded: false,
        organization:{
            "href": null,
            "name": null,
            "nameKey": null,
            "groups": [
            {
                "name": null,
                "users": [
                {
                    "href": null,
                    "email": null,
                    "fullName": null
                }
                ]
            }
            ],
            /*customData:{                
                "caseTypeDefinitions": [
                  {
                      "placeholder": 0
                  }
                ],
                "logoUrl": "",
                "panelDefinitions": [
                  {
                      "placeholder": 0
                  }
                ],
                "patientAttributes": [
                  {
                      "placeholder": 0
                  }
                ],
                "specimenAccessionSections": {
                    "rows": [
                      {
                          "cols": [
                            {
                                "sectionName": "",
                                "class": ""
                            }
                          ]
                      }
                    ]
                },
                "specimenDefinitions": [
                  {
                      "code": "",
                      "type": "",
                      "category": "",
                      "workFlowName": "",
                      "transports": [
                        {
                            "code": "",
                            "name": ""
                        },
                      ],
                      "accessionAttributes": [
                        {
                            "name": "",
                            "label": "",
                            "type": "",
                            "options": [
                              {
                                  "id": "",
                                  "name": ""
                              },
                            ],
                            "section": ""
                        },
                        {
                            "informationTooltip": "",
                            "informationSource": "",
                            "name": "",
                            "label": "",
                            "type": "",
                            "options": [],
                            "section": ""
                        }                        
                      ]
                  }
                ],
                "testDefinitions": [
                  {
                      "placeholder": 0
                  }
                ]                
            },*/
            //below will come from stormpath custom data
            css: ".navbar-brand:{background-color: #1e8fc6, padding:0, background-image:'http://vault.immunovault.com/img/logo.png', background-size: 220px 50px} .header .navbar{background-color: #36a9e1}",
            worklist:{
                worklists: ['specimenCatalog'],
                defaultWorklist: 'specimenCatalog'
            },
            dashboard:{
                dashboards: [
                    {
                        name:'biobankDashboard',
                        cards:[
                            'specimenCatalogSearch',
                            'top5Specimens',
                            'shoppingCart',
                            'orderStatus'
                        ]
                    }
                ],
                defaultDashboard: 'biobankDashboard'
            }
        }
    },
    namespaced: true,
    mutations: {
        LOAD_ORGANIZATION: (state, payload) => {
            Vue.set(state.organization, "customData", payload.customData);
            Object.assign(state.organization, payload);            
            state.loaded = true;
        },
        SAVE_ORGANIZATION: (state, payload) => {
        },
        //SET_ORGANIZATION: (state, payload) =>{
        //    state.organization = payload;
        //}
    },

    actions: {
        loadOrganization,
        saveOrganization
        //setOrganization: function(state, organization) {
        //    state.dispatch('SET_ORGANIZATION', organization);
        //},
    },

    getters: {
        organization: state => state.organization,
        organizationLoaded: state => state.loaded
    },
}

export default organizationModule;