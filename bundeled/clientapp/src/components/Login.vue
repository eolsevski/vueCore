<template>
    <div>
        <input type="text" placeholder="username" v-model="userName">
        <input type="password" placeholder="password" v-model="password">
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
        Login: async function(){
            const options = {
                method: 'post',
                url:'/weatherforecast/login',
                data: {
                    username: this.userName,
                    password: this.password
                }
            }
            
            await axios(options)
            //.then((response)=> this.token=response);
            .then((response) => this.token = response.data);
            /* eslint-disable no-console */
            console.log(this.token);
            /* eslint-enable no-console */
            localStorage.setItem('token',this.token);
        },
        sayHello: function(){
            /* eslint-disable no-console */
            console.log("hello");
            /* eslint-enable no-console */
        }
    }

   
})
</script>