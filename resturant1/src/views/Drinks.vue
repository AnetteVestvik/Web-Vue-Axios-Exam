<template>
<!------------ Template Drinks in Menu ----------->

    <div class="grey darken-4" heigt="100%">
        <!-- Buttons to move between the dishes and drinks menu -->
        <div class="text-center">
            <h2 class="white--text ">Drikke Meny</h2>
            <v-btn to="dishes"  class="ma-2" tile color="indigo" dark>Mat Meny</v-btn>
            <v-btn to="drinks" class="ma-2" tile color="indigo" disabled>Drikke Meny</v-btn>
        </div>

        <!-- Show all the drinks from DrinkList -->
        <DrinkList :drinks="drinks"/>

        <!-- Show the footer -->
        <TheFooter class="theFooter"/>

    </div>
</template>

<script>
import axios from 'axios';
import DrinkList from '@/components/DrinkList.vue';
import TheFooter from '@/components/layout/TheFooter.vue';

export default {
    name: 'Drinks',
    components: {
        DrinkList,
        TheFooter
    },
    data(){
        /* -- Dummy data -- */
        return{
            drinks: [{ 
                id: 999,
                name: "A name",
                price: 0,
                category: "Lunsj",
                size: 0,
                imageUrl: "AUrl.jpg",
                
            }]
        }
    },

    created() {
        //Using the drink Controller from the API
        const webAPIUrl = "https://localhost:5001/drink";

        /*-- Using httpGet to get the data from the API --*/
        axios.get(webAPIUrl)
            .then(response => {
                console.log(response.data);
                this.drinks = response.data
            })
        }
}
</script>

<style scoped>
    .theFooter{
        bottom: -240px;
    }
</style>