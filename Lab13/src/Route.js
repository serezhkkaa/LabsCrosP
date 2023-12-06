import { Route, Switch, useHistory } from "react-router-dom";
import Navbar from "./components/Navbar";
import { Security, SecureRoute, LoginCallback } from "@okta/okta-react";
import HomeScreen from "./components/HomeScreen";
import Profile from "./components/Profile";
import FirstLab from "./components/Lab1";
import SecondLab from "./components/Lab2";
import ThirdLab from "./components/Lab3";
import { oktaConfig } from "./config";
import { OktaAuth, toRelativeUrl } from "@okta/okta-auth-js";

const oktaAuth = new OktaAuth(oktaConfig);

const Routes = () => {
  const history = useHistory();
  const originalUri = async (_oktaAuth, originalUri) => {
    history.replace(toRelativeUrl(originalUri || "/", window.location.origin));
  };

  return (
    <Security oktaAuth={oktaAuth} restoreOriginalUri={originalUri}>
      <Navbar />
      <Switch>
        <Route path="/" exact={true} component={HomeScreen} />
        <SecureRoute path="/profile" component={Profile} />
        <Route path="/login/callback" component={LoginCallback} />
        <Route path="/lab/1" component={FirstLab} />
        <Route path="/lab/2" component={SecondLab} />
        <Route path="/lab/3" component={ThirdLab} />
      </Switch>
    </Security>
  );
};

export default Routes;
