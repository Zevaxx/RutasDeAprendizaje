import React, { useState } from "react";
import Spanish from "../lang/es.json";
import English from "../lang/en.json";
import { IntlProvider } from "react-intl";

export let Context = React.createContext();

const locale = navigator.language;

let lang;

if (locale.includes("en-US")) {
  lang = English;
} else {
  lang = Spanish;
}

const LangWrapper = (props) => {
  const [currentLocale, setCurrentLocale] = useState(locale);
  const [messages, setMessages] = useState(lang);

  const selectLang = (e) => {
    const newLocale = e.target.value;
    setCurrentLocale(newLocale);
    if (newLocale === "es") {
      setMessages(Spanish);
    } else {
      setMessages(English);
    }
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
