import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Model } from '../models/model';
import { formData } from '../models/formData';
import { IControlData } from '../interface/IControlData';

@Injectable()
export class DataService {
  public baseUrl: string = "http://localhost:61959/api/data/";
  filterProp: IControlData[] = [];
  constructor(private client: HttpClient) { }

  getData() {
    return this.client.get<Model[]>(this.baseUrl);
  }

  getFields() {
    return this.client.get<formData[]>(this.baseUrl + 'getfields');
  }

  updateData(item: formData) {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json');
    this.filterProp = item.properties;
    var param = {
      'samplingTime': item.samplingTime, 'ProjectName': this.getValue("projectname"),
      'ConstructionCount': this.getValue("constructioncount"),
      'IsConstructionCompleted': this.getValue("isconstructioncompleted"),
      'LengthOfTheRoad': this.getValue("lengthoftheroad")
    }
    return this.client.put(this.baseUrl, JSON.stringify(param), {
      headers: headers
    });
  }

  getValue(key) {
    let item = this.filterProp.find(x => x.fieldKey === key);
    if ( item === undefined) {
      return null;
    }
    return item.value;
  }
}
