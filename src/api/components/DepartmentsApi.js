import BaseAPI from "@/api/base/BaseApi.js";

class DepartmentAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "api/Department";
  }
}

export default new DepartmentAPI(); 