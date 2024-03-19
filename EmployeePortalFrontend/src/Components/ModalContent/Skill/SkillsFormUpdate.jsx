import { Fragment, useEffect} from "react";
import { useForm } from "react-hook-form";
import useUpdateRecord from "../../../CustomHooks/UpdateRecord";

import { ModalHeader, Button, Modal, Form, FormField } from "semantic-ui-react";

const EmployeeFormUpdate = (props) => {
  const { headerText, close, open, record, submit } = props;
  const { response, error, isPending, updateRecord} =  useUpdateRecord();

  useEffect(() => {
    if(response || error) {
      submit(response, error);
      close();
    }
  }, [response]);


  useEffect(() => {
    setValue('name', record.name);
    setValue('description', record.description);
  }, [record]);

  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm({
    defaultValues: {
      name: null,
      description: null,
    },
  });

  const onSubmit = async (data) => {
      await updateRecord(`skills/{${record.id}}`, data);
  };

  return (
    <Fragment>
      <Modal open={open} onClose={close} onOpen={open} size="small">
        <ModalHeader>{headerText}</ModalHeader>
        <Form
          onSubmit={handleSubmit(onSubmit)}
          style={{
            padding: "1.2em 1.2em",
          }}
        >
          <FormField>
            <label>Name</label>
            <input
              name="name"
              placeholder="Name"
              {...register("name", { required: true })}
              required
            />
          </FormField>
          <FormField>
            <label>Description</label>
            <input
              name="description"
              placeholder="Description"
              {...register("description", { required: true })}
              required
            />
          </FormField>
          <Button onClick={close}>Cancel</Button>
          <Button
            type="submit"
            loading={isPending && true}
            disabled={isPending && true}
            positive
          >
            Save
          </Button>
        </Form>
      </Modal>
    </Fragment>
  );
};

export default EmployeeFormUpdate;
