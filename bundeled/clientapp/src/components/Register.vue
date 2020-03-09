<template>
  <div>
    <b-form @submit="Register" @reset="onReset" v-if="show">

        <b-form-group id="input-group-1" >
        <b-form-input id="input-1" v-model="form.firstName" type="text" required placeholder="First name" ></b-form-input>
        </b-form-group>
        <b-form-group id="input-group-1" >
        <b-form-input id="input-1" v-model="form.secondName" type="text" required placeholder="Second name" ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-1" >
        <b-form-input id="input-1" v-model="form.password" type="password" required placeholder="Password" ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-1" description="We'll never share your email with anyone else.">
        <b-form-input id="input-1" v-model="form.email" type="email" required placeholder="Enter email" ></b-form-input>
        </b-form-group>



      <b-form-group id="input-group-2" label="Your User Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.userName"
          required
          placeholder="Enter user name"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Departament:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="form.departament"
          :options="departaments"
          required
        ></b-form-select>
      </b-form-group>

      <b-form-group id="input-group-4">
        <b-form-checkbox-group v-model="form.checked" id="checkboxes-4">
          <b-form-checkbox value="me">Check me out</b-form-checkbox>
          <b-form-checkbox value="that">Check that out</b-form-checkbox>
        </b-form-checkbox-group>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>

    <!-- for testing -->
    <b-card hidden class="mt-3" header="Form Data Result">
      <pre class="m-0">{{ form }}</pre>
    </b-card>
  </div>
</template>

<script>
import axios from 'axios';

  export default {
    data() {
      return {
        form: {
            firstName:'',
            secondName:'',
            password:'',
            email: '',
            userName: '',
            departament: null,
            checked: []
        },
        departaments: [{ text: 'Select One', value: null }, 'ITD', 'BRS'],
        show: true
      }
    },
    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        alert(JSON.stringify(this.form))
        this.Register;
      },
      onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.form.firstName = ''
        this.form.secondName = ''
        this.form.email = ''
        this.form.password = ''
        this.form.userName = ''
        this.form.departament = null
        this.form.checked = []
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      },
      Register: async function() {
      const options = {
        method: "post",
        url: "/user/register",
        data: this.form
      };
      await axios(options)
        //   .then(function(response) {
        // //    /* eslint-disable no-console */
        //     console.log("response: " + response);
        // // //   /* eslint-enable no-console */
        
        //   })
        // .catch(function(error) {
        //   /* eslint-disable no-console */
        //   console.log("errorMsg: " + error);
        //   /* eslint-enable no-console */
        // });
    },
    }
  }
</script>