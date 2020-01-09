import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './Login/login.component';
import {BrandComponent } from './Brand/brand.component';
import { HomeComponent } from './Brand/home.component';
import { BrandListComponent } from './Brand/BrandList.component';
import { BrandAddComponent } from './Brand/brandadd.component';
import { BrandEditComponent } from './Brand/brandedit.component';
import {CarouselModule} from 'angular4-carousel';
import { WelcomeComponent } from './welcome/welcome.component';
import { BrandService } from './Service/Brand.Service';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    BrandComponent,
    HomeComponent,
    BrandListComponent,
    BrandAddComponent,
    BrandEditComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    CarouselModule,
    HttpClientModule,
    RouterModule.forRoot([
     {path:'login', component:LoginComponent},
     {path:'welcome', component:WelcomeComponent},
     {path:'', redirectTo:'welcome', pathMatch:'full'},
     {path:'brand', component:BrandComponent},
     {path:'home', component:HomeComponent},
     {path:'brandlist', component:BrandListComponent},
     {path:'brandadd', component:BrandAddComponent},
     {path:'brandedit', component:BrandEditComponent},
     {path:'brandedit/:id', component:BrandEditComponent}
    ])
  ],
  providers: [BrandService],
  bootstrap: [AppComponent]
})
export class AppModule { }
