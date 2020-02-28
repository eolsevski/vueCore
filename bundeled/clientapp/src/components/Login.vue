<template>
  <div class="main">
    <input type="text" placeholder="username" v-model="userName" />
    <input type="password" placeholder="password" v-model="password" />
    <button class="login" @click="Login">Login</button>
    <lg class="lg" />
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      userName: "",
      password: "",
      token: "undefined"
    };
  },
  methods: { 
    Login: async function() {
      const options = {
        method: "post",
        url: "/user/login",
        data: {
          username: this.userName,
          password: this.password
        }
      };
      
      await axios(options)
      .then(function(response) {
        //this.token = response.data.token;
        localStorage.setItem("token", response.data.token);
        /* eslint-disable no-console */
        console.log(response.data.token);
        /* eslint-enable no-console */ 
        document.location.href=localStorage.getItem('fromLocation');

        })
      .catch(function(error) {
        /* eslint-disable no-console */
        console.log('errorMsg: ' + error);
        /* eslint-enable no-console */
        
        });
    },
    Logout: function() {
      localStorage.removeItem("token");
      this.token = "undefined";
    }
  }
  
  
};


</script>

<style scoped>
.main {
  --blueLocal: #9dabd4;
  --redLocal: #b00;
  --greenLocal: #9acd32;

  display: flex;
  flex-direction: column;
  max-width: 150px;
  align-self: center;
}
button {
  color: transparent;
  -webkit-text-stroke-width: 0.3px;

  font-size: 17pt;

  background: transparent;

  margin: 3px;

  width: 100px;
}
.login {
  -webkit-text-stroke-color: var(--greenLocal);
  border: 0.3px solid var(--greenLocal);
  align-self: flex-start;
}
input {
  border: var(--blueLocal) 0.3px solid;
  margin: 3px;
  font-size: 12pt;
}
.lg{
  align-self: flex-end;
}
::placeholder {
  color: var(--blueLocal);
  text-align: center;
}
</style>