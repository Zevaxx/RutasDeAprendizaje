import React, { useContext } from "react";
import { FormattedMessage } from "react-intl";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import { LoginMenu } from "./api-authorization/LoginMenu";
import "../css/NavMenu.css";
import { Context } from "../components/LangWrapper";

const NavMenu = (props) => {
  let context = useContext(Context);

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        light
      >
        <Container>
          <NavbarBrand tag={Link} to="/">
            <FormattedMessage
              id="app.layout.title"
              defaultMessage="No cargó desde archivo"
            />
            <select value={context.currentLocale} onChange={context.selectLang}>
              <option value="en-US">English</option>
              <option value="es">Español</option>
            </select>
          </NavbarBrand>
          <NavbarToggler className="mr-2" />
          <Collapse
            className="d-sm-inline-flex flex-sm-row-reverse"
            // isOpen={!this.state.collapsed}
            navbar
          >
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">
                  Home
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/counter">
                  Counter
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/fetch-data">
                  Fetch data
                </NavLink>
              </NavItem>
              <LoginMenu></LoginMenu>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
};

export default NavMenu;
