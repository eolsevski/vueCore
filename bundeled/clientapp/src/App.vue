<template>
  <div id="app">
    <nav id="nav" class="navbar navbar-expand-sm navbar-light bg-light">
      

      <a class="navbar-brand" href="/about">N</a>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mx-auto">
          <li class="nav-item active">
            <router-link class="nav-link active" to="/">Home <span class="sr-only">(current)Home</span></router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link active" to="/about">About</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link active" to="/secret">Secret</router-link>
          </li>
        </ul>


        <form class="form-inline my-1 my-sm-0">
          <router-link class="form-control mr-sm-1" v-if="!loged" to="/login">Login</router-link>
          <a
            class="form-control mr-sm-1"
            style="cursor: pointer;color:red"
            v-if="loged"
            v-on:click="Logout"
          >Logout</a>
        </form>
      </div>



    </nav>

    <router-view />
  </div>
</template>

<script>
export default {
  data() {
    return {
      loged: false
    };
  },

  mounted: function() {
    this.loged = this.checkLogedInStatus();
  },
  updated: function() {
    this.loged = this.checkLogedInStatus();
  },
  methods: {
    checkLogedInStatus: function() {
      if (localStorage.getItem("token") == "undefined") return false;
      if (localStorage.getItem("token") == null) return false;
      return true;
    },
    Logout: function() {
      localStorage.removeItem("token");
      this.$router.push("/");
      this.loged = false;
    }
  }
};
</script>

<style>
body {
  --blueLocal: #9dabd4;
  --redLocal: #b00;
  --greenLocal: #9acd32;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #9acd32;
}
</style>
