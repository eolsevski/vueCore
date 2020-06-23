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
        id="v"
        class="checkbox"
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
    checked: {
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
    inputChecked(name, checked) {
      //alert('midway catch: ' + " name: " + name);
      this.$emit("inputClicked", name, checked);
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
.checkbox {
  -webkit-appearance: none;
  margin-bottom:auto;
  padding: 0.5rem;
  border-radius: 0.3rem;
  display: inline-block;
  position: relative;
}
@media (prefers-color-scheme: dark) {
  .checkbox {
    background-color: var(--navBarDarkThemeGrey);
    border: 0.1rem solid var(--navBarDarkThemeLight);
    
  }
  .checkbox:hover, .checkbox:checked:hover {
    color: var(--navBarLightThemeLight);
    border: 0.15rem solid var(--navBarDarkThemeLight);;
  }
  .checkbox:checked{
    color: var(--navBarDarkThemeLight);
    border: 0.1rem solid var(--navBarDarkThemeLight);
    
  }
  .checkbox:active, .checkbox:checked:active {
  /* box-shadow: 0 1px 2px var(--navBarDarkThemeLight), inset 0px 1px 3px var(--navBarDarkThemeLight); */
  border: 0.1rem solid var(--navBarDarkThemeLight);
 
}
  .checkbox:checked:after {
	content: '\2714';
	font-size: 0.8rem;
	position: absolute;
	top: 0px;
	left: 3px;
  color: var(--navBarDarkThemeLight);
  
}

}
@media (prefers-color-scheme: light) {
  .checkbox {
    background-color: var(--navBarLightThemeGrey);
    border: 0.1rem solid var(--navBarLightThemeLight);
  }

  .checkbox:checked {
    color: var(--navBarLightThemeLight);
    border: 0.1rem solid var(--navBarLightThemeLight);
  }
  
  .checkbox:active,
  .checkbox:checked:active {
    box-shadow: 0 1px 2px var(--navBarDarkThemeLight), inset 0px 1px 3px var(--navBarDarkThemeLight);
    border: 0.1rem solid var(--navBarLightThemeLight);
  }
  .checkbox:checked:after {
    content: "\2714";
    font-size: 0.8rem;
    position: absolute;
    top: 0px;
    left: 3px;
    color: var(--navBarLightThemeLight);
  }
}

</style>