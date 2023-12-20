<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import type { categoryInfo } from "./model.ts";
import { categoryService } from "../service";

const router = useRouter();
const route = useRoute();
const id = route.params.id;
<<<<<<< HEAD
console.log(id);
=======
const disabled = ref(true);
>>>>>>> 8ac65db216eccd65c21dd7e020b218375d6889c5
const pageTitle = router.currentRoute.value.meta.title;

onMounted(() => {
  getById();
});

const category = ref<categoryInfo>({
  id: null,
  photo: null,
  name: null,
  description: null,
  isActive: null,
  createdOn: null,
});
const photo = ref({})

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

const edit = async () => {

  const categorySend = reactive<categoryInfo>({
  id: category.value.id,
  photo: photo,
  name: category.value.name,
  description: category.value.description,
  isActive: category.value.isActive,
  createdOn: category.value.createdOn,
});
  const categoryForm = new FormData();

  for (const [key, value] of Object.entries(categorySend)) {
    if (key === "photo") {
      //messionForm.append(`${key}`, value[0] as any);
      continue;
    }
    categoryForm.append(`${key}`, value as any);
  }
  if (categorySend.photo != null) {
    categoryForm.append(`photo`, categorySend.photo[0] as any);
  }

  try {
    const { data } = await categoryService.edit(id, categoryForm);
    //showNotification(data.msg);
    //loading.stop();
    router.go(-1);
  } catch {
    //loading.stop();
  }
};

const downloadImage = async () => {
  window.open(category.value.photo, '_blank');

  
}

const back = () => router.push({ name: "CategoriesList" });
</script>

<template src="./view.html"></template>
