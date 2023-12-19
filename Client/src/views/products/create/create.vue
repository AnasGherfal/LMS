<template src="./create.html"></template>
<script setup lang="ts">
import type { Product } from "./model";
import { productService } from "../service";
const product = reactive<Product>({
  name: null,
  category: null,
  photo: null,
  numberOfLicenses: null,
});
const router = useRouter();
const pageTitle = router.currentRoute.value.meta.title;

// Method to submit the form and add the new Product
const create = async () => {
  console.log("ff");
  const productForm = new FormData();

  for (const [key, value] of Object.entries(product)) {
    if (key === "photo") {
      //messionForm.append(`${key}`, value[0] as any);
      continue;
    }
    productForm.append(`${key}`, value as any);
  }
  if (product.photo != null) {
    productForm.append(`photo`, product.photo[0] as any);
  }

  try {
    const { data } = await productService.create(productForm);
    //showNotification(data.msg);
    //loading.stop();
    router.go(-1);
  } catch {
    //loading.stop();
  }
};
</script>
