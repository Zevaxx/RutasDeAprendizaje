import React from "react";
// import md5 from "md5";
import "bootstrap/dist/css/bootstrap.css";
// import Cookies from "universal-cookie";
import "../css/Login.css";

const Login = () => {
  return (
    <div className="containerPrincipal">
      <div className="containerLogin">
        <div className="form-group">
          <label>Usuario: </label>
          <br />
          <input
            type="text"
            className="form-control"
            name="username"
            // onChange={handleChange}
          />
          <br />
          <label>Contraseña: </label>
          <br />
          <input
            type="password"
            className="form-control"
            name="password"
            // onChange={handleChange}
          />
          <br />
          {/* <button className="btn btn-primary" onClick={()=>iniciarSesion()}>Iniciar Sesión</button> */}
        </div>
      </div>
    </div>
  );
};

export default Login;
