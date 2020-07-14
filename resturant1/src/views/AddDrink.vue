
<template>
    <!----------- Template Add Drink ----------->
    <v-container fluid >
        <v-row justify="center" align="center"
        >
            <!------- Input fields ------->
            <v-col cols="12" sm="6" md="3">
                <v-label>Navn</v-label>
                <v-text-field v-model="newDrink.name" :rules="rules.name"  label="Skriv ett navn"></v-text-field>
                <v-label>Pris</v-label>
                <v-text-field v-model.number="newDrink.price"  label="Skriv en pris"></v-text-field>
                <v-label>Størrese</v-label>
                <v-text-field v-model.number="newDrink.size" label="Angi størrelse i cl"></v-text-field>

                <!-- drop-down select menu to set category -->
                <v-select
                    v-model="select"
                    :items="items"
                    item-text="value"
                    label="Velg kategori" 
                    return-object
                ></v-select>
   
                <!-- Upload photo and show size of photo -->
                <v-file-input v-model="file" show-size ></v-file-input>
                
                

                <v-btn to="/admin"><v-icon>mdi-backspace</v-icon></v-btn>

                <!-- Notification to the user -->
                <v-snackbar v-model="snackbar" :timeout="timeout" >
                    {{ text }}
                </v-snackbar>

                <!-- When button is clicked add drink and show notification -->
                <v-btn class="save-btn" @click="addDrink(); snackbar = true">Lagre</v-btn>

                

            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import axios from 'axios';


export default {
    name: "AddDrink",
    data(){
        return{
            /* -- Rules for the input fileds -- */
            rules: {
                //the input filed for Name has to contain more than 0 letters
                name: [val => (val || '').length > 0 || 'Dette feltet er påkrevd!'],
            },
            /* -- Vegetarian is default set to false -- */
            checked: false,

            /* -- data for the notification -- */
            snackbar: false,
            text: 'En ny drikke er lagt til!',
            timeout: 2000,

            file: null,
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
            newDrink: {name: "", price: 0 , category:"",
                    size: 0, imageSrc: "" }
            }
            
        },
    methods: {
         /* ------- Method to add new drink ------ */
        addDrink(){
            //using the drinkAdmin Controller from the API
            let webAPIUrl = "https://localhost:5001/drinkAdmin";
            
            // category of the drink is equal too the selected value 
            this.newDrink.category = this.select.value;

            /* --- Upload photo to the new drink --- */
            this.newDrink.imageSrc = this.file.name;
            let data = new FormData();
            data.append("file", this.file)
            //Using httpPost to post a new drink to the API, with a photo
            axios.post( webAPIUrl, this.newDrink )
                .then(result => {
                    axios({
                        method: "post",
                        url:  "https://localhost:5001/drinkAdmin/uploadImage", 
                        data: data,
                        config: { headers: { 'Content-type': 'multiplart/form-data' } }
                        
                    })
                    console.log(result.data);

                    /* -- Clear the input fields -- */
                    this.newDrink.name="";
                    this.newDrink.price=0;
                    this.newDrink.size=0;
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







