import authService from "../components/api-authorization/AuthorizeService";

const Fetch = async (link, method = "GET") => {
  const token = await authService.getAccessToken();
  fetch(link, {
    method: method,
    headers: !token ? {} : { Authorization: `Bearer ${token}` },
  })
    .then((res) => res.json())
    .then(
      (result) => {
        return result;
      },
      (error) => {
        return "error :" + error;
      }
    )
    .catch((error) => {
      return "error :" + error;
    });
};

export default Fetch;
