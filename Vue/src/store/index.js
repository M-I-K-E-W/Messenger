import { createStore } from 'vuex';

export default createStore({
    state: {
        currentUser: [],
        messages: null,
        Users: null
    },
    mutations: {
        SetMessages(state, messages) {
            state.messages = messages
        },
        AddMessage(state, message) {
            state.messages.push(message)
        },
        setCurrentUser(state, user) {
            state.user = user;
        },
    },
});

//in Methods, we can now use
//this.$store.commit('setCurrentUser', 'email', 'id');