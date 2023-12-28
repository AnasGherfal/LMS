<script lang="ts" setup>
import { jsonToQueryString } from "@/utils/handlers";
import type { productListItem, ProductsListFilter, header } from "./model.ts";
import { productService } from "../service";

const router = useRouter();
const tempId = ref<number | null>();
const doneDialog = ref<boolean>(false);

onMounted(() => {
  getAll();
});
const pageTitle = router.currentRoute.value.meta.title;

const filter = reactive<ProductsListFilter>({
  pageNo: 1,
  pageSize: 10,
  name: null,
});
const totalPages = ref(5);

const products = ref<productListItem>();
const getAll = async (pageNo?: number, pageSize?: number, name?: string) => {
  try {
    const { data } = await productService.fetch(pageNo, pageSize, name);
    products.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    console.error();
  }
};

const headers = ref<header[]>([
  { title: "#", key: "photo" },
  { title: "الاسم", key: "name" },
  { title: " الفئة", key: "category" },
  { title: " عدد الرخص", key: "numberOfLicenses" },
  { title: "الحالة", key: "isActive" },
  { title: "الإجراءات", key: "actions" },
]);

watch(
  [() => filter.pageNo, () => filter.name],
  ([newPageNo, newName], [oldPageNo, oldName]) => {
    const name = newName !== null ? newName : filter.name ?? "";
    getAll(newPageNo, filter.pageSize, name);
  }
);

// Method to navigate to the create product page
const create = () => {
  router.push({ name: "CreateProducts" });
};
const view = (id: number) => {
  router.push({ name: "Product", params: { id } });
};

const showDialog = (val: number) => {
  tempId.value = val;
  doneDialog.value = true;
};
const canceleDialog = () => {
  doneDialog.value = false;
  tempId.value = null;
};

const deleteProduct = async () => {
  try {
    const { data } = await productService.deleteProduct(tempId.value!);
    getAll();
    canceleDialog();
  } catch {
    console.error();
  }
};

// Add these methods
const toggleLock = async (productId: number, newLockState: boolean) => {
  try {
    const endpoint = newLockState ? "lock" : "unlock";
    await productService.toggleLock(productId, endpoint);
    getAll();
    console.log(newLockState);
  } catch (error) {
    console.error(error);
  }
};
</script>

<template src="./list.html"></template>
