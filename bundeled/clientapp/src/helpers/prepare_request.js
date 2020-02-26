import auth_header from "./auth_header.js"

export default function prepareRequest(url){
    /*eslint-disable no-console*/
console.log('auth_header')
    /*eslint-enable no-console*/
    return{
            method: 'post',
            url: url,
            headers: auth_header() 
    }

}