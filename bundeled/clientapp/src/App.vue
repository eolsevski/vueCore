<template>
  <div id="app">
    <navbar />
    <div class="content-view">
      <router-view />
    </div>
  </div>
</template>

<script>
import navbar from "@/components/UI/Navbars/Navbar";

export default {
  components: { navbar }
};
</script>

<style>
:root {
  --blueLocal: #9dabd4;
  --skyLocal: #03e9f4;
  --redLocal: #b00;
  --greenLocal: #9acd32;
  --greyLocal: #333;
  --blackLocal: #222;
  --navBarDarkThemeLight:#9acd32;
  --navBarDarkThemeGrey:#333;
  --navBarDarkThemeBlack:#222;
  --navBarLightThemeLight: #9dabd4;
  --navBarLightThemeGrey: #fff;
  --navBarLightThemeBlack: #ccc;
}

.content-view {
  display: flex;
  justify-content: center;
  text-align: center;
}

/* if win settings dark mode */
@media (prefers-color-scheme: dark) {
  body,i {
    background: var(--navBarDarkThemeGrey);
    color: var(--navBarDarkThemeLight);
  }
  
}
@media (prefers-color-scheme: light) {
  body {
    background: white;
    color: var(--navBarLightThemeLight);
  }
}
</style>
