<template>
<!----------- Template Edit Drink ------------->
    <v-container fluid>
        <v-row justify="center" align="center">
            <v-col cols="12" sm="6" md="3">
                <h1>Rediger drikke</h1>

                <!-- Search by name -->
                <v-label>Søk etter navn (ordrett)</v-label>
                <v-text-field v-model="editName" label="navnet på drikken du vil redigere"></v-text-field>
                <v-btn small class="mb-2" @click="getDrink">hent drikke</v-btn>
                <hr>
                
                <!-- Inputfield for editing the choosen drink -->
                <v-label>Navn</v-label>
                <v-text-field v-model="editDrink.name" :rules="rules.name" label="Skriv ett navn"></v-text-field>
                <v-label>Pris</v-label>
                <v-text-field v-model.number="editDrink.price" label="Skriv inn pris"></v-text-field>
                <v-label>Størrelse</v-label>
                <v-text-field v-model.number="editDrink.size" label="Skriv størrelse i cl"></v-text-field>

                <!-- drop-down select menu to edit category -->
                <v-select
                    v-model="select"
                    :items="items"
                    item-text="value"
                    label="Velg kategori" 
                    return-object
                ></v-select>

                <v-btn to="/admin"><v-icon>mdi-backspace</v-icon></v-btn>

                <!-- Notification to the user -->
                <v-snackbar v-model="snackbar" :timeout="timeout" >
                    {{ text }}
                </v-snackbar>
                
                <!-- When button is clicked show notification -->
                <v-btn class="save-btn" @click="putDrink(); snackbar = true">lagre</v-btn>
                
            </v-col>
        </v-row>
    </v-container>
    
</template>

<script>
import axios from 'axios'
export default {
    name: "EditDrink",
    data(){
        return{
            
            editName: "",
            editDrink: { },
            /* -- Select values you can choose from to set category, default value is Alkoholfri -- */
            select: { value: 'Alkoholfri' },
            items: [
                { value: 'Alkoholfri' },
                { value: 'Fatøl' },
                { value: 'Flaskeøl' },
                { value: 'Rødvin'},
                { value: 'Hvitvin'},
                { value: 'Før-etter-middag'}
            ],
            /* -- Rules for the input fileds -- */
            rules: {
                //the input filed for Name has to contain more than 0 letters
                name: [val => (val || '').length > 0 || 'Dette feltet er påkrevd!'],
            },

            /* -- data for the notification -- */
            snackbar: false,
            text: 'Endringene er lagret',
            timeout: 2000,
        }
    },
    methods: {
         /* -- Method to get the drink by name, using the Get by name request -- */
        getDrink(){
            //using the drinkAdmin Controller from the API
            let webAPIUrl = `https://localhost:5001/drinkAdmin/${this.editName}`;
            axios.get( webAPIUrl )
            .then( result => {
                this.editDrink = result.data;
            })
        },
        /* -- Method to change values of the drink being edited, using httpPut -- */
        putDrink(){
            let webAPIUrl = "https://localhost:5001/drinkAdmin";
            
            this.editDrink.category = this.select.value;
            axios.put( webAPIUrl, this.editDrink )
        }
    }

}
</script>

<style scoped>
    .save-btn{
        left: 60%;
    }
</style>