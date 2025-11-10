import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { PerfectScrollbarPlugin } from 'vue3-perfect-scrollbar'
import VueApexCharts from 'vue3-apexcharts'
import Select2 from 'vue3-select2-component';
import {LoadingPlugin} from 'vue-loading-overlay';
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'
import '@/assets/styles/style.css'
import '@/assets/styles/icons/font-awesome.min.css'
import '@/assets/styles/icons/themify.css'
import '@/assets/styles/fontawesome.css' 
import '@/assets/styles/feather-icon.css' 
import '@/assets/styles/responsive.css' 
import 'vue-loading-overlay/dist/css/index.css';

createApp(App)
    .use(store)
    .use(router)
    .use(PerfectScrollbarPlugin)
    .use(VueApexCharts)
    .component('Select2', Select2)
    .use(LoadingPlugin)
    .mount('#app')
