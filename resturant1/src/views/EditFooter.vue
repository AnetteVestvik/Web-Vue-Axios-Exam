<template>
<!------------ Template Edit Footer ------------>
    <v-container fluid>
        <v-row justify="center" align="center">
            <v-col cols="12" sm="6" md="3">
                <h1>Rediger footer</h1>
                
                <!-- Inputfield for editing The Footer -->
                <v-label>Navn</v-label>
                <v-text-field v-model="name" :rules="rules.info"  label="Skriv ett navn"></v-text-field>
                <v-label>Type</v-label>
                <v-text-field v-model="type" :rules="rules.info" label="Skriv inn type bedrift"></v-text-field>
                <v-label>År grunnlagt</v-label>
                <v-text-field v-model="yearEstablished" :rules="rules.info" label="Skriv år grunnlagt"></v-text-field>
                <v-label>Telefon nummer</v-label>
                <v-text-field v-model="telefonNumber" :rules="rules.info" label="Skriv telefon nummer"></v-text-field>
                <v-label>Epost</v-label>
                <v-text-field v-model="epost" :rules="rules.info" label="Skriv epost adresse"></v-text-field>
                <v-label>Adresse</v-label>
                <v-text-field v-model="adress" :rules="rules.info" label="Skriv adressen"></v-text-field>

                <v-btn to="/admin"><v-icon>mdi-backspace</v-icon></v-btn>

                <!-- Notification to the user -->
                <v-snackbar v-model="snackbar" :timeout="timeout" >
                    {{ text }}
                </v-snackbar>
                
                <!-- When button is clicked show notification -->
                <v-btn class="save-btn" @click="editFooter(); snackbar = true" >lagre</v-btn>
                
            </v-col>
        </v-row>
    </v-container>
    
</template>

<script>
import CompanyInfoStore from '@/Stores/CompanyInfoStore.js';
export default {
    name: "EditFooter",
    
    data(){
        return{
            
            /* -- Getting the Company Info from LocalStorage -- */
             companyInfo : CompanyInfoStore.getCompanyInfo(),
             name: CompanyInfoStore.getCompanyInfo().name,
             type: CompanyInfoStore.getCompanyInfo().type,
             yearEstablished: CompanyInfoStore.getCompanyInfo().yearEstablished,
             telefonNumber: CompanyInfoStore.getCompanyInfo().telefonNumber,
             epost: CompanyInfoStore.getCompanyInfo().epost,
             adress: CompanyInfoStore.getCompanyInfo().adress,

            /* -- data for the notification -- */
            snackbar: false,
            text: 'Endringene er lagret',
            timeout: 2000,

            /* -- Rules for the input fileds -- */
            rules: {
                //the input filed for Name has to contain more than 0 letters
                info: [val => (val || '').length > 0 || 'Dette feltet er påkrevd!'],
            },
            
        }
    },
    methods: {
        
        /* --- Method to edit The Footer --- */ 
        editFooter(){
            
            /* -- Replace data with the new input -- */
            this.companyInfo.name = this.name
            this.companyInfo.type = this.type
            this.companyInfo.yearEstablished = this.yearEstablished
            this.companyInfo.telefonNumber = this.telefonNumber
            this.companyInfo.epost = this.epost
            this.companyInfo.adress = this.adress
            
            //Delete local storage
            window.localStorage.clear();
            //Re-creates local storage, works like an updated
            window.localStorage.setItem('info', JSON.stringify(this.companyInfo));
        } 
    }
}
</script>

<style scoped>
    .save-btn{
        left: 60%;
    }
</style>