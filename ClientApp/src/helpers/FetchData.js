import authService from "../components/api-authorization/AuthorizeService";

const FetchData = async (link, body = null, method = "GET") => {
  console.log("hola fetch");
  const token = await authService.getAccessToken();
  let petition = {
    method: method,
    headers: !token ? {} : { Authorization: `Bearer ${token}` },
  };

  if (method != "GET" || method != "DELETE") {
    petition.headers["Content-Type"] = "application/json";
    petition.body = JSON.stringify(body);
  }
  // console.log(petition);
  return fetch(link, petition)
    .then((res) => res.json())
    .then(
      (result) => {
        console.log(result);
        return result;
      },
      (error) => {
        console.log("error :" + JSON.stringify(error));
        return "error :" + error;
      }
    )
    .catch((error) => {
      return "error :" + error;
    });
};

export default FetchData;
