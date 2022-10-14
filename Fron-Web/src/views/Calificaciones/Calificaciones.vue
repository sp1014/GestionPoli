<template>
<div class="container-home">
<Header/>
<div class="home">
  <section class="form-register">
    <div clase="tabla">
     <v-card>
       <v-btn @click="agregar()" color="blue">Agregar</v-btn>
    <v-card-title>
      Calificaciones
      <v-spacer></v-spacer>
      <v-text-field  v-model="search" append-icon="mdi-magnify" label="Search" single-line hide-details ></v-text-field>
    </v-card-title>
    <v-data-table :headers="headers"  :items="datos" :search="search">        
    </v-data-table>
  </v-card> 
    </div>
  </section>

</div>
<Footer/>
</div>
</template>




<script>
import Header from '@/components/Header'
import Footer from '@/components/Footer';
import axios from "axios";
   export default {
     components:{
       Header,
       Footer
     },
      data () {
      return {
        search: '',
        headers: [
          {text: 'Nombre', value: 'user.name'},
          {text: 'Apellido', value: 'user.lastName'},
          { text: 'Curso', value: 'grade.codGrade' },
          { text: 'Materia', value: 'course.nameCourse' },
          { text: 'Nota 1', value: 'califications.calification1' },
          { text: 'Nota 2', value: 'califications.calification2' },
          { text: 'Nota 3', value: 'califications.calification3' },
           { text: 'Nota Final', value: 'califications.calificationFinal' },
        ],
        desserts: [
          {
            name: 'Frozen Yogurt',
            calories: 159,
            fat: 6.0,
            carbs: 24,
            protein: 4.0,
            iron: '1%',
          },
          {
            name: 'Ice cream sandwich',
            calories: 237,
            fat: 9.0,
            carbs: 37,
            protein: 4.3,
            iron: '1%',
          },
          {
            name: 'Eclair',
            calories: 262,
            fat: 16.0,
            carbs: 23,
            protein: 6.0,
            iron: '7%',
          },
          {
            name: 'Cupcake',
            calories: 305,
            fat: 3.7,
            carbs: 67,
            protein: 4.3,
            iron: '8%',
          },
          {
            name: 'Gingerbread',
            calories: 356,
            fat: 16.0,
            carbs: 49,
            protein: 3.9,
            iron: '16%',
          },
          {
            name: 'Jelly bean',
            calories: 375,
            fat: 0.0,
            carbs: 94,
            protein: 0.0,
            iron: '0%',
          },
          {
            name: 'Lollipop',
            calories: 392,
            fat: 0.2,
            carbs: 98,
            protein: 0,
            iron: '2%',
          },
          {
            name: 'Honeycomb',
            calories: 408,
            fat: 3.2,
            carbs: 87,
            protein: 6.5,
            iron: '45%',
          },
          {
            name: 'Donut',
            calories: 452,
            fat: 25.0,
            carbs: 51,
            protein: 4.9,
            iron: '22%',
          },
          {
            name: 'KitKat',
            calories: 518,
            fat: 26.0,
            carbs: 65,
            protein: 7,
            iron: '6%',
          },
        ],
        datos:[]
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
      axios.get('https://localhost:44394/api/AllocationLoad', config).then((response) => {
       this.datos=response.data
       console.log(this.datos)
      // this.desserts=datos.data;
     })
     },
     agregar(){
        this.$router.push(`/NuevaCalificacion`);
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

.blue{
  position: absolute;
  top: -2em;
  right: 2em;
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

