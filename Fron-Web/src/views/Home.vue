<template>
<div class="container-home">
<Header/>
 <h3> Hello {{datos.name}}, {{datos.rol.nameRole}}</h3> 
 
 <Footer/> 
 </div>
</template>

<script>
import axios from "axios";
import Footer from '@/components/Footer';
import Header from '@/components/Header';
   export default {
     components:{
       Header,
       Footer
     },
    
    data () {
      return {
        datos: '',
       
      }
    },
   

    created(){
      this.getUser()
    },
    methods:{
         NewUser(){
       this.$router.push('/Nuevo');
    },
     async getUser(){
      console.log(this.$store.state.data.data)
       let config = {
        headers: {
          "Authorization": "Bearer "+this.$store.state.data.data,
        },
      };

      axios.get('https://localhost:44394/api/Login', config).then((response) => {
       this.datos=response.data
      // this.desserts=datos.data;
     })
     }
    },
     computed:{
        
      }
  }
</script>
<style scoped>
.container-home{
  width: 95%;
  margin: 3em;
  margin-top: 0em;
}
</style>

