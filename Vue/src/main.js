import { createApp } from 'vue';
import App from './App.vue';

import router from './router'
//import messageHub from './signalr';
import store from './store';

createApp(App)
    .use(router)
    .use(store)
    //.use(messageHub)
    .mount('#app')
