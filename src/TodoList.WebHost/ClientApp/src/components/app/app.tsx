import React, { FunctionComponent, ReactElement } from 'react';
import classes from  './app.module.css';

const App: FunctionComponent = (): ReactElement => {
  return <div className={classes.red}>Test</div>;
};

export default App;
