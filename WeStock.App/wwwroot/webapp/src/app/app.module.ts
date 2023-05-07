import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { ChatComponent } from './chat/chat.component';
import { SignupComponent } from './signup/signup.component';
import { AuthService } from './auth.service';
import { ExceptionService } from './exception.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthService, ExceptionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
