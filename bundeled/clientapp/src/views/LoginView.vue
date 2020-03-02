<template>
    <div>
        <h3>Type Yours credentials</h3>
        <login @logedIn="logIn"/>
    </div>
</template>


<script>

import Login from '@/components/Login.vue'

export default {
    components:{
    Login
} ,
  methods: {
      logIn: function(){
        this.$emit('logedIn');
      }
    },
}
</script>




<style scoped>
div{
    display: flex;
    flex-direction: column;
    }
</style>