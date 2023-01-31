import {
    createRouter,
    createWebHashHistory
} from 'vue-router';
import SignIn from '../components/SignIn.vue';
import MessageCenter from '../components/MessageCenter.vue';

export default createRouter({
    history: createWebHashHistory(),
    routes:[{
        path: '/',
        name: 'SignIn',
        component: SignIn
    },{
        path: '/Messages',
        name: 'Messages',
        component: MessageCenter
    }],
});