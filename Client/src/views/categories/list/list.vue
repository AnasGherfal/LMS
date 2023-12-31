<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import type {
  categoryListItem,
  CategoriesListFilter,
  header,
} from "./model.ts";
import { categoryService } from "../service";

const router = useRouter();
const tempId = ref<number | null>();
const doneDialog = ref<boolean>(false);
const search = ref();
const pageTitle = router.currentRoute.value.meta.title;

onMounted(() => {
  getAll();
});

const filter = reactive<CategoriesListFilter>({
  pageNo: 1,
  pageSize: 5,
  name: null,
});
const totalPages = ref(5);

const categories = ref<categoryListItem[]>([]);
const getAll = async (pageNo?: number, pageSize?: number, name?: string) => {
  try {

    const { data } = await categoryService.fetch(pageNo, pageSize, name);
    // loading.stop();
    categories.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    //loading.stop();
  }
};

watch(
  [() => filter.pageNo, () => filter.name],
  ([newPageNo, newName]) => {
    const name = newName !== null ? newName : filter.name ?? "";
    getAll(newPageNo, filter.pageSize, name);
  }
);

const headers = ref<header[]>([
  { title: "#", key: "photo" },
  { title: "الاسم", key: "name" },
  // { title: "تاريخ الإنشاء", key: "createdOn" },
  { title: "عدد المنتجات", key: "numberOfProducts" },
  { title: "الحالة", key: "isActive" },

  { title: "الإجراءات", key: "actions" },
]);

// Method to navigate to the create category page
const create = () => {
  router.push({ name: "CreateCategories" });
};
const view = (id: number) => {
  router.push({ name: "Category", params: { id } });
};

const showDialog = (val: number) => {
  tempId.value = val;
  doneDialog.value = true;
};
const canceleDialog = () => {
  doneDialog.value = false;
  tempId.value = null;
};

const deleteCategory = async () => {
  try {
    const { data } = await categoryService.deleteCategory(tempId.value!);
    getAll();
    canceleDialog();
  } catch {
    console.error();
  }
};
const toggleLock = async (categoryId: number, newLockState: boolean) => {
  try {
    const endpoint = newLockState ? "lock" : "unlock";
    await categoryService.toggleLock(categoryId, endpoint);
    getAll();
  } catch (error) {
    console.error(error);
  }
};
</script>

<template src="./list.html"></template>
