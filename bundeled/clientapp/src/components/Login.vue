<template>
    <div>
        <input type="text" placeholder="username" v-model="userName">
        <input type="password" placeholder="password" v-model="password">
        <input v-model="token">
        <button @click="Login">Login</button>
    </div>
</template>

<script>
import Vue from "vue";
import axios from 'axios';

export default Vue.extend({
data(){
    return{
        userName:'',
        password:'',
        token:'undefined'
    }
    },
    methods: {
        Login: function(){
            const options = {
                method: 'post',
                url:'/weatherforecast/login',
                data: {
                    username: this.userName,
                    password: this.password
                }
            }
            /* eslint-disable no-console */
            axios(options).then((response) => this.token = response.data);
            console.log(this.token);
            /* eslint-enable no-console */
        }
    }

   
})
</script>