import React from "react";
import { Image } from "./styles";
import FotoTop from "../images/Home/imagen1.jpg";
import FotoBody from "../images/Home/foto2.jpg";
import { FormattedMessage } from "react-intl";
import "../css/main.css";

export const Home = () => {
  return (
    <div>
      <h1>
        <FormattedMessage
          id="app.layout.title"
          defaultMessage="Rutas de aprendizaje"
        />
        !
      </h1>
      {/* buscador  */}
      <section className="intro">
        <div className="mask d-flex align-items-center h-100">
          <div className="container">
            <div className="card">
              <div className="card-body p-2">
                <div className="row">
                  <div className="col-12">
                    <div className="input-group">
                      <a
                        className="input-group-text text-body dropdown-toggle"
                        role="button"
                        id="dropdownMenuLink"
                        data-mdb-toggle="dropdown"
                        aria-expanded="false"
                      >
                        Categorías
                      </a>
                      <ul
                        className="dropdown-menu"
                        aria-labelledby="dropdownMenuLink"
                      >
                        <li>
                          <a className="dropdown-item" href="#">
                            Accessories
                          </a>
                        </li>
                      </ul>
                      <div className="form-outline flex-fill">
                        <input
                          type="search"
                          id="form1"
                          className="form-control form-control-lg"
                        />
                        <label className="form-label">Enter keywords?</label>
                      </div>
                      <button type="button" className="btn btn-success">
                        <i className="fas fa-search"></i>
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <section id="header">
        <div className="container mt-5">
          <div className="row">
            <div className="col-md-6 col-sm-6">
              <div className="header-content-left">
                <Image src={FotoTop} alt="fototop" />
              </div>
            </div>
            <div className="col-md-6 col-sm-6">
              <div className="header-content-right">
                <h1 className="display-4">
                  <FormattedMessage
                    id="app.home.title1"
                    defaultMessage="Do you have a course in mind?"
                  />
                </h1>
                <p className="mt-5">
                  <FormattedMessage
                    id="app.home.subtitle1"
                    defaultMessage="Create, share and learn. Get inspired by leading professionals in the sector learning their techniques and secrets. Learn in community, sharing ideas and projects with thousands of creatives around the world. Learn with the best. The Creative Community."
                  />
                </p>
                {/* <a
                    href="#"
                    className="btn btn-outline-secondary header-btn btn-lg mt-2"
                  >
                    Más Información
                  </a> */}
              </div>
            </div>
          </div>
        </div>
      </section>

      <section id="testimonial">
        <div className="container">
          <p className="h2 mb-2">
            <FormattedMessage id="app.home.cite" />
          </p>
          <p className="h4">- Pablo Neruda</p>
        </div>
      </section>

      <h1 className="display-5">Top de Rutas</h1>

      <div className="card-group">
        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/windows10.jpg"
            alt="Card 1"
          />
          <div className="card-body">
            <h5 className="card-title">Sistemas Operativos Windows</h5>
            <p className="card-text">
              Es el software principal o conjunto de programas de un sistema
              informático que gestiona los recursos
            </p>
          </div>
        </div>
        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/oracle.png"
            alt="Card 2"
          />
          <div className="card-body">
            <h5 className="card-title">Bases de Datos</h5>
            <p className="card-text">
              Una base de datos es un conjunto de datos pertenecientes a un
              mismo contexto y almacenados sistemáticamente para su posterior
              uso.
            </p>
          </div>
        </div>
        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/musica.jpg"
            alt="Card  3"
          />
          <div className="card-body">
            <h5 className="card-title">Artes Musicales</h5>
            <p className="card-text">
              El arte de crear y organizar sonidos y silencios respetando los
              principios fundamentales de la melodía, la armonía y el ritmo,
              mediante la intervención de complejos procesos psicoanímicos
            </p>
          </div>
        </div>
      </div>

      <br></br>
      <h1 className="display-5">Disciplinas</h1>

      <div className="card-group">
        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/informatica.jpg"
            alt="Card 1"
          />
          <div className="card-body">
            <h5 className="card-title">Informática</h5>
          </div>
        </div>

        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/artes.jpg"
            alt="Card  2"
          />
          <div className="card-body">
            <h5 className="card-title">Artes</h5>
          </div>
        </div>

        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/redes.jpg"
            alt="Card  3"
          />
          <div className="card-body">
            <h5 className="card-title">Redes</h5>
          </div>
        </div>

        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/rrhh.jpg"
            alt="Card  4"
          />
          <div className="card-body">
            <h5 className="card-title">Recursos Humanos</h5>
          </div>
        </div>
        <br></br>
        <div className="card">
          <img
            className="card-img-top"
            // src="../src/img/contabilidad.jpg"
            alt="Card  5"
          />
          <div className="card-body">
            <h5 className="card-title">Contabilidad</h5>
          </div>
        </div>
      </div>

      <section id="info-one">
        <div className="container">
          <div className="row mt-5">
            <div className="col-md-6">
              <div className="info-left">
                <Image src={FotoBody} alt="imgbody" />
              </div>
            </div>
            <div className="col-md-6 my-auto">
              <div className="info-right">
                <p>
                  <FormattedMessage id="app.home.subtitle2" />
                </p>
                {/* <a href="#" className="btn btn-outline-secondary btn-lg">
                    Ver Más
                  </a> */}
              </div>
            </div>
          </div>
        </div>
      </section>

      <section id="info-two">
        <div className="container">
          <div className="row my-5">
            <div className="col-md-12">
              <h2>
                <FormattedMessage id="app.home.title2" />
              </h2>
              <p>
                <FormattedMessage id="app.home.subtitle3" />
              </p>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};
