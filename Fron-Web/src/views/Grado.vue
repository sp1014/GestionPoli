<template>
<div class="container-home">
<Header/>
<div class="home">
    <section class="form-register">
    <div clase="tabla">
     <v-card>
    <v-card-title>
      Grados
      <v-spacer></v-spacer>
      <v-text-field  v-model="searchCourse" append-icon="mdi-magnify" label="Buscar" single-line hide-details ></v-text-field>
    </v-card-title>
    <v-data-table :headers="headersCourse"  :items="datosCourse" :search="searchCourse">        
    </v-data-table>
  </v-card> 
    </div>
  </section>
</div>
</div>
</template>

<script>
import Header from '@/components/Header'
import axios from "axios";
   export default {
     components:{
       Header
     },
      data () {
      return {
        searchCourse:'',
         headersCourse: [
          {text: 'Id', value: 'id'},
          {text: 'Grado', value: 'codGrade'},
          { text: 'Estado', value: 'status' },
    
        ],

        datos:[],
        datosCourse:[]
      }      
    },
      created(){
      this.getUser()
    },
    methods:{
        getColor (califications) {
        if (califications.calification1 > 29) return 'red'
        else if (calories > 200) return 'orange'
        else return 'green'
      },
     async getUser(){
       let config = {
        headers: {
          "Authorization": "Bearer "+this.$store.state.data.data,
        },
      };
        axios.get('https://localhost:44394/api/Grade', config).then((response) => {
       this.datosCourse=response.data
       console.log(this.datos)
      // this.desserts=datos.data;
     })
     }
    },
   }
</script>
<style scoped>
.container-home{
  width: 98%;
  margin: 1em;
  margin-top: 0em;
 
}
.home{
  margin: 0em;
}


.form-register {
  width: 100%;
  background: #f1f7f7;
  padding: 10px;
  margin: auto;
  margin-top: 1em;
  border-radius: 2px;
  font-family: 'calibri';
  color: white;
  box-shadow: 7px 13px 37px rgb(144, 166, 180);
}


.v-card{
    background: #fff;
    margin: 1em;
border: 80px solid #fff;
}
</style>

