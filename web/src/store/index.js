import { createStore } from 'vuex'
import auth from './auth.js'
import musteri from './musteri.js';
export default createStore({
  modules: { auth, musteri },
  state: {
    showSidebarMenu: false,
    showLoading: false
  },
  getters: {
  },
  mutations: {
    toggleSidebarMenu (state) {
      state.showSidebarMenu = !state.showSidebarMenu;
    },
    showLoadingOverlay (state) {
      state.showLoading = true;
    },
    hideLoadingOverlay (state) {
      state.showLoading = false;
    },
    
  },
  actions: {
    /*
    isAuthenticated ({ commit }) {
      let token = tokenService.getLocalAccessToken();
      if(token){
        if(tokenService.checkTokenExpired(token)){
          try {
            store.commit('showLoadingOverlay');
            var response = axios.post(process.env.BASE_URL, { refreshToken: tokenService.getLocalRefreshToken() });
            if (response && response.data){
              tokenService.setKullanici(response.data);
            }
          } catch (_error) {
              store.commit('hideLoadingOverlay');
              return Promise.reject(_error);
          }    
        }
        config.headers["Authorization"] = "Bearer " +  tokenService.getLocalAccessToken();
      }
    }
      */
  },
})
