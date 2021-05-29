import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./routes/App";
import LangWrapper from "./components/LangWrapper";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <LangWrapper>
      <App />
    </LangWrapper>
  </BrowserRouter>,
  rootElement
);
