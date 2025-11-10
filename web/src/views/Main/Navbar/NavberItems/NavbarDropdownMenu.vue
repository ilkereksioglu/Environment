.<template>
    <li class="dropdown">
        <a @click="$emit('changeSelectedDropdown', MenuDropdown.Title)" class="nav-link menu-title" :class="{ 'active': MenuDropdown.Title == selectedTab }" href="javascript:void(0)"><i class="me-2 fa" :class="[MenuDropdown.Icon]"></i><span>{{ MenuDropdown.Title }}</span><div class="according-menu"><i class="fa fa-angle-right" :class="{ 'open': MenuDropdown.Title == selectedTab }"></i></div></a>
        <ul class="nav-submenu menu-content d-grid" :class="{ 'open': MenuDropdown.Title == selectedTab }">
            <div>
                <template v-for="(Menu, index) in MenuDropdown.Menus" :key="index">
                    <li v-if="!Menu.IsDropDown"><router-link :to="Menu.Link">{{ Menu.Name }}</router-link></li>
                    <li v-else>
                    <a class="submenu-title" href="javascript:void(0)">{{ Menu.Name }}<span class="sub-arrow"><i class="fa fa-chevron-right"></i></span></a>
                    <ul class="nav-sub-childmenu submenu-content">
                        <li v-for="(NestedMenu, index2) in Menu.NestedMenus" :key="index2"><a :href="NestedMenu.Link">{{ NestedMenu.Name }}</a></li>
                    </ul>
                    </li>
                </template>
            </div>
        </ul>
    </li>
</template>

<script>
export default {
    props: {
        MenuDropdown: {
            type: Object,
            default: () => ({}),
        },
        selectedTab: {
            type: String
        }
    },
    data () {
        return {
            showDropdown: false
        }
    }
}
</script>

<style scoped>
    ul.menu-content {
        overflow:hidden;
        position:relative;
        grid-template-rows: 0fr;
        transition: grid-template-rows  0.5s linear 0s; 
    }

    ul.menu-content.open {
        grid-template-rows: 1fr;
    }

    ul.menu-content > * {
        overflow: hidden;
    }

    .according-menu i{
        transition: transform 0.3s linear;
    }

    .according-menu i.open{
        transform: rotate(90deg); 
    }
</style>