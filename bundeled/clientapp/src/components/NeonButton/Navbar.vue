<template>
    <div class="body light direction-col">
        <NButton 
        v-for="button in buttons"
        :key="button.Value"
        :value="button.Value"
        :href="button.Href"
        />
    </div>
</template>

<script>
import NButton from '@/components/NeonButton/NButton'
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
        ]
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
background:whitesmoke;
}
.dark{
background: #050801;
}
.direction-col{
    flex-direction: column;
}
</style>