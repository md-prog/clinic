import MainView from './components/Main.vue'
import DashboardView from './components/dash/Dashboard.vue'
import MessagesView from './components/Messages.vue'
import TablesView from './components/dash/Tables.vue'
import TasksView from './components/dash/Tasks.vue'
import SettingView from './components/dash/Setting.vue'
import ServerView from './components/dash/Server.vue'
import ReposView from './components/dash/Repos.vue'
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
              component: DashboardView,
              name: 'Dashboard',
              description: 'Overview of environment'
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
              path: 'repos',
              component: ReposView,
              name: 'Repository',
              description: 'List of popular javascript repos'
          }
        ]
    }, 
    { 
        path: '/mailbox',
        component: MailBoxView,
        name: 'MailBox'
    },
    {
        // not found handler
        path: '*',
        component: NotFoundView
    }
]

export default routes
