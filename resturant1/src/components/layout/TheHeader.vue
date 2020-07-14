<template>
    <!------------------ Template The Header -------------->

  <!--- Using parallax component to create a 3d effect
   that makes the image appear to scroll slower than the window. --->
  <v-parallax
    dark
    src="https://localhost:5001/images/header.jpg"
  >
    <v-row
      align="center"
      justify="center"
    >
      <v-col class="text-center" cols="12">
        <!-- Text on the image -->
        <h1 class="display-1 ">Egon</h1>
        <h4 class="subheading">For kos og hygge!</h4>
      </v-col>
    </v-row>
  </v-parallax>

</template>

<script>
export default {
    name: "TheHeader"
}
</script>