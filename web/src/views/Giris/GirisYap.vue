<template>
<!--
<div class="loader-wrapper">
  <div class="theme-loader">    
    <div class="loader-p"></div>
  </div>
</div>
-->
<!-- Loader ends-->
<!-- page-wrapper Start-->
<section>         
  <div class="container-fluid p-0">
    <div class="row">
      <div class="col-12">
        <div class="login-card">
          <form class="theme-form login-form">
            <h4>Giris Yap</h4>
            <h6>Hos geldiniz!</h6>
            <div class="form-group">
              <label>Kullanici Adi</label>
              <div class="input-group">
                <span class="input-group-text"><i class="icon-email"></i></span>
                <input @blur="v$.user.kullaniciAdi.$touch" class="form-control" type="text" required="" placeholder="Kullanici adi" v-model="user.kullaniciAdi">
              </div>
              <div class="position-absolute text-danger">
                <small v-if="v$.user.kullaniciAdi.$error && v$.user.kullaniciAdi.$dirty">
                  {{ v$.user.kullaniciAdi.$errors[0].$message }}
                </small>
              </div>
            </div>
            <div class="form-group">
              <label>Sifre</label>
              <div class="input-group"><span class="input-group-text"><i class="icon-lock"></i></span>
                <input @blur="v$.user.password.$touch" class="form-control" type="password" name="login[password]" required="" placeholder="*********" v-model="user.password">
                <div class="show-hide"><span class="show">                         </span></div>
              </div>
              <div class="position-absolute text-danger">
                <small v-if="v$.user.password.$error && v$.user.password.$dirty">
                  {{ v$.user.password.$errors[0].$message }}
                </small>
              </div>
            </div>
            <div class="form-group">
              <div class="checkbox">
                <input id="checkbox1" type="checkbox">
                <label for="checkbox1">Remember password</label>
              </div><a class="link" href="forget-password.html">Forgot password?</a>
            </div>
            <div class="form-group">
              <button :class="{ disabled: v$.$invalid }" class="btn btn-primary btn-block" type="submit" @click.prevent="girisYap">Sign in</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</section>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import { required, email, helpers } from '@vuelidate/validators'

export default {
  setup () {
    return { v$: useVuelidate() }
  },
  validations() {
    return {
      user: {
        kullaniciAdi: { required: helpers.withMessage('Lutfen kullanici adinizi giriniz', required) },
        password: { required: helpers.withMessage('Lutfen sifrenizi adini giriniz', required) },
      },
    }
  },
  data() {
    return {
      user: {
        kullaniciAdi: '',
        password: '',
      }
    }
  },
  methods: {
    async girisYap() {
      let result = await this.v$.$validate()
      if(!result)
        return;
      this.$store.dispatch('auth/girisYap', this.user).then(
        (response) => {
          this.$router.push('/');
        },
        () => {}
      );
    }
  }
}
</script>

<style>

</style>