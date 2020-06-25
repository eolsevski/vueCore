<template>
    <div class="body" >
        <NButton 
        v-for="button in getButtons"
        :key="button.Value"
        
        :value="button.Value"
        :href="button.Href"
        :Visible="button.Visible?true:logedIn"
        
        />
        <!--:value='$t("NavBar."+button.Value)'  -->
        <userDropdown/>
        <langDropdown/>
        <!-- <NButton 
        :darkModeButton=true 
        @eee="darkMode=!darkMode"
        /> -->
        
    </div>
</template>

<script>
import NButton from '@/components/UI/Buttons/NButton'
import userDropdown from '@/components/UI/Dropdown/NUserDropDown'
import langDropdown from '@/components/UI/Dropdown/NLangDropDown'
import {mapGetters} from 'vuex'
export default {
    computed:{
        ...mapGetters(['logedIn']),
        getButtons(){
            return [
                {
                Value: this.$i18n.t("NavBar.Home"),
                Href:"/",
                Visible:true
                },
                {
                Value:this.$i18n.t("NavBar.About"),
                Href:"/about",
                Visible:false
                },
                {
                Value:this.$i18n.t("NavBar.Secret"),
                Href:"/secret",
                Visible:false
                },
                {
                Value:this.$i18n.t("NavBar.Upload"),
                Href:"/upload",
                Visible:false
                },
        ]
            
        
        }
        },
    methods:{
        isLoged(){
            return this.logedIn;
        }
    },
    components:{
        NButton,
        userDropdown,
        langDropdown
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