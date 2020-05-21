import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate';
import Cookies from 'js-cookie';

Vue.use(Vuex);

// function initialState() {
//     alert(localStorage.getItem('token'));
//     if (localStorage.getItem('token') == null) return false;
//     if (localStorage.token != 'undefined') return true;
//     return false;
// }

export const store = new Vuex.Store({
    namespace: true,
    state: {
        logedIn: false,
        user: {
            UserName : "",
            Token : ""
        }
    },
    plugins: [ createPersistedState({
        getItem: key => Cookies.get(key),
        setItem: (key, value) => Cookies.set(key, value, {expires: 3, secure: true}),
        removeItem: key => Cookies.remove(key)
    })],
    mutations: {
        logingIn: state => state.logedIn = true,
        unlogingIn: state => state.logedIn = false

    // },
    // methods: {
    //     logingIn(){
    //         store.commit('logingIn');
    //     },
    //     unlogingIn(){
    //         store.commit('unlogingIn');
    //     }
     }
})