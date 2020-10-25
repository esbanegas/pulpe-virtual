import React from "react";
import ReactDOM from "react-dom";
import { initializeIcons } from "@uifabric/icons";

import "./index.css";
import App from "./App";

initializeIcons();

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);
