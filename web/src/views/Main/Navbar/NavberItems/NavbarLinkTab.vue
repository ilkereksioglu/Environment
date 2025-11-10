.<template>
  <li><a class="nav-link menu-title link-nav" :href="Link"><i data-feather="headphones"></i><span>{{ Title }}</span></a></li>
</template>

<script>
export default {
    props: ['Title', 'Link']
}
</script>