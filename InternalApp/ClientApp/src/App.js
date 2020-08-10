import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import CandidatesList from './components/candidates-list.component'

export default () => (
  <Layout>
    <Route exact path='/' component={CandidatesList} />
  </Layout>
);
