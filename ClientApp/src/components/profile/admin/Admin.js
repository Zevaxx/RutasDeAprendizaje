import React from "react";
// import Roles from "./roles/Roles";
import { Link } from "react-router-dom";

const Admin = () => {
  return (
    <div>
      <Link to="/admin/roles"> Administración de roles.</Link>
    </div>
  );
};

export default Admin;
