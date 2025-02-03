import http from '@/http-common';

export default class LoginService {
    async Login(data){
        let response = await http.post(`api/v1/auth?username=${data.username}&password=${data.password}`); //passando os dados inseridos pelo user, para api pelo link
        console.log(response);
        return response.data;
    }
}