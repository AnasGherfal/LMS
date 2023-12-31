<script setup lang="ts">
    const snack = useSnackbarStore();
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
 
    </v-snackbar>
</template>
