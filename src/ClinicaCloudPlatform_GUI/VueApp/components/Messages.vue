<template>
    <div>
        <h1>Messages</h1>
        <Message v-for="msg in messages" :message="msg" />
        <button @click="fetchNextMessage(lastFetchedMessageDate)" class="btn-primary">Fetch a message</button>
    </div>
</template>

<script>
  import { mapGetters, mapActions } from 'vuex';
  import Message from './Message.vue'

  export default {
    components: { Message },
    computed: {
            store: function () {
                return this.$parent.$store
            },
            state: function () {
                return this.store.state
            },
            ...mapGetters('sample', ['messages', 'lastFetchedMessageDate'])
    },
    methods: mapActions('sample', ['fetchInitialMessages', 'fetchNextMessage']),

    beforeMount() {
        if(this.lastFetchedMessageDate < 0){
            this.fetchInitialMessages();}
        }
    };
</script>