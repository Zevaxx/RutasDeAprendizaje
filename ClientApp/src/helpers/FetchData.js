import authService from "../components/api-authorization/AuthorizeService";

const FetchData = async (link, body = null, method = "GET") => {
  console.log("hola fetch");
  const token = await authService.getAccessToken();
  console.log(token);
  fetch(link, {
    method: method,
      headers: !token ? {} : { Authorization: `Bearer ${token}` }
     // body: body && JSON.stringify(body),
  })
    .then((res) => res.json())
    .then(
        (result) => {
            console.log("okey")
            console.log(result)
        return result;
      },
        (error) => {
            console.log("error :" + JSON.stringify(error))
            
        return "error :" + error;
      }
    )
    .catch((error) => {
      return "error :" + error;
    });
};

export default FetchData;
