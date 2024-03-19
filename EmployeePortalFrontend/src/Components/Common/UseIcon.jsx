import { Fragment } from "react";
import { Item } from "semantic-ui-react";

const UserIcon = (props) => {
    const {firstName, lastName} = props;
    const initials = `${firstName?.charAt(0)}${lastName?.charAt(0)}`;
    
    return (
        <Fragment>
            <Item className="user_icon_container">
                <Item className="user_icon">{initials}</Item>
            </Item>
        </Fragment>
    );
};

export default UserIcon;