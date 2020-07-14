<template>
    <div>
        <!-- v-for every dish in the computed function lunsjDish-->
        <!--- Used to place all lunsj-dishes together ---> 
        <h2 class="white--text ">Lunsj</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="dish in lunsjDish" :key="dish.id" >

                <DishItem
                    :id="dish.id"
                    :name="dish.name"
                    :price="dish.price"
                    :category="dish.category"
                    :content="dish.content"
                    :allergies="dish.allergies"
                    :imageSrc="dish.imageSrc"
                    :vegetarian="dish.vegetarian" 
                    :rateing="dish.rateing"  
                />
                
            </v-col>
        </v-row>

        <!-- v-for every dish in the computed function appetizerDish-->
        <!--- Used to place all appetizers together ---> 
        <h2 class="white--text ">Forrett</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="dish in appetizerDish" :key="dish.id" >

                <DishItem
                    :id="dish.id"
                    :name="dish.name"
                    :price="dish.price"
                    :category="dish.category"
                    :content="dish.content"
                    :allergies="dish.allergies"
                    :imageSrc="dish.imageSrc"
                    :vegetarian="dish.vegetarian"
                    :rateing="dish.rateing"  
                />
            </v-col>
        </v-row>

        <!-- v-for every dish in the computed function dinnerDish-->
        <!--- Used to place all dinner-dishes together ---> 
        <h2 class="white--text" >Hovedrett</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="dish in dinnerDish" :key="dish.id" >

                <DishItem
                    :id="dish.id"
                    :name="dish.name"
                    :price="dish.price"
                    :category="dish.category"
                    :content="dish.content"
                    :allergies="dish.allergies"
                    :imageSrc="dish.imageSrc"
                    :vegetarian="dish.vegetarian"
                    :rateing="dish.rateing"  
                />
            </v-col>
        </v-row>

        <!-- v-for every dish in the computed function dessertDish-->
        <!--- Used to place all desserts together ---> 
        <h2 class="white--text ">Dessert</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="dish in dessertDish" :key="dish.id" >

                <DishItem
                    :id="dish.id"
                    :name="dish.name"
                    :price="dish.price"
                    :category="dish.category"
                    :content="dish.content"
                    :allergies="dish.allergies"
                    :imageSrc="dish.imageSrc"
                    :vegetarian="dish.vegetarian"
                    :rateing="dish.rateing"  
                />
            </v-col>
        </v-row>
    </div>
</template>

<script>

import DishItem from './DishItem.vue';


export default {
    name: "DishList",
    props: { 
        dishes: Array
    },
    components: {
        DishItem
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