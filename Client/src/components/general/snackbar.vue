<script setup lang="ts">
    const snack = useSnackbarStore();
    console.log(snack)
</script>
<template>
    <v-snackbar v-model="snack.$state.show"
                location="left bottom"
                :color="snack.$state.type"
                variant="outlined"
                multiLine>
        <v-icon :color="snack.$state.type">{{snack.$state.icon}}</v-icon>
        
    <v-icon size="small" color="snack.$state.type">snack.$state.icon</v-icon>
    <span>{{ snack.$state.message }}</span>
        <template v-slot:action="{ attrs }">
            <v-btn :color="snack.$state.type"
                   text
                   v-bind="attrs"
                   @click="show = false"
                   icon>
                <v-icon>mdi-close</v-icon>
            </v-btn>
        </template>
    </v-snackbar>
</template>
