<!-- eslint-disable @typescript-eslint/no-unused-vars -->

<script setup lang="ts">
import type { License } from "./model";
import { licenseService } from "../service";
import { jsonToQueryString } from "@/utils/handlers";
import { productService } from "@/views/products/service";
import { departmentService } from "@/views/departments/service";
import type { productListItem } from "@/views/products/list/model";
import type { departmentListItem } from "@/views/departments/list/model";

const router = useRouter();
const products = ref<productListItem>();
  const departments = ref<departmentListItem[]>([]);
const departmentOwner = ref();
const store = useLookupStore();
const loading = useLoadingStore();
const rules = computed(() => [
    (v: any) => !!v || 'مطلوب',
]);

const license = reactive<License>({
  productId: null,
  departmentId: null,
  numOfDevices: null,
  serialKey: null,
  impactLevel: null,
  impactDescription: null,
  startDate: null,
  expireDate: null,
  contact: null,
  timeType: null,
  priceInUSD: null,
  priceInLYD: null,
  productType: null,
  endOfSale: null, 
  endOfManufacture: null,
  endOfSupport: null,

});


const filter = reactive({
  pageNo: 1,
  pageSize: 10,
  title: null,
  status: null,
  date: null,
});

onMounted(() => {
  getProducts();
  getDepartments();
  store.getLicenseTypes();
  store.getImpactLevel();
  store.getProdcutsTypes();

});

const pageTitle = router.currentRoute.value.meta.title;

const getProducts = async (
  pageNo?: number,
  pageSize?: number,
  name?: string
) => {
  try {
    const { data } = await productService.fetch(pageNo, pageSize, name);
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

const create = async () => {
  const licenseForm = new FormData();
  loading.start();
  for (const [key, value] of Object.entries(license)) {
    if (key === "endOfSupport" || key === "endOfManufacture" || key === "endOfSale") {
      if (value === null) {
        license[key] = "";
      }
    }
  }
  for (const [key, value] of Object.entries(license)) {
    licenseForm.append(`${key}`, value as any);
  }

  try {
    const { data } = await licenseService.create(licenseForm);
    router.back();
    router.push({ name: "LicensesList" });
    loading.stop();
  } catch {
    //loading.stop();
  }
};
</script>
<template src="./create.html"></template>
