<template>
  <button v-show='this.$store.state.lgn' class="logout" @click="Logout">Logout</button>
</template>

<script>



export default {
  data(){ return {vsbl: this.$store.state.logedIn}
  },
  methods: {
    Logout: function() {
      localStorage.removeItem("token");
      this.token = "undefined";
      //document.location.href='/';
      this.$router.push("/");
       this.$store.commit('unloged');
    },
   logedIn: function() {
     //todo refactor
      if(localStorage.getItem("token")==null) return false;
     
      return true;
    }
  },
  computed: {
    
  }
};
</script>

<style scoped>
div {
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