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
            commit('showLoadingOverlay', null, { root: true });
            return api.get('/musteri/' + id).then(
                (response) => {
                    commit('musteriGetirSuccess');
                    commit('hideLoadingOverlay', null, { root: true });
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
        async musteriEkleGuncelle({commit}, id, musteri){
            commit('showLoadingOverlay', null, { root: true });
            console.log(musteri);
            return api.post('/musteri/' + id, musteri).then(
                (response) => {
                    commit('musteriEkleGuncelleSuccess');
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.resolve(response.data);
                },
                (error) => {
                    commit('musteriEkleGuncelleFail');
                    commit('hideLoadingOverlay', null, { root: true });
                    return Promise.reject(error.message);
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