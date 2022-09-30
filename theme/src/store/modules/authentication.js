import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const authentication = {
  state: {
    data:[]
  },
  mutations: {
    getUser(state,data){
      state.data = data
    }

  },
  actions: {
  },
  modules: {
  }
}
