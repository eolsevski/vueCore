<template>
  <div class="home">
    <img alt="Vue logo" src="../../assets/logo.png" />
    <p  v-on:click="consoleLocale()">{{ $t("message") }}</p>
  </div>
</template>

<script>
export default {
};
</script>
