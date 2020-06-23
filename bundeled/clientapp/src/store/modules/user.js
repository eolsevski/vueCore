import prepare_request from "@/helpers/prepare_request";
import axios from "axios";
import Vue from 'vue';

const state = {
    user: {
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
    setToken(state, token) {
        state.user.token = token;
    }
}

const getters = {
    getUserName(state) {
        return state.user.userName;
    },
    getToken(state) {
        return state.user.token;
    },
    logedIn(state) {
        return state.user.token ? true : false;
    }
}

const actions = {
    async fetchToken({ commit }, user,) {
        
        Vue.$log.debug('UserName: ' + user.userName);
        let credentials = { userName: user.userName, token: null };

        const options = {
            method: "post",
            url: "/user/login",
            data: {
                username: user.userName,
                password: user.password
            }
        };

        await axios(options)
            .then(function (response) {
                credentials.token = response.data.user.token;
                commit("setUser", credentials);
                Vue.$log.debug("response status: " + response.status); 
                return response.data.user.token;
            })
            .catch(function (error) {
                () => { Vue.$log.fatal("errorMsg: " + error); }
            });
    },

    async checkToken({ commit }) {
        return await axios(prepare_request('/user/checktoken'))
            .then(function () {
                Vue.$log.debug("token still valid");
                return true;
            })
            .catch(function () {
                Vue.$log.debug("token invalid. Loging Out");
                commit('logout');
                return false
            });
    }
}
export default {
    state,
    mutations,
    getters,
    actions
}