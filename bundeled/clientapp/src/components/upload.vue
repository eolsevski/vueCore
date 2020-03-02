<template>
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <h1>Vue JS Axios - Image Upload using PHP API - ItSolutionStuff.com</h1>
      <label>File
        <input type="file" id="file" ref="file" v-on:change="onChangeFileUpload()"/>
      </label>
        <button v-on:click="submitForm()">Upload</button>
    </div>
  </div>
</template>
  
<script>

import axios from 'axios';


  export default {
    data(){
      return {
        file: ''
      }
    },
  
    methods: {
      submitForm(){
            let formData = new FormData();
            formData.append('file', this.file);
  
            axios.post('/user/upload',
                formData,
                {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
              }
            ).then(function(data){
                /*eslint-disable no-console*/
              console.log(data.data);
              /*eslint-enable no-console*/
            })
            .catch(function(){
                /*eslint-disable no-console*/
              console.log('FAILURE!!');
              /*eslint-enable no-console*/
            });
      },
  
      onChangeFileUpload(){
        this.file = this.$refs.file.files;
      }
    }
  }
</script>