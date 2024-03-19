import { Fragment } from "react";
import { Container } from "semantic-ui-react";
import "../../Styles/Common.css";

export default function CustomContainer({ children }) {
  return (
    <Fragment>
      <Container className="custom_container">{children}</Container>
    </Fragment>
  );
}
