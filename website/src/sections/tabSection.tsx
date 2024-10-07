import { useState } from "react";


export const Tabs = () => {

    const [toggleState, setTogglesState] = useState(1);
    const toggleTab = (index:number) => {
        console.log(index);
    }

    return(
        <div className="container">
            <div className="bloc-tabs">
                <div 
                className="tabs active-tabs" onClick={() =>toggleTab(1)}> Tab 1</div>
                <div className="tabs" onClick={() =>toggleTab(2)}>Tab 2</div>
                <div className="tabs"onClick={() =>toggleTab(3)}>Tab 3 </div>
            </div>

            <div className="content-tabs">
                <div className="content active-content">
                    <h2>Content 1</h2>
                    <hr />
                    <p>
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit. 
                        Non perferendis magnam soluta cumque eos autem at sed! Nihil quaerat, 
                        maxime beatae aperiam excepturi ea consectetur incidunt ipsa. Magnam, nesciunt quaerat!
                    </p>
                </div>
                <div className="content">
                    <h2>Content 2</h2>
                    <hr />
                    <p>
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit. 
                        Non perferendis magnam soluta cumque eos autem at sed! Nihil quaerat, 
                        maxime beatae aperiam excepturi ea consectetur incidunt ipsa. Magnam, nesciunt quaerat!
                    </p>
                </div>
                <div className="content">
                    <h2>Content 3</h2>
                    <hr />
                    <p>
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit. 
                        Non perferendis magnam soluta cumque eos autem at sed! Nihil quaerat, 
                        maxime beatae aperiam excepturi ea consectetur incidunt ipsa. Magnam, nesciunt quaerat!
                    </p>
                </div>
                
                
            </div>
            
        </div>
    );
};