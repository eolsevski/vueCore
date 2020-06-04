import store from '../store'

export default function auth_header() {

    //const token = localStorage.getItem("token");

    const storedToken = store.state.user.user.token;

    if (storedToken) {
        return { Authorization: "Bearer " + storedToken };
    } else {
        return {};
    }
}