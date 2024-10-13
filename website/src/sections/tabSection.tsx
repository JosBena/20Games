import { useState } from "react";


export const Tabs = () => {

    const [toggleState, setTogglesState] = useState(1);
    const toggleTab = (index:number) => {
        console.log(index);
    }

    return(
        <div className="container">
            <ul className="tabs">
                <li>
                    <a href="#" aria-current="page" className="tabsActive"> Profile</a>
                </li>
                <li>
                    <a href="#" aria-current="page" className="tabsHover"> 2</a>
                </li>
                <li>
                    <a href="#" aria-current="page" className="tabsHover"> 3</a>
                </li>
            </ul>
            
        </div>
    );
};