    <script lang="ts" setup>
      import appBar from './appBar.vue'
      import sideBar from './sideBar.vue'
    </script>
<template>
    <v-layout class="bg-grey">
        <sideBar />
        <appBar class="px-8" />
        <v-main class="d-flex flex-1-1 align-start justify-start ma-4 mx-8" style="min-height: 300px;">
            <v-row>
                <v-col>
                    <router-view />
                </v-col>
            </v-row>
        </v-main>
    </v-layout>
</template>

