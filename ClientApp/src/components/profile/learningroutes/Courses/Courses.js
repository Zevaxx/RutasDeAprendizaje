import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import FetchData from "../../../../helpers/FetchData";
import { ListGroup, ListGroupItem, Button, Input } from "reactstrap";
import authService from "../../..//api-authorization/AuthorizeService";

const Courses = () => {
  const { route } = useParams();
  const [ruta, setRuta] = useState({});
  const [reload, setReload] = useState(false);
  const [nuevoCurso, setNuevoCurso] = useState({
    routeId: route,
    courseName: "",
    courseDescripcion: "",
    courseLength: "",
  });

  useEffect(() => {
    const getRuta = async () => {
      const currentRoute = await FetchData(`api/Learningroutes/${route}`);
      setRuta(currentRoute);
    };
    getRuta();
  }, [reload]);

  const createCourseForm = (event) => {
    const value = event.target.value;
    setNuevoCurso({ ...nuevoCurso, [event.target.name]: value });
    console.log(nuevoCurso);
  };

  const crearCourse = async (event) => {
    event.preventDefault();
    const user = await authService.getUser();
    const dataform = { ...nuevoCurso, userId: user.sub };
    console.log("esto es lo que se está pasando");
    console.log(dataform);
    await FetchData("api/Courses", "POST", dataform);
    setNuevoCurso({
      routeId: route,
    });
    setReload(!reload);
  };

  return (
    <div>
      <h1>Nombre :{ruta.lrName}</h1> <br></br>
      <h1>Descripción: {ruta.lrDiscipline}</h1>
      <div>
        <h2>Cursos en la ruta </h2>
        <ul>
          {ruta.courses?.length == 0 ? (
            <div> Esta ruta no tiene cursos, Crealos! </div>
          ) : (
            ruta.courses?.map((course) => (
              <li key={course.courseId}>
                <h2> {course.courseName}</h2>
                <p>{course.courseDescripcion}</p>
                <p>{course.courseName}</p>
              </li>
            ))
          )}
        </ul>
      </div>
      <div>
        <h2>Crear Cursos</h2>
        <h3>Crea tu nuevo curso acá!</h3>
        <div>
          <form onSubmit={crearCourse}>
            <div>
              Nombre del curso
              <Input
                type="text"
                name="courseName"
                value={nuevoCurso.courseName}
                onChange={createCourseForm}
                required
              ></Input>
            </div>
            <div>
              Description Descripción
              <Input
                type="text"
                name="courseDescripcion"
                value={nuevoCurso.courseDescripcion}
                onChange={createCourseForm}
                required
              ></Input>
            </div>
            <div>
              Largo del curso
              <Input
                type="number"
                name="courseLength"
                value={nuevoCurso.courseLength}
                onChange={createCourseForm}
                required
              ></Input>
            </div>
            <Button type="submit" color="success">
              Guarda tu curso! 🐱‍💻
            </Button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Courses;
