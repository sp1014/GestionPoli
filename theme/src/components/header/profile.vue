<template>
  <li class="profile-nav onhover-dropdown p-0 mr-0">
    <div class="media profile-media">
      <img
        class="b-r-10"
        src="../../assets/images/dashboard/profile.jpg"
        alt=""
      />
      <div class="media-body">
        <span>Emay Walter</span>
        <p class="mb-0 font-roboto">
          Admin <i class="middle fa fa-angle-down"></i>
        </p>
      </div>
    </div>
    <ul class="profile-dropdown onhover-show-div">
      <li>
        <a  @click="settings"><feather type="user"></feather><span>Account </span></a>
      </li>
      <li>
        <a @click="logout"
          ><feather type="log-in"></feather><span>Log out</span></a
        >
      </li>
    </ul>
  </li>
</template>

<script>
  import firebase from 'firebase';
  import UserAuth from '../../auth/js/index';

  export default {
    name: 'Profile',
    methods: {
      logout: function() {
        firebase
          .auth()
          .signOut()
          .then(() => {
            UserAuth.Logout();
            this.$router.replace('/auth/login');
          });
      },
      settings: function(){
           this.$router.replace('/users/edit');
      }
    },
  };
</script>
