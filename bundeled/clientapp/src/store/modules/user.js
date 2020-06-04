const state = {
    user:{
    userName: null,
    token: null
    }
}

const mutations = {
    logout(state) {
        state.user.userName = null;
        state.user.token = null;
    },
    setUser(state, credentials) {
        state.user.userName = credentials.userName;
        state.user.token = credentials.token;
    },
    setToken(state, token){
        state.user.token = token;
    }
}
export default {
    state,
    mutations
}