<template src="./view.html">
</template>

<script lang="ts" setup>
    import { type UserInfo, type EmpItem, } from "./model";
    import { userService } from "../service";

    const router = useRouter();
    const pageTitle = router.currentRoute.value.meta.title;

    onMounted(() => {
        getUser();
    });

    let user = ref<UserInfo>({
        userId: null,
        empId: null,
        userName: null,
        fullName: null,
        jobDesc: null,
        entity: null,
        actJobDesc: null,
        actEntity: null,
        role: null,
        createdBy: null,
        createdOn: null,
        status: null
    });

    const getUser = async () => {
            const { data } = await userService.fetchById(router.currentRoute.value.params.id);

            user.value.userId = data.content.userId;
            user.value.userName = data.content.userName;
            user.value.empId = data.content.empId;
            user.value.fullName = data.content.fullName;
            user.value.jobDesc = data.content.jobDesc;
            user.value.entity = data.content.entity;
            user.value.actJobDesc = data.content.actJobDesc;
            user.value.actEntity = data.content.actEntity;
            user.value.role = data.content.role;
            user.value.createdBy = data.content.createdBy;
            user.value.createdOn = data.content.createdOn;
            user.value.status = data.content.status;        
    };
    const back = () => router.push({ name: "UsersList" });

</script>