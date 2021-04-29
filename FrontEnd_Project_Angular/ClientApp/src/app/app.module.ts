import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DetailsComponent } from './details/details.component';
import { SummaryComponent } from './summary/summary.component';
import { DynamicFormComponent } from './dynamic-form/dynamic-form.component';
import { TextboxComponentComponent } from './textbox/textbox-component.component';
import { DataService } from './services/data.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DetailsComponent,
    SummaryComponent,
    DynamicFormComponent,
    TextboxComponentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: SummaryComponent, pathMatch: 'full' },
      { path: 'details', component: DetailsComponent }
    ])
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
