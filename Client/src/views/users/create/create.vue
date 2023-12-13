<template src="./create.html">
</template>

<script lang="ts" setup>
    import { type User, type EmpItem, } from "./model";
    import { userService } from "../service";
    const router = useRouter();
    const pageTitle = router.currentRoute.value.meta.title;
    const snack = useSnackbarStore();
    const lookup = useLookupStore();
    onMounted(() => {
        lookup.getRoles();
        getEmpList();
    });
    const emp = ref<EmpItem>({
        empId: null,
        userId: null,
        fullName: null
    });

    const rules = computed(() => [
        (v: any) => !!v || 'Name is required',
        //    (v: any) => (v && v.length <= 10) || 'Name must be less than 10 characters',
    ]);

    let user = ref<User>({
        "userId": 0,
        "empId": 0,
        "empCode": "",
        "userName": "",
        "fullName": "",
        "jobDesc": "",
        "entity": "",
        "entityId": 0,
        "actJobDesc": "",
        "actEntity": "",
        "actEntityId": 0,
        "roleId": 1
    });

    const empLists = ref<EmpItem[]>();
    const getEmpList = async () => {
        try {
            const { data } = await userService.fetchEmpList();

            empLists.value = data;
        } catch {
        }
    };

    const onEmpSelect = async () => {

            if (emp.value.empId == null) {
                console.log(emp.value)
                return;
            }
            const { data } = await userService.fetchEmpInfo(emp.value.empId);

            user.value.userId = emp.value.userId;
            user.value.userName = data.content.userName;
            user.value.empId = data.content.empId;
            user.value.empCode = data.content.empCode;
            user.value.fullName = data.content.fullName;
            user.value.jobDesc = data.content.jobDesc;
            user.value.entity = data.content.entity;
            user.value.entityId = data.content.entityId;
            user.value.actJobDesc = data.content.actJobDesc;
            user.value.actEntity = data.content.actEntity;
            user.value.actEntityId = data.content.actEntityId;

    };

    const submit = async () => {
            userService.create(user.value)
                .then(({ data }) => {
                    back();
                })

    };

    const back = () => router.push({ name: "UsersList" });

</script>