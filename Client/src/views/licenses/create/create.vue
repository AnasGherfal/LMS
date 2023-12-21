<!-- eslint-disable @typescript-eslint/no-unused-vars -->

<script setup lang="ts">
import type { License } from "./model";
import { licenseService } from "../service";
import { jsonToQueryString } from "@/utils/handlers";
import { productService } from "@/views/products/service";
import { departmentService } from "@/views/departments/service";

const router = useRouter();
const products = ref([]);
const departments = ref<[]>([]);
const departmentOwner = ref();
const license = reactive<License>({
  ProductId: null,
  DepartmentId: null,
  NumOfDevices: null,
  SerialKey: null,
  ImpactLevel: null,
  ImpactDescription: null,
  StartDate: null,
  ExpireDate: null,
  Contact: null,
  TimeType: null,
  PriceInUSD: null,
  PriceInLYD: null,
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
});

const pageTitle = router.currentRoute.value.meta.title;

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



const create = async () => {
  const licenseForm = new FormData();

  for (const [key, value] of Object.entries(license)) {
    licenseForm.append(`${key}`, value as any);
  }

  try {
    const { data } = await licenseService.create(licenseForm);
    //showNotification(data.msg);
    //loading.stop();
    router.go(-1);
  } catch {
    //loading.stop();
  }
};
</script>
<template src="./create.html"></template>
