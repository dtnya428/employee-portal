import { Icon } from "semantic-ui-react";

const alertMessages = [
  {
    name: "Success",
    attributes: { positive: true, floating: true },
    icon: <Icon name="check circle" size="large" />,
  },
  {
    name: "Warning",
    attributes: { warning: true, floating: true },
    icon: <Icon name="warning sign" size="large" />,
  },
  {
    name: "Error",
    attributes: { negative: true, floating: true },
    icon: <Icon name="warning circle" size="large" />,
  },
  {
    name: "Info",
    attributes: { info: true, floating: true },
    icon: <Icon name="info circle" size="large" />,
  },
];

export default alertMessages;
