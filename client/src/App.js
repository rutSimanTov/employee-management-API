import React, { useEffect, useState } from 'react';
import { getAllemployees } from './api.js';


function App() {
    const [employees, setemployees] = useState([]);

    useEffect(() => {
        getAllemployees().then(data => {
            console.log("data: " + data)
            setemployees(data)
        });

    }, [])
    return (
    <div>
        <h1>employees</h1>
        {
            !employees||employees.length == 0 ? <div>no employees</div> :
                <ul>
                    {employees.map(e => <li >{e.id}  |  {e.name}   |  {e.age}  |  {e.experiance}</li>)}
                </ul>
        }
    </div>
);}

export default App;