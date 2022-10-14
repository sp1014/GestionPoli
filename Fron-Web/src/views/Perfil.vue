<template>
<div class="container-home">
<Header/>
<div class="home">
  <section class="form-register">
      <v-form v-model="valid">
    <v-container>
        <v-avatar  class="foto" color="primary" size="130"><img src="https://e7.pngegg.com/pngimages/184/821/png-clipart-mangalore-united-states-management-computer-science-business-profile-angle-white.png"></v-avatar>
      <div class="form">
      <v-layout>
        <v-flex  xs12  md4  >
          <v-text-field  v-model="data.name" :rules="nameRules" label="Nombre" required></v-text-field>
        </v-flex>
    
        <v-flex xs12 md4>
          <v-text-field  v-model="data.lastName"  :rules="nameRules" label="Apellido" required></v-text-field>
        </v-flex>
        
        <v-flex  xs12 md4>
          <v-text-field v-model="data.email" :rules="emailRules" label="E-mail" required></v-text-field>
        </v-flex>      
      </v-layout>
          <v-layout>
        <v-flex  xs12  md4  >
          <v-text-field  v-model="data.password" :rules="passwordRules"  :counter="18"  label="Contraseña" required></v-text-field>
        </v-flex>
    
        <v-flex xs12 md4>
          <v-text-field  v-model="data.doc"  :rules="docRules" :counter="15" label="Documento" required></v-text-field>
        </v-flex>
        
        <v-flex  xs12 md4>
            <v-select  v-model="idTypeDoc"
          :hint="`${idTypeDoc.id},${idTypeDoc.nameTypeDoc}`"
          :items="lisDoc"
          item-text="nameTypeDoc"
          item-value="id"
          label="Tipo Documento"
          persistent-hint
          return-object
          single-line  required></v-select>
        </v-flex>      
      </v-layout>
      </div>
    </v-container>
      <v-btn  class="mr-4"  @click="Update()">submit</v-btn>
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
      lisDoc:'',
      data:'',
      valid: false,
      idTypeDoc:'',
      lastName: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 10 || 'Name must be less than 10 characters'
      ],
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid'
      ]
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
      axios.get('https://localhost:44394/api/Login', config).then((response) => {
       this.datos=response.data
       axios.get('https://localhost:44394/api/User/'+this.datos.id, config).then((response) => {
        this.data=response.data
       });
       axios.get('https://localhost:44394/api/UserData/Doc').then((response) => {
        this.lisDoc=response.data
        console.log(this.lisDoc)
       });

      // this.desserts=datos.data;
     })
     },
     Update(){
       const data = {
          id:this.data.id,
          name:this.data.name,
          lastName: this.data.lastName,
          email: this.data.email,
          password: this.data.password,
          doc: this.data.doc,    
          status: this.datos.status,
          idRol: this.datos.idRol,
         idTypeDoc: this.idTypeDoc.id,
        }
       console.log(data)
        let config = {
        headers: {
          "Authorization": "Bearer "+this.$store.state.data.data,
        },
      };
          axios.post("https://localhost:44394/api/user",this.form)
      axios.put(`https://localhost:44394/api/User/${this.data.id}`,data,config).then((response) => {
        console.log(response)
      }).catch(e=>{
        console.log(e)
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
.v-btn{
    position: absolute;
    right: 20em;
    top: 40em;
}
.v-card{
    background: #fff;
    margin: 1em;
border: 80px solid #fff;
}
</style>

