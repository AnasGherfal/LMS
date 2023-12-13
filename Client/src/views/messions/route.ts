export default [
    {
        path: '/messions',
        name: 'Messions',
        component: () => import('./index.vue'),
        meta: {
            title: 'المهام',
            hasChildren: false,
            icon: "mdi-file-document-multiple-outline",
            roles: [1,2] 
        },
        children: [
            {
                path: '',
                name: 'MessionsList',
                component: () => import('./list/list.vue'),
                meta: {
                    title: 'قائمة المهام',
                    isSideBar: true,
                },
            },
            {
                path: 'create',
                name: 'CreateMession',
                component: () => import('./create/create.vue'),
                meta: {
                    title: 'مهمة جديدة',
                },
            },
            {
                path: ':id',
                name: 'Mession',
                component: () => import('./view/view.vue'),
                meta: {
                    title: 'عرض المهمة',
                },
            },
            
        ]
    }
]