  
  <script lang="ts" setup>
  
  
      const router = useRouter();
      const items = computed(() => (router.currentRoute.value.matched.filter(s => s.name != 'Home').map(a => a.meta)));
      console.log(router.currentRoute.value)
      console.log(items.value)
  
  </script>
<template>
    <v-app-bar app fixed>
            <v-breadcrumbs :items="items">
                <template v-slot:prepend>
                    <v-icon size="small" icon="item.icon"></v-icon>
                </template>
                <template v-slot:title="{ item }">
                    {{ item.title }}
                </template>
            </v-breadcrumbs>
        <v-spacer></v-spacer>
        <v-btn prepend-icon="mdi-logout" variant="text" rounded="1">
  تسجيل خروج
</v-btn>
    </v-app-bar>
</template>
