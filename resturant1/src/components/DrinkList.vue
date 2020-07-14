<template>
    <div>
        
        <!-- v-for every drink in the computed function nonAlcoholList-->
        <!--- Used to place all non alchol drinks together ---> 
        <h2 class="white--text ">Alkoholfritt</h2>
        <v-row >
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="drink in nonAlcoholList " :key="drink.id" >

                <DrinkItem
                    :name="drink.name"
                    :price="drink.price"
                    :category="drink.category"
                    :size="drink.size"
                    :imageSrc="drink.imageSrc" 
                      
                />
                
            </v-col>
        </v-row>

        <!-- v-for every drink in the computed function barrelsBeerList-->
        <!--- Used to place all barrels beer's together ---> 
        <h2 class="white--text ">Fatøl</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="drink in barrelsBeerList" :key="drink.id" >

                <DrinkItem
                    :name="drink.name"
                    :price="drink.price"
                    :category="drink.category"
                    :size="drink.size"
                    :imageSrc="drink.imageSrc"
                      
                />
                
            </v-col>
        </v-row>

        <!-- v-for every drink in the computed function bottleBeerList-->
        <!--- Used to place all bottles of beer together ---> 
        <h2 class="white--text ">Flaskeøl</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="drink in bottleBeerList" :key="drink.id" >

                <DrinkItem
                    :name="drink.name"
                    :price="drink.price"
                    :category="drink.category"
                    :size="drink.size"
                    :imageSrc="drink.imageSrc"
                      
                />
                
            </v-col>
        </v-row>

         <!-- v-for every drink in the computed function redWineList-->
        <!--- Used to place all red wines together ---> 
        <h2 class="white--text ">Rødvin</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="drink in redWinelist" :key="drink.id" >

                <DrinkItem
                    :name="drink.name"
                    :price="drink.price"
                    :category="drink.category"
                    :size="drink.size"
                    :imageSrc="drink.imageSrc"
                      
                />
                
            </v-col>
        </v-row>

        <!-- v-for every drink in the computed function whiteWineList-->
        <!--- Used to place all white wines together ---> 
        <h2 class="white--text ">Hvitvin</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="drink in whiteWineList" :key="drink.id" >

                <DrinkItem
                    :name="drink.name"
                    :price="drink.price"
                    :category="drink.category"
                    :size="drink.size"
                    :imageSrc="drink.imageSrc"
                      
                />
                
            </v-col>
        </v-row>

        <!-- v-for every drink in the computed function prePastDinnerDrinks-->
        <!--- Used to place all pre-past dinner drinks together ---> 
        <h2 class="white--text ">Drikke til før og etter middag</h2>
        <v-row>
            <v-col  cols="12" sm="6" md="4" lg="3" xl="3"
            v-for="drink in prePastDinnerDrinks" :key="drink.id" >

                <DrinkItem
                    :name="drink.name"
                    :price="drink.price"
                    :category="drink.category"
                    :size="drink.size"
                    :imageSrc="drink.imageSrc"
                      
                />
                
            </v-col>
        </v-row>
        
    </div>
</template>

<script>

import DrinkItem from './DrinkItem.vue';


export default {
    name: "DrinkList",
    props: { 
        drinks: Array
    },
    components: {
        DrinkItem
    },
    
    /* --- Computed functions that filters by category --- */
    /* --- With computed the functions get called by itself --- */
    computed: {
     nonAlcoholList: function() {
       return this.drinks.filter(function(u) {
         return u.category == 'Alkoholfri'
        });
    },
    barrelsBeerList: function() {
       return this.drinks.filter(function(u) {
         return u.category == 'Fatøl'
     });
   },
   bottleBeerList: function() {
       return this.drinks.filter(function(u) {
         return u.category == 'Flaskeøl'
     });
   },
   redWinelist: function() {
       return this.drinks.filter(function(u) {
         return u.category == 'Rødvin'
     });
   },
   whiteWineList: function() {
       return this.drinks.filter(function(u) {
         return u.category == 'Hvitvin'
     });
   },
   prePastDinnerDrinks: function() {
       return this.drinks.filter(function(u) {
         return u.category == 'Før-etter-middag'
     });
   }
   
    
}

}
</script>