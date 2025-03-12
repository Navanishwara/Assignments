import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './components/app-header/app-header.component';
import { AppFooterComponent } from './components/app-footer/app-footer.component';
import { AppContentComponent } from './components/app-content/app-content.component';
import { CandidatesListComponent } from './components/candidates-list/candidates-list.component';
import { AddCandidatesComponent } from './components/add-candidates/add-candidates.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule, Routes } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { GetCandidatesByNameComponent } from './components/get-candidates-by-name/get-candidates-by-name.component';
import { GetCandidatesByemailComponent } from './components/get-candidates-byemail/get-candidates-byemail.component';
import { GetCandidatesByphoneComponent } from './components/get-candidates-byphone/get-candidates-byphone.component';



const routes : Routes =[
  {
    path:"candidate-list",
    component: CandidatesListComponent,
   
  },
  {
    path:"add-candidates",
    component : AddCandidatesComponent,
  
  },
  {
    path :"GetByName",
    component: GetCandidatesByNameComponent
  },
  {
    path:"GetByEmail",
    component:GetCandidatesByemailComponent
  },
  {
    path:"GetByPhone",
    component:GetCandidatesByphoneComponent
  },
  {
    path :"home/:id",
    component: CandidatesListComponent
  },
 
  
  {
    path: '',
    redirectTo:'/home',
    pathMatch:'full'
    
  }
];
@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    AppFooterComponent,
    AppContentComponent,
    CandidatesListComponent,
    AddCandidatesComponent,
    GetCandidatesByNameComponent,
    GetCandidatesByemailComponent,
    GetCandidatesByphoneComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  RouterModule.forRoot(routes)
  ],
 
  bootstrap: [AppComponent]
})
export class AppModule { }

