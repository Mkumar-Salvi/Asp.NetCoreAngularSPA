import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Model } from '../models/model';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html'
})
export class SummaryComponent {
  public summary: Model[];
  public baseUrl: string = "http://localhost:61959/api/data";
  constructor(http: HttpClient) {
    http.get<Model[]>(this.baseUrl).subscribe(result => {
      this.summary = result;
    }, error => console.error(error));
  }
}
