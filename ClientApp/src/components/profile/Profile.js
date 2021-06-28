import React, { useEffect, useState } from "react";
import authService from "../api-authorization/AuthorizeService";

const Profile = (props) => {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState({});

  useEffect(() => {
    const guid = async () => {
      const user = await authService.getUser();
      const token = await authService.getAccessToken();
      // console.log(token);
      fetch(`api/user/${user.sub}`, {
        headers: !token ? {} : { Authorization: `Bearer ${token}` },
      })
        .then((res) => res.json())
        .then(
          (result) => {
                setIsLoaded(true);
                console.log(result);
                setItems(result);
          },
          // Nota: es importante manejar errores aquí y no en
          // un bloque catch() para que no interceptemos errores
          // de errores reales en los componentes.
          (error) => {
            setIsLoaded(true);
            setError(error);
          }
        )
        .catch((error) => {
          return "error :" + error;
        });
    };
    guid();
  }, []);

  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
      return <div>{items.userName} { items.role}</div>;
  }
};

export default Profile;
