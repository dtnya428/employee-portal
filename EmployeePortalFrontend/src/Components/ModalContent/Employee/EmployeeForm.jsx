import { Fragment, useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import usePostData from "../../../CustomHooks/PostData";

import { ModalHeader, Button, Modal, Form, FormField } from "semantic-ui-react";

const EmployeeForm = (props) => {
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
      middleName: null,
      email: null,
      mobile: null,
    },
  });

  const onSubmit = async (data) => {
    await postData("employees", data);
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
            <label>First Name</label>
            <input
              name="firstName"
              placeholder="First Name"
              {...register("firstName", { required: true })}
              required
            />
          </FormField>
          <FormField>
            <label>Middle Name</label>
            <input
              name="middleName"
              placeholder="Middle Name"
              {...register("middleName", { required: false })}
            />
          </FormField>
          <FormField>
            <label>Last Name</label>
            <input
              name="lastName"
              placeholder="Last Name"
              {...register("lastName", { required: true })}
              required
            />
          </FormField>
          <FormField>
            <label>Email</label>
            <input
              name="email"
              placeholder="Email"
              {...register("email", { required: false })}
            />
          </FormField>
          <FormField>
            <label>Mobile</label>
            <input
              name="mobile"
              placeholder="Mobile"
              {...register("mobile", { required: false })}
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

export default EmployeeForm;
