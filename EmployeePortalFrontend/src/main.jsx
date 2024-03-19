import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import routerData from "./Services/RouterData";
import CustomContainer from "./Components/Common/CustomContainter";

import "./index.css";

const router = createBrowserRouter(routerData);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <CustomContainer>
      <RouterProvider router={router} />
    </CustomContainer>
  </React.StrictMode>
);
