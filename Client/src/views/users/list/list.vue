<template src="./list.html">
</template>

<script lang="ts" setup>
    import type { UserListItem, UserListFilter, Header, Status } from "./model.ts";
    import { userService } from "../service";
    import {
        jsonToQueryString
    } from "@/utils/handlers";
        const identity = useIdentityStore();

    const router = useRouter();
    const pageTitle = router.currentRoute.value.meta.title;
    const snack = useSnackbarStore();

    const pagesCount = ref<number>(0);
    const filter = reactive<UserListFilter>({
        pageNo: 1,
        pageSize: 10,
        empName: '',
        status: -1,
    });
    onMounted(() => {
        getAll();
    });

    const items = ref<UserListItem[]>();
    const getAll = async (pageNo?: number) => {
        try {
            //snack.showSnack("hello", "mdi-eye-outlined", "success");
            filter.pageNo = pageNo ?? filter.pageNo;

            const queryString = jsonToQueryString(filter);
            const { data } = await userService.fetch(queryString);

            items.value = data.content;
            pagesCount.value = data.totalPages;

        } catch {
        }
    };

    const headers = ref<Header[]>([
        { title: 'اسم المستخدم', key: 'fullName' },
        { title: 'الكيان الإداري', key: 'entity' },
        { title: 'نوع المستخدم', key: 'role' },
        { title: 'القائم بالتسجيل', key: 'createdBy' },
        { title: 'تاريخ التسجيل', key: 'createdOn' },
        { title: 'الحالة', key: 'status' },
        { title: 'الإجراءات', key: 'actions' },
    ]);

    const statusList = ref<Status[]>([
        { value: -1, text: 'الكل' },
        { value: 1, text: 'مفعل' },
        { value: 2, text: 'مجمد' },
    ]);

    const create = () => router.push({ name: "CreateUser" });

    const view = (id: number) => router.push({ name: "User", params: { id: id } });


    const tempId = ref<number | null>();
    const deleteDialog = ref<boolean>(false);

    const showDialog = (val: number) => {
        tempId.value = val;
        deleteDialog.value = true;
    }
    const canceleDialog = () => {
        deleteDialog.value = false;
        tempId.value = null;
    };

    const deleteUser = async () => {
        try {
            const { data } = await userService.deleteUser(tempId.value!);
            getAll();
            canceleDialog();
        }
        catch {
        }
    };


</script>