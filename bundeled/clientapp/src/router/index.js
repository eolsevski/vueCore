import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Home/Home'
import * as components from '../components/index'

Vue.use(VueRouter)

const routes = [{
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        component: ()=>Promise.resolve(components.About)
    },
    {
        path: '/login',
        name: 'Login',
        component: ()=>Promise.resolve(components.Login)
    },
    {
        path: '/secret',
        name: 'Secret',
        component: ()=>Promise.resolve(components.Secret)
    },
    {
        path: '/upload',
        name: 'Upload',
        component: ()=>Promise.resolve(components.Upload)
    },
    {
        path: '/register',
        name: 'Register',
        component: ()=>Promise.resolve(components.Register)
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})
router.beforeEach((to, from, next) => {
    const publicPages = ['/login', '/', '/register'];
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