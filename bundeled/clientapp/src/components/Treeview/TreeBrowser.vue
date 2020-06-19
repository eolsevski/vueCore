<template>
  <div>
    <div :style="{'margin-left': `${depth * 35}px`}" class="node">
      <i
        @click="expandCollapsed"
        v-if="hasChildren"
        class="fa fa-folder-o"
        v-bind:class="{ 'fa fa-folder-open-o': expanded }"
      ></i>
      {{node.name}}
      <input
        type="checkbox"
        id="jack"
        v-bind:value="node.id"
        v-model="checkd"
        @click="inputChecked(node.fulPath, checkd)"
      />
    
    </div>

    <!-- eslint-disable -->
    <TreeBrowser
      v-if="expanded"
      v-for="child in node.children"
      :key="child.id"
      :node="child"
      :depth="depth + 1"
      @inputClicked="inputChecked"
    />
    
    <!-- eslint-enable -->
  </div>
</template>

<script>
export default {
  name: "TreeBrowser",
  props: {
    node: Object,
    depth: {
      type: Number,
      default: 0
    },
    name: {
      type: String,
      default: ""
    },
    checked:{
      type: Boolean,
      default: false
    }
    
  },

  data() {
    return {
      checkd: false,
      expanded: false
    };
  },
  methods: {
    expandCollapsed() {
      this.expanded = !this.expanded;
      //let newName = ""+ this.node.name + name;
      if (!this.hasChildren) {
        //this.$emit("onClick", node, newName);
      }
    },
    inputChecked(name, checked){
      //alert('midway catch: ' + " name: " + name);
      this.$emit('inputClicked', name, checked);
    }
  },
  computed: {
    hasChildren() {
      return this.node.children;
    }
  }
};
</script>

<style >
.node {
  text-align: left;
}
</style>