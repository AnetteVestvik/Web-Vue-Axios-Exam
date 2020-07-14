<template>
    <!------------ Template Menu Page ------------->
    <div class="grey darken-4 text-center" id="container">

    <!-- Image with buttons to Dishes and Drinkes -->
    <v-img height="90%" src="https://localhost:5001/images/header.jpg">
      <h1>Meny</h1>
      <v-btn to="dishes" class="ma-2" tile color="indigo" dark>Mat Meny</v-btn>
      <v-btn to="drinks" class="ma-2" tile color="indigo" dark>Drikke Meny</v-btn>
    </v-img>

    <!-- Show the Footer -->
    <TheFooter/>
   
    </div>
</template>

<script>
import TheFooter from '@/components/layout/TheFooter.vue';
export default {
  name:"Menu",
  components: {
    TheFooter
  }
}
</script>

<style scoped>
    #container{
      height: 100%;
    }
</style>
