import React, { Component, Fragment } from "react";
import { NavItem, NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import authService from "./AuthorizeService";
import { ApplicationPaths } from "./ApiAuthorizationConstants";
import { FormattedMessage } from "react-intl";

export class LoginMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      userName: null,
    };
  }

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    this.populateState();
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    const [isAuthenticated, user] = await Promise.all([
      authService.isAuthenticated(),
      authService.getUser(),
    ]);
    this.setState({
      isAuthenticated,
      userName: user && user.name,
    });
  }

  render() {
    const { isAuthenticated, userName } = this.state;
    if (!isAuthenticated) {
      const registerPath = `${ApplicationPaths.Register}`;
      const loginPath = `${ApplicationPaths.Login}`;
      return this.anonymousView(registerPath, loginPath);
    } else {
      const profilePath = `${ApplicationPaths.Profile}`;
      const logoutPath = {
        pathname: `${ApplicationPaths.LogOut}`,
        state: { local: true },
      };
      return this.authenticatedView(userName, profilePath, logoutPath);
    }
  }

  authenticatedView(userName, profilePath, logoutPath) {
    return (
      <Fragment>
        <NavItem>
          <NavLink
            tag={Link}
            className="text-dark border rounded"
            to={"/perfil"}
          >
            <FormattedMessage
              id="app.layout.profile"
              defaultMessage="profile "
            />
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink
            tag={Link}
            className="text-dark border rounded"
            to={profilePath}
          >
            <FormattedMessage
              id="app.layout.admCuenta"
              defaultMessage="Adm Cuenta de "
            />
            {userName}
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink
            tag={Link}
            className="text-dark border rounded"
            to={logoutPath}
          >
            <FormattedMessage id="app.layout.logout" defaultMessage="Logout " />
          </NavLink>
        </NavItem>
      </Fragment>
    );
  }

  anonymousView(registerPath, loginPath) {
    return (
      <Fragment>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to={registerPath}>
            Registro
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to={loginPath}>
            Ingresar
          </NavLink>
        </NavItem>
      </Fragment>
    );
  }
}
