import React, { useEffect, useState } from "react";
import FetchData from "../../../helpers/FetchData";
import authService from "../../api-authorization/AuthorizeService";
import { ListGroup, ListGroupItem, Button, Input } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";

const LearningRoutes = () => {
  const [reload, setReload] = useState(true);
  const [misRutas, setMisRutas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [createRuteForm, setCreateRuteForm] = useState({
    userId: "",
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

  const crearRuta = async () => {
    const user = await authService.getUser();
    setCreateRuteForm({ ...createRuteForm, userId: user.sub });
    console.log(createRuteForm);
    await FetchData("api/Learningroutes", "POST", createRuteForm);
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
                  </div>
                </ListGroupItem>
              ))}
            </ListGroup>
          )}
        </div>
        {/* boton de editar */}
        Nueva ruta de aprendizaje
        <div>
          Nombre de la ruta
          <Input
            type="text"
            name="lrName"
            defaultValue=""
            onChange={handleForm}
          ></Input>
        </div>
        <div>
          Descripcion de la ruta
          <Input
            type="text"
            name="lrDescription"
            defaultValue=""
            onChange={handleForm}
          ></Input>
        </div>
        <div>
          Dificultad de la ruta
          <Input
            type="number"
            name="lrDificulty"
            defaultValue=""
            onChange={handleForm}
          ></Input>
        </div>
        <div>
          Diga una disciplina que corresponda
          <Input
            type="text"
            name="lrDiscipline"
            defaultValue=""
            onChange={handleForm}
          ></Input>
        </div>
        <Button color="success" type="button" onClick={crearRuta}>
          Guardar la ruta!
        </Button>
      </div>
    );
  }
};

export default LearningRoutes;
