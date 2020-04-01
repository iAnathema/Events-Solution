export const environment = {
    production: true,
    apiUrl: window['apiUrl'] || 'http://localhost:5000/api'
};

//IdentityServer Section
export const IdentityServerEnv =  {
    authority: 'http://auth.example.org', 
    client_id: 'events.app',
    redirect_uri: 'http://localhost:4200/auth-callback',
    post_logout_redirect_uri: 'http://localhost:4200/login',
    response_type:"id_token token",
    scope:"openid name role profile username email events",
    filterProtocolClaims: true,
    loadUserInfo: true,
    automaticSilentRenew: true,
    silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
  }
  
  