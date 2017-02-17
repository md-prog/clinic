import MainView from './components/Main.vue'
import GenericDashboardView1 from './components/dash/GenericDashboard1.vue'
import GenericDashboardView2 from './components/dash/GenericDashboard2.vue'
import ClientAdminView from './components/admin/ClientAdmin.vue'
import TablesView from './components/dash/Tables.vue'
import TasksView from './components/dash/Tasks.vue'
import SettingView from './components/dash/Setting.vue'
import ServerView from './components/dash/Server.vue'
import MailBoxView from './components/Mailbox.vue'
import NotFoundView from './components/404.vue'

const routes= [
    {
        path: '/',
        component: MainView,
        name: 'Main',        
        children: [
          {
              path: '',
              component: GenericDashboardView1,
              name: 'Dashboard1',
              description: 'Generic example 1'
          }, {
              path: 'dashboard2',
              component: GenericDashboardView2,
              name: 'Dashboard2',
              description: 'Simple and advance table examples'
          }, {
              path: 'tables',
              component: TablesView,
              name: 'Tables',
              description: 'Simple and advance table examples'
          }, {
              path: 'tasks',
              component: TasksView,
              name: 'Tasks',
              description: 'Tasks page in the form of a timeline'
          }, {
              path: 'admin/clientadmin',
              component: ClientAdminView,
              name: 'Client Admin',
              description: 'Client Administration'
          }, {
              path: 'setting',
              component: SettingView,
              name: 'Settings',
              description: 'User settings page'
          }, {
              path: 'server',
              component: ServerView,
              name: 'Servers',
              description: 'List of our servers'
          }, {
              path: 'mailbox',
              component: MailBoxView,
              name: 'Mailbox'
          }
        ]
    },
    {
        // not found handler
        path: '*',
        component: NotFoundView
    }
]

export default routes
