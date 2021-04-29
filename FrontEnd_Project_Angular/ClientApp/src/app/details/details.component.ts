import { Component, Inject } from '@angular/core';
import { DataService } from '../services/data.service';
import { formData } from '../models/formData';
import { IControlData } from '../interface/IControlData';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  providers: [DataService]
})

export class DetailsComponent {
  public data: formData[];
  public properties: IControlData[];
  public selected?: formData;
  
  constructor(private dataService: DataService) {

    this.dataService.getFields().subscribe((result: formData[]) => {
      this.data = result;
      this.selected = this.data[0];
      this.properties = this.selected.properties;
    }, error => console.error(error));
  }


  onSelect(detail: formData): void {
    this.selected = detail;
    this.properties = this.selected.properties;
  }

  updateData(item: formData) {
    this.dataService.updateData(item).subscribe((result: formData) => {
      this.selected = result;
      alert("Data saved successfully");
    }, error => console.error(error));
  }
}
