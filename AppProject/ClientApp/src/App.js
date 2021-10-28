import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { ProblemOne } from './components/ProblemOne';
import { ProblemTwo } from './components/ProblemTwo';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/ProblemOne' component={ProblemOne} />
        <Route exact path='/ProblemTwo' component={ProblemTwo} />
      </Layout>
    );
  }
}
