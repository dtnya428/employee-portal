import {
  ModalHeader,
  ModalDescription,
  ModalContent,
  ModalActions,
  Button,
  Modal,
} from "semantic-ui-react";

const CustomModal = (props) => {
  const { headerText, content, close, open, submit } = props;
  return (
    <Modal open={open} onClose={close} onOpen={open} size="small">
      <ModalHeader>{headerText}</ModalHeader>
      <ModalContent image>
        <ModalDescription>{content}</ModalDescription>
      </ModalContent>
      <ModalActions>
        <Button onClick={close}>Cancel</Button>
        <Button onClick={submit} positive>
          Save
        </Button>
      </ModalActions>
    </Modal>
  );
};

export default CustomModal;
