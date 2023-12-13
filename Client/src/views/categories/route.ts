export default [
    {
        path: '/categories',
        name: 'Categories',
        component: () => import('./index.vue'),
        meta: {
            title: 'Categories',
            hasChildren: false,
            icon: "mdi-file-document-multiple-outline",
            // roles: [1,2] 
        },
        children: [
            {
                path: '',
                name: 'CategoriesList',
                component: () => import('./list/list.vue'),
                meta: {
                    title: 'Categories list',
                    isSideBar: true,
                },
            },
            {
                path: 'create',
                name: 'CreateCategories',
                component: () => import('./create/create.vue'),
                meta: {
                    title: ' جديدة',
                },
            },
            {
                path: ':id',
                name: 'Categories',
                component: () => import('./view/view.vue'),
                meta: {
                    title: 'عرض ',
                },
            },
            
        ]
    }
]