import React, { useEffect, useState } from "react";
import { Image } from "./styles";
import FotoTop from "../images/Home/imagen1.jpg";
import FotoBody from "../images/Home/foto2.jpg";
import { FormattedMessage } from "react-intl";
import "../css/main.css";
import FetchData from "../helpers/FetchData";
import {
  Pagination,
  PaginationItem,
  PaginationLink,
  Button,
  ListGroup,
  ListGroupItem,
} from "reactstrap";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from "@fortawesome/free-solid-svg-icons";

export const Home = () => {
  const [topRutas, setTopRutas] = useState({});
  const [reload, setReload] = useState(false);
  const [search, setSearch] = useState(false);
  const [loading, setLoading] = useState(true);
  const [pageTopRutas, setpageTopRutas] = useState(1);
  const [findedRoutes, setFindedRoutes] = useState([]);
  const [keyword, setKeyWord] = useState("");

  useEffect(() => {
    const fetchTopRutas = async () => {
      const getTopRutas = await FetchData(
        `api/Learningroutes/?page=${pageTopRutas}`
      );
      setTopRutas(getTopRutas);
    };
    fetchTopRutas(topRutas);

    setLoading(false);
  }, [reload]);

  useEffect(() => {
    const fetchSearchRutas = async () => {
      const getSearchRutas = await FetchData(
        `Learningroutes/search/${keyword}`
      );
      setFindedRoutes(getSearchRutas);
    };
    fetchSearchRutas();
    const rutesToShow = findedRoutes
      ? findedRoutes
      : [false, "no se encontraron rutas 😢"];

    setFindedRoutes(rutesToShow);
  }, [search]);

  const newPageTopRutes = (page) => {
    setpageTopRutas(page);
    setReload(!reload);
  };

  const changeHandeler = (e) => {
    setKeyWord(e.target.value);
    setSearch(!search);
  };

  if (loading == true) return <div> Loading ...</div>;
  if (loading == false)
    return (
      <div>
        <h1 className="mb-4">
          <FormattedMessage
            id="app.layout.title"
            defaultMessage="Rutas de aprendizaje"
          />
          !
        </h1>
        {/* buscador  */}
        <section className="intro">
          <div className="mask d-flex align-items-center ">
            <div className="container">
              <div className="row justify-content-center">
                <div className="col-8">
                  <div className="input-group">
                    {/* <a
                          className="input-group-text text-body dropdown-toggle"
                          role="button"
                          id="dropdownMenuLink"
                          data-mdb-toggle="dropdown"
                          aria-expanded="false"
                        >
                          Categorías
                        </a> */}
                    <ul
                      className="dropdown-menu"
                      aria-labelledby="dropdownMenuLink"
                    >
                      {/* <li>
                        <a className="dropdown-item" href="#">
                          Accessories
                        </a>
                      </li> */}
                    </ul>
                    <div className="form-outline flex-fill position-relative">
                      <input
                        type="search"
                        placeholder="Quieres aprender algo? Encuentralo! 🐱‍👤"
                        id="SearchRute"
                        className="form-control form-control-lg "
                        onChange={changeHandeler}
                        value={keyword}
                      />
                      {/* {findedRoutes == false ? (
                        <ListGroup>
                          <ListGroupItem>
                            <h3>"no se encontraron rutas 😢"</h3>
                          </ListGroupItem>
                        </ListGroup>
                      ) : (
                        findedRoutes?.map((rute) => (
                          <ListGroup>
                            <ListGroupItem>
                              <h2>1</h2>
                              <p>2</p>
                            </ListGroupItem>
                          </ListGroup>
                        ))
                      )} */}
                      {/* <label className="form-label">Enter keywords</label> */}
                    </div>
                  </div>
                </div>
                <div className="col-2">
                  <Button type="button" className="" color="success">
                    <FontAwesomeIcon icon={faSearch}></FontAwesomeIcon>
                  </Button>
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
        {topRutas.learningrutes?.length === 0 ? (
          <div> No hay rutas por ahora</div>
        ) : (
          <div>
            <div className="card-group d-flex">
              {topRutas.learningrutes?.map((lr) => (
                <div className="card" key={lr.routeId}>
                  <div className="card-body">
                    <h5 className="card-title">{lr.routeName}</h5>
                    <p className="card-text">{lr.routeDescription}</p>
                    <Button
                      tag={Link}
                      color="success"
                      to={`/ruta/${lr.routeId}`}
                    >
                      <FormattedMessage id="app.profile.seeroute" />
                    </Button>
                  </div>
                </div>
              ))}
            </div>
            <div className="d-block m-auto">
              <Pagination aria-label="Page navigation example">
                <PaginationItem>
                  {topRutas.paginations?.prevPage > 0 ? (
                    <PaginationLink
                      previous
                      onClick={() =>
                        newPageTopRutes(topRutas.paginations.prevPage)
                      }
                    />
                  ) : (
                    ""
                  )}
                </PaginationItem>
                {/* <PaginationItem>
                <PaginationLink href="#">1</PaginationLink>
              </PaginationItem> */}
                <PaginationItem>
                  <PaginationLink
                  // activeonClick={() =>
                  //   newPageTopRutes(topRutas.paginations?.nextPage)
                  // }
                  >
                    <div>{topRutas.paginations?.page}</div>
                  </PaginationLink>
                </PaginationItem>
                {/* <PaginationItem>
                 <PaginationLink href="#">3</PaginationLink>
               </PaginationItem> */}
                {console.log(topRutas.paginations)}
                {topRutas.paginations?.page < topRutas.paginations?.lastPage ? (
                  <PaginationItem>
                    <PaginationLink
                      next
                      onClick={() =>
                        newPageTopRutes(topRutas.paginations?.nextPage)
                      }
                    ></PaginationLink>
                  </PaginationItem>
                ) : (
                  ""
                )}
              </Pagination>
            </div>
          </div>
        )}

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
