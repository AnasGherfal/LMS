<script lang="ts" setup>
import type { categoryListItem } from "./model.ts";
import { categoryService } from "../service";

const router = useRouter();
const route = useRoute();
const id = (route.params.id);
console.log(id);
const pageTitle = router.currentRoute.value.meta.title;

onMounted(() => {
    getById();

});

const category = ref<categoryListItem>({
  id: null,
  icon: null,
  name: null,
  description: null,
  isActive: null,
  createdOn: null,
});

const getById = async () => {
  try {
    //loading.start();

    const { data } = await categoryService.fetchById(id);
    //loading.stop();
    category.value = data.content;
  } catch {
    //loading.stop();
  }
};
</script>

<template src="./view.html"></template>
