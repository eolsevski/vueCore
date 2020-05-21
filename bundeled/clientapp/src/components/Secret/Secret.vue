<template>
  <div>
    <label>{{message}}</label>
    <button @click="getMessage">get it</button>
  </div>
</template>

<script>
import Vue from "vue";

import prepare_request from "@/helpers/prepare_request";

import axios from "axios";

export default Vue.extend({
  data() {
    return {
      message: "empty",
      url: "/user/secret",
      request: ""
    };
  },
  methods: {
    getMessage: async function() {
      this.request = prepare_request(this.url);

      this.message = await axios(this.request)
        .then(function(response) {
          return response.data;
        })
        .catch(function(error) {
          if (error.response.status == 401) {
            return "neautorizuotas";
          }
          return "klaida";
        });
      
    }
  }
});
</script>