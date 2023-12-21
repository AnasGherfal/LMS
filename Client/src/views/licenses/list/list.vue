<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import { jsonToQueryString } from "@/utils/handlers";
import type { licenseListItem, licenseListFilter, header } from "./model.ts";
import { licenseService } from "../service";
import { productService } from "@/views/products/service";
import { departmentService } from "@/views/departments/service";

const router = useRouter();
const tempId = ref<number | null>();
const doneDialog = ref<boolean>(false);
const pageTitle = router.currentRoute.value.meta.title;
const products = ref([]);
const departments = ref<[]>([]);
onMounted(() => {
  getAll();
  getDepartments();
  getProducts();
});

const filter = reactive<licenseListFilter>({
  pageNo: 1,
  pageSize: 10,
  DepartmentId: null,
  ProductId: null,
});
const totalPages = ref(5);

const getProducts = async (pageNo?: number) => {
  try {
    //loading.start();

    filter.pageNo = pageNo ?? filter.pageNo;
    const queryString = jsonToQueryString(filter);
    const { data } = await productService.fetch(queryString);
    //loading.stop();
    products.value = data.content;
  } catch {
    //loading.stop();
  }
};

const getDepartments = async () => {
  try {
    //loading.start();

    const { data } = await departmentService.fetch();
    //loading.stop();
    departments.value = data.content;
  } catch {
    //loading.stop();
  }
};



const licenses = ref<licenseListItem[]>([]);
const getAll = async (pageNo?: number, pageSize?: number, productId?:string, departmentId?: string) => {
  try {
    const { data } = await licenseService.fetch(pageNo, pageSize, productId, departmentId);
    //loading.stop();
    licenses.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    //loading.stop();
  }
};

const headers = ref<header[]>([
  // { title: "#", key: "id" },
  { title: " المنتج", key: "productName" },
  { title: "القسم", key: "departmentName" },

  { title: "تواصل", key: "contact" },
  { title: "مستوى الخطوره", key: "impactLevel" },
  { title: "تاريخ بداية الترخيص", key: "startDate" },
  { title: "تاريخ نهاية الترخيص", key: "expireDate" },
  { title: "الحالة", key: "isActive" },
  //   { title: "تاريخ الانشاء", key: "createdOn" },

  { title: "الإجراءات", key: "actions" },
]);

// Method to navigate to the create category page
const create = () => {
  router.push({ name: "CreateLicense" });
};
const view = (id: number) => {
  router.push({ name: "License", params: { id } });
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
    const { data } = await licenseService.deletelicense(tempId.value!);
    getAll();
    canceleDialog();
  } catch {
    console.error();
  }
};
</script>

<template src="./list.html"></template>
