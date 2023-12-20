<script lang="ts" setup>
import type { licenseInfo } from "./model.ts";
import { licenseService } from "../service";

const router = useRouter();
const route = useRoute();
const id = (route.params.id);
const pageTitle = router.currentRoute.value.meta.title;

onMounted(() => {
    getById();

});

const license = ref<licenseInfo>({
  id :  null,
  productName: null,
  departmentName: null,
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
    isActive : null,
    createdOn : null,
});

const getById = async () => {
  try {
    //loading.start();

    const { data } = await licenseService.fetchById(id);
    //loading.stop();
    license.value = data.content;
  } catch {
    //loading.stop();
  }
};

const back = () => router.push({ name: "LicensesList" });

</script>

<template src="./view.html"></template>
