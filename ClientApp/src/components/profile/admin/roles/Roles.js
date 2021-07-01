import React, { useEffect, useState } from "react";
import FetchData from "../../../../helpers/FetchData";

const Roles = () => {
  const [roles, setRoles] = useState({});

  useEffect(() => {
    const apiCall = async () => {
      const roles = await FetchData("api/admin/roles");
      //console.log(roles);
      setRoles(roles);
    };
    apiCall();
  }, []);

  return (
    <div>
      Acá agrega un rol a un usuario.
      {/* {roles} */}
      {/* {roles.map((rol) => (
        <li>{rol}</li>
      ))} */}
    </div>
  );
};

export default Roles;
