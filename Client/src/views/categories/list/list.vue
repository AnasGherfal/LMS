<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import { jsonToQueryString } from "@/utils/handlers";
import type {
  categoryListItem,
  CategoriesListFilter,
  header,
} from "./model.ts";
import { categoryService } from "../service";

const router = useRouter();
const tempId = ref<number | null>();
  const doneDialog = ref<boolean>(false);

onMounted(() => {
  getAll();
});
const pageTitle = router.currentRoute.value.meta.title;

const filter = reactive<CategoriesListFilter>({
  pageNo: 1,
  pageSize: 10,
  title: null,
  status: null,
  date: null,
});
const totalPages = ref(5);

const categories = ref<categoryListItem[]>([]);
const getAll = async (pageNo?: number) => {
  try {
    //loading.start();

    filter.pageNo = pageNo ?? filter.pageNo;
    const queryString = jsonToQueryString(filter);
    const { data } = await categoryService.fetch(queryString);
    //loading.stop();
    categories.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    //loading.stop();
  }
};

const headers = ref<header[]>([
  // { title: "#", key: "id" },
  { title: "الاسم", key: "name" },
  // { title: "تاريخ الإنشاء", key: "createdOn" },
  { title: "عدد الفئات", key: "numberOfCategories" },
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
        }
        catch {
          console.error()
        }
    };
</script>

<template src="./list.html"></template>
