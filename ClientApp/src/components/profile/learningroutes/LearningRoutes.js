import React, { useEffect, useState } from "react";
import FetchData from "../../../helpers/FetchData";
import authService from "../../api-authorization/AuthorizeService";
import { ListGroup, ListGroupItem, Button, Input } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faPlus } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";

const LearningRoutes = () => {
  const [reload, setReload] = useState(true);
  const [misRutas, setMisRutas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [createRuteForm, setCreateRuteForm] = useState({
    lrName: "",
    lrDescription: "",
    lrDificulty: "",
    lrDiscipline: "",
  });

  useEffect(() => {
    const getMisRutas = async () => {
      const user = await authService.getUser();
      const newMisRutas = await FetchData(
        `api/Learningroutes/mis-rutas/${user.sub}`
      );
      setMisRutas(newMisRutas);
      setLoading(false);
    };

    getMisRutas();
    console.log(misRutas);
  }, [reload]);

  const DeleteRute = async (ruteId) => {
    await FetchData(`api/Learningroutes/${ruteId}`, "DELETE");
    setReload(!reload);
  };

  const handleForm = (event) => {
    const value = event.target.value;
    setCreateRuteForm({ ...createRuteForm, [event.target.name]: value });
    // console.log(createRuteForm);
  };

  const crearRuta = async (event) => {
    event.preventDefault();
    const user = await authService.getUser();
    const dataform = { ...createRuteForm, userId: user.sub };
    await FetchData("api/Learningroutes", "POST", dataform);
    setCreateRuteForm({
      lrName: "",
      lrDescription: "",
      lrDificulty: "",
      lrDiscipline: "",
    });
    setReload(!reload);
  };

  if (loading) {
    return <div> Cargando ...</div>;
  } else {
    return (
      <div>
        <div>
          listado de tus rutas de aprendizaje
          {misRutas.length == 0 ? (
            <div> Aun no tienes rutas creadas</div>
          ) : (
            <ListGroup className="">
              {misRutas.map((misrutas) => (
                <ListGroupItem className="d-flex" key={misrutas.routeId}>
                  <div className="col-8">
                    <h4>{misrutas.routeName}</h4>
                    <p>Descripción : {misrutas.routeDescription}</p>
                    <div>Dificultad: {misrutas.routeDifficulty}</div>
                    <div>Disciplina: {misrutas.routeDiscripline || ""}</div>
                  </div>
                  <div className="col-4">
                    <Button
                      color="danger"
                      onClick={() => DeleteRute(misrutas.routeId)}
                    >
                      <FontAwesomeIcon icon={faTrash}></FontAwesomeIcon>
                    </Button>
                    <Button
                      tag={Link}
                      color="success"
                      to={`/perfil/courses/${misrutas.routeId}`}
                    >
                      <FontAwesomeIcon icon={faPlus}></FontAwesomeIcon>
                    </Button>
                  </div>
                </ListGroupItem>
              ))}
            </ListGroup>
          )}
        </div>
        {/* boton de editar */}
        Nueva ruta de aprendizaje
        <form onSubmit={crearRuta}>
          <div>
            Nombre de la ruta
            <Input
              type="text"
              name="lrName"
              value={createRuteForm.lrName}
              onChange={handleForm}
              required
            ></Input>
          </div>
          <div>
            Descripcion de la ruta
            <Input
              type="text"
              name="lrDescription"
              value={createRuteForm.lrDescription}
              onChange={handleForm}
              required
            ></Input>
          </div>
          <div>
            Dificultad de la ruta
            <Input
              type="number"
              name="lrDificulty"
              value={createRuteForm.lrDificulty}
              onChange={handleForm}
              required
            ></Input>
          </div>
          <div>
            Diga una disciplina que corresponda
            <Input
              type="text"
              name="lrDiscipline"
              value={createRuteForm.lrDiscipline}
              onChange={handleForm}
              required
            ></Input>
          </div>
          <Button color="success" type="submit">
            Guardar la ruta!
          </Button>
        </form>
      </div>
    );
  }
};

export default LearningRoutes;
