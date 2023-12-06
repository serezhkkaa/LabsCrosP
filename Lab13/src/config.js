export const oktaConfig = {
  issuer: "https://dev-95822749.okta.com/oauth2/default",
  clientId: "0oadoj2wfdeAwyIJm5d7",
  redirectUri: `${window.location.origin}/login/callback`,
  scopes: ["openid", "profile", "email"],
  pkce: true,
};
