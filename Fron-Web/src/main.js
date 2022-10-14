import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

import axios from 'axios'
import VueAxios from 'vue-axios'
import {BootstrapVue, IconsPlugin} from 'bootstrap-vue'

import '@mdi/font/css/materialdesignicons.css' // Ensure you are using css-loader
import Vuetify from 'vuetify/lib'

Vue.use(VueAxios, axios)

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

Vue.use(Vuetify)


import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

export default new Vuetify({
  icons: {
    iconfont: 'mdi', // default - only for display purposes
  },
})
new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
