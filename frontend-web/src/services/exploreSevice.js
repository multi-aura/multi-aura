import axios from "axios";

/**
 * Lấy danh sách emoji từ API.
 * @returns {Promise<Array>} Danh sách emoji.
 */
export const getEmoji = async () => {
  try {
    const response = await axios.get("https://emojihub.yurace.pro/api/all");
    if (response.data) {
      return response.data;
    }
    throw new Error("Không có dữ liệu trả về từ API");
  } catch (error) {
    console.error("Lỗi khi lấy emoji:", error);
    throw error;
  }
};

/**
 * Lấy địa chỉ từ tọa độ (latitude và longitude).
 * @param {number} lat - Latitude.
 * @param {number} lng - Longitude.
 * @returns {Promise<string>} Địa chỉ đã loại bỏ mã bưu chính.
 */
export const getAddressFromCoordinates = async (lat, lng) => {
  try {
    const response = await axios.get(
      `https://nominatim.openstreetmap.org/reverse?format=json&lat=${lat}&lon=${lng}`
    );

    if (response.data && response.data.display_name) {
      let location = response.data.display_name;

      // Loại bỏ mã bưu chính (nếu có)
      const addressParts = location.split(", ");
      const filteredParts = addressParts.filter(
        (part) => !/^\d{5,}$/.test(part) // Loại bỏ các phần chỉ chứa số
      );
      location = filteredParts.join(", ");

      return location || "Không tìm thấy địa chỉ";
    } else {
      return "Không tìm thấy địa chỉ";
    }
  } catch (error) {
    console.error("Lỗi khi gọi API Nominatim:", error);
    throw new Error("Không thể lấy địa chỉ cụ thể");
  }
};
