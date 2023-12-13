    <script lang="ts" setup>
        const alertBox = useAlertStore();
    </script>
<template>
    <v-alert closable
             :value="alertBox.$state.show"
             variant="outlined"   
             location="left bottom"
             type="warning"
             :text="alertBox.$state.message"
             position="absolute"
             border="left">
    </v-alert>

</template>
