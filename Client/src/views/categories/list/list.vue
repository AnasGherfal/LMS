<script lang="ts" setup>
const page = ref(1);
const pp = ref(Array.from({ length: 5 }, (k, v) => ({
  title: ' فئة ' + (v + 1),
  text: 'Lorem ipsum dolor situe cupiditate minima, at placeat tota',
  icon:' mdi-ice-cream'
  
})));
</script>
<template src="./list.html"></template>
