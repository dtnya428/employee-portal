import { Header } from "semantic-ui-react";

const MainHeader = ({ header }) => {
  return (
    <Header
      as="h1"
      style={{
        color: "#1a1a1a",
        fontSize: "2.4em",
        lineHeight: 1.1,
        paddingTop: 20,
      }}
    >
      {header}
    </Header>
  );
};

export default MainHeader;
