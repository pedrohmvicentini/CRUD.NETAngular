import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Person } from 'src/app/models/person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.css']
})
export class EditPersonComponent implements OnInit {
  @Input() person?: Person;
  @Output() peopleUpdated = new EventEmitter<Person[]>();

  constructor(private personService: PersonService) { }

  ngOnInit(): void {

  }

  updatePerson(person: Person) {
    this.personService
      .UpdatePerson(person)
      .subscribe((people) => this.peopleUpdated.emit(people));
  }

  deletePerson(person: Person) {
    this.personService
      .DeletePerson(person)
      .subscribe((people) => this.peopleUpdated.emit(people));
  }

  createPerson(person: Person) {
    this.personService
      .CreatePerson(person)
      .subscribe((people) => this.peopleUpdated.emit(people));
  }

}
