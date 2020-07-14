<template>
<!------------ Template Edit Dish ---------------->
    <v-container fluid>
        <v-row justify="center" align="center">
            <v-col cols="12" sm="6" md="3">
                <h1>Rediger matrett</h1>

                <!-- Search by name -->
                <v-label>Søk etter navn (ordrett)</v-label>
                <v-text-field v-model="editName" label="navnet på retten du vil redigere"></v-text-field>
                <v-btn small class="mb-2" @click="getDish">hent matrett</v-btn>
                <hr>
                
                <!---- Inputfield for editing the choosen dish ---->
                <v-label>Navn</v-label>
                <v-text-field v-model="editDish.name" :rules="rules.name" label="Skriv ett navn"></v-text-field>
                <v-label>Pris</v-label>
                <v-text-field v-model.number="editDish.price" label="Skriv inn pris"></v-text-field>
                <v-label>Rangering</v-label>
                <v-text-field v-model.number="editDish.rateing" label="Sett rangering"></v-text-field>

                <!-- drop-down select menu to edit category -->
                <v-select
                    v-model="select"
                    :items="items"
                    item-text="value"
                    label="Velg kategori" 
                    return-object
                ></v-select>

                <v-label>Allergier</v-label>
                <v-text-field v-model="editDish.allergies" label="Skriv inn allergier"></v-text-field>
                <v-label>Tilbehør</v-label>
                <v-text-field v-model="editDish.content" label="Skriv inn tilbehør"></v-text-field>

                <!-- Checkbox to set if vegetarian is true or false -->
                <v-checkbox
                v-model="checked"
                :label="`Vegetarisk: ${checked.toString()}`"
                ></v-checkbox>
                
                <hr>
                <v-btn to="/admin"><v-icon>mdi-backspace</v-icon></v-btn>

                <!-- Notification to the user -->
                <v-snackbar v-model="snackbar" :timeout="timeout" >
                    {{ text }}
                </v-snackbar>
                
                <v-btn class="save-btn" @click="putDish(); snackbar = true">lagre</v-btn>
                
            </v-col>
        </v-row>
    </v-container>
    
</template>

<script>
import axios from 'axios'
export default {
    name: "EditDish",
    data(){
        return{
            editName: "",
            editDish: { },

            /* -- Select values you can choose from to set category, default value is Lunsj -- */
            select: { value: 'Lunsj' },
            items: [
            { value: 'Lunsj' },
            { value: 'Forrett' },
            { value: 'Hovedrett'},
            { value: 'Dessert'}
            ],
            /* -- Vegetarian is default set to false -- */
            checked: false,

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
        
        /* -- Method to get the dish by name, using the Get by name request -- */
        getDish(){
            //using the dishAdmin Controller from the API
            let webAPIUrl = `https://localhost:5001/dishAdmin/${this.editName}`;
            axios.get( webAPIUrl )
            .then( result => {
                this.editDish = result.data;
            })
        },

        /* -- Method to change values of the dish being edited, using httpPut -- */
        putDish(){
            let webAPIUrl = "https://localhost:5001/dishAdmin";

            this.editDish.vegetarian = this.checked;
            this.editDish.category = this.select.value;
            axios.put( webAPIUrl, this.editDish )
        }
    }

}
</script>

<style scoped>
    .save-btn{
        left: 60%;
    }
</style>