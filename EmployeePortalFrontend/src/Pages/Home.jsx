import { Fragment } from "react";
import { useNavigate } from "react-router-dom";

import { Button } from "semantic-ui-react";
import MainHeader from "../Components/Common/MainHeader";

import homeMenu from "../Services/HomeMenu";

import "../Styles/Home.css";

export default function Home() {
  const navigate = useNavigate();

  return (
    <Fragment>
      <MainHeader header="Employee Portal" />
      {homeMenu.map((menuItem) => {
        return (
          <Button
            className="btn"
            fluid
            key={menuItem.name}
            primary
            content={menuItem.name}
            onClick={() => navigate(menuItem.path)}
          />
        );
      })}
    </Fragment>
  );
}
