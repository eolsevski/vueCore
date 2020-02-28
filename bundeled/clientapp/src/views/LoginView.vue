<template>
    <div>
        <h3>Type Yours credentials</h3>
        <login/>
    </div>
</template>

<script>
import Login from '@/components/Login.vue'

export default {
components:{
    Login
}    
}
</script>

<style scoped>
div{
    display: flex;
    flex-direction: column;
    }
</style>