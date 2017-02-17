import { loadOrganization, saveOrganization } from './actions'
const organizationModule = {
    state: { 
        organization:{
            name: 'Texas BioBank',
            nameKey: 'tbb',
            groups:[
                { 
                    href: 'https://api.stormpath.com/v1/groups/3oF6051KOfFy3MU1uUl0Ji',
                    groupName:'Client Admin',
                    users:[
                        {
                            'href':'https://api.stormpath.com/v1/accounts/2JdLMXWOM3Arg1DoiL60Fl',
                            email:'ian@arsclinica.com',
                            fullName: 'Ian Scott Field'
                        }
                    ],
                    groupName:'Client User',
                    users:[
                    ]
                }
            ],
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
        LOAD_ORGANIZATION: (state, payload) => {}
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
        organization: state => state.organization
    },
}

export default organizationModule;