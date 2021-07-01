import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "../components/Layout";
import { Home } from "../pages/Home";
import AuthorizeRoute from "../components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "../components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "../components/api-authorization/ApiAuthorizationConstants";
import Profile from "../components/profile/Profile";
import Roles from "../components/profile/admin/roles/Roles";
import Admin from "../components/profile/admin/Admin";

import "../css/custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
            <AuthorizeRoute exact path="/perfil" component={Profile} />
            <AuthorizeRoute exact path="/admin" component={Admin} />
            <AuthorizeRoute exact path="/admin/roles" component={Roles} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
