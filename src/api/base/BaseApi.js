import BaseAPIConfig from "../base/BaseApiConfig";

export default class BaseAPI {
  constructor() {
    this.controller = null;
  }// anth muon ti controller la cai gi vay
  /**
   * Phương thức lấy tất cả dữ liệu
   */
  getAll() {
    return BaseAPIConfig.get(`${this.controller}`); 
  }
  /**
   * Phương thức lấy dữ liệu theo id
   */
  get(id) {
    return BaseAPIConfig.get(`${this.controller}/${id}`);
  }
  /**
   * Hàm lấy dữ liệu phân trang
   * @param {*} payload
   */
  paging(payload) {
    return BaseAPIConfig.post(`${this.controller}/paging`, payload); 
  }                                                                   
  /**                                                                 
   * Hàm cập nhật dữ liệu
   * @param {*} id
   * @param {*} body
   */
  put(id, body) {
    return BaseAPIConfig.put(`${this.controller}/${id}`, body);
  }
  /**
   * Hàm cập thêm mới dữ liệu
   * @param {*} id
   * @param {*} body
   */
   post( body) {
    return BaseAPIConfig.post(`${this.controller}`, body);
  }
  /**
   * Hàm xóa bản ghi
   * @param {*} id
   */
  delete(id) {
    return BaseAPIConfig.delete(`${this.controller}/${id}`);
  }
}