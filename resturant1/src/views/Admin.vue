<template>
<!------------- Template Admin Page ----------------->
    <div>
    <v-container fluid>
        <v-row justify="center" align="center">
            <h1>Admin</h1>
        </v-row>
    </v-container>
    
    <!---- Container for the buttons to get too Add Dish and Add Drink ---->
    <v-container fluid>
        <v-row justify="center" align="center">
            <v-btn class="ma-2" tile outlined color="success" to="/add-dish">
                <v-icon left>mdi-plus</v-icon> Ny matrett
            </v-btn>

            <v-btn class="ma-3" tile outlined color="success" to="/add-drink">
                <v-icon left>mdi-plus</v-icon> Ny drikke
            </v-btn>
        </v-row>
    </v-container>
    
    <!--- Container with button to get too EditDish, and too list all the dishes from DishAdminList --->
    <v-container fluid>
        <v-row justify="center" align="center">
            <h1>Matretter</h1>
        </v-row>
        <v-row justify="center" align="center">
            <v-btn to="edit-dish">
                Rediger matretter
            </v-btn>
        </v-row>
        <DishAdminList :dishes="dishes"/>
    </v-container>
    
    <!--- Container with button to get too EditDrink, and too list all the drinks from DrinkAdminList --->
    <v-spacer></v-spacer>
    <v-container fluid>
        <v-row justify="center" align="center">
        <h1>Drikke</h1>
        </v-row>
        <v-row justify="center" align="center">
            <v-btn to="edit-drink">
                Rediger drikker
            </v-btn>
        </v-row>
        <DrinkAdminList :drinks="drinks"/>
    </v-container>

    <!-- Button to get too EditFooter -->
    <v-row justify="center" align="center">
            <v-btn to="edit-footer">Rediger Footer</v-btn>
    </v-row>
    
    <!-- Show the footer -->
    <TheFooter id="theFooter"/>
    
    </div>
</template>

<script>
import axios from 'axios';
import DishAdminList from '@/components/DishAdminList.vue';
import DrinkAdminList from '@/components/DrinkAdminList.vue';
import TheFooter from '@/components/layout/TheFooter.vue';

export default {
    name: 'Admin',
    components: {
        DishAdminList,
        DrinkAdminList,
        TheFooter
    },
    data(){
        /* -- Dummy Data -- */
        return{
            dishes: [{
                id: 999,
                name: "A name"
            }],
            drinks: [{
                id: 999,
                name: "A name"
            }]
        }
    },
      
    created(){
        //Using the dishAdmin Controller from the API
        const webAPIUrlDish = "https://localhost:5001/dishAdmin";
        /*-- Using httpGet to get the data from the API --*/
        axios.get(webAPIUrlDish)
            .then(response => {
                console.log(response.data);
                this.dishes = response.data
            });

        //Using the drinkAdmin Controller from the API
        const webAPIUrlDrink = "https://localhost:5001/drinkAdmin";
        /*-- Using httpGet to get the data from the API --*/
        axios.get(webAPIUrlDrink)
            .then(response => {
                console.log(response.data);
                this.drinks = response.data
            });
    }     
}
    
</script>

<style scoped>
   #theFooter{
      bottom: -250px; 
    }
</style>

