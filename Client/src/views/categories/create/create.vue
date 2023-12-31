<template src="./create.html"></template>
<script setup lang="ts">

import type { Category } from "./model";
import { categoryService} from '../service'

const rules = computed(() => [
    (v: any) => !!v || 'مطلوب',
]);

const category = reactive<Category>({
    name: null,
    description: null,
    photo:null,
})
const router = useRouter();
const pageTitle = router.currentRoute.value.meta.title;

// Method to submit the form and add the new Category
const create = async () => {
const categoryForm = new FormData();

for (const [key, value] of Object.entries(category)) {
   
        if (key === 'photo') {       
            //messionForm.append(`${key}`, value[0] as any);
            continue;
        }
        categoryForm.append(`${key}`, value as any);
    }
    if (category.photo != null) {
        categoryForm.append(`photo`, category.photo[0] as any)
    }
  
    try {
        router.back();
        const { data } = await categoryService.create(categoryForm);
        // loading.stop();
    } catch {
        //loading.stop();
    }
};
</script>
