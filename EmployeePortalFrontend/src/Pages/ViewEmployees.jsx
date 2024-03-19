import { Fragment, useEffect, useState } from "react";
import { useNavigate } from "react-router";
import useGetData from "../CustomHooks/GetData";

import {
  Button,
  Icon,
  Image,
  Item,
  Input,
  ItemContent,
  Header,
  HeaderSubheader,
  Loader,
  Menu,
  Popup,
} from "semantic-ui-react";
import { useMediaQuery } from "react-responsive";
import "../Styles/Employees.css";

import EmployeeForm from "../Components/ModalContent/Employee/EmployeeForm";
import DeleteEmployee from "../Components/ModalContent/Employee/DeleteEmployee";
import MainHeader from "../Components/Common/MainHeader";
import AlertMessage from "../Components/Common/AlertMessage";
import UserIcon from "../Components/Common/UseIcon";
import alertMessages from "../Services/AlertMessages";

const ViewEmployees = () => {
  const navigate = useNavigate();

  const { responseData, error, isLoading, fetchData } = useGetData();
  const [openMenuId, setOpenMenuId] = useState(null);
  const [openAddEmployee, setOpenAddEmployee] = useState(false);
  const [openDeleteEmployee, setOpenDeleteEmployee] = useState(false);
  const [record, setRecord] = useState({ id: "", name: "", description: "" });
  const [showMessage, setShowMessage] = useState(false);
  const [alertSettings, setAlertSettings] = useState({
    attributes: null,
    icon: null,
    message: "",
  });

  const isMobile = useMediaQuery({ maxWidth: 767 });

  useEffect(() => {
    fetchData("employees");
  }, []);

  const handleMenuClose = () => {
    setOpenMenuId(null);
  };

  const handleSubmission = (response, error) => {
    if (response?.status === 200) {
      setAlertSettings({
        attributes: alertMessages.filter((item) => item?.name === "Success")[0]
          .attributes,
        icon: alertMessages.filter((item) => item?.name === "Success")[0].icon,
        message:  response.api && `Successfully ${response.api}` || `Successfully Submitted`,
      });

      setShowMessage(true);
    } else if (error !== null) {
      setAlertSettings({
        attributes: alertMessages.filter((item) => item?.name === "Error")[0]
          .attributes,
        icon: alertMessages.filter((item) => item?.name === "Error")[0].icon,
        message: error?.message || "An error has occured",
      });
      setShowMessage(true);
    }

    setTimeout(() => {
      setShowMessage(false);

      setAlertSettings({
        attributes: null,
        icon: null,
        message: "",
      });

      fetchData("employees");
    }, 3000);
  };

  return (
  <Fragment>
    {openAddEmployee &&
      <EmployeeForm
        headerText="Add New Employee"
        close={() => setOpenAddEmployee(false)}
        open={openAddEmployee}
        submit={handleSubmission}
      />
      }

    {openDeleteEmployee && <DeleteEmployee
        headerText="Delete Employee"
        close={() => setOpenDeleteEmployee(false)}
        open={openDeleteEmployee}
        record={record}
        submit={handleSubmission}
      />
     }

      <MainHeader header="Employees" />

      <Item className="search_btn_container">
        <Input fluid={isMobile && true} icon="search" placeholder="Search..." />
        <Button
          primary
          onClick={() => setOpenAddEmployee(true)}
          fluid={isMobile && true}
        >
          <Icon name="add" />
          Add <span hidden={!isMobile && true}>Employee</span> &nbsp;&nbsp;
        </Button>
      </Item>

      {isLoading && <Loader active inline="centered" />}
      {responseData && (
        <Item className="emp_items_container">
          {responseData.map((item) => {
            return (
              <Item className="emp_item" key={item.id} fluid>
                <Item className="emp_item_info">
                <UserIcon firstName={item.firstName} lastName={item.lastName} />
                  <ItemContent className="emp_item_info_content">
                    <Header as="h4">
                      {item.firstName} {item.middleName && item.middleName}{" "}
                      {item.lastName}
                      <HeaderSubheader>
                        {item.email && item.email}
                      </HeaderSubheader>
                    </Header>
                  </ItemContent>
                </Item>

                <Item>
                  <Popup
                    trigger={
                      <Icon
                        name="ellipsis vertical"
                        size="large"
                        style={{ cursor: "pointer" }}
                      />
                    }
                    content={
                      <Menu vertical icon="labeled" size="small">
                        <Menu.Item
                          content="View Profile"
                           onClick={() => navigate(`/viewProfile` , { state: { id: item.id } })}
                        />
                        <Menu.Item
                          content="Delete"
                          onClick={() => {
                            setOpenDeleteEmployee(true);
                            setRecord((prev) => ({ ...prev, id: item.id }));
                            handleMenuClose();
                          }}
                        />
                      </Menu>
                    }
                    on="click"
                    position="bottom right"
                    open={openMenuId === item.id}
                    onClose={() => handleMenuClose()}
                    onOpen={() => setOpenMenuId(item.id)}
                  />
                </Item>
              </Item>
            );
          })}
        </Item>
      )}

      {showMessage && (
        <AlertMessage
          attr={alertSettings?.attributes}
          icon={alertSettings.icon}
          message={alertSettings.message}
        />
      )}

      <Item className="back_to_home_btn">
        <Button
          className="back"
          onClick={() => navigate("/")}
          fluid={isMobile && true}
        >
          <Icon name="arrow left" />
          &nbsp;Back <span hidden={!isMobile && true}>to Home</span>
        </Button>
      </Item>
    </Fragment>
  );
};

export default ViewEmployees;
