<template>
  <div id="app" class=""  >
   <navbar/>
<div class="content-view ">
    <router-view/>
    </div>
  </div>
</template>

<script>

import navbar from "@/components/UI/Navbars/BNavbar";

export default {
 components:{navbar}
  }
</script>

<style>
:root{
  --blueLocal: #9dabd4;
  --redLocal: #b00;
  --greenLocal: #9acd32;
}
.dark-mode{
  background: black;
  color: white;
}
.content-view{
  display: flex;
  justify-content:center;
  text-align: center;
}
</style>
