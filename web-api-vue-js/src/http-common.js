import Axios from 'axios';

const createAxios = Axios.create({
    baseURL: "http://localhost:5193" //link da nossa api
});

export default createAxios;