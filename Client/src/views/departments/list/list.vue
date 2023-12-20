<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import { jsonToQueryString } from "@/utils/handlers";
import type {
  departmentListItem,
  departmentsListFilter,
  header,
} from "./model.ts";
import { departmentService } from "../service";

const router = useRouter();
const tempId = ref<number | null>();
const doneDialog = ref<boolean>(false);

onMounted(() => {
  getAll();
});
const pageTitle = router.currentRoute.value.meta.title;

const filter = reactive<departmentsListFilter>({
  pageNo: 1,
  pageSize: 400,
  title: null,
  status: null,
  date: null,
});
const totalPages = ref(5);

const departments = ref<departmentListItem[]>([]);
const getAll = async (pageNo?: number) => {
  try {
    //loading.start();

    filter.pageNo = pageNo ?? filter.pageNo;
    const queryString = jsonToQueryString(filter);
    const { data } = await departmentService.fetch(queryString);
    //loading.stop();
    departments.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    //loading.stop();
  }
};

const headers = ref<header[]>([
  // { title: "#", key: "id" },
  { title: "رقم التعريف", key: "id" },
  { title: "إسم القسم", key: "name" },

  // { title: "تاريخ الإنشاء", key: "createdOn" },
  { title: "الحالة", key: "isActive" },
]);

// Method to navigate to the create category page
const create = () => {
  router.push({ name: "CreateDepartments" });
};
const view = (id: number) => {
  router.push({ name: "Department", params: { id } });
};

const showDialog = (val: number) => {
  tempId.value = val;
  doneDialog.value = true;
};
const canceleDialog = () => {
  doneDialog.value = false;
  tempId.value = null;
};

// const deleteDepartment = async () => {
//   try {
//     const { data } = await departmentService.deleteCategory(tempId.value!);
//     getAll();
//     canceleDialog();
//   } catch {
//     console.error();
//   }
// };
</script>

<template src="./list.html"></template>
