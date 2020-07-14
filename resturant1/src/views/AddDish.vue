<template>
    <!----------- Template Add Dish --------------->
    <v-container fluid >
        <v-row justify="center" align="center"
        >
            <!-------- Input fields ------->
            <v-col cols="12" sm="6" md="3">
                <v-label>Navn</v-label>
                <v-text-field v-model="newDish.name" :rules="rules.name"  label="Skriv ett navn"></v-text-field>
                <v-label>Pris</v-label>
                <v-text-field v-model.number="newDish.price"  label="Skriv en pris"></v-text-field>
                <v-label>Rating</v-label>
                <v-text-field v-model.number="newDish.rateing" label="Gi en rating"></v-text-field>

                <!-- drop-down select menu to set category -->
                <v-select
                    v-model="select"
                    :items="items"
                    item-text="value"
                    label="Velg kategori" 
                    return-object
                ></v-select>
           
                <v-label>Allergier</v-label>
                <v-text-field v-model="newDish.allergies" label="Skriv inn allergier"></v-text-field>
                <v-label>Tilbehør</v-label>
                <v-text-field v-model="newDish.content" label="Skriv innholdet i retten"></v-text-field>

                <!-- Checkbox to set if vegetarian is true or false -->
                <v-checkbox
                v-model="checked"
                :label="`Vegetarisk: ${checked.toString()}`"
                ></v-checkbox>
                
                <hr>
                <!-- Upload photo and show size of photo -->
                <v-file-input v-model="file" show-size ></v-file-input>
                
                <v-btn to="/admin"><v-icon>mdi-backspace</v-icon></v-btn>

                <!-- Notification to the user -->
                <v-snackbar v-model="snackbar" :timeout="timeout" >
                    {{ text }}
                </v-snackbar>

                <!-- When button is clicked add dish and show notification -->
                <v-btn class="save-btn" @click="addDish(); snackbar = true">Lagre</v-btn>

                
                
            </v-col>
        </v-row>
    </v-container>

</template>

<script>
import axios from 'axios';

export default {
    name: "AddDish",
    data(){
        return{
            /* -- Rules for the input fileds -- */
            rules: {
                //the input filed for Name has to contain more than 0 letters
                name: [val => (val || '').length > 0 || 'Dette feltet er påkrevd!'],
            },
            
            /* -- data for the notification -- */
            snackbar: false,
            text: 'En ny matrett er lagt til!',
            timeout: 2000,

            file: null,

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

            newDish: {name: "", price: 0 , allergies: "", category:"",
                    content: "", rateing: 0, vegetarian: false, imageSrc: "" }
            }
        },

    methods: {
         /* ------- Method to add new dish -------- */
        addDish(){

            //using the dishAdmin Controller from the API
            let webAPIUrl = "https://localhost:5001/dishAdmin";
            
            // value of vegetarian is equal too the value of checked
            this.newDish.vegetarian = this.checked;

            // category of the dish is equal too the selected value 
            this.newDish.category = this.select.value;
            
            /* --- Upload photo to the new dish --- */
            this.newDish.imageSrc = this.file.name;
            let data = new FormData();
            data.append("file", this.file)
            //Using httpPost to post a new dish to the API, with a photo
            axios.post( webAPIUrl, this.newDish )
                .then(result => {
                    axios({
                        method: "post",
                        url:  "https://localhost:5001/dishAdmin/uploadImage", 
                        data: data,
                        config: { headers: { 'Content-type': 'multiplart/form-data' } }
                        
                    })

                    console.log(result.data);
                    
                    /* -- Clear the input fields -- */
                    this.newDish.name="";
                    this.newDish.price=0;
                    this.newDish.rateing=0;
                    this.newDish.allergies="";
                    this.newDish.content="";

                })
            
        }
        
    }
    
}
</script>

<style scoped>
    .save-btn{
        left: 60%;
    }
</style>







