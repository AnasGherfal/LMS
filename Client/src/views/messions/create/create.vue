<script lang="ts" setup>
import { type Mission } from "./model";
import { messionsService } from '../service'

const lookup = useLookupStore();
const router = useRouter();
const pageTitle = router.currentRoute.value.meta.title;


lookup.getEntities();

const rules = computed(() => [
    (v: any) => !!v || 'required',
]);

const mession = reactive<Mission>({
    title: null,
    content: null,
    date: null,
    expectedEndDate: null,
    remarks: null,
    entities: [],
    file: null,
});

const create = async () => {

    const messionForm = new FormData();
    for (const [key, value] of Object.entries(mession)) {
        if (key === 'entities') {
            continue;
        }
        if (key === 'file') {       
            //messionForm.append(`${key}`, value[0] as any);
            continue;
        }
        messionForm.append(`${key}`, value as any);
    }
    if (mession.file != null) {
        messionForm.append(`file`, mession.file[0] as any)
    }
    if (mession.entities.length > 0) {
        for (var i = 0; i < mession.entities.length; i++) {
            messionForm.append(`entities[${i}]`, mession.entities[i] as any);
        }
    }
    try {
        const { data } = await messionsService.create(messionForm);;
        //showNotification(data.msg);
        //loading.stop();
        router.go(-1);
    } catch {
        //loading.stop();
    }
};
const fileChange = () => {

    console.log("x")
}
</script>

<template src="./create.html"></template>
