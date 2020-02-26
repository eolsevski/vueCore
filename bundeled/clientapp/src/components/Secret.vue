<template>
  <div>
    <label>{{message}}</label>
    <button @click="getMessage">get it</button>
  </div>
</template>

<script>
import Vue from "vue";

import prepare_request from '../helpers/prepare_request';
//import auth_header from '../helpers/index';
import axios from 'axios';
//prepare_request();
//import say from '../components/Say';


export default Vue.extend({
  data() {
    return {
      message: 'empty',
      url: '/weatherforecast/secret',
      options: ''
    };
  },
  methods: {
    getMessage: async function() {

      //prepare_request(this.url);
this.options=prepare_request(this.url);

      //prepare_request();
      /*eslint-disable no-console*/
      console.log(this.options);
      this.message = await axios(this.options).then(function(response){
          console.log(response.data);
          return response.data;
      })
       .catch(function(error){
         if(error.response.status==401) {
           console.log('neautorizuotas');
           return "neautorizuotas"
         }
         return "klaida"
       });

      //console.log(prepare_request(this.url));
      //console.log(this.options);
      /*eslint-enable no-console*/
    },

    // auth_header: function() {

    //     /*eslint-disable no-console*/
    //   console.log("auth_header");
    //   /*eslint-enable no-console*/
    //   // return authorization header with jwt token
    //   let token = localStorage.getItem("token");

    //   if (token) {
    //     return { Authorization: "Bearer " + token };
    //   } else {
    //     return {};
    //   }
    // },

    // prepareRequest: function() {
    //   /*eslint-disable no-console*/
    //   console.log("prepareRequest");
    //   /*eslint-enable no-console*/
    //   return {
    //     method: "post",
    //     url: '/weatherforecast/secret',
    //     headers: this.auth_header()
    //   };
    // }
  }
});
</script>