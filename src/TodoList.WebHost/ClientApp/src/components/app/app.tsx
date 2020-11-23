import React, { FunctionComponent, ReactElement } from 'react';
import classes from  './app.module.scss';

const App: FunctionComponent = (): ReactElement => {
  return <div className={classes.red}>Test</div>;
};

export default App;
