<template>
  <!---------- Template for the Navigation Bar ---------------->
  <v-app>
    <v-app-bar
      app
      dark>
    
    <!-- Logo in the nav-bar -->
    <v-toolbar-title>
        <v-img width=" 30%" src="https://localhost:5001/images/logo.png"></v-img>
    </v-toolbar-title>
    <v-spacer></v-spacer>

    <!----- Buttons too the other pages in the nav-bar ----->
    <v-btn to="/home">
      <v-icon>mdi-home</v-icon>
    </v-btn>

    <v-btn to="menu">
      <v-icon>mdi-silverware</v-icon>
    </v-btn>

    <v-btn to="admin">
      <v-icon>mdi-account-edit</v-icon>
    </v-btn>

    </v-app-bar>

    <!-- Container with the views -->
    <v-content>
      <router-view></router-view>
    </v-content>

  </v-app>
</template>

<script>

export default {
  name: 'App',
}
</script>
