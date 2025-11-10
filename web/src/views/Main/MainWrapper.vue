<template>
  <VerticalSideBar></VerticalSideBar>
  <MainContent></MainContent>
</template>

<script>
  import VerticalSideBar from './Navbar/VerticalSideBar.vue'
  import MainContent from './Content/MainContent.vue'

  export default {
    components: {
      VerticalSideBar,
      MainContent
    },
    data() {
      return {
        greeting: 'Hello World!'
      }
    }
  }
</script>

<style>
</style>
