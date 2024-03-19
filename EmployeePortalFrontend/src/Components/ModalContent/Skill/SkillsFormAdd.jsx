import { Fragment, useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import usePostData from "../../../CustomHooks/PostData";

import { ModalHeader, Button, Modal, Form, FormField } from "semantic-ui-react";

const EmployeeFormAdd = (props) => {
  const { headerText, close, open, submit } = props;
  const { response, error, isPending, postData } = usePostData();

  useEffect(() => {
    if(response || error) {
      submit(response, error);
      close();
    }
  }, [response]);
  
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm({
    defaultValues: {
      name: null,
      description: null,
    },
  });

  const onSubmit = async (data) => {
    await postData("skills", data);
    reset();
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

export default EmployeeFormAdd;
