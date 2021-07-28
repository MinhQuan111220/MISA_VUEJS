<template>
  <div id="main">
    <TheMenu />
    <TheConTent />
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import TheConTent from './components/layout/TheConTent.vue'
import TheMenu from './components/layout/TheMenu.vue'

export default {
  name: 'Main',
  components: {
    TheConTent,
    TheMenu
  }
}
</script>

<style>

@import url('../src/assets/css/base/Base.css');
</style>
