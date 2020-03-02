<template>
  <div id="app">
    <div id="nav">
      <div id="buttons">
        <router-link to="/">Home</router-link>|
        <router-link to="/about">About</router-link>|
        <router-link to="/secret">Secret</router-link>
        <logout v-if="loged" class="main-app-logout" @logOut="logOut" />
        
      </div>
    </div>

    <router-view  @logedIn="logedIn"/>
  </div>
</template>

<script>
export default {
  data(){return{
    loged: false
  }},
  mounted:function(){
    this.checkLogedInStatus()
  },
  methods: {
    logOut: function(){
      this.loged = false;
    },
    logedIn: function(){
      this.loged = true;
    },
    checkLogedInStatus: function(){
      
      if(localStorage.getItem('token')=='undefined') return;
      if(localStorage.getItem('token')==null) return;
      this.loged = true;
      
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
.main-app-logout {
  border: red dashe 2px;
  position: absolute;
  top: 20px;
  right: 0;
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  border: red dashe 2px;
  display: flex;
}

#buttons {
  padding: 30px;
  display: flex;
  flex-direction: row;
  justify-content: center;

  width: 100%;
}
#buttons .lg:last-child {
  margin-left: auto;
}
#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #9acd32;
}
</style>
