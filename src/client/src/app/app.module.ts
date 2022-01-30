import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { DivisoresComponent } from './divisores/divisores.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoadingInterceptor } from './interceptors/loading';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    DivisoresComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSpinnerModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
