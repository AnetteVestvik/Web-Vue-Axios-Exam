<template>
<!-------------- Template Dishes in Menu ------------>
    <div class="grey darken-4" heigt="100%">
        
        <!-- Buttons to move between the dishes and drinks menu -->
        <div class=" text-center">
            <h2 class="white--text" >Mat Meny</h2>
            <v-btn to="dishes"  class="ma-2" tile color="indigo" disabled>Mat Meny</v-btn>
            <v-btn to="drinks" class="ma-2" tile color="indigo" dark>Drikke Meny</v-btn>
        </div>

        <!-- Show all the dishes from DishList -->
        <DishList :dishes="dishes"/>
    
        <!-- Show the footer -->
        <TheFooter class="theFooter"/>

    </div>
</template>

<script>
import axios from 'axios';
import DishList from '@/components/DishList.vue';
import TheFooter from '@/components/layout/TheFooter.vue';

export default {
    name: 'Dishes',
    components: {
        DishList,
        TheFooter
    },
    data(){
        /* -- Dummy data -- */
        return{
            dishes: [{ 
                id: 999,
                name: "A name",
                price: 0,
                category: "Lunsj",
                allergies: "E",
                content: "Some content",
                imageUrl: "AUrl.jpg",
                vegetarian: true,
                rateing: 5
                
            }]
        }
    },

    created() {
        //Using the dish Controller from the API
        const webAPIUrl = "https://localhost:5001/dish";

        /*-- Using httpGet to get the data from the API --*/
        axios.get(webAPIUrl)
            .then(response => {
                console.log(response.data);
                this.dishes = response.data
            })
        }
}
</script>

<style scoped>
    .theFooter{
        bottom: -240px;
    }

</style>