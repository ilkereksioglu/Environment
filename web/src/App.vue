<template>
  <loading
    :active="$store.state.showLoading"
    :can-cancel="false"
    :is-full-page="fullPage"
    :color="'#ffffff'"
    :loader="spinner"
    :width="32"
    :height="32"
    :backgroundColor="'#878787'"
    :opacity="0.5"
    :zIndex="999999"
  >
  </loading>
  <div v-if="this.$router.currentRoute.value.name !== 'girisYap'" class="page-wrapper compact-wrapper" id="pageWrapper">
    <PageHeader />
    <div class="page-body-wrapper sidebar-icon">
      <MainWrapper></MainWrapper>
    </div>
  </div>
  <div v-else>
    <router-view></router-view>
  </div>
</template>

<script>
import MainWrapper from './views/Main/MainWrapper.vue'
import PageHeader from './views/Layouts/Header/PageHeader.vue'
import Loading from 'vue-loading-overlay';

  export default {
  components: {
      MainWrapper,
      PageHeader,
      Loading,
  },
  data() {
    return {
      greeting: 'Hello World!',
    }
  }
}
</script>

<style>

</style>
