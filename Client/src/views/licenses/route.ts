export default [
    {
        path: '/licenses',
        name: 'Licenses',
        component: () => import('./index.vue'),
        meta: {
            title: 'الرخص',
            hasChildren: false,
            icon: "mdi-file-document-multiple-outline",
            // roles: [1,2] 
        },
        children: [
            {
                path: '',
                name: 'LicensesList',
                component: () => import('./list/list.vue'),
                meta: {
                    title: 'قائمة الرخص',
                    isSideBar: true,
                },
            },
            {
                path: '/create',
                name: 'CreateLicense',
                component: () => import('./create/create.vue'),
                meta: {
                    title: 'رخصة جديدة',
                },
            },
            {
                path: ':id',
                name: 'License',
                component: () => import('./view/view.vue'),
                meta: {
                    title: 'عرض الرخصة',
                },
            },
            
        ]
    }
]