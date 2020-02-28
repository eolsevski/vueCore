import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'
import Login from '../views/LoginView'
import Secret from '../views/SecretView'


Vue.use(VueRouter)

const routes = [
  {
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
    component: () => import(/* webpackChunkName: "about" */ '../views/About')
  },
  {
    path: '/login',
    name:'Login',
    component: Login
},
{
  path: '/secret',
  name:'Secret',
  component: Secret
}

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})


router.beforeEach((to, from, next) =>{
  const publicPages = ['/login','/'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('token');
  localStorage.setItem('from', document.referrer);
  localStorage.setItem('to',to.path);
  localStorage.setItem('next',next);



  if (authRequired && !loggedIn) {
    return next('/login');
  }

  next();
}
)





export default router
