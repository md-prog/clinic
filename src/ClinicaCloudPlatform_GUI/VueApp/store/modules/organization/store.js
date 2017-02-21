import { loadOrganization, saveOrganization } from './actions'
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
            customData: "{}",
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
            Object.assign(state.organization, payload);
            state.loaded = true;
        }
        ,
        SAVE_ORGANIZATION: (state, payload) => {
        },
        //SET_ORGANIZATION: (state, payload) =>{
        //    state.organization = payload;
        //}
    },

    actions: {
        loadOrganization,
        saveOrganization,
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