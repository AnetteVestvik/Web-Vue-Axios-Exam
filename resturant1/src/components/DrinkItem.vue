<template>
<!-------- Template of every drink in menu -------->
<div>
    <article>
    <v-card class="mx-auto" height="400">
       <v-card-title> {{ name }} </v-card-title>
            
       <!-- Getting the photo from the API -->
       
        <v-img class="align-end"
            :src="`https://localhost:5001/images/${ imageSrc}`" max-height="225"
              contain> 
        </v-img>
       
       
        <v-card-text>
            <p> {{ price }},-</p>
            <!-- If the size is bigger than 0, then show size -->
            <p v-if="size > 0"> 0.{{ size }} liter </p>
        </v-card-text>
    </v-card> 
    </article>
</div>
    
</template>
    
<script>
export default {
    name: "DrinkItem",
    props: {
           name: String,
           price: Number,
           size: Number,
           category: String,
           imageSrc: String
    }
}
</script>



