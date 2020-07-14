<template>
  <!---------------------- Template The Footer  ----------------------->
  <v-footer class="footer"
    dark
    padless
  >
    <v-card width="100%"
      flat
      tile
      class="grey darken-4 white--text text-center"
    >
    <v-divider></v-divider>

    <!--- Sosial media buttons --->
      <v-card-text>
        <v-btn
          v-for="icon in icons"
          :key="icon"
          class="mx-4 white--text"
          icon
        >
          <v-icon size="24px">{{ icon }}</v-icon>
        </v-btn>
      </v-card-text>

      <!--- Listing out the company info --->
      <v-card-text class="white--text pt-0" >
        {{companyInfo.name}} er en {{companyInfo.type}} etablert i {{companyInfo.yearEstablished}}, for og av folket
      </v-card-text>
      <v-card-text class="white--text pt-0" >
          <div> Telefon nummer: {{companyInfo.telefonNumber}}</div>
          <div> Email adresse: {{companyInfo.epost}}</div>
          <div> Adresse: {{companyInfo.adress}}</div>
      </v-card-text>

      <v-divider></v-divider>

      <!--- Using current date time object to get the current year --->
      <v-card-text class="white--text">
        {{ new Date().getFullYear() }} — {{companyInfo.name}}
      </v-card-text>
      
    </v-card>
  </v-footer>
</template>


<script>
import CompanyInfoStore from '@/Stores/CompanyInfoStore.js';

export default {
    name: "TheFooter",
    data(){
        return {
            //retriving data from localStorage
            companyInfo : CompanyInfoStore.getCompanyInfo(),
            //Putting icons in an array
            icons: [
                'mdi-facebook',
                'mdi-twitter',
                'mdi-google',
                'mdi-instagram',
            ],
        }
    }
}
</script>

<style scoped>
    .footer{
        position: absolute;
        bottom: 0;
        width: 100%;
    }
</style>