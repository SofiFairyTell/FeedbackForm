import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';


import { NgxMaskModule } from "ngx-mask";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatCardModule } from '@angular/material/card'
import { MatFormFieldModule, MatInputModule, MatSelectModule, MatIconModule } from '@angular/material'
//import { MatTooltipModule } from '@angular/material/tooltip'

import { RecaptchaModule, RecaptchaFormsModule, RecaptchaLoaderService, RECAPTCHA_SETTINGS, RecaptchaSettings } from 'ng-recaptcha';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot({showMaskTyped: true}),
    BrowserAnimationsModule,

    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
   // MatTooltipModule,
    MatIconModule,
    RecaptchaFormsModule,
    RecaptchaModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
    //RouterModule.forRoot(appRoutes)
  ],
  providers: [{
    provide: RECAPTCHA_SETTINGS,
    useValue: { siteKey: 'FeedbackForm' } as RecaptchaSettings
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
