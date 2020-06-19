<template>
  <div class="upload">
    <upload/>
    <treeBrowser
    :node="root"
    @onClick="nodeWasClicked"
    @inputClicked="markItem"
    />
    
    <span>Checked names: {{checkedItems}}</span>
    <Navbar  />
    
  </div>
</template>

<script>
import upload from '@/components/Upload/upload'
import treeBrowser from '../Treeview/TreeBrowser'
import Navbar from '@/components/UI/Navbars/Navbar'


export default {
  data() {
    return {
      checkedItems: [],
      root: {
        name: 'My Own Files',
        fulPath: 'My Own Files',
        children: [
          {
            name: 'music',
            fulPath: 'My Own Files/music',
            children:[
              {
                name:'song.mp3',
                fulPath: 'My Own Files/music/song.mp3',
              }
            ]
          },
          {
            fulPath: 'My Own Files/workspace',
            name:'workspace',
            children:[
              {
                fulPath: 'My Own Files/workspace/source.smthng',
                name: 'source.smthng',
                
              }
            ]
          }
        ]
      },
      
    }
  },
  methods:{
    nodeWasClicked(node){
alert(node.id);
    },
    markItem(name, checked){
      if(checked)
      {this.checkedItems.splice(this.checkedItems.indexOf(name),1)}
      else{
        this.checkedItems.push(name);
      }
      
    }
  },
    components:{
        upload,
        treeBrowser,
        Navbar
    }
}
</script>

<style scoped>
.upload{
  background: black;
  color: aliceblue;
}
</style>