<template>
    <div class="body direction-row light"  :class="{  'dark' : darkMode}">
        <NButton 
        v-for="button in buttons"
        :key="button.Value"
        :value="button.Value"
        :href="button.Href"
        />
        <NButton 
        :darkModeButton=true 
        @eee="darkMode=!darkMode"
        />
    </div>
</template>

<script>
import NButton from '@/components/UI/Buttons/NButton'
export default {
    props:[],
    data(){return {
        buttons:[
                {
                Value:"Home",
                Href:"/"
                },
                {
                Value:"About",
                Href:"/about"
                },
                {
                Value:"Secret",
                Href:"/secret"
                },
                {
                Value:"Upload",
                Href:"/upload"
                },
        ],
        darkMode:false
    }   
    },
    components:{
        NButton
    }
}
</script>

<style scoped>
.body{
    background: white;
    width: 100%;
    display: flex;
    justify-content: flex-end;
    align-items: flex-start;
    flex-direction: row;

}
.light{
background:white;
color: black;
}
.dark{
background: #050801;
color: white;
}
.direction-col{
    flex-direction: column;
}
.direction-row{
    flex-direction: row;
}
</style>