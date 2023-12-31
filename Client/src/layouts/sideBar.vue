<script setup lang="ts">
const router = useRouter();
const links = router.options.routes[0].children;
// const hasAccess = (link: any) => link.meta.roles.includes(identity.user.roleId);

const side = [
  {
    title: "الرخص",
    icon: "mdi mdi-license",
    path: "/licenses",
  },
  {
    title: "المنتجات",
    icon: "mdi mdi-package-variant",
    path: "/products",
  },
  {
    title: "الفئات",
    icon: "mdi mdi-shape",
    path: "/categories",
  },
  {
    title: "الأقسام",
    icon: "mdi mdi-sitemap",
    path: "/departments",
  },
];
</script>

<template>
  <v-navigation-drawer class="sidebar" permanent>
    <v-list-item
      class="sidebar__brand"
      prepend-avatar="/newLogo.png"
      title="نظام إدارة الرخص"
    ></v-list-item>
    <hr class="sidebar__hr" />
    <v-list class="sidebar__nav pa-0">
      <div v-for="(link, i) in links">
        <v-list-item link :key="i" :title="link.meta.title" :to="link.path">
          <template v-slot:prepend>
            <v-icon :icon="link.meta.icon" size="x-small"></v-icon>
          </template>
        </v-list-item>
      </div>
    </v-list>
  </v-navigation-drawer>
</template>
