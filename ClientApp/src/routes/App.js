import React from "react";
import { Route, Switch } from "react-router";
import Layout from "../components/Layout";
import Login from "../pages/Login";

// import {Menu}  from '../pages/Menu'
// import { Home } from '../components/Home';

const App = () => {
  return (
    <Layout>
      <Switch>
        <Route exact path="/" component={Login} />
        {/* <Route path='/counter' component={Menu} /> */}
      </Switch>
    </Layout>
  );
};

export default App;
