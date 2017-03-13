<template>
    <div class="aside-menu">
        <ul class="nav nav-tabs" role="tablist">
            <li v-if="this.$route.meta.hasHistoryItems" class="nav-item">
                <a class="nav-link active" data-toggle="tab" href="#recent" role="tab">
                    <i class="fa fa-history"></i>
                    <span class="label label-info">{{ 12 }}</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#messages" role="tab">
                    <i class="icon-envelope-letter"></i>
                    <span class="label label-success">{{ user.messageCount }}</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#notifications" role="tab">
                    <i class="icon-bell"></i>
                    <span class="label label-warning">{{ user.notificationCount }}</span>
                </a>
            </li>
        </ul>
        <div class="tab-content">

            <div class="tab-pane p-1 active" id="recent" role="tabpanel">
                <div class="header">
                    <strong>Recent {{this.$route.meta.historyItemName}}</strong>
                </div>
                <div v-if="historyItems.length > 0">
                    <div v-for="item in historyItems">
                        <div class="message">
                            <router-link exact class="dropdown-item" :to="{name: 'Accessioning', params: {orgNameKey: organization.nameKey, id: item.id}}">
                                <div>
                                    <small class="text-muted">{{item.title}}</small>
                                    <small class="text-muted float-right mt-q">
                                        {{item.timeStamp | prettyDate}}
                                    </small>
                                </div>
                                <div class="text-truncate font-weight-bold">{{item.headline}}</div>
                                <div class="text-muted">{{item.content | truncate}}</div>
                            </router-link>
                        </div>
                        <hr />
                    </div>
                </div>
            </div>

            <div class="tab-pane p-1" id="messages" role="tabpanel">
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
    </div>
</template>

<script>

    module.exports = {
        name: 'SecondarySidebar',
        props: {
            user: Object,
            organization: Object,
            historyItems: Array
        }
    };
</script>