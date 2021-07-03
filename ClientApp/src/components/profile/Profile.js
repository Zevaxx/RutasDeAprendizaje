import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import imgUsuarioDefault from "../../images/Profile/perfildeusuario.jpg";
import { Button } from "reactstrap";
import FetchData from "../../helpers/FetchData";
import "../../css/profile.css";

const Profile = (props) => {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [user, setUser] = useState({});

  useEffect(() => {
    const guid = async () => {
      const user = await authService.getUser();
      const token = await authService.getAccessToken();
      fetch(`api/user/${user.sub}`, {
        headers: !token ? {} : { Authorization: `Bearer ${token}` },
      })
        .then((res) => res.json())
        .then(
          (result) => {
            setIsLoaded(true);
            setUser(result);
          },
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

  const ModifyUserInfo = async (event) => {
    let user = await authService.getUser();
    let newUser = await FetchData(
      `api/user/${user.sub}`,
      { id: user.sub, description: "hola! 🧨👀💋, esta si que si" },
      "PUT"
    );
    console.log("acaaaa esta el nuevo usuario");
    console.log(newUser);
    setUser(newUser);
  };

  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
    return (
      <div className="profile-background">
        <section className="seccion-perfil-usuario">
          <div className="perfil-usuario-header">
            <div className="perfil-usuario-portada">
              <div className="perfil-usuario-avatar">
                <img src={imgUsuarioDefault} alt="img-avatar" />
                <button type="button" className="boton-avatar">
                  <i className="far fa-image"></i>
                </button>
              </div>
              <button type="button" className="boton-portada">
                <i className="far fa-image"></i> Cambiar fondo
              </button>
            </div>
          </div>
          <div className="perfil-usuario-body">
            <div className="perfil-usuario-bio">
              <h3 className="titulo">{user.userName}</h3>
              <p className="texto m-auto">
                {user.userDescription || "Agrega una descripción"}
              </p>
              <Button type="button" onClick={() => ModifyUserInfo()}>
                cambiar descripión
              </Button>
            </div>
            <div className="perfil-usuario-footer">
              <ul className="lista-datos">
                <li>
                  <i className="icono fas fa-user-check"></i> Nombre:
                </li>
                <li>
                  <i className="icono fas fa-map-signs"></i> Usuario:
                </li>
                <li>
                  <i className="icono fas fa-briefcase"></i> Rutas:
                </li>
              </ul>
            </div>
            <div className="perfil-usuario-actividad">
              <ul className="lista-datos">
                <li>
                  <i className="icono fas fa-user-graduate"></i> Cursos
                  Suscritos:
                </li>
              </ul>
              <p className="texto">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>

              <ul className="lista-datos">
                <li>
                  <i className="icono fas fa-graduation-cap"></i> Cursos
                  Creados:
                </li>
              </ul>
              <p className="texto">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </div>

            <div className="perfil-usuario-actividad">
              <ul className="lista-datos">
                <li>
                  <i className="icono fas fa-coins"></i> Descripción de su
                  Actividad:
                </li>
              </ul>
            </div>
          </div>
        </section>
        {user.role === "admin" ? (
          <div>
            <Link to="/admin"> Administración </Link>
          </div>
        ) : (
          <div>no es admin</div>
        )}
      </div>
    );
  }
};

export default Profile;
