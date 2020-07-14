<template>
    <div>
        <!-- v-for every dish in the computed function lunsjDish-->
        <!--- Used to place all lunsj-dishes together ---> 
        <h2 class="h2-title">Lunsj</h2>
        <v-row justify="center" align="center">
            <v-col  cols="12" sm="11" md="11" lg="11" xl="11"
            v-for="dish in lunsjDish" :key="dish.id" >

                <DishAdminItem
                    :name="dish.name"
                    :category="dish.category"
                    :id="dish.id"
                />
            </v-col>
        </v-row>
        <!-- v-for every dish in the computed function appetizerDish-->
        <!--- Used to place all the appetizers together ---> 
        <h2 class="h2-title">Forrett</h2>
        <v-row justify="center" align="center">
            <v-col  cols="12" sm="11" md="11" lg="11" xl="11"
            v-for="dish in appetizerDish" :key="dish.id" >

                <DishAdminItem
                    :name="dish.name"
                    :category="dish.category"
                    :id="dish.id"
                />
            </v-col>
        </v-row>

        <!-- v-for every dish in the computed function dinnerDish-->
        <!--- Used to place all the dinner dishes together ---> 
        <h2 class="h2-title">Hovedrett</h2>
        <v-row justify="center" align="center">
            <v-col  cols="12" sm="11" md="11" lg="11" xl="11"
            v-for="dish in dinnerDish" :key="dish.id" >

                <DishAdminItem
                    :name="dish.name"
                    :category="dish.category"
                    :id="dish.id"
                />
            </v-col>
        </v-row>

        <!-- v-for every dish in the computed function dessertDish-->
        <!--- Used to place all desserts together ---> 
        <h2 class="h2-title">Dessert</h2>
        <v-row justify="center" align="center">
            <v-col cols="12" sm="11" md="11" lg="11" xl="11"
            v-for="dish in dessertDish" :key="dish.id" >

                <DishAdminItem
                    :name="dish.name"
                    :category="dish.category"
                    :id="dish.id"
                />
            </v-col>
        </v-row>

    </div>
</template>

<script>

import DishAdminItem from './DishAdminItem.vue';


export default {
    name: "DishAdminList",
    props: {
        dishes: Array
    },
    components: {
        DishAdminItem
    },
    /* --- Computed functions that filters by category --- */
    /* --- With computed the functions get called by itself --- */
    computed: {
        lunsjDish: function() {
        return this.dishes.filter(function(u) {
            return u.category == 'Lunsj'
            });
        },
        dinnerDish: function() {
        return this.dishes.filter(function(u) {
            return u.category == 'Hovedrett'
        });
        },
        appetizerDish: function() {
            return this.dishes.filter(function(u) {
                return u.category == 'Forrett'
            });
        },
        dessertDish: function() {
            return this.dishes.filter(function(u) {
                return u.category == 'Dessert'
            });
        }
    
}
}
</script>

<style >
    .h2-title{
        margin-left: 5rem;
    }
</style>