<template>
    <aside class="aside-menu">
        <ul class="nav nav-tabs" role="tablist">
            <!-- Messages-->
            <li class="nav-item">
                <a class="nav-link active" data-toggle="tab" href="#messages" role="tab">
                    <i class="icon-envelope-letter"></i>
                    <span class="label label-success">{{ user.messageCount }}</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#notifications" role="tab">
                    <i class="icon-bell"></i>
                    <span class="label label-success">{{ user.notificationCount }}</span>
                </a>
            </li>
            <!--<li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#tasks" role="tab">
                    <i class="icon-list" />
                    <span class="label label-success">{{ user.taskCount }}</span>
                </a>
            </li>-->
        </ul>
        <!--Right menu tabs-->
        <div class="tab-content">
            <div class="tab-pane p-1 active" id="messages" role="tabpanel">
                <div class="header">
                    <strong>You have {{ user.messageCount }} message(s)</strong>
                </div>
                <div v-if="user.hasMessages">
                    <div v-for="message in user.customData.messages">
                        <div class="message">
                            <router-link exact class="dropdown-item" :to="{name: 'Mailbox', params: {type: 'messages'}}">
                                <div>
                                    <small class="text-muted">{{message.from}}</small>
                                    <small class="text-muted float-right mt-q">
                                        {{message.timeStamp | prettyDate}}
                                    </small>
                                </div>
                                <div class="text-truncate font-weight-bold">{{message.subject}}</div>
                                <div class="text-muted">{{message.text | truncate}}</div>
                            </router-link>
                        </div>
                        <hr />
                    </div>
                    <a href="#" class="dropdown-item text-center">
                        <strong><router-link exact :to="{name: 'Mailbox', params: {type: 'messages'}}">View all messages</router-link></strong>
                    </a>
                </div>

            </div>
            <div class="tab-pane p-1" id="notifications" role="tabpanel">
                <div class="header"><strong>You have {{ user.notificationCount }} notification(s)</strong></div>
                <div v-if="user.hasNotifications">

                    <div v-for="notification in user.customData.notifications">
                        <div class="message">
                            <router-link exact class="dropdown-item" :to="{name: 'Mailbox', params: {type: 'notifications'}}">
                                <div>
                                    <small class="text-muted">{{notification.from}}</small>
                                    <small class="text-muted float-right mt-q">
                                        {{notification.timeStamp | prettyDate}}
                                    </small>
                                </div>
                                <div class="text-truncate font-weight-bold">{{notification.subject}}</div>
                                <div class="text-muted">{{notification.text | truncate}}</div>
                            </router-link>
                        </div>
                        <hr />

                        <a href="#" class="dropdown-item text-center">
                            <strong>
                                <router-link exact :to="{name: 'Mailbox', params: {type: 'notifications'}}">
                                    View all notifications
                                </router-link>
                            </strong>
                        </a>

                    </div>
                </div>
            </div>
        </div>
    </aside>
</template>

<script>

    module.exports = {
        name: 'SecondarySidebar',
        props: {
            user: Object,
            organization: Object
        }
    };
</script>