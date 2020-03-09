import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'
import Login from '../views/LoginView'


Vue.use(VueRouter)

const routes = [{
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "about" */ '../views/About')
    },
    {
        path: '/login',
        name: 'Login',
        component: Login
    },
    {
        path: '/secret',
        name: 'Secret',
        component: () =>
            import ( /* webpackChunkName: "about" */ '../views/SecretView')
    },
    {
        path: '/upload',
        name: 'Upload',
        component: () =>
            import ( /* webpackChunkName: "about" */ '../views/uploadView')
    },
    {
        path: '/logout',
        name: 'Logout',
        component: () =>
            import ( /* webpackChunkName: "about" */ '../components/LogOut')
    },
    {
        path: '/register',
        name: 'Register',
        component: () =>
            import ( /* webpackChunkName: "about" */ '../views/RegisterView')
    }

]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})


router.beforeEach((to, from, next) => {
    const publicPages = ['/login', '/'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('token');
    //remember last path before login, 
    if (to.path != '/login')
        localStorage.setItem('to', to.path);

    if (authRequired && !loggedIn) {
        return next('/login');
    }


    next();
})





export default router