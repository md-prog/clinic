import Main from './components/Main.vue'
//import GenericDashboard1 from './components/main/GenericDashboard1.vue'
//import GenericDashboard2 from './components/main/GenericDashboard2.vue'
import ClientAdmin from './components/admin/ClientAdmin.vue'
import Tables from './components/main/Tables.vue'
import Tasks from './components/main/Tasks.vue'
import Setting from './components/main/Setting.vue'
//import Server from './components/main/Server.vue'
import MailBox from './components/Mailbox.vue'
import NotFound from './components/404.vue'
import Accessioning from './components/accessioning/Accessioning.vue'
import Worklist from './components/list/Worklist.vue'
import DashboardContainer from './components/dash/DashboardContainer.vue'
import SpecimenTrackingDashboard from './components/tracking/SpecimenTrackingDashboard.vue'

const routes= [
    {
        path: '/',
        component: Main,
        name: 'Dashboards',   
        children: [
            {
                path: '',
                redirect: 'dashboard/user',
                meta: {
                    showInNavMenu: false
                }
            },
          {
              path: 'dashboard/user/:id?',
              component: DashboardContainer,
              name: 'My Dashboard',
              meta: {
                  title: 'My Dashboard',
                  iconClass: 'fa fa-th-large'
              }
          }
        ]
    },
    {
        path: '/',
        component: Main,
        name: 'Sample Management',
        description: '',
        meta: {title: 'Sample Management'},
        children: [
            {
                path: 'accessioning/:id/:orgNameKey',
                component: Accessioning,
                name: 'Edit Accession',
                description: 'Edit sample/accession',
                meta: {
                    title: 'Accessioning',
                    showInNavMenu: false,                    
                    hasHistoryItems: true,
                    historyItemName: 'Accessions'
                }
            }, {
                path: 'accessioning',
                component: Accessioning,
                name: 'New Accession',
                description: 'Add sample/accession to the system',
                meta: {
                    title: 'Accessioning',
                    iconClass: 'fa fa-plus',
                    hasHistoryItems: true,
                    historyItemName: 'Accessions'
                }            
            },{
                path: 'dashboard/specimentracking',
                component: SpecimenTrackingDashboard,
                name: 'Specimen Tracking',
                description: 'Track and review specimen status/location',
                meta: {
                    title: 'Specimen Tracking Dashboard',
                    iconClass: 'fa fa-map-marker'
                }            
            },

        ]
    },
    {
        path: '/',
        component: Main,
        name: 'Lists',
        description: '',
        meta: {title: 'Lists'},
        children: [
        {
            path: 'list/worklist/catalog',
            component: Worklist,
            name: 'Specimen Catalog',
            description: '',
            meta: {
                title: 'Catalog',
                iconClass: 'fa fa-shopping-cart'
            }
        }, {
            path: 'list/worklist/inventory',
            component: Worklist,
            name: 'Specimen Inventory',
            description: '',
            meta: {
                title: 'Inventory',
                iconClass: "icon-chemistry"
            }
        }, {
            path: 'list/worklist/specimens',
            component: Worklist,
            name: 'Specimen Worklist',
            description: '',
            meta: {title: 'Worklist',
                iconClass: 'fa fa-tasks'
            }
        }, {
            path: 'list/worklist/cases',
            component: Worklist,
            name: 'Case Worklist',
            description: '',
            meta: {title: 'Worklist'}
        }
        ]
    },
    {
        path: '/',
        component: Main,
        name: 'Tools',
        description: '',
        meta: {title: 'Tools'},
        children: [
     {
         path: 'admin/clientadmin',
         component: ClientAdmin,
         name: 'Client Admin',
         description: 'Client Administration',
         meta: {title: 'Client Admin'}
     }, {
         path: 'setting',
         component: Setting,
         name: 'Settings',
         description: 'User settings page',
         meta: {title: 'Settings'}
     }, {
         path: 'mailbox',
         component: MailBox,
         name: 'Mailbox',
         meta: {title: 'Mailbox'}
     }
        ]
    },
    {
        // not found handler
        path: '*',
        component: NotFound
    }
]

export default routes
