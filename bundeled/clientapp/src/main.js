import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store  from './store'
import 'babel-polyfill'
import '@/components'
import i18n from './i18n'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import VueLogger from 'vuejs-logger';


// Install BootstrapVue
Vue.use(BootstrapVue)

// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

Vue.config.productionTip = false


const isDevelopment = process.env.NODE_ENV === 'development';

const options = {
    isEnabled: true,
    logLevel : isDevelopment ? 'debug' : 'error',
    stringifyArguments : false,
    showLogLevel : true,
    showMethodName : true,
    separator: '|',
    showConsoleColors: true
};
 
Vue.use(VueLogger, options);

new Vue({
    router,
    store,
    i18n,
    render: h => h(App)
}).$mount('#app')