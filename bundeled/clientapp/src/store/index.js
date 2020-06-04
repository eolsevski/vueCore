import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate';
import Cookies from 'js-cookie';
import user from './modules/user'

Vue.use(Vuex);

export default new Vuex.Store({
        plugins: [createPersistedState(
        {
        storage: {
          getItem: key => Cookies.get(key),
          setItem: (key, value) => Cookies.set(key, value, { expires: 3, secure: false }),
          removeItem: key => Cookies.remove(key)
        }
      }
      )],
    modules: {
        user
    }
    
})

