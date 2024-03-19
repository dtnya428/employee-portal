import { Fragment, useState, useEffect } from "react";
import { useLocation } from 'react-router-dom';
import { useNavigate } from "react-router";
import useGetData from "../CustomHooks/GetData";

import { Divider, Grid, GridColumn, GridRow, Header, HeaderContent, HeaderSubheader, Icon, Item , Image, Button, ButtonContent} from "semantic-ui-react";
import { useMediaQuery } from "react-responsive";
import "../Styles/Employees.css";

const ViewEmployeeProfile = () => {
    const navigate = useNavigate();
    const { responseData, error, isLoading, fetchData } = useGetData();
    const isMobile = useMediaQuery({ maxWidth: 767 });
    const {state} = useLocation();
    const { id } = state; 

    useEffect(() => {
        fetchData(`employees/detailed/{${id}}`);
      }, [id]);
   
    return (
        <Fragment>
            <Item className="emp_profile_container">
                <Item className="emp_details_container">
                    <Item className="emp_details_details">
                        <Image
                            className="emp_item_info_img"
                            size="small"
                            src="https://react.semantic-ui.com/images/avatar/large/jenny.jpg"
                        />    
                        <Header as='h2'>
                            <HeaderContent>
                                {responseData && <span>{responseData.firstName} {responseData?.middleName} {responseData.lastName}</span>}
                                <HeaderSubheader>{responseData.email && <span><Icon name="mail" size="small"/>&nbsp;{responseData.email}</span>}</HeaderSubheader>
                                <HeaderSubheader>{responseData.mobile && <span><Icon name="call" size="small"/>&nbsp;{responseData.mobile}</span>}</HeaderSubheader>
                            </HeaderContent>
                        </Header>
                    </Item>
                    <Button icon>
                        <Icon name='setting' />
                    </Button>
                </Item>

                <Item className="offerings_container">
                    {responseData && ( 
                        <Fragment>
                            <Header as="h3" content="Offerings"/>
                            <Grid divided='vertically'>
                                <GridRow columns={isMobile ? 1 : 2}>
                                    {typeof responseData.offerings !== 'undefined' && responseData.offerings.length !== 0 ? (
                                    
                                        responseData.offerings.map((item) => {
                                            return (
                                                <GridColumn key={item.id}>
                                                    <Item className="item_container">
                                                        <Item className="offering_items">
                                                            <Item>{ item.businessUnit && <span><b>Business Unit:</b>&nbsp;{item.businessUnit}</span>}</Item>
                                                            <Item>{ item.primaryOffering && <span><b>Primary Offering:</b>&nbsp;{item.primaryOffering}</span>}</Item>
                                                            <Item>{ item.secondaryOffering && <span><b>Secondary Offering:</b>&nbsp;{item.secondaryOffering}</span>}</Item>
                                                            <Item>{ item.tribe && <span><b>Tribe:</b>&nbsp;{item.tribe}</span>}</Item>
                                                        </Item>
                                                        <Icon name="trash alternate"/>
                                                    </Item>
                                                </GridColumn>
                                            )
                                        })
                                    )
                                    :
                                    ( 
                                        <Item className="default_content">
                                            <Header as="h5">0 Offerings</Header>
                                        </Item> 
                                    )}
                                </GridRow>
                            </Grid>
                            <Item className="add_btn_container">
                                <Button icon primary fluid={isMobile && true}>
                                    <Icon name='add' />
                                    <span hidden={!isMobile && true}>Add Offerings</span>
                                </Button>
                            </Item>
                            <Divider />
                        </Fragment>
                    )}      
                </Item>

                <Item className="skills_container">
                    {responseData && ( 
                        <Fragment>
                            <Header as="h3" content="Skills"/>
                            <Grid divided='vertically'>
                                <GridRow columns={isMobile ? 1 : 2}>
                                    {typeof responseData.offerings !== 'undefined' && responseData.skills.length !== 0 ?
                                        (responseData.skills.map((item) => {
                                            return(
                                                <GridColumn key={item.id}>
                                                    <Item className="item_container">
                                                        <Item>{item.name}</Item>
                                                        <Icon name="trash alternate"/>
                                                    </Item>
                                                </GridColumn>
                                            )
                                        })
                                        ) 
                                        :
                                        (
                                            <Item className="default_content">
                                                <Header as="h5">0 Skills</Header>
                                            </Item>
                                        )
                                    }
                                </GridRow>
                            </Grid>
                            <Item className="add_btn_container">
                                <Button icon primary fluid={isMobile && true}>
                                    <Icon name='add' />
                                    <span hidden={!isMobile && true}>Add Skills</span>
                                </Button>
                            </Item>
                        </Fragment>
                    )}      
                </Item>

                <Item className="back_to_home_btn">
                   

                    <Button
                        className="back"
                        onClick={() => navigate("/viewEmployees")}
                        fluid={isMobile && true}
                        >
                            <Icon name="arrow left" />&nbsp;Employees 
                    </Button>

                    <Button
                        className="back"
                        onClick={() => navigate("/")}
                        fluid={isMobile && true}
                        >
                            Home&nbsp;<Icon name="arrow right" />
                    </Button>
                </Item>
            </Item>
        </Fragment>
    )
};

export default ViewEmployeeProfile;