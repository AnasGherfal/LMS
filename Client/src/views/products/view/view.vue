<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import type { productInfo } from "./model.ts";
import { productService } from "../service";

const router = useRouter();
const route = useRoute();
const id = route.params.id;
const disabled = ref(true);
const pageTitle = router.currentRoute.value.meta.title;

onMounted(() => {
  getById();
});

const product = ref<productInfo>({
  id: null,
  photo: null,
  name: null,
  category: null,
  numberOfLicense: null,
  isActive: null,
  createdOn: null,
});
const photo = ref({});

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

const edit = async () => {
  const productSend = reactive<productInfo>({
    id: product.value.id,
    photo: photo,
    name: product.value.name,
    category: product.value.category,
    numberOfLicense: product.value.numberOfLicense,
    isActive: product.value.isActive,
    createdOn: product.value.createdOn,
  });
  const productForm = new FormData();

  for (const [key, value] of Object.entries(productSend)) {
    if (key === "photo") {
      //messionForm.append(`${key}`, value[0] as any);
      continue;
    }
    productForm.append(`${key}`, value as any);
  }
  if (productSend.photo != null) {
    productForm.append(`photo`, productSend.photo[0] as any);
  }

  try {
    const { data } = await productService.edit(id, productForm);
    //showNotification(data.msg);
    //loading.stop();
    router.go(-1);
  } catch {
    //loading.stop();
  }
};

const downloadImage = async () => {
  window.open(product.value.photo, "_blank");
};

const back = () => router.push({ name: "ProductList" });
</script>

<template src="./view.html"></template>
