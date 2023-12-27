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
  <v-navigation-drawer class="sidebar" permanent color="#016CE0">
    <v-list-item
      class="sidebar__brand"
      prepend-avatar="/newLogo.png"
      title="نظام إدارة الرخص"
    ></v-list-item>
    <hr class="sidebar__hr" />
    <v-list class="sidebar__nav pa-0"> </v-list>
    <div v-for="item in side" :key="item.title">
      <v-list-item :title="item.title" :to="item.path">
        <template v-slot:prepend>
          <v-icon :icon="item.icon" size="small" color="#E08B00"></v-icon>
        </template>
      </v-list-item>
    </div>
  </v-navigation-drawer>
</template>
