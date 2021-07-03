import React, { useEffect, useState } from "react";
import Spanish from "../lang/es.json";
import English from "../lang/en.json";
import { IntlProvider } from "react-intl";
export let Context = React.createContext();

const LangWrapper = (props) => {
  const [currentLocale, setCurrentLocale] = useState("es");
  const [messages, setMessages] = useState(Spanish);

  useEffect(() => {
    console.log("idioma a cargar " + currentLocale);
    localStorage.getItem("selectedLang") &&
      setCurrentLocale(localStorage.getItem("selectedLang"));
    console.log(
      "idioma guardado localmente " + localStorage.getItem("selectedLang")
    );
    localStorage.getItem("selectedLang") === "en" && setMessages(English);
    localStorage.getItem("selectedLang") === "es" && setMessages(Spanish);
  }, [currentLocale]);

  const selectLang = (e) => {
    localStorage.setItem("selectedLang", e.target.value);
    setCurrentLocale(e.target.value);
  };

  return (
    <Context.Provider value={{ currentLocale, selectLang }}>
      <IntlProvider locale={currentLocale} messages={messages}>
        {props.children}
      </IntlProvider>
    </Context.Provider>
  );
};

export default LangWrapper;
