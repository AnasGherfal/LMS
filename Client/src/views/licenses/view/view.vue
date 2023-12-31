<script lang="ts" setup>
import type { licenseInfo } from "./model.ts";
import { licenseService } from "../service";
import {formatDate} from "@/utils/timeFormat"
import type { departmentListItem } from "@/views/departments/list/model";
import { departmentService } from "@/views/departments/service";

const router = useRouter();
const route = useRoute();
const id = route.params.id;
const pageTitle = router.currentRoute.value.meta.title;
const store = useLookupStore();

onMounted(() => {
  getById();
  getDepartments();
store.getLicenseTypes()
store.getImpactLevel()

});
const departments = ref<departmentListItem[]>();

const license = ref<licenseInfo>({
  id: null,
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
  isActive: null,
  createdOn: null,
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

const getLicenseTypes = (licenseTypeId: number | null) => {
  const licenseType = store.licenseTypesLookup.find(
    (dep) => dep.id === licenseTypeId
  );

  return licenseType ? licenseType.name : "";
};
const back = () => router.push({ name: "LicensesList" });
</script>

<template src="./view.html"></template>
