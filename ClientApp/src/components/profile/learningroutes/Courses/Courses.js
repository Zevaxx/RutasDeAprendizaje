import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import FetchData from "../../../../helpers/FetchData";

const Courses = () => {
  const { route } = useParams();
  const [ruta, setRuta] = useState({});

  useEffect(() => {
    const getRuta = async () => {
      const currentRoute = await FetchData(`api/Learningroutes/${route}`);
      setRuta(currentRoute);
    };
    getRuta();
  }, []);

  return (
    <div>
      Nombre :{ruta.lrName} <br></br>
      Descripción: {ruta.lrDiscipline}
    </div>
  );
};

export default Courses;
