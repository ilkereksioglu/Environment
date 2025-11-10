<template>
  <header class="main-nav" :class="{'close_icon': $store.state.showSidebarMenu}">
    <div class="sidebar-user text-center">
      <a class="setting-primary" href="javascript:void(0)"><i data-feather="settings"></i></a><img class="img-90 rounded-circle" src="https://cdn-img.zerozero.pt/img/logos/equipas/210707_imgbank_1712309277.png" alt="">
      <div class="badge-bottom"><span class="badge badge-primary">New</span></div><a href="#">
        <h6 class="mt-3 f-14 f-w-600">Emay Walter</h6>
      </a>
      <p class="mb-0 font-roboto">Human Resources Department</p>
      <ul>
        <li>
          <span><span class="counter">19.8</span>k</span>
          <p>Follow</p>
        </li>
        <li>
          <span>2 year</span>
          <p>Experince</p>
        </li>
        <li>
          <span><span class="counter">95.2</span>k</span>
          <p>Follower </p>
        </li>
      </ul>
    </div>
    <nav>
      <div class="main-navbar">
        <div class="left-arrow" id="left-arrow"><i data-feather="arrow-left"></i></div>
        <div id="mainnav">
          <ul class="nav-menu custom-scrollbar">
            <li class="back-btn">
              <div class="mobile-back text-end"><span>Back</span><i class="fa fa-angle-right ps-2" aria-hidden="true"></i></div>
            </li>
            <NavbarMainTitle Title="General" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Ana Sayfa', Icon: 'fa-home', Menus: [{ Name: 'Default', Link: { name: 'musteriDetail', params: { id: 123 }} }, { Name: 'Ecommerce', Link: '#' } ] }" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Müşteri Yönetimi', Icon: 'fa-user', Menus: [{ Name: 'Müşteri Ekle', Link: { name: 'musteriDetail', params: { id: 0 }} }, { Name: 'Müşteri Listesi', Link: { name: 'musteriDetail', params: { id: 0 }} } ] }" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Teklif Yönetimi', Icon: 'fa-file', Menus: [{ Name: 'Boxed', Link: '#' }, { Name: 'RTL', Link: '#' } ] }" />
            <NavbarMainTitle Title="Components" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'UI Kits', Icon: 'fa-wrench', Menus: [{ Name: 'State Color', Link: '#' }, { Name: 'Typography', Link: '#' }, { Name: 'Avatars', Link: '#' }, { Name: 'Grid', Link: '#' }, { Name: 'Progress', Link: '#' }, { Name: 'Tabs', IsDropDown: true, NestedMenus: [{ Name: 'Bootstrap Tabs', Link: '#' }, { Name: 'Line Tabs', Link: '#' }] } ] }" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Bonus UI', Icon: 'fa-star', Menus: [{ Name: 'Rating', Link: '#' }, { Name: 'Tour', Link: '#' }, { Name: 'Avatars', Link: '#' }, { Name: 'Scrollable', Link: '#' }, { Name: 'Dropzone', Link: '#' }, { Name: 'TimeLine', IsDropDown: true, NestedMenus: [{ Name: 'TimeLine 1', Link: '#' }, { Name: 'Time Line 2', Link: '#' }] } ] }" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Builders', Icon: 'fa-square', Menus: [{ Name: 'Layout', Link: '#' }, { Name: 'Template', Link: '#' } ] }" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Icon', Icon: 'fa-info', Menus: [{ Name: 'Font', Link: '#' }, { Name: 'Awesome', Link: '#' } ] }" />
            <NavbarMainTitle Title="Forms" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Form Controls', Icon: 'fa-car', Menus: [{ Name: 'Control', Link: '#' }, { Name: 'Validation', Link: '#' } ] }" />
            <NavbarDropdownMenu @changeSelectedDropdown="changeSelectedTab" :selectedTab="selectedTab" :MenuDropdown="{ Title: 'Icon', Icon: 'fa-ship', Menus: [{ Name: 'Font', Link: '#' }, { Name: 'Awesome', Link: '#' } ] }" />
            <NavbarMainTitle Title="Miscellanous" />
            <NavbarLinkTab Link="#" Title="Support Ticket" />
          </ul>
        </div>
        <div class="right-arrow" id="right-arrow"><i data-feather="arrow-right"></i></div>
      </div>
    </nav>
  </header>
</template>

<script>
import NavbarMainTitle from './NavberItems/NavbarMainTitle.vue'
import NavbarDropdownMenu from './NavberItems/NavbarDropdownMenu.vue'
import NavbarLinkTab from './NavberItems/NavbarLinkTab.vue'

  export default {
    components: {
        NavbarMainTitle,
        NavbarDropdownMenu,
        NavbarLinkTab
    },
    data() {
      return {
        greeting: 'Hello World!',
        selectedTab: ''
      }
    },
    methods: {
      changeSelectedTab(selectedTab) {
        if(selectedTab == this.selectedTab)
            this.selectedTab = '';
          else
            this.selectedTab = selectedTab;
      }
    }
  }
</script>

<style>
</style>