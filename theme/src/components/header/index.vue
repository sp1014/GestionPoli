<template>
  <div class="header-wrapper row m-0">
    <SearchBar />
    <Logo />
    <div class="left-header col horizontal-wrapper pl-0">
      <ul class="horizontal-menu">
      </ul>
    </div>
    <div class="nav-right col-8 pull-right right-header p-0">
      <ul class="nav-menus">
        <li class="language-nav">
          <Language />
        </li>
        <li>
          <span class="header-search"
            ><feather type="search" @click="search_open()"></feather
          ></span>
        </li>
        <Notifications />
        <li>
          <Mode />
        </li>
        <li class="maximize">
          <Maximize />
        </li>
        <Profile />
      </ul>
    </div>
  </div>
</template>
<script>
  import { mapState } from 'vuex';

  import Language from './language';
  import Notifications from './notifications';
  import Mode from './mode';
  import Maximize from './maximize';
  import Profile from './profile';
  import Logo from './logo';
  import SearchBar from './search';

  export default {
    name: 'Search',
    components: {
      Language,
      Notifications,
      Mode,
      Maximize,
      Profile,
      Logo,
      SearchBar,
    },
    data() {
      return {

      };
    },
    computed: {
      ...mapState({
        menuItems: (state) => state.menu.searchData,
        megamenuItems: (state) => state.menu.megamenu,
        searchOpen: (state) => state.menu.searchOpen,
      }),
    },
    methods: {
      search_open() {
        this.$store.state.menu.searchOpen = true;
      },
    
    },
  };
</script>
