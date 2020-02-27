<template>
  <div>
    <label>{{message}}</label>
    <button @click="getMessage">get it</button>
  </div>
</template>

<script>
import Vue from "vue";

import prepare_request from "../helpers/prepare_request";

import axios from "axios";

export default Vue.extend({
  data() {
    return {
      message: "empty",
      url: "/weatherforecast/secret",
      options: ""
    };
  },
  methods: {
    getMessage: async function() {
      this.options = prepare_request(this.url);

      //prepare_request();
      /*eslint-disable no-console*/
      console.log(this.options);
      this.message = await axios(this.options)
        .then(function(response) {
          console.log(response.data);
          return response.data;
        })
        .catch(function(error) {
          if (error.response.status == 401) {
            console.log("neautorizuotas");
            return "neautorizuotas";
          }
          return "klaida";
        });
      /*eslint-enable no-console*/
    }
  }
});
</script>