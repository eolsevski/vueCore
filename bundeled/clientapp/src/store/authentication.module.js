export const authentication = {
    state: { authenticated: false },
    action: {
        prisijunges({ commit })
    },
    mutations: {
        lgin(authenticated) {
            state.authenticated = true;
        },
        lgout(authenticated) {
            state.authenticated = false;
        }

    }
}