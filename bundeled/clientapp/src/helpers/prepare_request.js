import auth_header from "./auth_header.js"

export default function prepareRequest(url) {

    return {
        method: 'post',
        url: url,
        headers: auth_header()
    }

}