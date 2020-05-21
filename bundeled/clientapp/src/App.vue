<template>
  <div id="app">
    <b-navbar toggleable="lg" type="dark" :variant="color">
      <b-navbar-brand href="#">Gjensidige</b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <router-link class="nav-link active" to="/">{{$t("NavBar.Home")}}</router-link>
          <router-link v-if="loged" class="nav-link active" to="/about">{{$t("NavBar.About")}}</router-link>
          <router-link v-if="loged" class="nav-link active" to="/secret">{{$t("NavBar.Secret")}}</router-link>
          <router-link v-if="loged" class="nav-link active" to="/upload">{{$t("NavBar.Upload")}}</router-link>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-form-input disabled size="sm" class="mr-sm-2" v-bind:placeholder=" $t('NavBar.Search') "></b-form-input>
            <b-button disabled size="sm" class="my-2 my-sm-0" type="submit">{{$t("NavBar.Search")}}</b-button>
          </b-nav-form>

          <b-nav-item-dropdown v-bind:text="$t('NavBar.Lang')" right> 
            <b-dropdown-item v-on:click="setLocale('en')">EN</b-dropdown-item>
            <b-dropdown-item v-on:click="setLocale('lt')">LT</b-dropdown-item>
            <b-dropdown-item href="#">RU</b-dropdown-item>
            <b-dropdown-item href="#">FA</b-dropdown-item>
          </b-nav-item-dropdown>

          <b-nav-item-dropdown  v-bind:text="$t('NavBar.Color')" right>
            <b-dropdown-item v-for="color in colorVariants" :key="color" @click="setColorSchema(color)">{{color}}</b-dropdown-item>
          </b-nav-item-dropdown>

          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template v-slot:button-content>
              <em>{{$t("NavBar.User")}}</em>
            </template>
            <!-- <b-dropdown-item href="#">Profile</b-dropdown-item>
            <b-dropdown-item href="#">Sign Out</b-dropdown-item> -->
            <b-dropdown-item class="b-dropdown-item"  v-if="!loged" to="/login" @click="logingIn()">Login</b-dropdown-item>
            <b-dropdown-item class="b-dropdown-item"  v-if="!loged" to="/register">Register</b-dropdown-item>
            <b-dropdown-item class="b-dropdown-item" style="cursor: pointer;color:red" v-if="loged" v-on:click="Logout" >Logout</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>

<div class="content-view">
    <router-view/>
    </div>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import axios from 'axios';
import prepare_request from "./helpers/prepare_request";

export default {
  data() {
    return {
      loged: false,
      colorVariants:['primary', 'success', 'info', 'warning', 'danger', 'dark'],
      color:'primary', 
      tmp:""
    };
  },

  mounted: async function() {
    this.loged = await this.checkLogedInStatus();
  },
  updated: async function() {
    this.loged = await this.checkLogedInStatus();
  },
  methods: {
    setColorSchema:function(color){
      this.color=color;
    },

    checkLogedInStatus: async  function() {
      if (localStorage.getItem("token") == "undefined") return false;
      if (localStorage.getItem("token") == null) return false;

       return await  axios(prepare_request('/user/checktoken'))
      .then(function () { 
        return true
        })
      .catch(function () {
        localStorage.removeItem("token");
        if(this.$router.currentRoute.path!='/')
      {
        this.$router.push("/");
      }
        return false
        });
    },

    Logout: function() {
      localStorage.removeItem("token");
    
      if(this.$router.currentRoute.path!='/')
      {
        this.$router.push("/");
      }
      this.loged = false;
    },

    setLocale(locate) {
      this.$i18n.locale = locate
    },
    logingIn(){ /*need store commint*/}
  }
}
</script>

<style>
:root{
--blueLocal: #9dabd4;
  --redLocal: #b00;
  --greenLocal: #9acd32;
}
.content-view{
  display: flex;
  justify-content:center;
  text-align: center;
}
</style>
