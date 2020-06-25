<template>
  <div class="dropdown">
    <button class="dropbtn">{{this.$i18n.locale}}</button>
    <i class="fa fa-globe" aria-hidden="true"></i>
    <div class="dropdown-content" style="left:0;">
      <a
        v-for="language in languages"
        v-bind:key="language"
        v-on:click="setLocale(language)"
      >{{language}}</a>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    setLocale(locate) {
      this.$i18n.locale = locate;
    }
  },
  components: {},
  computed: {
    languages() {
      return Object.keys(this.$i18n.messages);
    }
  }
};
</script>

<style scoped>
a,
.dropbtn,
i {
  margin: -4px 0 0 0;
  display: inline-block;
  letter-spacing: 0.3rem;
  font-size: 1rem;
  text-decoration: none;
  text-transform: uppercase;
  transition: 0.5s;
  letter-spacing: 4px;
  -webkit-box-reflect: below 1px linear-gradient(transparent, #0005);
  font-size: 1rem;
  border: none;
  cursor: pointer;
}
a,
.dropbtn {
  font-family: "Times New Roman", Times, serif;
  padding: 1rem 1rem;
}
.dropbtn {
  position: relative;
}
.dropdown {
  position: relative;
  display: inline-block;
  margin-top: auto;
  margin-bottom: auto;
}

.dropdown-content {
  display: none;
  position: absolute;
  right: 0;
  font-family: "Times New Roman", Times, serif;
  min-width: 3rem;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
}

.dropdown-content a {
  padding: 1rem 1.1rem;
  text-decoration: none;
  display: block;
  font-family: "Times New Roman", Times, serif;
}

.dropdown:hover .dropdown-content {
  display: block;
}
/* if win settings dark mode */
@media (prefers-color-scheme: dark) {
  a,
  .dropbtn,
  i {
    color: var(--navBarDarkThemeLight);
    background: transparent;
  }
  .dropdown-content a {
    color: var(--navBarDarkThemeLight);
  }
  .dropdown-content a:hover {
    background-color: var(--navBarDarkThemeLight);
    color: var(--navBarDarkThemeGrey);
  }
  .dropdown-content a {
    background: var(--navBarDarkThemeGrey);
  }
}
@media (prefers-color-scheme: light) {
  a,
  .dropbtn,
  i {
    color: var(--navBarLightThemeLight);
    background: transparent;
  }
  .dropdown-content a {
    color: var(--navBarLightThemeLight);
  }
  .dropdown-content a:hover {
    background-color: var(--navBarLightThemeLight);
    color: var(--navBarLightThemeGrey);
  }
  .dropdown-content a {
    background: var(--navBarLightThemeGrey);
  }
}
</style>