import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateAccountComponent } from './create-account/create-account.component';
// import { HomeComponent } from './home/home.component';
// import { AboutComponent } from './about/about.component';
// import { ContactComponent } from './contact/contact.component';
import { LogInComponent } from './log-in/log-in.component';
//import { PortalComponent } from './portal/portal.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateAccountComponent,
    // HomeComponent,
    // AboutComponent,
    // ContactComponent,
    LogInComponent,
    //PortalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
