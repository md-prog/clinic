﻿import Main from './components/Main.vue'
import GenericDashboard1 from './components/dash/GenericDashboard1.vue'
import GenericDashboard2 from './components/dash/GenericDashboard2.vue'
import ClientAdmin from './components/admin/ClientAdmin.vue'
import Tables from './components/dash/Tables.vue'
import Tasks from './components/dash/Tasks.vue'
import Setting from './components/dash/Setting.vue'
import Server from './components/dash/Server.vue'
import MailBox from './components/Mailbox.vue'
import NotFound from './components/404.vue'
import Accessioning from './components/accessioning/Accessioning.vue'

const routes= [
    {
        path: '/',
        component: Main,
        name: 'Main',        
        children: [
          {
              path: '',
              component: GenericDashboard1,
              name: 'Dashboard1',
              description: 'Generic example 1'
          }, {
              path: 'dashboard2',
              component: GenericDashboard2,
              name: 'Dashboard2',
              description: 'Simple and advance table examples'
          }, {
              path: 'tables',
              component: Tables,
              name: 'Tables',
              description: 'Simple and advance table examples'
          }, {
              path: 'tasks',
              component: Tasks,
              name: 'Tasks',
              description: 'Tasks page in the form of a timeline'
          }, {
              path: 'admin/clientadmin',
              component: ClientAdmin,
              name: 'Client Admin',
              description: 'Client Administration'
          }, {
              path: 'accessioning/:id/:orgNameKey',
              component: Accessioning,
              name: 'Edit Accession',
              description: 'Edit sample/accession'
          }, {
              path: 'accessioning',
              component: Accessioning,
              name: 'New Accession',
              description: 'Add sample/accession to the system'
          }, {
              path: 'setting',
              component: Setting,
              name: 'Settings',
              description: 'User settings page'
          }, {
              path: 'server',
              component: Server,
              name: 'Servers',
              description: 'List of our servers'
          }, {
              path: 'mailbox',
              component: MailBox,
              name: 'Mailbox'
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
