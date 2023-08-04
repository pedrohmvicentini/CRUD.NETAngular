import { Injectable } from '@angular/core';
import { Person } from '../models/person';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private url = "Person";

  constructor(private http: HttpClient) { }

  public getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(`${environment.apiUrl}/${this.url}`);
  }

  public UpdatePerson(person: Person): Observable<Person[]> {
    return this.http.put<Person[]>(`${environment.apiUrl}/${this.url}`, person);
  }

  public CreatePerson(person: Person): Observable<Person[]> {
    return this.http.post<Person[]>(`${environment.apiUrl}/${this.url}`, person);
  }

  public DeletePerson(person: Person): Observable<Person[]> {
    return this.http.delete<Person[]>(`${environment.apiUrl}/${this.url}/${person.id}`);
  }
}
