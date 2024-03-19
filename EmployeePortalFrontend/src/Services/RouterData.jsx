import App from "../App";
import Skills from "../Pages/ViewSkills";
import ViewEmployees from "../Pages/ViewEmployees";
import ViewEmployeeProfile from "../Pages/ViewEmployeeProfile";

const routerData = [
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/viewEmployees",
    element: <ViewEmployees />,
  },
  {
    path: "/viewSkills",
    element: <Skills />,
  },
  {
    path: `/viewProfile`,
    element: <ViewEmployeeProfile />,
  },
];

export default routerData;
