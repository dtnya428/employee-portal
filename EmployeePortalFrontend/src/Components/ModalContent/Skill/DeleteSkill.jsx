import { useEffect } from "react";
import {
  ModalHeader,
  ModalDescription,
  ModalContent,
  ModalActions,
  Button,
  Modal,
} from "semantic-ui-react";

import useDeleteRecord from "../../../CustomHooks/DeleteData";

const DeleteSkill = (props) => {
  const { response, error, isPending, deleteRecord } = useDeleteRecord();
  const { headerText, close, open, record, submit } = props;

  useEffect(() => {
    if (response || error) {
      submit(response, error);
      close();
    }
  }, [response]);

  const handleSubmission = async () => {
    await deleteRecord(`skills/{${record.id}}`);
  };

  return (
    <Modal open={open} onClose={close} onOpen={open} size="small">
      <ModalHeader>{headerText}</ModalHeader>
      <ModalContent image>
        <ModalDescription>
          <p>Are you sure you would like to delete this skill?</p>
        </ModalDescription>
      </ModalContent>
      <ModalActions>
        <Button onClick={close}>Cancel</Button>
        <Button
          type="submit"
          loading={isPending && true}
          disabled={isPending && true}
          onClick={handleSubmission}
          positive
        >
          Save
        </Button>
      </ModalActions>
    </Modal>
  );
};

export default DeleteSkill;
