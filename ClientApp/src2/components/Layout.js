import React, { useContext } from "react";
import { Container } from "reactstrap";
import { FormattedMessage } from "react-intl";
import { Context } from "../components/LangWrapper";

const Layout = (props) => {
  const context = useContext(Context);

  return (
    <div>
      <FormattedMessage
        id="app.layout.title"
        defaultMessage="No cargó desde archivo"
      />
      <select value={context.currentLocale} onChange={context.selectLang}>
        <option value="en-US">English</option>
        <option value="es">Español</option>
      </select>
      <Container>{props.children}</Container>
    </div>
  );
};

export default Layout;
