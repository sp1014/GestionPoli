<template>
<div class="container-home">
<Header/>
<div class="home">
  <section class="form-register">
    <v-form v-model="valid">
    <v-container>
    <div class="form">
    <v-layout>
    <v-flex  xs12 md4>
    <v-select  v-model="idCourse" :hint="`${idCourse.id},${idCourse.nameCourse}`" :items="listCourse"
    item-text="nameCourse" item-value="id" label="Materia" persistent-hint return-object single-line  required></v-select>
    </v-flex> 
    
    <v-flex  xs12 md4>
    <v-select  v-model="idUser" :hint="`${idUser.id},${idUser.name}`" :items="listUser"
    item-text= "name" item-value="id" label="Estudiante" persistent-hint return-object single-line  required></v-select>
    </v-flex> 
        
    <v-flex  xs12 md4>
    <v-select  v-model="idGrade" :hint="`${idGrade.id},${idGrade.codGrade}`" :items="lisGrade"
    item-text="codGrade" item-value="id" label="Curso" persistent-hint return-object single-line  required></v-select>
    </v-flex>      
    
    <v-flex xs12 md4>
    <v-text-field  v-model="idCalification"  :rules="nameRules" label="Calificacion id" oncopy="return false;" disabled></v-text-field>
    </v-flex>
    
    </v-layout>
    <br>
    <v-layout>
    <div class="text-center">
    <v-dialog v-model="dialog"  width="900">
    <template v-slot:activator="{ on, attrs }">
    <v-btn  color="red lighten-2" dark v-bind="attrs" v-on="on">Calificaciones Nuevas</v-btn>
    </template>

    <v-card>
    <v-card-title class="text-h5 grey lighten-2">Calificaciones</v-card-title>
    <br>
    <v-card-text>      
    <v-flex>
          <v-text-field  v-model="Calificaciones.calification1"  :rules="nameRules" label="Nota #1" required></v-text-field>
          <v-text-field  v-model="Calificaciones.calification2"  :rules="nameRules" label="Nota #2" required></v-text-field>
          <v-text-field  v-model="Calificaciones.calification3"  :rules="nameRules" label="Nota #3" required></v-text-field>
    </v-flex>
    </v-card-text>

    <v-divider></v-divider>

    <v-card-actions>
       <v-spacer></v-spacer>
          <v-btn color="red" text @click="dialog = false">Cancelar</v-btn>
          <v-btn color="blue" text @click="Nota(),dialog = false">Guardar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
    </v-layout>
    </div>
    </v-container>
      <v-btn  class="mr-4 btn"  @click="Update()">submit</v-btn>
  </v-form>
  </section>
</div>
</div>
</template>

<script>
import Header from '@/components/Header';
import axios from "axios";
   export default {
     components:{
       Header
     },
    data () {
        return {
            listCourse:[],
            listUser:[],
            lisGrade:[],
            dialog: false,
            data:'',
            valid: false,
            nameRules: [v => !!v || 'Name is required',v => v.length <= 10 || 'Name must be less than 10 characters'],
            Calificaciones: {
              calification1:'',
              calification2:'',
              calification3:''
            },
            idCalification:'',
            idCourse:'',
            idUser:'',
            idGrade:''
        }
    },

    created(){
    this.getUserId()
    },
   
   methods:{
       async getUserId(){
       let config = {
        headers: {
          "Authorization": "Bearer "+this.$store.state.data.data,
        },
      };
      axios.get('https://localhost:44394/api/Course', config).then((response) => {
       this.listCourse=response.data
       console.log(this.listCourse)

       axios.get('https://localhost:44394/api/User/idRol/'+3, config).then((response) => {
        this.listUser=response.data
        var arreglado = this.listUser.map( item => { 
        return { id: item.id , name : item.name+' '+item.lastName }; 
         });
        this.listUser=arreglado
       });
       axios.get('https://localhost:44394/api/Grade',config).then((response) => {
        this.lisGrade=response.data
       });
     })
     },
     Update(){
       const data = {
        idCourse:this.idCourse.id,
        idUser:this.idUser.id,
        idGrade:this.idGrade.id,
        idCalifications:this.idCalification,
       
        }
       console.log(data)
        let config = {
        headers: {
          "Authorization": "Bearer "+this.$store.state.data.data,
        },
      };
          axios.post("https://localhost:44394/api/AllocationLoad",data,config).then((response) => {
           this.$router.push(`/Calificaciones`);
      })
     
     },

     Nota(){
         let config = {
        headers: {
          "Authorization": "Bearer "+this.$store.state.data.data,
        },
      };
          axios.post("https://localhost:44394/api/Calificacions",this.Calificaciones,config).then((response) => {
          console.log(response)
          this.idCalification = response.data.id
          })
     }
      }
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

.foto{
    margin-top: 2em;
}
.label{
    color: black;
     background: black;
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
.form{
    margin-top: 4em;
    height: 35em;
}
.layout{
     grid-gap: 3em;
    
}
.btn{
    position: absolute;
    right: 20em;
    top: 40em;
}

</style>
