<template>
    <div>
        <!-- Showing every drink from the API -->
        <v-row justify="center" align="center">
            <v-col  cols="12" sm="12" md="12" lg="11" xl="12"
            v-for="drink in drinks" :key="drink.id" >

                <DrinkAdminItem
                    :name="drink.name"
                    :id="drink.id"
                />
            </v-col>
        </v-row>

    </div>
</template>

<script>

import DrinkAdminItem from './DrinkAdminItem.vue';


export default {
    name: "DrinkAdminList",
    props: {
        drinks: Array
    },
    components: {
        DrinkAdminItem
    }
}
</script>