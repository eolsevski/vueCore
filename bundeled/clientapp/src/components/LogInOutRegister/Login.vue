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
  computed: mapGetters(["logedIn"]),
  methods: {
    ...mapActions(["fetchToken"]),
    Login2() {
      const self = this;
      this.fetchToken({
        userName: this.userName,
        password: this.password
      }).then(() => {
        if (self.logedIn) {
          self.$router.push(localStorage.getItem("to"));
        }
      });
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
  align-self: flex-start;
}
input {
  margin: 3px;
  font-size: 12pt;
}
.lg {
  align-self: flex-end;
}
::placeholder {
  text-align: center;
}
@media (prefers-color-scheme: dark) {
  .login {
    -webkit-text-stroke-color: var(--navBarDarkThemeLight);
    border: 0.3px solid var(--navBarDarkThemeLight);
  }
  input {
    border: var(--navBarDarkThemeLight) 0.3px solid;
    color: var(--navBarDarkThemeLight);
    background: transparent;
  }
  ::placeholder {
    color: var(--navBarDarkThemeLight);
  }
}
@media (prefers-color-scheme: light) {
  .login {
    -webkit-text-stroke-color: var(--navBarLightThemeLight);
    border: 0.3px solid var(--navBarLightThemeLight);
  }
  input {
    border: var(--navBarLightThemeLight) 0.3px solid;
    color: var(--navBarLightThemeLight);
    background: transparent;
  }
  ::placeholder {
    color: var(--navBarLightThemeLight);
  }
}
</style>