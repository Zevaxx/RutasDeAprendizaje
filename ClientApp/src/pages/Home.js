import React from "react";
import { Testimonial, Image } from "./styles";
import FotoTop from "../images/Home/imagen1.jpg";
import FotoBody from "../images/Home/foto2.jpg";
import { FormattedMessage } from "react-intl";

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
      <section id="header">
        <div className="container mt-5">
          <div className="row">
            <div className="col-md-6 col-sm-6">
              <div className="header-content-left">
                <Image src={FotoTop} />
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

      <Testimonial>
        <div className="container">
          <p className="h2 mb-2">
            <FormattedMessage id="app.home.cite" />
          </p>
          <p className="h4">- Pablo Neruda</p>
        </div>
      </Testimonial>

      <section id="info-one">
        <div className="container">
          <div className="row mt-5">
            <div className="col-md-6">
              <div className="info-left">
                <Image src={FotoBody} />
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
