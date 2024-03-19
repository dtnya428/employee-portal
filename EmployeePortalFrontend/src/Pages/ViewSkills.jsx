import { Fragment, useEffect, useState } from "react";
import { useNavigate } from "react-router";
import  useGetData  from "../CustomHooks/GetData"

import {
  Button,
  Icon,
  Item,
  Input,
  ItemContent,
  Loader,
  Menu,
  Popup,
} from "semantic-ui-react";
import { useMediaQuery } from "react-responsive";

import "../Styles/Skills.css";

import MainHeader from "../Components/Common/MainHeader";
import EmployeeFormAdd from "../Components/ModalContent/Skill/SkillsFormAdd";
import DeleteSkill from "../Components/ModalContent/Skill/DeleteSkill";
import EmployeeFormUpdate from "../Components/ModalContent/Skill/SkillsFormUpdate";
import AlertMessage from "../Components/Common/AlertMessage";
import alertMessages from "../Services/AlertMessages";

const Skills = () => {
  const navigate = useNavigate();

  const { responseData, error, isLoading, fetchData } = useGetData();
  const [openSkillsFormAdd, setOpenSkillsFormAdd] = useState(false);
  const [openSkillsFormUpdate, setOpenSkillsFormUpdate] = useState(false);
  const [openDeleteSkill, setOpenDeleteSkill] = useState(false);
  const [record, setRecord] = useState({ id: "", name: "", description: "" });
  const [showMessage, setShowMessage] = useState(false);
  const [alertSettings, setAlertSettings] = useState({
    attributes: null,
    icon: null,
    message: "",
  });
  const [openMenuId, setOpenMenuId] = useState(null);

  const isMobile = useMediaQuery({ maxWidth: 767 });

  useEffect(() => {
    fetchData("skills");
  }, []);

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

      fetchData("skills");
    }, 3000);
  };

  const handleMenuClose = () => {
    setOpenMenuId(null);
  };

  return (
    <Fragment>
     {openSkillsFormAdd && <EmployeeFormAdd
        headerText="Add New Skill"
        close={() => setOpenSkillsFormAdd(false)}
        open={openSkillsFormAdd}
        submit={handleSubmission}
      />
     }

     {openSkillsFormUpdate &&  <EmployeeFormUpdate
        headerText="Update Skill"
        close={() => setOpenSkillsFormUpdate(false)}
        open={openSkillsFormUpdate}
        record={record}
        submit={handleSubmission}
      />
     }

     {openDeleteSkill && <DeleteSkill
        headerText="Delete Skill"
        close={() => setOpenDeleteSkill(false)}
        open={openDeleteSkill}
        record={record}
        submit={handleSubmission}
      />
     }

      <MainHeader header="Skills" />
      <Item className="search_btn_container">
        <Input icon="search" placeholder="Search..." />
        <Button
          primary
          fluid={isMobile && true}
          onClick={() => {
            setOpenSkillsFormAdd(true);
            setRecord({ id: "", name: "", description: "" });
          }}
        >
          <Icon name="add" />
          Add <span hidden={!isMobile && true}>Skill</span> &nbsp;&nbsp;
        </Button>
      </Item>

      {isLoading && <Loader active inline="centered" />}
      {responseData && (
        <Item
          style={{
            textAlign: "left",
          }}
        >
        <Item className="skills_items_container">
          {responseData.map((item) => {
            return (
              <Item key={item.id}  className="skills_item" >
                <ItemContent>{item.name}</ItemContent>
                <ItemContent>{item.description}</ItemContent>
                <ItemContent>
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
                          content="Edit"
                          onClick={() => {
                          setOpenSkillsFormUpdate(true);
                          setRecord({
                            id: item.id,
                            name: item.name,
                            description: item.description,
                          });
                          handleMenuClose();
                        }}
                        />
                        <Menu.Item
                          content="Delete"
                          onClick={() => {
                            setOpenDeleteSkill(true);
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
              </ItemContent>
            </Item>
            );
          })}
          </Item>
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

export default Skills;
