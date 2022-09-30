<template>
  <div>
    <!-- page-wrapper Start-->
    <div class="container-fluid p-0">
      <div class="row m-0">
        <div class="col-12 p-0">
          <div class="login-card">
            <div>
              <div>
                <a class="logo">
                  <img
                    class="img-fluid for-light"
                    src="../assets/images/logo/login.png"
                    alt="looginpage"
                  />
                  <img
                    class="img-fluid for-dark"
                    src="../assets/images/logo/logo_dark.png"
                    alt="looginpage"
                  />
                </a>
              </div>
              <div class="login-main">
                <b-card no-body>
                  <b-tabs pills vertical>
                    <b-tab active>
                      <template #title>
                        <img
                          src="../assets/images/login/firebase.svg"
                          id="firebase-tooltip"
                        />
                        <span>Gestion Academica</span>
                      </template>
                      <b-card-text>
                        <form class="theme-form">
                          <h4>Sign in to account</h4>
                          <p>Enter your email & password to login</p>
                          <div class="form-group">
                            <label class="col-form-label">Email Address</label>
                            <input
                              v-model="email"
                              class="form-control"
                              type="email"
                              required=""
                              placeholder="Test@gmail.com"
                              :class="{
                                'is-invalid': submitted && !email,
                              }"
                            />
                            <div
                              v-show="submitted && !email"
                              class="invalid-feedback"
                            >
                              Email is required
                            </div>
                          </div>
                          <div class="form-group">
                            <label class="col-form-label">Password</label>
                            <input
                              v-model="password"
                              autocomplete=""
                              class="form-control"
                              :type="type"
                              name="login[password]"
                              required=""
                              placeholder="*********"
                              :class="{
                                'is-invalid': submitted && !email,
                              }"
                            />
                            <div
                              v-show="submitted && !password"
                              class="invalid-feedback"
                            >
                              Email is required
                            </div>
                            <div class="show-hide" @click="showPassword">
                              <span class="show"></span>
                            </div>
                          </div>
                          <div class="form-group mb-0">
                            <div class="checkbox p-0">
                              <input id="checkbox1" type="checkbox" />
                              <label class="text-muted" for="checkbox1"
                                >Remember password</label
                              >
                            </div>
                            <button
                              class="btn btn-primary btn-block"
                              type="button"
                              @click="signUp"
                            >
                              Login
                            </button>
                          </div>
       
                          <p class="mt-4 mb-0">
                            Don't have account?
                            <router-link
                              class="ml-2"
                              tag="a"
                              to="/auth/register"
                            >
                              Create Account
                            </router-link>
                          </p>
                        </form>
                      </b-card-text>
                    </b-tab>
                  </b-tabs>
                </b-card>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- latest jquery-->
  </div>
</template>

<script>
import axios from "axios";
  //import firebase from 'firebase';
  import Userauth from '../auth/js/index';
  
  export default {
    name: 'login',
    data() {
      return {
        type: '',
        email: '',
        password: '',
        passwordjwt: '',
        submitted: false,
        Token: '',
      };
    },
    computed: {
 
      loggingIn() {
        return this.$store.state.authentication.status.loggingIn;
      },
    },
    created() {
      this.$store.dispatch('authentication/logout');
    },
    methods: {
      showPassword: function() {
        if (this.type === 'password') {
          this.type = 'text';
        } else {
          this.type = 'password';
        }
      },
      // Firebase login
    /*  signUp: function() {

        this.submitted = true;
        if (this.email === '' && this.password === '') {
          (this.email = 'test@admin.com'), (this.password = 'test@123456');
        } else {
          firebase
            .auth()
            .signInWithEmailAndPassword(this.email, this.password)
            .then(
              (result) => {
                Userauth.localLogin(result);
                this.$router.replace('/dashboard');
              },
              (err) => {
                (this.email = 'test@admin.com'), (this.password = 'test@123456');
                this.$toasted.show('Oops...' + err.message, {
                  theme: 'bubble',
                  position: 'bottom-right',
                  type: 'error',
                  duration: 2000,
                });
              }
            );
        }
      },*/
           signUp () {
              let json = {
               "email" : this.email,
               "password": this.password
             };
              axios.post('https://localhost:44394/api/login', json)
                 .then( data =>{          
                     this.$store.commit("getUser", data);
               this.$router.push('/dashboard');        
        })
      },
    },
  };
</script>
