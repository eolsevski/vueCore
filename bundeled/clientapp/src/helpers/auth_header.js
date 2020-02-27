export default function auth_header() {

    let token = localStorage.getItem("token");

    if (token) {
        return { Authorization: "Bearer " + token };
    } else {
        return {};
    }
}