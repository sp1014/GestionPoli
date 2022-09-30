<template>
  <div class="header-logo-wrapper">
    <div class="logo-wrapper">
      <router-link to="/">
        <img class="img-fluid" src="../../assets/images/logo/logo.png" alt />
      </router-link>
    </div>
    <div class="toggle-sidebar" @click="toggle_sidebar">
      <feather
        class="status_toggle middle sidebar-toggle"
        type="align-center"
        id="sidebar-toggle"
      ></feather>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Logo',
    methods: {
      toggle_sidebar() {
        this.$store.dispatch('menu/opensidebar');
      },
    },
  };
</script>
