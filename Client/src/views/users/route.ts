export default [
    {
        path: '/users',
        name: 'Users',
        component: () => import('./index.vue'),
        meta: {
            title: 'المستخدمون',
            hasChildren: false,
            icon: "mdi-account-group-outline",
            roles: [1]
        },
        children: [
            {
                path: '',
                name: 'UsersList',
                component: () => import('./list/list.vue'),
                meta: {
                    title: 'قائمة المستخدمين',
                    isSideBar: true,
                },
            },
            {
                path: 'create',
                name: 'CreateUser',
                component: () => import('./create/create.vue'),
                meta: {
                    title: 'مستخدم جديد',
                },
            },
            {
                path: ':id',
                name: 'User',
                component: () => import('./view/view.vue'),
                meta: {
                    title: 'بيانات المستخدم',
                },
            },
            //{
            //    path: ':id/update',
            //    name: 'UpdateUser',
            //    component: () => import('./list/list.vue'),
            //    meta: {
            //        title: 'تعديل المستخدم',
            //    },
            //},
            
        ]
    }
]