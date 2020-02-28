<template>

    <button class="logout" @click="Logout">Logout</button>
</template>

<script>
//import Vue from 'vue'

export default {
  methods: {
      Logout: function() {
      localStorage.removeItem("token");
      this.token = "undefined";
      document.location.href='/';
    }
  }
  
}
</script>

<style scoped>
div{
    display: flex;
    flex-direction: column;
    }
button {
  color: transparent;
  -webkit-text-stroke-width: 0.3px;

  font-size: 17pt;

  background: transparent;

  margin: 3px;

  width: 100px;
}
.logout {
  -webkit-text-stroke-color: var(--redLocal);
  border: 0.3px solid var(--redLocal);
  align-self: flex-end;
}
</style>