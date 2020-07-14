<template>
<!--------------- Template Home Page -------------------->
  <div class="grey darken-4 text-center" height="100%">

    <!-- Show the Header -->
    <TheHeader/>

    <!------------------------------  Photo Gallery ------------------------------>
    <!---- The picures are downloaded from: https://www.egon.no/bildebank ------>
    <div class="image-container">
      <h1 class="white--text display-1 font-weight-thin" >Del dine opplevelser på vår instagram</h1>
        <v-row>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse1.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse2.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse3.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse4.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse5.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse6.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse7.jpg"></v-img>
          </v-col>
          <v-col cols="12" sm="6" md="4" lg="3" xl="3">
              <v-img height="400px" src="https://localhost:5001/images/egon-opplevelse8.jpg"></v-img>
          </v-col>
        </v-row>
    </div>
   
    <!-- Show the Footer -->
    <TheFooter id="theFooter"/>
  </div>
</template>

<script>
import TheFooter from '@/components/layout/TheFooter.vue';
import TheHeader from '@/components/layout/TheHeader.vue';
export default {
  name: 'Home',
  components: {
    TheHeader,
     TheFooter
  }
}
</script>

<style scoped>
  
    #theFooter{
      bottom: -220px; 
    }
    
    .image-container{
      margin: 1rem;

    }
</style>
