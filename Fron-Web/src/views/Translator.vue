<template>
  <div>
    <link
      href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css"
      rel="stylesheet"
      integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor"
      crossorigin="anonymous"
    />
    <Header />
    <div id="contenedor">
      <div>
        <div class="container">
          <div class="mb-3">
            <input
              class="form-control"
              type="file"
              id="formFile"
              v-on:change="getFile($event)"
              required
            />

            <label for="formFile"></label>
          </div>
          <div class="flex-wrap input-group mb-3">
            <label class="input-group-text" for="inputGroupSelect01" id="from">
              Translate from</label
            >
            <select
              v-model="Seleccionado"
              class="form-select"
              id="Translatefrom"
              required
            >
              <option v-for="data in datos" :value="data" :key="data">
                {{ data.name }}
              </option>
            </select>
          </div>
          <div id="errorFile"></div>
          <div id="errorSelectFrom"></div>
          <div id="errorSelectInto"></div>
          <div class="input-group mb-3">
            <label class="input-group-text" for="inputGroupSelect01" id="into"
              >Translate into</label
            >
            <select class="form-select" id="TranslateInto" required>
              <option selected></option>
              <option v-for="data in datos" :value="data" :key="data">
                {{ data.name }}
              </option>
            </select>
          </div>
          <br />
          <div
            class="btn-group"
            role="group"
            aria-label="Basic mixed styles example"
          >
            <button
              id="traduccion"
              type="button"
              class="btn btn-primary"
              @click="saveTranslate($event)"
            >
              Traducir
            </button>
          </div>
          <div class="preloader" v-if="loading">
          
         
        </div>
        
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Header from "@/components/Header.vue";
import global from "../../config.js";
import axios from "axios";
const crear = "https://localhost:5024/api/FileList/listTranslate";

export default {
  data() {
    return {
      titulo: "Translate file",
      uploadURL: global.URL_FILE,
      urlTranslate: global.URL_TRANSLATE,
      file: "",
      isCreate: false,
      PropertyName: "PropertyName",
      Seleccionado: {},
      datos: [],
      groups: [],
      loading: false,
      admin: "",
      updateFile: [],
      updateFiles: {},
      Link: "",
    };
  },
  computed: {
    data() {
      if (this.$store.state.data.data.idRol == 1) {
        this.admin = "Administrator";
      } else {
        this.admin = "User";
      }
      return this.$store.state.data.data;
    },
  },
  components: {
    Header,
  },
  mounted: function () {
    let direccion =
      "https://localhost:44394/api/file/" + this.$store.state.data.data.id;
    axios.get(direccion).then((data) => {
      this.empleados = data.data.updateFile;
    });
  },
  mounted: function () {
    let direccion = global.API_LANGUAGES;
    axios.get(direccion).then((data) => {
      this.datos = data.data;
      this.groups = this.getTranslate();
    });
  },
  methods: {
    clearFile() {
      this.updateFiles.Id = 0;
      this.updateFiles.Link = "";
      this.updateFiles.NameFile = "";
      this.updateFiles.Status = "";
    },
    getFile(event) {
      var formFile = document.getElementById("formFile");
      var archivoRuta = formFile.value;
      var extPermitidas = /(.docx|.txt)$/i;
      if (!extPermitidas.exec(archivoRuta)) {
        alert("Make sure you have selected a file type docx or txt");
        formFile.value = "";
        return false;
      }
      var ValidationFile = document.getElementById("formFile").files[0].size;
      if (ValidationFile > 500000000) {
        alert("El archivo no debe pesar mas de 500MB");
      } else {
        this.file = event.target.files[0];
        console.log(this.file);
        console.log(this.items);
      }
    },
    submitForm(event) {
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      };
      this.$http
        .post(this.uploadURL, formData, config)
        .then(function (response) {
          if (response.status === 200) {
            console.log(response.data);
          }
        });
    },
    getTranslate(event) {
      event.preventDefault();
      let formData = new FormData();
      formData.append("file", this.file);
      let config = {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      };

      axios.post(this.urlTranslate, formData, config).then((response) => {
        
        console.log(response.data.translatedFileUrl);
        var enlace = response.data.translatedFileUrl;
        window.location = response.data.translatedFileUrl;
        this.Link = enlace;
        if(response.data.translatedFileUrl != null){
          this.loading= false;
        }
        axios.post(
          crear,
          this.updateFiles,
          (this.updateFiles.NameFile =
            document.getElementById("formFile").files[0].name),
          ((this.updateFiles.Link = this.Link),
          (this.updateFiles.idUser = this.data.id))
        );
      });
    },

    saveTranslate(event) {
      var text1 = document.getElementById("formFile");
      var text2 = document.getElementById("Translatefrom");
      var text3 = document.getElementById("TranslateInto");
      var errorFile = document.getElementById("errorFile");
      var errorSelectFrom = document.getElementById("errorSelectFrom");
      var errorSelectInto = document.getElementById("errorSelectInto");
      errorFile.style.color = "red";
      errorSelectFrom.style.color = "red";
      errorSelectInto.style.color = "red";
      console.log("enviando formulario...");

      var mensajeErrorFile = [];
      var mensajeErrorSelectFrom = [];
      var mensajeErrorSelectInto = [];

     
 if (
        text1.value === null ||
        text1.value === "" ||
        text2.value === null ||
        text2.value === "" ||
        text3.value === null ||
        text3.value === ""
      )
      {
      if (text1.value === null || text1.value === "") {
        mensajeErrorFile.push("Enter a file");
      }
      if (text2.value === null || text2.value === "") {
        mensajeErrorSelectFrom.push("Select a language");
      }
      if (text3.value === null || text3.value === "") {
        mensajeErrorSelectInto.push("Select a language");
      }
      }else
      {
        this.loading= true;
        this.submitForm(event), this.getTranslate(event);
         
      }
       errorFile.innerHTML = mensajeErrorFile.join("");
      errorSelectFrom.innerHTML = mensajeErrorSelectFrom.join("");
      errorSelectInto.innerHTML = mensajeErrorSelectInto.join("");
       
    },
  },
};
</script>
<style scoped>
* {
  margin: 0px;
  padding: 0px;
}
#errorFile {
  position: absolute;
  color: #2f6bd9;
  top: 200px;
  left: 414px;
}
#errorSelectFrom {
  position: absolute;
  color: #2f6bd9;
  top: 295px;
  left: 404px;
}
#errorSelectInto {
  position: absolute;
  color: #2f6bd9;
  top: 295px;
  left: 910px;
}
.form-control {
  position: absolute;
  top: 155px;
  left: 410px;
  width: 1000px;
  height: 40px;
}
.form-select {
  position: absolute;
  top: 150px;
  left: 145px;
  width: 690px;
  height: 40px;
}
.input-group-text {
  position: absolute;
  top: 300px;
  left: 10px;
  height: 40px;
}
.btn {
  position: absolute;
  top: 36px;
  left: 1122px;
}
.barraStyle {
  position: absolute;
  width: 150px;
  color: rgb(202, 55, 10);
  height: 40px;
  top: 456px;
  left: 950px;
}
#charge {
  position: absolute;
  top: 465px;
  left: 850px;
  color: rgb(5, 83, 5);
}
#Translatefrom {
  position: absolute;
  top: 79px;
  left: 216px;
  width: 360px;
  height: 40px;
}
#TranslateInto {
  position: absolute;
  top: 68px;
  left: 717px;
  width: 380px;
  height: 40px;
}
#from {
  position: absolute;
  top: 79px;
  left: 91px;
  width: 125px;
}
#into {
  position: absolute;
  top: 68px;
  left: 591px;
  width: 125px;
}
#cargado{
  position: absolute;
  top: 315px;
  left: 850px;
}
.preloader {
  position: absolute;
  top:375px;
  left:855px;
  width: 70px;
  height: 70px;
  border: 10px solid #eee;
  border-top: 10px solid #2E69B2;
  border-radius: 50%;
  animation-name: girar;
  animation-duration: 2s;
  animation-iteration-count: infinite;
  animation-timing-function: linear;
}
@keyframes girar {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>