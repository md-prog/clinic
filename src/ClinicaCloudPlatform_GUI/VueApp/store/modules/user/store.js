import { getUser, updateCustomData} from './actions'

const userModule = {
    state: { user: {
        customData:{
            messages:[
            ],
            notifications:[
            ],
            tasks:[             
            ]
        },
        groups:{
            items:[
            ]
        }
    }
    },
    namespaced: true,
    mutations: {
        GET_USER: (state, payload) => {
            Object.assign(state.user, payload.account);
            
            //dummy data
            state.user.customData.messages = [
                {id: "1", from: "Kyle Dunn", subject: "Message 1", text: "Message 1 is abc 123 def 456 ghi 789", timeStamp: "2012-04-23T18:25:43.000Z", read: true}, 
                {id: "2", from: "Ian Field", subject: "Message 2", text: "Message 2 is abc 123 def 456 ghi 789", timeStamp: "2012-04-23T18:29:41.000Z", read: false}
            ]

            state.user.messageCount = 0;
            state.user.hasMessages = (typeof state.user.customData.messages !== 'undefined' && state.user.customData.messages.length > 0);
            if(state.user.hasMessages)
                state.user.messageCount = state.user.customData.messages.length;

            state.user.notificationCount = 0;
            state.user.hasNotifications = (typeof state.user.customData.notifications !== 'undefined' && state.user.customData.notifications.length > 0);
            if(state.user.hasNotifications)
                state.user.notificationCount = state.user.customData.notifications.length;

            state.user.taskCount = 0;
            state.user.hasTasks = (typeof state.user.customData.tasks !== 'undefined' && state.user.customData.tasks.length > 0);
            if(state.user.hasTasks)
                state.user.taskCount = state.user.customData.tasks.length;

            if(!state.user.groups.items)
                state.user.groups.items = [];
        }
        
        ,
        UPDATE_CUSTOM_DATA: (state, payload) => {
            
        }
    },

    actions: {
        getUser,
        updateCustomData
    },

    getters: {
        user: state => state.user
    },
}

export default userModule;