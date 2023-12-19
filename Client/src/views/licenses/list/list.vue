<!-- eslint-disable @typescript-eslint/no-unused-vars -->
<script lang="ts" setup>
import { jsonToQueryString } from "@/utils/handlers";
import type {
    licenseListItem,
    licenseListFilter,
    header,
} from "./model.ts";
import { licenseService } from "../service";

const router = useRouter();
const tempId = ref<number | null>();
  const doneDialog = ref<boolean>(false);

onMounted(() => {
  getAll();
});
const pageTitle = router.currentRoute.value.meta.title;

const filter = reactive<licenseListFilter>({
  pageNo: 1,
  pageSize: 10,
  DepartmentId: null,
  ProductId: null,
});
const totalPages = ref(5);

const licenses = ref<licenseListItem[]>([]);
const getAll = async (pageNo?: number) => {
  try {
    //loading.start();

    filter.pageNo = pageNo ?? filter.pageNo;
    const queryString = jsonToQueryString(filter);
    const { data } = await licenseService.fetch(queryString);
    //loading.stop();
    licenses.value = data.content;
    totalPages.value = data.totalPages;
  } catch {
    //loading.stop();
  }
};

const headers = ref<header[]>([
  // { title: "#", key: "id" },
  { title: "اسم المنتج", key: "productName" },
  { title: "اسم الديبارتمنت", key: "departmentName" },

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
