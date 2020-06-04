import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Home/Home'
import * as components from '../components/index'
import store from '../store'
Vue.use(VueRouter)

const routes = [{
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        component: components.About
    },
    {
        path: '/login',
        name: 'Login',
        component: components.Login
    },
    {
        path: '/secret',
        name: 'Secret',
        component: components.Secret
    },
    {
        path: '/upload',
        name: 'Upload',
        component: components.Upload
    },
    {
        path: '/register',
        name: 'Register',
        component: components.Register
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
    const loggedIn = store.state.user.user.token;
    //remember last path before login, 
    if (to.path != '/login')
        localStorage.setItem('to', to.path);

    if (authRequired && !loggedIn) {
        return next('/login');
    }
    next();
})
export default router