import axios from "axios";

const url = "https://localhost:7263/api";

export const getAllEmployees = async () => {
    try {
        const res = await axios.get(`${url}/employee`);
        return res.data
    }
    catch (e) { throw e };
}

export const getAllProfession = async () => {
    try {
        const res = await axios.get(`${url}/profession`);
        return res.data
    }
    catch (e) { throw e };
}