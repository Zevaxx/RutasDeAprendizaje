import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import imgUsuarioDefault from "../../images/Profile/perfildeusuario.jpg";
import {
  Button,
  Input,
  Card,
  CardBody,
  CardTitle,
  CardSubtitle,
} from "reactstrap";
import FetchData from "../../helpers/FetchData";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEdit,
  faUserCheck,
  faMapSigns,
  faBriefcase,
  faUserGraduate,
  faGraduationCap,
  faCoins,
  faImage,
} from "@fortawesome/free-solid-svg-icons";
import { UserDescription } from "./styles";
import "../../css/profile.css";

const Profile = (props) => {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [user, setUser] = useState({});
  const [userDescription, setUserDescription] = useState("");

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
            console.log(result);
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

  const ModifyUserInfo = async (userDescription) => {
    let user = await authService.getUser();
    console.log(userDescription || "hola");
    let newUser = await FetchData(
      `api/user/${user.sub}`,
      { id: user.sub, description: userDescription },
      "PUT"
    );
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
                  <FontAwesomeIcon icon={faImage}></FontAwesomeIcon>
                </button>
              </div>
              <button type="button" className="boton-portada">
                <FontAwesomeIcon icon={faImage}></FontAwesomeIcon>
                Cambiar fondo
              </button>
            </div>
          </div>
          <div className="perfil-usuario-body">
            <div className="perfil-usuario-bio">
              <h3 className="titulo">{user.userName}</h3>
              <h5 className="titulo">{user.userRole}</h5>
              <div className="texto m-auto d-flex">
                {user.userDescription ? (
                  <>
                    <UserDescription> {user.userDescription}</UserDescription>
                    <Button type="button" onClick={() => ModifyUserInfo("")}>
                      <FontAwesomeIcon icon={faEdit}></FontAwesomeIcon>
                    </Button>
                  </>
                ) : (
                  <>
                    <Input
                      type="text"
                      name="userDescription"
                      placeholder="Agrega una descripción"
                      defaultValue=""
                      onChange={(e) => setUserDescription(e.target.value)}
                    ></Input>
                    <Button
                      type="button"
                      onClick={() => ModifyUserInfo(userDescription)}
                    >
                      Actualiza descripcion
                    </Button>
                  </>
                )}
              </div>
            </div>
            <div className="perfil-usuario-footer">
              <ul className="lista-datos">
                <li>
                  <FontAwesomeIcon icon={faUserCheck}></FontAwesomeIcon> Nombre:
                  {user.userName}
                </li>

                <li>
                  <FontAwesomeIcon icon={faBriefcase}></FontAwesomeIcon> Rutas:
                  {user.rutasCreadas?.length == 0 ? (
                    <h5>No tienes rutas creadas</h5>
                  ) : (
                    user.rutasCreadas?.map((ruta) => (
                      <div>
                        <Card>
                          <CardBody>
                            <CardTitle tag="h5">Card title</CardTitle>
                            <CardSubtitle tag="h6" className="mb-2 text-muted">
                              Card subtitle
                            </CardSubtitle>
                            <Button>Button</Button>
                          </CardBody>
                        </Card>
                      </div>
                    ))
                  )}
                </li>
              </ul>
            </div>
            <div className="perfil-usuario-actividad">
              <ul className="lista-datos">
                <li>
                  <FontAwesomeIcon icon={faUserGraduate}></FontAwesomeIcon>
                  Rutas Suscritas:
                </li>
              </ul>
              <div>
                {user.rutasSuscritas?.length === 0 ? (
                  <h5>No tienes rutas suscritas</h5>
                ) : (
                  user.rutasSuscritas?.map((ruta) => (
                    <div>
                      <Card>
                        <CardBody>
                          <CardTitle tag="h5">Card title</CardTitle>
                          <CardSubtitle tag="h6" className="mb-2 text-muted">
                            Card subtitle
                          </CardSubtitle>
                          <Button>Button</Button>
                        </CardBody>
                      </Card>
                    </div>
                  ))
                )}
              </div>

              {/* <ul className="lista-datos">
                <li>
                  <FontAwesomeIcon icon={faGraduationCap}></FontAwesomeIcon>
                  Cursos Creados:
                </li>
              </ul> */}
              {/* <p className="texto">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p> */}
            </div>

            <div className="perfil-usuario-actividad">
              <ul className="lista-datos">
                <li>
                  <FontAwesomeIcon icon={faCoins}></FontAwesomeIcon>
                  Descripción de su Actividad:
                </li>
              </ul>
            </div>
          </div>
        </section>
        {user.userRole?.find((roles) => roles === "admin") ? (
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
