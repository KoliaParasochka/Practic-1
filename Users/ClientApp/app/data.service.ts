import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './users';

@Injectable()
export class DataService {
    private url = "api/users";

    constructor(private http: HttpClient) {
    }

    // Getting the list of users from home controller.
    getUsers() {
        return this.http.get(this.url);
    }

    // Updating users.
    updateUser(user: User) {
        return this.http.put(this.url + '/' + user.id, user);
    }
}