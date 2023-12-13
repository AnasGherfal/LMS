<script lang="ts" setup>

    const loading = useLoadingStore();
    console.log(loading.$state.loading)
</script>
<template>
    <v-overlay :value="loading.$state.loading" class="loading-overlay">
        <v-progress-circular indeterminate
                             size="64"
                             color="primary"></v-progress-circular>
    </v-overlay>
</template>


<style lang="scss">
    .overlay {
        z-index: 1000;
        position: fixed;
        background: rgba(72, 72, 72, 0.1);
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
    }

    .loader {
        z-index: 9999;
        position: fixed;
        top: 45%;
        left: 45%;
        width: 64px;
        height: 64px;
        background-image: linear-gradient(#fff 24px, transparent 0), linear-gradient(var(--clr-primary) 24px, transparent 0), linear-gradient(var(--clr-primary) 24px, transparent 0), linear-gradient(#fff 24px, transparent 0);
        background-repeat: no-repeat;
        background-size: 24px 24px;
        background-position: left top, left bottom, right top, right bottom;
        animation: rotate 1s linear infinite;
    }

    @keyframes rotate {
        0% {
            width: 64px;
            height: 64px;
            transform: rotate(0deg);
        }

        50% {
            width: 30px;
            height: 30px;
            transform: rotate(180deg);
        }

        100% {
            width: 64px;
            height: 64px;
            transform: rotate(360deg);
        }
    }
</style>