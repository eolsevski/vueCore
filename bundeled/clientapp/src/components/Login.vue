<template>
  <div class="main">
    <input type="text" placeholder="username" v-model="userName" />
    <input type="password" placeholder="password" v-model="password" />
    <button class="login" @click="Login">Login</button>
    <button class="logout" @click="Logout">Logout</button>
  </div>
</template>

<script>
import Vue from "vue";
import axios from "axios";

export default Vue.extend({
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
        url: "/weatherforecast/login",
        data: {
          username: this.userName,
          password: this.password
        }
      };
      await axios(options).then(response => (this.token = response.data.token));
      localStorage.setItem("token", this.token);
    },
    Logout: function() {
      localStorage.removeItem("token");
      this.token = "undefined";
    }
  }
});
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

  width: 70%;
}
.login {
  -webkit-text-stroke-color: var(--greenLocal);
  border: 0.3px solid var(--greenLocal);
  align-self: flex-start;
}

.logout {
  -webkit-text-stroke-color: var(--redLocal);
  border: 0.3px solid var(--redLocal);
  align-self: flex-end;
}

input {
  border: var(--blueLocal) 0.3px solid;
  margin: 3px;
  font-size: 12pt;
}
::placeholder {
  color: var(--blueLocal);
  text-align: center;
}
</style>