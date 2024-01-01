<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import { jsonToQueryString } from "@/utils/handlers";
import type { licenseListItem, licenseListFilter, header } from "./model.ts";
import { licenseService } from "../service";
import { productService } from "@/views/products/service";
import { departmentService } from "@/views/departments/service";
import type { departmentListItem } from "@/views/departments/list/model";
import type { productListItem } from "@/views/products/list/model";
import { formatDate } from "@/utils/timeFormat";

const router = useRouter();
const tempId = ref<number | null>();
const doneDialog = ref<boolean>(false);
const pageTitle = router.currentRoute.value.meta.title;
const products = ref<productListItem>();
const departments = ref<departmentListItem[]>();
const store = useLookupStore();
onMounted(() => {
  getAll();
  getDepartments();
  getProducts();
  store.getImpactLevel();
  // getDepartmentNameById(55);
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
    const { data } = await productService.fetch();
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
const getDepartmentNameById = (departmentId: number | null) => {
  const department = departments.value?.find((dep) => dep.id === departmentId);

  return department ? department.name : "";
};

const getImpactLevel = (impactLevelId: number | null) => {
  const impactLevel = store.impactLevelLookup.find(
    (dep) => dep.id === impactLevelId
  );

  return impactLevel ? impactLevel.name : "";
};

const licenses = ref<licenseListItem[]>([]);
const getAll = async (
  pageNo?: number,
  pageSize?: number,
  productId?: string,
  departmentId?: string
) => {
  try {
    const { data } = await licenseService.fetch(
      pageNo,
      pageSize,
      productId,
      departmentId
    );
    //loading.stop();
    licenses.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    //loading.stop();
  }
};

watch(
  [() => filter.pageNo, () => filter.DepartmentId, () => filter.ProductId],
  ([pageNo, department, product]) => {
    const pageNumber: number = pageNo !== null ? Number(pageNo) : 0; // Using 0 as default if it's null
    const departmentId: string | undefined =
      department !== null ? department : undefined;
    const productId: string | undefined =
      product !== null ? product : undefined;
    getAll(pageNumber, filter.pageSize, productId, departmentId);
  }
);

const headers = ref<header[]>([
  // { title: "#", key: "id" },
  { title: " المنتج", key: "productName" , width: '10%'},
  { title: "القسم", key: "departmentId" , width: '20%'},

  // { title: "تواصل", key: "contact" , width: '5%'},
  { title: "مستوى الخطوره", key: "impactLevel", width: '10%' },
  { title: "تاريخ بداية الترخيص", key: "startDate", width: '10%' },
  { title: "تاريخ نهاية الترخيص", key: "expireDate", width: '10%' },
  { title: "الحالة", key: "isActive", width: '5%' },
  //   { title: "تاريخ الانشاء", key: "createdOn" },

  { title: "الإجراءات", key: "actions" , width: '30%' },
]);

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

const deleteLicense = async () => {
  try {
    const { data } = await licenseService.deletelicense(tempId.value!);
    getAll();
    canceleDialog();
  } catch {
    console.error();
  }
};

const toggleLock = async (licenseId: number, newLockState: boolean) => {
  try {
    const endpoint = newLockState ? "lock" : "unlock";
    await licenseService.toggleLock(licenseId, endpoint);
    getAll();
    console.log(newLockState);
  } catch (error) {
    console.error(error);
  }
};
</script>

<template src="./list.html"></template>
