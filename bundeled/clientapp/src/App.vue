<template>
  <div id="app">
    <div id="nav">
      <div id="buttons">
        <router-link to="/">Home</router-link>|
        <router-link to="/about">About</router-link>|
        <router-link to="/secret">Secret</router-link>|
        <router-link class='login' v-if="!loged" to="/login">Login</router-link>
        <a style="cursor: pointer;color:red" class='logout' v-if="loged"  v-on:click="Logout">Logout</a>
      </div>
    </div>

    <router-view/>
  </div>
</template>

<script>
export default {
  data(){return{
    loged:false
  }},
  
  mounted:function(){
    this.loged = this.checkLogedInStatus()
  },
  updated:function(){
    this.loged = this.checkLogedInStatus()
  },
  methods: {
    checkLogedInStatus: function(){
      if(localStorage.getItem('token')=='undefined') return false;
      if(localStorage.getItem('token')==null) return false;
      return true;
    },
    Logout: function() {
      localStorage.removeItem("token");
      this.$router.push("/");
      this.loged = false;
    }  
  },
  
}
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
#nav {
  display: flex;
}

#buttons {
  padding: 30px;
  display: flex;
  flex-direction: row;
  justify-content: center;

  width: 100%;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}



#nav a.router-link-exact-active {
  color: #9acd32;
}
.logout{
  color: var(--redLocal);
}
</style>
