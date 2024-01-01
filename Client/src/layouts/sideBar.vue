<script setup lang="ts">
const router = useRouter();
const links = router.options.routes[0].children;
// const hasAccess = (link: any) => link.meta.roles.includes(identity.user.roleId);


</script>

<template>
  <v-navigation-drawer class="sidebar" permanent>
    <v-list-item class="  sidebar__brand">
      <img src="/whitelogo.png" />
    </v-list-item>
    <h3 class="text-center mb-4">نظام إدارة التراخيص</h3>
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
