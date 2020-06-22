<template>
  <div class="main">
    <input type="text" placeholder="username" v-model="userName" />
    <input type="password" placeholder="password" v-model="password" />
    <button class="login" @click="Login2">Login</button>
  </div>
</template>

<script>
import axios from "axios";
import { mapActions, mapGetters } from "vuex";
export default {
  data() {
    return {
      userName: "userName",
      password: "password",
      token: null
    };
  },
  computed:mapGetters(['logedIn']),
  methods: {
    ...mapActions(["fetchToken"]),
    Login2() {
      const self = this;
      this.fetchToken({ userName: this.userName, password: this.password })
      .then(()=>{
      if(self.logedIn){
      self.$router.push(localStorage.getItem("to"));
      }
      }
      );
    },

    Login: async function() {
      const self = this;
      let credentials = { userName: this.userName, token: null };

      const options = {
        method: "post",
        url: "/user/login",
        data: {
          username: this.userName,
          password: this.password
        }
      };
      this.token = await axios(options)
        .then(function(response) {
          credentials.token = response.data.user.token;

          self.$store.commit("setUser", credentials);

          self.$router.push(localStorage.getItem("to"));

          return response.data.user.token;
        })
        .catch(function(error) {
          () => {
            this.$log.fatal("errorMsg: " + error);
          };
        });

      this.$log.debug("loged as " + this.$store.state.user.user.userName);

      this.$log.debug(this.token);
    }
  },
  async mounted() {
    //this.fetchToken("this.userName",this.password);
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