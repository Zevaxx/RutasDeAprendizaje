import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import FetchData from "../helpers/FetchData";
import { Jumbotron, ListGroup, ListGroupItem } from "reactstrap";

const LearningRoutesPublic = () => {
  const { route } = useParams();
  const [ruta, setRuta] = useState({});
  // const [reload, setReload] = useState(false);

  useEffect(() => {
    const getRuta = async () => {
      const currentRoute = await FetchData(`api/Learningroutes/${route}`);
      setRuta(currentRoute);
    };
    getRuta();
  }, []);

  return (
    <div>
      <h1>Nombre :{ruta.lrName}</h1> <br></br>
      <h2>Descripción: {ruta.lrDiscipline}</h2>
      <div>
        <h3>Cursos en la ruta </h3>
        <ul>
          {ruta.courses?.length == 0 ? (
            <div> Esta ruta no tiene cursos, vuelve pronto 🐱‍💻! </div>
          ) : (
            ruta.courses?.map((course) => (
              <ListGroup key={course.courseId}>
                <ListGroupItem>
                  <h2>{course.courseName}</h2>
                  <p>{course.courseDescripcion}</p>
                  <p>{course.courseName}</p>
                </ListGroupItem>
              </ListGroup>
            ))
          )}
        </ul>
      </div>
    </div>
  );
};

export default LearningRoutesPublic;
