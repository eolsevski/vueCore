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
            <b-form-input
              disabled
              size="sm"
              class="mr-sm-2"
              v-bind:placeholder=" $t('NavBar.Search') "
            ></b-form-input>
            <b-button disabled size="sm" class="my-2 my-sm-0" type="submit">{{$t("NavBar.Search")}}</b-button>
          </b-nav-form>

          <b-nav-item-dropdown v-bind:text="$t('NavBar.Lang')" right>
            <b-dropdown-item v-on:click="setLocale('en')">EN</b-dropdown-item>
            <b-dropdown-item v-on:click="setLocale('lt')">LT</b-dropdown-item>
            <b-dropdown-item href="#">RU</b-dropdown-item>
            <b-dropdown-item href="#">FA</b-dropdown-item>
          </b-nav-item-dropdown>

          <b-nav-item-dropdown v-bind:text="$t('NavBar.Color')" right>
            <b-dropdown-item
              v-for="color in colorVariants"
              :key="color"
              @click="setColorSchema(color)"
            >{{color}}</b-dropdown-item>
          </b-nav-item-dropdown>

          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template v-slot:button-content>
              <em>{{userName($t("NavBar.User"))}}</em>
            </template>

            <!-- <b-dropdown-item href="#">Profile</b-dropdown-item>
            <b-dropdown-item href="#">Sign Out</b-dropdown-item>-->
            <b-dropdown-item
              class="b-dropdown-item"
              v-if="!loged"
              to="/login"
              @click="checkLogedInStatus()"
            >Login</b-dropdown-item>
            <b-dropdown-item class="b-dropdown-item" v-if="!loged" to="/register">Register</b-dropdown-item>
            <b-dropdown-item
              class="b-dropdown-item"
              style="cursor: pointer;color:red"
              v-if="loged"
              @click="Logout"
            >Logout</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>

    <div class="content-view"></div>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import prepare_request from "@/helpers/prepare_request";
import axios from "axios";

export default {
  data() {
    return {
      loged: false,
      colorVariants:['primary', 'success', 'info', 'warning', 'danger', 'dark'],
      color:'primary', 
      tmp:""
    };
  },
  computed:{
   
  },
  mounted: 
    async function() {
    this.loged = await this.checkLogedInStatus();
    
  },
  updated: async function() {
    this.loged = await this.checkLogedInStatus();
  },
  methods: {
    setColorSchema:function(color){
      this.color=color;
    },
    userName(userName){

      const result = this.$store.state.user.user.userName;
    
      if(result==null)
      {return userName}
      else{
        return result    
      }
    },
    
    checkLogedInStatus: async function() {
      const self = this;
      if (this.$store.state.user.user.token == "undefined") return false;
      if (this.$store.state.user.user.token == null) return false;

       return await axios(prepare_request('/user/checktoken'))
      .then(function () { 
        return true
        })
      .catch(function () {
        self.$store.commit('logout');
        localStorage.removeItem("token");
        if(self.$router.currentRoute.path!='/')
          {this.$router.push("/");}
        return false
        });
    },

    Logout: function() {
      localStorage.removeItem("token");
      this.$store.commit('logout');
      if(this.$router.currentRoute.path!='/')
      { this.$router.push("/"); }
      this.loged = false;
    },

    setLocale(locate) {
      this.$i18n.locale = locate
    }
    
  }
}
</script>