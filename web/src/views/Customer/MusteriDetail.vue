<template>
    <div class="container-fluid">
        <div class="page-header">
            <div class="row">
            <div class="col-sm-6">
                <h3>MÜŞTERİ EKLEME</h3>
                <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Ana Sayfa</a></li>
                <li class="breadcrumb-item">Musteri</li>
                <li class="breadcrumb-item active">Musteri Detay</li>
                </ol>
            </div>
            <div class="col-sm-6">
                <!-- Bookmark Start-->
                <div class="bookmark">
                <ul>
                    <li><a href="javascript:void(0)" data-container="body" data-bs-toggle="popover" data-placement="top" title="" data-original-title="Tables"><i data-feather="inbox"></i></a></li>
                    <li><a href="javascript:void(0)" data-container="body" data-bs-toggle="popover" data-placement="top" title="" data-original-title="Chat"><i data-feather="message-square"></i></a></li>
                    <li><a href="javascript:void(0)" data-container="body" data-bs-toggle="popover" data-placement="top" title="" data-original-title="Icons"><i data-feather="command"></i></a></li>
                    <li><a href="javascript:void(0)" data-container="body" data-bs-toggle="popover" data-placement="top" title="" data-original-title="Learning"><i data-feather="layers"></i></a></li>
                    <li><a href="javascript:void(0)"><i class="bookmark-search" data-feather="star"></i></a>
                    <form class="form-inline search-form">
                        <div class="form-group form-control-search">
                        <input type="text" placeholder="Search..">
                        </div>
                    </form>
                    </li>
                </ul>
                </div>
                <!-- Bookmark Ends-->
            </div>
            </div>
        </div>
    </div>
        <!-- Container-fluid starts-->
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12 col-xl-12">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card" v-if="form.musteri">
                        <div class="card-header pb-0">
                        <h5>MÜŞTERİ BİLGİLERİ</h5><span>Yeni <a href="#">musteri</a> ekleme ve update etme sayfasi</span>
                        </div>
                        <div class="card-body">
                            <form class="theme-form d-flex">
                                <!--Musteri Bilgileri start-->
                                <div class="col-4 p-2 border-end">
                                    <h5 class="mb-4">MÜŞTERİ BİLGİLERİ</h5>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="musteriKod">Müşteri Kodu:</label>
                                        <input v-model="form.musteri.kod" class="form-control" type="text" aria-describedby="musteriKod" placeholder="Müşteri kodu gir">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="musteriAd">Müşteri Adı:</label>
                                        <input v-model="form.musteri.ad" class="form-control" type="text" aria-describedby="musteriAd" placeholder="Müşteri adı gir">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="unvan">Ünvan:</label>
                                        <input v-model="form.musteri.unvan" class="form-control" type="text" aria-describedby="unvan" placeholder="Ünvan gir">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="kontak">Kontak / Yetkili:</label>
                                        <input v-model="form.musteri.kontak" class="form-control" type="text" aria-describedby="kontak" placeholder="Kontak gir">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="musteriTip">Müşteri Tipi</label>
                                        <select v-model="form.musteri.musteriTipId" class="form-select digits">
                                            <option disabled value="">Lütfen müşteri tipi seçiniz</option>
                                            <option :selected="form.musteri.musteriTipId > 0 ? tip.id == form.musteri.musteriTipId : tip.varsayilan" v-for="tip in musteriTipleri" :key="tip.index" :value="tip.id">{{ tip.ad }}</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="musteriKategori">Müşteri Kategorisi</label>
                                        <select v-model="form.musteri.musteriKategoriId" class="form-select digits">
                                            <option disabled value="">Lütfen kategori seçiniz</option>
                                            <option :selected="form.musteri.musteriKategoriId > 0 ? tip.id == form.musteri.musteriKategoriId : kategori.varsayilan" v-for="kategori in musteriKategorileri" :key="kategori.index" :value="kategori.id">{{ kategori.ad }}</option>
                                        </select>
                                    </div>
                                   <div class="mb-3">
                                        <label class="col-form-label pt-0" for="musteriKaynak">Müşteri Kaynagi</label>
                                        <select v-model="form.musteri.musteriKaynakId" class="form-select digits">
                                            <option disabled value="">Lütfen kaynak seçiniz</option>
                                            <option :selected="form.musteri.musteriKaynakId > 0 ? tip.id == form.musteri.musteriKaynakId : kaynak.varsayilan" v-for="kaynak in musteriKaynaklari" :key="kaynak.index" :value="kaynak.id">{{ kaynak.ad }}</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="musteriSektor">Müşteri Sektoru</label>
                                        <select v-model="form.musteri.musteriSektorId" class="form-select digits">
                                            <option disabled value="">Lütfen kaynak seçiniz</option>
                                            <option :selected="form.musteri.musteriSektorId > 0 ? sektor.id == form.musteri.musteriSektorId : sektor.varsayilan" v-for="sektor in musteriSektorleri" :key="sektor.index" :value="sektor.id">{{ sektor.ad }}</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0">Aktif / Pasif</label>
                                        <select v-model="form.musteri.status" class="form-select digits">
                                            <option value="0">Pasif</option>
                                            <option selected value="1">Aktif</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="aciklama">Açıklama</label>
                                        <textarea class="form-control btn-square" id="aciklama" v-model="form.musteri.aciklama" rows="3"></textarea>
                                    </div>
                                    <div class="checkbox p-0">
                                        <input type="checkbox" v-model="form.musteri.takipDurumu">
                                        <label class="mb-0" for="takipDurumu">Takip Durumu</label>
                                    </div>
                                </div>
                                <!--Musteri Bilgileri end-->
                                <!--Iletisim Bilgileri start-->
                                <div class="col-4 p-2">
                                    <h5 class="mb-4">İLETİŞİM BİLGİLERİ</h5>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="adresTip">Adres Tipi</label>
                                        <select v-model="form.adres.adresTipId" class="form-select digits">
                                            <option disabled value="0">Lütfen adres tipi seçiniz</option>
                                            <option :selected="form.adres.adresTipId && form.adres.adresTipId > 0 ? adresTip.id == form.adres.adresTipId : adresTip.varsayilan" v-for="adresTip in adresTipleri" :key="adresTip.index" :value="adresTip.id">{{ adresTip.ad }}</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="adresSatiri1">Adres Satırı 1</label>
                                        <input v-model="form.adres.satir1" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="adresSatiri2">Adres Satırı 2</label>
                                        <input v-model="form.adres.satir2" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="sehir">Şehir</label>
                                        <select v-model="form.adres.sehir" class="form-select digits">
                                            <option selected value="Kocaeli">Kocaeli</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="ilce">İlçe</label>
                                        <input v-model="form.adres.ilce" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="postaKodu">Posta Kodu</label>
                                        <input v-model="form.adres.postaKodu" class="form-control" type="number" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="bolgeKodu">Bölge Kodu</label>
                                        <input v-model="form.adres.bolgeKodu" class="form-control" type="number" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="telefon">Telefon</label>
                                        <input v-model="form.musteri.telefon" class="form-control" type="tel" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="telefon2">Telefon2</label>
                                        <input v-model="form.musteri.telefon2" class="form-control" type="tel" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="faks">Faks</label>
                                        <input v-model="form.musteri.faks" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="cepTelefonu">Cep Telefonu</label>
                                        <input v-model="form.musteri.cepTelefonu" class="form-control" type="tel" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="email">Email</label>
                                        <input v-model="form.musteri.email" class="form-control" type="email" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="email2">Email2</label>
                                        <input v-model="form.musteri.email2" class="form-control" type="email" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="webAdres">Web Adresi</label>
                                        <input  v-model="form.musteri.webAdres" class="form-control" type="text" placeholder="">
                                    </div>
                                </div>
                                <!--Iletisim Bilgileri end-->
                                <!--Finans Bilgileri & Sosyal Medya start-->
                                <div class="col-4 p-2 border-start">
                                    <h5 class="mb-4">FINANS BİLGİLERİ</h5>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="vergiDairesi">Vergi Dairesi</label>
                                        <input v-model="form.musteri.vergiDairesi" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="vergiNumarasi">Vergi Numarası</label>
                                        <input v-model="form.musteri.vergiNumarasi" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="riskDurumu">Risk Durumu</label>
                                        <select v-model="form.musteri.riskDurumu" class="form-select digits">
                                            <option hidden selected value=""></option>
                                            <option value="0">Risksiz</option>
                                            <option value="1">Riskli</option>
                                        </select>
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="iskonto">İskonto (%)</label>
                                        <input v-model="form.musteri.iskonto" class="form-control" type="number" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="bakiye">Bakiye</label>
                                        <input v-model="form.musteri.bakiye" class="form-control" type="number" placeholder="">
                                    </div>
                                    <h5 class="mb-4">SOSYAL MEDYA</h5>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="skype"><i class="fa fa-skype me-2" style="color: #00aff0; spadding: 2px;"></i>Skype</label>
                                        <input v-model="form.musteri.detay.sosyalMedya.skype" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="linkedin"><i class="fa fa-linkedin me-2" style="background-color: #0A66C2; color: white; padding: 2px;"></i>LinkedIn</label>
                                        <input v-model="form.musteri.detay.sosyalMedya.linkedin" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="facebook"><i class="fa fa-facebook me-2" style="background-color: #3b5999; color: white; padding: 2px;"></i>Facebook</label>
                                        <input v-model="form.musteri.detay.sosyalMedya.facebook" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="instagram"><i class="fa fa-instagram me-2" style="color: #ee2a7b ; padding: 2px;"></i>Instagram</label>
                                        <input v-model="form.musteri.detay.sosyalMedya.instagram" class="form-control" type="text" placeholder="">
                                    </div>
                                    <div class="mb-3">
                                        <label class="col-form-label pt-0" for="twitter"><i class="fa fa-twitter me-2" style="color: 1DA1F2 ; padding: 2px;"></i>Twitter</label>
                                        <input v-model="form.musteri.detay.sosyalMedya.twitter" class="form-control" type="text" placeholder="">
                                    </div>
                                </div>
                                <!--Finans Bilgileri & Sosyal Medya end-->
                            </form>
                        </div>
                        <div class="card-footer d-flex justify-content-end">
                            <button class="btn btn-primary me-2" @click="musteriEkleGuncelle">Kaydet</button>
                            <button class="btn btn-secondary">Yeni Kayıt</button>
                        </div>
                    </div>
                    <div v-else>
                        {{ error.message }}
                    </div>
                </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import { required, email, helpers } from '@vuelidate/validators'
import Swal from 'sweetalert2'

export default {
  setup () {
    return { v$: useVuelidate() }
  },
  validations() {
    return {
      form: {
        musteri: {
            kod: '',
            ad: '',
            unvan: '',
            kontak: '',
            musteriTipId: 0,
            musteriKaynakId: 0,
            musteriSektorId: 0,
            musteriKategoriId: 0,
            ekip: '',
            aciklama: '',
            takipDurumu: true,
            telefon: '',
            telefon2: '',
            faks: '',
            cepTelefonu: '',
            email: '',
            email2: '',
            webAdres: '',
            vergiNo: 0,
            vergiDairesi: '',
            iskonto: 0,
            detay: { sosyalMedya: {} }
        },
        adres: {
            adresTipId: 0
        },
      },
    }
  },
  data() {
    return {
      form: {
        musteri: {
            kod: '',
            ad: '',
            unvan: '',
            kontak: '',
            musteriTipId: 0,
            musteriKaynakId: 0,
            musteriSektorId: 0,
            musteriKategoriId: 0,
            ekip: '',
            aciklama: '',
            takipDurumu: true,
            telefon: '',
            telefon2: '',
            faks: '',
            cepTelefonu: '',
            email: '',
            email2: '',
            webAdres: '',
            vergiNo: 0,
            vergiDairesi: '',
            iskonto: 0,
            detay: { sosyalMedya: {} }
        },
        adres: {
            adresTipId: 0
        },
      },
      musteriTipleri: [],
      musteriKaynaklari: [],
      musteriKategorileri: [],
      musteriSektorleri: [],
      adresTipleri: [],
      veriListesi: [],
      error: {}
    }
  },
  created() {
    this.$store.dispatch('musteri/musteriGetir', + this.$route.params.id).then(
        (response) => {
          console.log(response);
          this.form.musteri = response.data.musteri;
          this.form.adres = response.data.adres;
          this.musteriTipleri = response.data.musteriTipleri;
          this.musteriSektorleri = response.data.musteriSektorleri;
          this.musteriKategorileri = response.data.musteriKategorileri;
          this.musteriKaynaklari = response.data.musteriKaynaklari;
          this.adresTipleri = response.data.adresTipleri;
          this.veriListesi = response.data.veriListesi;
        },
        () => {console.log("response");}
      );
  },
  methods: {
    async musteriEkleGuncelle() {
      let result = await this.v$.$validate()
      if(!result)
        return;
      var payload = { id: this.$route.params.id, musteri: this.form };
      this.$store.dispatch('musteri/musteriEkleGuncelle', payload).then(
        (response) => {
            this.$router.push('/');
        },
        (error) => {
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
            
            this.error = error;
        }
      );
    }
  }
}
</script>

<style>
    form span {
        font-weight: 400;
    }
</style>