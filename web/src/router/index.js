import { createRouter, createWebHistory } from 'vue-router'
import store from "../store/index.js";
import tokenService from  "../services/token.js";
import HomeView from '../views/HomeView.vue'
import GirisYap from '../views/Giris/GirisYap.vue'
import MusteriDetail from '../views/Customer/MusteriDetail.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/girisyap',
    name: 'girisYap',
    component: GirisYap
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/musteri/:id(\\d+)',
    name: 'musteriDetail',
    component: MusteriDetail
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach(async (to, from, next) => {
  var isAuthenticated = true;
  try{
    var isExpired = tokenService.checkAccessTokenExpiration();
    console.log("Expired: ", isExpired);
    if(isExpired)
      store.commit('showLoadingOverlay');
    isAuthenticated = await tokenService.isAuthenticated();
    console.log(isAuthenticated, "opps");
    store.commit('hideLoadingOverlay');
  } catch(error){}
  store.commit('hideLoadingOverlay');
  if (
    to.fullPath.startsWith('/girisyap')
  ) {
    if (isAuthenticated) {
      console.log("dont");
      next('/');
    }else{
      next();
    }
  }else{
    if (!isAuthenticated)
      next('/girisyap');
    next();
  }
});

export default router
