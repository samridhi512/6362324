import logo from './logo.svg';
import './App.css';
import { EmployeesData } from './Employee';
import EmployeesList from './EmployeesList';
import { useState } from 'react';
function App() {
  const Employees = EmployeesData;
  const [theme, setTheme] = useState('light');
  return (
    <>
      <div>
        <label>SELECT A THEME </label>
        <select onChange={(e) => setTheme(e.target.value)}>
          <option value='light'>Light</option>
          <option value='dark'>Dark</option>
        </select>

      </div>
      <EmployeesList theme={theme} employees={Employees} />
    </>
  );
}

export default App;


