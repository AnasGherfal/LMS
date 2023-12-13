<script lang="ts" setup>
    import { type Mission, type Header } from "./model";
    import { messionsService } from '../service'
    import { noteTruncate } from "@/utils/handlers";

    const identity = useIdentityStore();
    const lookup = useLookupStore();
    const router = useRouter();
    const route = useRoute();
    const pageTitle = router.currentRoute.value.meta.title;
    const id = parseInt(route.params.id as string);


    const updateDialog = ref<boolean>(false);
    const commentDialog = ref<boolean>(false);
    const content = ref<string | null>(null);


    onMounted(() => {
        lookup.getEntities();
        getById();
    });


    const rules = computed(() => [
        (v: any) => !!v || 'Name is required',
        (v: any) => (v && v.length <= 10) || 'Name must be less than 10 characters',
    ]);

    const mission = ref<Mission>({
        title: null,
        content: null,
        date: null,
        expectedEndDate: null,
        remarks: null,
        entitieName: null,
        entities: [],
        comments: [],
        updates: [],
        file: null,
    });

    const getById = async () => {
        try {
            //loading.start();

            const { data } = await messionsService.fetchById(id);
            //loading.stop();
            mission.value = data.content;
            mission.value.updates = data.content.updates
        } catch {
            //loading.stop();
        }
    };

    const createUpdate = async () => {{
        try {
            //loading.start();
            let body = {
                id: id,
                content: content.value
            }
            await messionsService.createUpdate(id, body);
            //loading.stop();
            canceleDialog();
            getById();
        } catch {
            //loading.stop();
        }
    }}


    const createComment = async () => {{
        try {
            //loading.start();
            let body = {
                id: id,
                content: content.value
            }
            await messionsService.createComment(id, body);
            //loading.stop();
            canceleDialog();
            getById();
        } catch {
            //loading.stop();
        }
    }}

    const canceleDialog = () => {
        updateDialog.value = false;
        commentDialog.value = false;
        content.value = null;
    };
    const updatesHeaders = ref<Header[]>([
        { title: 'التحديث', key: 'content' },
        { title: 'منشأ بواسطة', key: 'createdBy' },
        { title: 'تاريخ التحديث', key: 'createdOn' },
    ]);

    const commentsHeaders = ref<Header[]>([
        { title: 'الملاحظات', key: 'content' },
        { title: 'منشأ بواسطة', key: 'createdBy' },
        { title: 'تاريخ الملاحظة', key: 'createdOn' },
    ]);


    const viewFile = async () => {
        try {
            
            const res = await messionsService.fetchFileById(id);
            console.log(res)
            const url = window.URL.createObjectURL(new Blob([res.data], { type: res.headers["Content-Type"] }))
            const link = document.createElement('a')
            link.href = url
            const filename = res.headers['content-disposition'].split('=')[1].split(';')[0].replace(/(^"|"$)/g, '')
            link.setAttribute('download', filename)
            document.body.appendChild(link)
            link.click();
            link.remove();
        } catch {
            //loading.stop();
        }
  
    }
</script>

<template src="./view.html">
</template>
