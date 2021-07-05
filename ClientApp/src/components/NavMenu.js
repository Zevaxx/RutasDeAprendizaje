import React, { useContext, useState } from "react";
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

  const [collapsed, setCollapsed] = useState(true);

  let toggleNavbar = () => {
    setCollapsed(!collapsed);
  };

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        light
      >
        <Container>
          <NavbarBrand className="d-flex" tag={Link} to="/">
            <div className="mx-2">
              <FormattedMessage
                id="app.layout.title"
                defaultMessage="Rutas de aprendizaje"
              />
            </div>
          </NavbarBrand>
          <select value={context.currentLocale} onChange={context.selectLang}>
            <option value="es">Español</option>
            <option value="en">English</option>
          </select>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse
            className="d-sm-inline-flex flex-sm-row-reverse"
            isOpen={collapsed}
            navbar
          >
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">
                  <FormattedMessage
                    id="app.layout.home"
                    defaultMessage="Home"
                  />
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
