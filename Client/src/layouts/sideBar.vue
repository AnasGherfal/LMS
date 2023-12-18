<script setup lang="ts">
    const router = useRouter();
    const links = router.options.routes[0].children;
    // const hasAccess = (link: any) => link.meta.roles.includes(identity.user.roleId);

    const side = [{
      title: "القائمة الرئيسية",
      icon: "",
      path:"/"
    },
    {
      title: "الرخص",
      icon: "",
      path:"/licenses"
    },
    {
      title: "المنتجات",
      icon: "",
      path:"/products"
    },
    {
      title: "الفئات",
      icon: "",
      path:"/categories"
    },
    {
      title: "الأقسام",
      icon: "",
      path:"/departments"
    },
    
    ]
</script>

<template>
    <v-navigation-drawer  class="sidebar"  width="300" permanent>
      <v-list-item class="sidebar__brand" prepend-avatar="/ltt.jpg" title="نظام إدارة الرخص"></v-list-item>
      <hr class="sidebar__hr" />
      <v-list class="sidebar__nav pa-0">
</v-list>
<div v-for="item in side" :key="item.title">

  <v-list-item :title="item.title" :to="item.path">
    
  </v-list-item>
</div>

  
    </v-navigation-drawer>
</template>