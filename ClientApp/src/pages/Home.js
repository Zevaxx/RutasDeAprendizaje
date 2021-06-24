import React from "react";
import { Testimonial, Image } from "./styles";
import FotoTop from "../images/Home/imagen1.jpg";
import FotoBody from "../images/Home/foto2.jpg";

export const Home = () => {
  return (
    <div>
      <h1>Rutas de apredizaje!</h1>
      <section id="header">
        <div class="container mt-5">
          <div class="row">
            <div class="col-md-6 col-sm-6">
              <div class="header-content-left">
                <Image src={FotoTop} />
              </div>
            </div>
            <div class="col-md-6 col-sm-6">
              <div class="header-content-right">
                <h1 class="display-4">Tienes algún curso en mente?</h1>
                <p class="mt-5">
                  Crea, comparte y aprende. Inspírate con profesionales
                  destacados del sector aprendiendo sus técnicas y secretos.
                  Aprende en comunidad, compartiendo ideas y proyectos con miles
                  de creativos del mundo. Aprende con los mejores. La Comunidad
                  Creativa.
                </p>
                {/* <a
                    href="#"
                    class="btn btn-outline-secondary header-btn btn-lg mt-2"
                  >
                    Más Información
                  </a> */}
              </div>
            </div>
          </div>
        </div>
      </section>

      <Testimonial>
        <div class="container">
          <p class="h2 mb-2">
            No te amargues con tu propio fracaso ni se lo cargues a otro.
            Acéptate ahora o seguirás justificándote como un niño. Recuerda que
            cualquier momento es bueno para comenzar y que ninguno es tan
            terrible para claudicar.
          </p>
          <p class="h4">- Pablo Neruda</p>
        </div>
      </Testimonial>

      <section id="info-one">
        <div class="container">
          <div class="row mt-5">
            <div class="col-md-6">
              <div class="info-left">
                <Image src={FotoBody} />
              </div>
            </div>
            <div class="col-md-6 my-auto">
              <div class="info-right">
                <p>
                  Estos son algunos de nuestros colavoradores más activos dentro
                  de nuestra ruta de aprendizaje.
                </p>
                {/* <a href="#" class="btn btn-outline-secondary btn-lg">
                    Ver Más
                  </a> */}
              </div>
            </div>
          </div>
        </div>
      </section>

      <section id="info-two">
        <div class="container">
          <div class="row my-5">
            <div class="col-md-6">
              <h2>¿Tienes dudas?</h2>
              <p>
                Escríbenos en el siguiente formulario y aclararemos todas tus
                consultas.
              </p>
            </div>
            <div class="col-md-6">
              <h2>¿Qué nos destaca?</h2>
              <p>
                En Rutas de Aprendizaje podrás realizar todos los cursos que
                sean de tu interés, la veces que quieras y cuando quieras, ya
                que todos nuestro colaboradores lo hacen con el fin de comparitr
                sus conocimientos. ¡Es Gratutito!
              </p>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};
