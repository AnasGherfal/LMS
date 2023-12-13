<template src="./list.html"></template>

<script lang="ts" setup>
    import type { MissionListItem, MissionsListFilter, header, status } from "./model.ts";
    import { missionStatusLookup } from "./model.ts";
    import { jsonToQueryString, noteTruncate } from "@/utils/handlers";
    import { messionsService } from '../service'
    const identity = useIdentityStore();

    const router = useRouter();
    const lookups = useLookupStore();
    const doneDialog = ref<boolean>(false);
    const tempId = ref<number | null>();

    onMounted(() => {
        lookups.getEntities();
        getAll();
    });

    const pageTitle = router.currentRoute.value.meta.title;
    const filter = reactive<MissionsListFilter>({
        pageNo: 1,
        pageSize: 10,
        title: null,
        entityId: null,
        status: null,
        date: null,
    });
    const totalPages = ref(10);
    const messions = ref<MissionListItem[]>([]);


    const getAll = async (pageNo?: number) => {
        try {
            //loading.start();
           
            filter.pageNo = pageNo ?? filter.pageNo;
            console.log(filter.entityId);
            const queryString = jsonToQueryString(filter);
            const { data } = await messionsService.fetch(queryString);
            //loading.stop();
            messions.value = data.content;
            totalPages.value = data.totalPages;
        } catch {
            //loading.stop();
        }
    };

    const create = () => router.push({ name: "CreateMession" });

    const view = (id: number) => {
        router.push({ name: "Mession", params: { id } })
    };

    const headers = ref<header[]>([
        { title: '#', key: 'id' },
        { title: 'الموضوع', key: 'title' },
        { title: 'الجهة المكلفة', key: 'entity' },
        { title: 'تاريخ اصدار المهمة', key: 'date' },
        { title: 'منشأ بواسطة', key: 'createdBy' },
        { title: 'تاريخ الإنشاء', key: 'createdOn' },
        { title: 'الحالة', key: 'status' },
        { title: 'الإجراءات', key: 'actions' },
    ]);

    const done = async () => {
        try {
            const { data } = await messionsService.done(tempId.value!);
            getAll();
            canceleDialog();
        }
        catch {
        }
    };

    const showDialog = (val: number) => {
        tempId.value = val;
        doneDialog.value = true;
    }
    const canceleDialog = () => {
        doneDialog.value = false;
        tempId.value = null;
    };
 
</script>