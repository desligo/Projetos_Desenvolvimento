import React from "react";
import {Redirect, Switch, Route, Router} from "react-router-dom";
import RouteGuard from "./components/RouteGuard";


import {history} from './helpers/history';

import Homepage from "./pages/HomePage"
import LoginPage from "../src/LoginPage"

function Routes(){
    return (
        <Router history={history}>
            <Switch>
                <Route exact path="/" component={HomePage}/>
                <Route path="/LoginPage" component={LoginPage}/>
                <Redirect to="/" />
            </Switch>
        </Router>
    );
}

export default Routes