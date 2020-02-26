export default function auth_header(){
   
        /*eslint-disable no-console*/
      console.log("auth_header");
      /*eslint-enable no-console*/
      // return authorization header with jwt token
      let token = localStorage.getItem("token");

      if (token) {
        return { Authorization: "Bearer " + token };
      } else {
        return {};
      }
}