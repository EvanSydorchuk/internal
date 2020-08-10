import http from "../http-common";

class CandidatesDataService {
  getAll(params) {
      console.log("get")
    return http.get("/Candidates", { params });
  }
}

export default new CandidatesDataService();