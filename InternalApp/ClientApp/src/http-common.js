import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:44302/api/",
  headers: {
    "Content-type": "application/json"
  }
});