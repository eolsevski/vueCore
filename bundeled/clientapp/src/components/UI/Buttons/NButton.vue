<template>
  <div class="button">
    <label for="toggle">&#9776;</label>
    <input type="checkbox" id="toggle" />
    <div class="menu">
      <!-- <template v-if="darkModeButton">
               <a @click="$emit('eee')">
                <span></span>
                <span></span>
                <span></span>
                <span></span> 
                 <i  class="fa fa-adjust" aria-hidden="true"></i>
                 </a>
      </template>-->
      <template v-if="Visible">
        <router-link :to="href" tag="a">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          {{value}}
        </router-link>
      </template>
    </div>
  </div>
</template>

<script>
export default {
  props: ["value", "href", "Visible"]
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

a {
  position: relative;
  display: inline-block;
  padding: 1rem 1rem;
  margin: 40px 0;
  font-size: 1rem;
  text-decoration: none;
  text-transform: uppercase;
  overflow: hidden;
  transition: 0.5s;
  letter-spacing: 0.3rem;
  cursor: pointer;
  /*ATTENTION*/
  -webkit-box-reflect: below 1px linear-gradient(transparent, #0005);
  font-family: "Times New Roman", Times, serif;
}

a span {
  position: absolute;
  display: block;
}

a span:nth-child(1) {
  top: 0;
  left: -100%;
  width: 100%;
  height: 2px;
}
a:hover span:nth-child(1) {
  animation: animate1 1s linear infinite;
}

@keyframes animate1 {
  0% {
    left: -100%;
  }
  50%,
  100% {
    left: 100%;
  }
}

a span:nth-child(2) {
  top: -100%;
  right: 0;
  width: 2px;
  height: 100%;
}
a:hover span:nth-child(2) {
  animation: animate2 1s linear infinite;
  animation-delay: 0.25s;
}

@keyframes animate2 {
  0% {
    top: -100%;
  }
  50%,
  100% {
    top: 100%;
  }
}

a span:nth-child(3) {
  bottom: 0;
  right: -100%;
  width: 100%;
  height: 2px;
}
a:hover span:nth-child(3) {
  animation: animate3 1s linear infinite;
  animation-delay: 0.5s;
}

@keyframes animate3 {
  0% {
    right: -100%;
  }
  50%,
  100% {
    right: 100%;
  }
}

a span:nth-child(4) {
  bottom: -100%;
  left: 0;
  width: 2px;
  height: 100%;
}
a:hover span:nth-child(4) {
  animation: animate4 1s linear infinite;
  animation-delay: 0.75s;
}

@keyframes animate4 {
  0% {
    bottom: -100%;
  }
  50%,
  100% {
    bottom: 100%;
  }
}

#toggle {
  display: none;
}

label {
  display: none;
}

@media only screen and (max-width: 500px) {
  body {
    justify-content: center;
  }
  label {
    cursor: pointer;
    width: 20px;
    border: 1px solid black;
  }
  .menu {
    text-align: center;
    width: 100%;
    display: none;
  }
  .menu a {
    clear: right;
    display: block;
  }
  #toggle:checked + .menu {
    display: block;
  }
}
@media (prefers-color-scheme: dark) {
  a {
    color: var(--navBarDarkThemeLight);
  }
  a:hover {
    background: var(--navBarDarkThemeLight);
    color: var(--navBarDarkThemeGrey);
    box-shadow: 0 0 5px var(--navBarDarkThemeLight),
      0 0 25px var(--navBarDarkThemeLight), 0 0 50px var(--navBarDarkThemeLight),
      0 0 200px var(--navBarDarkThemeLight);
    transition-delay: 1s;
  }
  a span:nth-child(1) {
    background: linear-gradient(90deg, transparent, var(--navBarDarkThemeLight));
  }
  a span:nth-child(2) {
      background: linear-gradient(180deg, transparent, var(--navBarDarkThemeLight));
  }
  a span:nth-child(3) {
      background: linear-gradient(270deg, transparent, var(--navBarDarkThemeLight));
  }
  a span:nth-child(4) {
      background: linear-gradient(360deg, transparent, var(--navBarDarkThemeLight));
  }
}

@media (prefers-color-scheme: light) {
  a {
    color: var(--navBarLightThemeLight);
  }
  a:hover {
    background: var(--navBarLightThemeLight);
    color: var(--navBarLightThemeGrey);
    box-shadow: 0 0 5px var(--navBarLightThemeLight),
      0 0 25px var(--navBarLightThemeLight), 0 0 50px var(--navBarLightThemeLight),
      0 0 200px var(--navBarLightThemeLight);
    transition-delay: 1s;
  }
  a span:nth-child(1) {
    background: linear-gradient(90deg, transparent, var(--navBarLightThemeLight));
  }
  a span:nth-child(2) {
      background: linear-gradient(180deg, transparent, var(--navBarLightThemeLight));
  }
  a span:nth-child(3) {
      background: linear-gradient(270deg, transparent, var(--navBarLightThemeLight));
  }
  a span:nth-child(4) {
      background: linear-gradient(180deg, transparent, var(--navBarLightThemeLight));
  }
}
</style>