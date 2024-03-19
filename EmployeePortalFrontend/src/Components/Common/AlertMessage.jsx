import { Fragment, useState } from "react";

import { MessageHeader, Message } from "semantic-ui-react";

import "../../Styles/Common.css";

const AlertMessage = ({ attr, icon, message }) => {
  return (
    <Fragment>
      <Message className="message_container" {...attr}>
        {icon}
        <MessageHeader>{message}</MessageHeader>
      </Message>
    </Fragment>
  );
};

export default AlertMessage;
