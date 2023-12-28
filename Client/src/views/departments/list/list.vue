<script lang="ts" setup>
import type {
  departmentListItem,
  departmentsListFilter,
  header,
} from "@/views/departments/list/model";
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
  pageSize: 7,
  title: null,
  status: null,
  date: null,
});
const totalPages = ref(5);

const departments = ref<departmentListItem[]>();
const getAll = async () => {
  try {
    //loading.start();

    const { data } = await departmentService.fetch();
    //loading.stop();
    departments.value = data.content;
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

// Add the new code here
const items = ref(Array.from({ length: 50 }, (k, v) => v + 1));

const load = ({ done }: { done: (status: string) => void }) => {
  setTimeout(() => {
    const lastItem = items.value?.[items.value.length - 1] ?? 0;
    items.value.push(...Array.from({ length: 10 }, (_, v) => v + lastItem + 1));
    done("ok");
  }, 1000);
};
</script>

<template src="./list.html"></template>
