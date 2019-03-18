import { Component, OnInit, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  private events: Event[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl);
        http.get<Event[]>(baseUrl + 'api/Event/Index').subscribe(result => {
          this.events = result;
          console.log(this.events);
        }, error => console.error(error));
   };

  ngOnInit() {
  }



}


interface Event {
  Id: number;
  Name: string; 
  StartTime: Date;
  EndTime: Date;
  EstimatedBudget: number;
  Description: string;
  LocationId: number;
  EventTypeId: number;
  EventImage: FormData;
  ImageUri: string;
}
