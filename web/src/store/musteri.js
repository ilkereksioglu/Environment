import api from '../services/api'
import axios from "axios"
import Swal from 'sweetalert2'

export default {
    namespaced: true,
    state: {
    },
    getters: {
    },
    actions: {
        async musteriGetir({commit}, id){
            //commit('showLoadingOverlay', null, { root: true });
            return api.get('/musteri/' + id).then(
                (response) => {
                    commit('musteriGetirSuccess');
                    commit('hideLoadingOverlay', null, { root: true });
                    console.log("isItClosed?")
                    return Promise.resolve(response.data);
                },
                (error) => {
                    console.log(error);
                    commit('musteriGetirFail');
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.reject(error.message);
                }
            );
        },
        async musteriEkleGuncelle({commit}, payload){
            commit('showLoadingOverlay', null, { root: true });
            return api.post('/musteri/' + payload.id, payload.musteri).then(
                (response) => {
                    commit('musteriEkleGuncelleSuccess');
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.resolve(response.data);
                },
                (error) => {
                    commit('musteriEkleGuncelleFail');
                    commit('hideLoadingOverlay', null, { root: true });
                    console.log(error);
                    return Promise.reject(error);
                }
            );
        },
    },
    mutations: {
        musteriGetirSuccess(state) { },
        musteriGetirFail(state) { },
        musteriEkleGuncelleSuccess(state) { },
        musteriEkleGuncelleFail(state) { },
    }
}