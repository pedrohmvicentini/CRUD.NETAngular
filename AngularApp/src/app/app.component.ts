import { Component } from '@angular/core';
import { Person } from './models/person';
import { PersonService } from './services/person.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularApp';
  people: Person[] = [];
  personToEdit?: Person;

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.personService
      .getPeople()
      .subscribe((result: Person[]) => (this.people = result));
  }

  initNewContact() {
    this.personToEdit = new Person();
  }

  editContact(person: Person) {
    this.personToEdit = person;
  }
}
