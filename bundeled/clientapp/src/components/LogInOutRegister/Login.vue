<template>
  <div class="main">
    <input type="text" placeholder="username" v-model="userName" />
    <input type="password" placeholder="password" v-model="password" />
    <button class="login" @click="Login">Login</button>
    
  </div>
</template>

<script>
import axios from "axios";
import router from "../router";

export default {
  data() {
    return {
      userName: "userName",
      password: "password"
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
          localStorage.setItem("token", response.data.token);
          router.push(localStorage.getItem("to"));
        })
        .catch(function(error) {
          /* eslint-disable no-console */
          console.log("errorMsg: " + error);
          /* eslint-enable no-console */
        });
    },
    Logout: function() {
      localStorage.token = "undefined";
    }
  }
};
</script>

<style scoped>

.main {
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
  /* for IE */
  -webkit-text-stroke-color: #9acd32;
  border: 0.3px solid #9acd32;
  
  align-self: flex-start;
}
input {
  border: var(--blueLocal) 0.3px solid;
  /* for IE */
  border: #9dabd4 0.3px solid;
  margin: 3px;
  font-size: 12pt;
}
.lg {
  align-self: flex-end;
}
::placeholder {
  color: var(--blueLocal);
  /* for IE */
  color: #9dabd4;
  text-align: center;
}
</style>