<template>
    <div class="body" >
        <NButton 
        v-for="button in buttons"
        :key="button.Value"
        :value="button.Value"
        :href="button.Href"
        :Visible="button.Visible?true:logedIn"
        />
        <dropdown/>
        <!-- <NButton 
        :darkModeButton=true 
        @eee="darkMode=!darkMode"
        /> -->
        
    </div>
</template>

<script>
import NButton from '@/components/UI/Buttons/NButton'
import dropdown from '@/components/UI/Dropdown/NDropDown'
import {mapGetters} from 'vuex'
export default {
    props:[],
    data(){return {
        buttons:[
                {
                Value:"Home",
                Href:"/",
                Visible:true
                },
                {
                Value:"About",
                Href:"/about",
                Visible:false
                },
                {
                Value:"Secret",
                Href:"/secret",
                Visible:false
                },
                {
                Value:"Upload",
                Href:"/upload",
                Visible:false
                },
        ]
        
    }   
    },
    computed:mapGetters(['logedIn']),
    methods:{
        isLoged(){
            return this.logedIn;
        }
    },
    components:{
        NButton,
        dropdown
    }
}
</script>

<style scoped>
.body{
    margin-right: 5rem;
    width: 98%;
    display: flex;
    justify-content: flex-end;
    align-items: flex-start;
    flex-direction: row;
/* border: solid tomato 1px; */
}

.direction-col{
    flex-direction: column;
}
.direction-row{
    flex-direction: row;
}
</style>