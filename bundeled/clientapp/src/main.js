import Vue from 'vue';
import App from './App.vue';
import router from './router';
import { store } from './store';
import Vuex from 'vuex';
import 'babel-polyfill';
import VueI18n from 'vue-i18n'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

import '@/components';
import i18n from './i18n'

// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

Vue.config.productionTip = false;
Vue.use([Vuex, VueI18n]);

new Vue({
    router,
    store,
    i18n,
    render: h => h(App)
}).$mount('#app')