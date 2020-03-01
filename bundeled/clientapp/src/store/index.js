import Vue from 'vue'
import Vuex from 'vuex'


Vue.use(Vuex);

function initialState() {
    alert(localStorage.getItem('token'));
    if (localStorage.getItem('token') == null) return false;
    if (localStorage.token != 'undefined') return true;
    return false;
}

export const store = new Vuex.Store({
    namespace: true,
    state: {
        lgn: initialState
    },
    mutations: {
        loged: state => state.lgn = true,
        unloged: state => state.lgn = false
    }
})