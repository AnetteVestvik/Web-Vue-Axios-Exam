<template>
<!------------ Template of every dish in menu -------->
<div>
    <article>
    <v-card class="mx-auto" height="550">
       <v-card-title> {{ name }}
            <!-- If the dish is vegetarian then print (vegetarian) in the title -->
            <v-card-text class="vegetarian"
            v-if="vegetarian" > (vegetarisk)</v-card-text>
        </v-card-title>
            
       <!-- Getting the photo from the API -->
           <v-img class="align-end"
           height="200px"
            :src="`https://localhost:5001/images/${ imageSrc}`"> 
           </v-img>
       
        <v-card-text>
            <p> {{ price }},-</p>
            <p> med {{ content }} </p>
            <!-- If there are allergies in a dish, then print them -->
            <p v-if="allergies"> allergier: {{ allergies }} </p>
        </v-card-text>
        <v-divider dark></v-divider>

        <!------ Star rating ------>
        <v-card-actions class="pa-4" >
        
            <v-spacer></v-spacer>
            <span class="grey--text text--lighten-2 caption mr-2">
                <!-- show current rating -->
                ({{ editRating }})
            </span>
            <v-rating
                v-model.number="editRating"
                background-color="white"
                color="yellow accent-4"
                dense
                half-increments
                hover
                size="20"
            ></v-rating>
        </v-card-actions>

        <!-- Notification to the user when rated-->
        <v-snackbar v-model="snackbar" :timeout="timeout" >
            {{ text }}
        </v-snackbar>

        <!-- When button is clicked add rating and show notification -->
        <v-btn class="rating-btn" @click="putRating(); snackbar = true">gi din rating</v-btn>

    </v-card> 
    </article>
</div>
</template>
    
<script>
import axios from 'axios'
export default {
    name: "DishItem",
    data(){
        return{
            /* -- data for the notification -- */
            snackbar: false,
            text: 'Takk for tilbakemeldingen!',
            timeout: 2000,
            
            editDish: { },
            editRating: this.rateing
        }
    },
    props: {
           id: Number,
           name: String,
           price: Number,
           category: String,
           content: String,
           allergies: String,
           imageSrc: String,
           vegetarian: Boolean,
           rateing: Number
    },
    methods: {
        
        /* --- Method to change the rating in the API by using Star Rating --- */
        putRating(){
            //using the dish controller from API
            let webAPIUrl = "https://localhost:5001/dish";
            
            /* --- Do not change anything but the rating --- */
            this.editDish.name = this.name;
            this.editDish.price = this.price;
            this.editDish.category = this.category;
            this.editDish.allergies = this.allergies;
            this.editDish.imageSrc= this.imageSrc;
            this.editDish.vegetarian = this.vegetarian;

            /* --- change rating of the dish --- */
            this.editDish.rateing = this.editRating;
            this.editDish.id = this.id;
            axios.put( webAPIUrl, this.editDish)
                
        }
    },
    
    
}
    

</script>

<style>
    .vegetarian{
        color:green;
        position: absolute;
        left: 70%;
    }
    .like-btn{
        position: absolute;
        left: 70%;
    }
    .rating-btn{
        left: 55%;
    }
    
</style>

