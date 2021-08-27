<template>
  <div id="main">
    <TheMenu />
    <TheNavbar 
    @active="active"
    />
    <TheConTent 
    :isActive="isActive"
    />
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import TheConTent from './components/layout/TheConTent.vue'
import TheMenu from './components/layout/TheMenu.vue'
import TheNavbar from './components/layout/TheNavBar.vue'
export default {
  name: 'Main',
  components: {
    TheConTent,
    TheMenu,
    TheNavbar
  },
  methods: {
    active(index){
      if(index==1){
        this.isActive = true
      }else{
        this.isActive = false
      }
    }
  },
  data() {
    return {
      isActive : false
    }
  },
}
</script>

<style>

@import url('../src/assets/css/base/Base.css');
</style>
