import api from '../services/api'
import axios from "axios"
import Swal from 'sweetalert2'
import tokenService from '../services/token'

export default {
    namespaced: true,
    state: {
    },
    getters: {
    },
    actions: {
        async accessTokenGetir({commit}, refreshToken){
            commit('showLoadingOverlay', null, { root: true });
            return api.post('/tokengetir', refreshToken).then(
                (response) => {
                    commit('accessTokenGetirSuccess', user);
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.resolve(response.data);
                },
                (error) => {
                    commit('accessTokenGetirFail', user);
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.reject(error.message);
                }
            );
        },
        girisYap({commit}, kullanici){
            commit('showLoadingOverlay', null, { root: true });
            return axios.post(process.env.VUE_APP_BASE_URL + "/girisyap", kullanici).then(
                (response) => {
                    commit('girisYapSuccess', kullanici);
                    tokenService.setKullanici(response.data);
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.resolve(response.data);
                },
                (error) => {
                    commit('hideLoadingOverlay', null, { root: true });
                    console.log(error);
                    Swal.fire({
                        title: 'Error!',
                        text: error.message,
                        icon: 'error',
                        confirmButtonText: 'Tamam',
                        cancelButtonText: 'Kapat',
                        showCancelButton: true,
                        showCloseButton: true
                    });
                    commit('girisYapFail', user);
                    return Promise.reject(error.message);
                }
            );
        }
    },
    mutations: {
        accessTokenGetirSuccess(state) { },
        accessTokenGetirFail(state) { },
        girisYapSuccess(state) { },
        girisYapFail(state) { },
    }
}