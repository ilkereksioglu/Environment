import { jwtDecode } from "jwt-decode";
import axios from "axios";

class TokenService {
  getLocalRefreshToken() {
    const user = JSON.parse(localStorage.getItem('kullanici'));
    return user ? user.refreshToken : null;
  }

  getLocalAccessToken() {
    const user = JSON.parse(localStorage.getItem('kullanici'));
    return user ? user.accessToken : null;
  }

  checkAccessTokenExpiration(){
    var token = this.getLocalAccessToken();
    if(!token)
      return false;
    let decoded = jwtDecode(token);
    let now = Date.now().valueOf();
    if(decoded.exp * 1000 > now)
      return false;
    return true;
  }

  checkTokenExpired(token){
    let decoded = jwtDecode(token);
    let now = Date.now().valueOf();;
    if(decoded.exp * 1000 > now)
      return false;
    return true;
  }

  getKullanici() {
    return JSON.parse(localStorage.getItem('kullanici'));
  }

  setKullanici(kullanici) {
    localStorage.setItem('kullanici', JSON.stringify(kullanici));
  }

  removeKullanici() {
    localStorage.removeItem('kullanici');
  }

  async getAccessTokenIfAuthenticated() {
    let token = this.getLocalAccessToken();
    if(token){
      if(this.checkTokenExpired(token)){
        try {
          var response = await axios.post(process.env.VUE_APP_BASE_URL + "/tokengetir", { refreshToken: this.getLocalRefreshToken() });
          if (response && response.data && response.data.data){
            this.setKullanici(response.data.data);
            return Promise.resolve(this.getLocalAccessToken());
          }
        } catch (_error) {
            this.removeKullanici();
            return Promise.reject(_error);
        }    
      }else{
        return Promise.resolve(token);
      }
    }
    this.removeKullanici();
    return Promise.reject("");
  }

  async isAuthenticated() {
    let token = this.getLocalAccessToken();
    if(token){
      if(this.checkTokenExpired(token)){
        try {
          var response = await axios.post(process.env.VUE_APP_BASE_URL + "/tokengetir", { refreshToken: this.getLocalRefreshToken() });
          if (response && response.data && response.data.data){
            this.setKullanici(response.data.data);
            return Promise.resolve(true);
          }
        } catch (_error) {
            this.removeKullanici();
            return Promise.resolve(false);
        }    
      }else{
        return Promise.resolve(true);
      }
    }
    this.removeKullanici();
    return Promise.resolve(false);
  }
}

export default new TokenService();