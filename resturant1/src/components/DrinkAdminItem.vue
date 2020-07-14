<template>
<!------------ Template of every drink in admin --------->
<div>
    <v-container fluid>
        <v-card height="90">
            <v-card-title> {{ name }} </v-card-title>
                <!-- delete button -->
                <v-row justify="end" align="center">
                    <v-btn class="deleteBtn" @click="deleteDrink">
                        <v-icon>mdi-delete</v-icon>
                    </v-btn>
                </v-row>
        </v-card> 
    </v-container>
</div>
</template>
    
<script>
import axios from 'axios';

export default {
    name: "DrinkAdminItem",
    props: {
           name: String,
           id: Number
    },
    data(){
        return{
            deleteId: this.id
        }
    },
    methods: {
        /* ---- Method to delete drink ----*/
        /* ---- Delete drink that has the same ID as the button clicked ---- */
        deleteDrink(){
            //using the drinkAdmin controller from API
            let webAPIUrl = `https://localhost:5001/drinkAdmin/${this.deleteId}`;
            axios.delete( webAPIUrl )
                .then(
                    result => {
                        console.log(result.data);
                        this.deleteId="";
                        // window reload
                        this.$router.go();
                    }
                )
        }
    }
}
</script>

<style scoped>
    .deleteBtn{
        margin-top: -3rem;
        margin-right: 2rem;
    }
</style>


