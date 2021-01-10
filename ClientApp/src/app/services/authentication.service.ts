import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { LocalUser } from '../models/LocalUser';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private readonly usersApiURL = window.origin + '/api/users';

    private currentUserSubject: BehaviorSubject<LocalUser>;
    public currentUser: Observable<LocalUser>;

    constructor(private readonly client: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<LocalUser>(
            JSON.parse(localStorage.getItem('currentUser') as string)
        );
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): LocalUser {
        return this.currentUserSubject.value;
    }

    public login(email: string, password: string): Observable<any> {
        return this.client.post<LocalUser>(`${this.usersApiURL}/login`, { email, password })
            .pipe(map((user) => {
                // Set the current LocalUser object in local storage
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    public logout(): void {
        // remove user from local storage and set current user to null
        localStorage.removeItem('currentUser');
        // @ts-ignore
        this.currentUserSubject.next(null);
    }
}
