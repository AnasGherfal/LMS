<script lang="ts" setup>
import type { productListItem } from "./model.ts";
import { productService } from "../service";

const router = useRouter();
const route = useRoute();
const id = route.params.id;
console.log(id);
const pageTitle = router.currentRoute.value.meta.title;

onMounted(() => {
  getById();
});

const product = ref<productListItem>({
  id: null,
  icon: null,
  name: null,
  category: null,
  numberOfLicense: null,
  isActive: null,
  createdOn: null,
});

const getById = async () => {
  try {
    //loading.start();

    const { data } = await productService.fetchById(id);
    //loading.stop();
    product.value = data.content;
  } catch {
    //loading.stop();
  }
};
</script>

<template src="./view.html"></template>
