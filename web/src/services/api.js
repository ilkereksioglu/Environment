import axios from "axios";
import store from "../store/index.js";
import tokenService from  "./token.js";

const axiosInstance = axios.create({
  baseURL: process.env.VUE_APP_BASE_URL,
  headers: {
  },
});

//interceptors
axiosInstance.interceptors.request.use(async (config) => {
  store.commit('showLoadingOverlay');
  try{
    //error thrown if not authenticated to redirect to girisyap
    var token = await tokenService.getAccessTokenIfAuthenticated();
    config.headers["Authorization"] = "Bearer " +  token;
  } catch (error) {
      window.location.href = '/girisyap';
      return Promise.reject(error);
  } 

  return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

axiosInstance.interceptors.response.use(
  (res) => {
    store.commit('hideLoadingOverlay');
    return res;
  },
  async (err) => {
    const originalConfig = err.config;

    if (originalConfig.url !== '/girisyap' && err.response && err.response.status === 401) {
      // Access Token was expired
      originalConfig.Authorization = '';
      setTimeout(() => {
            window.location.href = '/girisyap';
        }, 100);
    }

    store.commit('hideLoadingOverlay');
    return Promise.reject(err.response);
  }
);

export default axiosInstance;
