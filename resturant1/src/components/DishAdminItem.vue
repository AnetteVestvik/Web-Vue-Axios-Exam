
<template>
<!-------------- Template of every dish in Admin ------------->
<div>
    <v-container fluid>
    <v-card height="90">
       <v-card-title> {{ name }}
        </v-card-title>
            <!-- delete button -->
            <v-row justify="end" align="center">
                <v-btn class="deleteBtn" @click="deleteDish">
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
    name: "DishAdminItem",
    props: {
           name: String,
           category: String,
           id: Number
    },
    data(){
        return{
            deleteId: this.id
        }
    },
    methods: {
        /* ---- Method to delete dish ----*/
        /* ---- Delete dish that has the same ID as the button clicked ---- */
        deleteDish(){
            //using the dishAdmin controller from API
            let webAPIUrl = `https://localhost:5001/dishAdmin/${this.deleteId}`;
            axios.delete( webAPIUrl )
                .then(
                    result => {
                        console.log(result.data);
                        this.deleteId="";
                        //Reload window
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


