import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { LoginLayoutComponent } from './login-layout/login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout/main-layout.component';
import { AuthGuard } from './_interceptor/auth.guard';
import { AnggotaCreateComponent } from './_pages/Anggota/anggota-create/anggota-create.component';
import { AnggotaListComponent } from './_pages/Anggota/anggota-list/anggota-list.component';
import { BukuCreateComponent } from './_pages/Buku/buku-create/buku-create.component';
import { BukuListComponent } from './_pages/Buku/buku-list/buku-list.component';

 
import { ForbiddenComponent } from './_pages/forbidden/forbidden.component';
import { HomeComponent } from './_pages/home/home.component';
import { LoginComponent } from './_pages/login/login.component';
import { NotFoundComponent } from './_pages/not-found/not-found.component';
import { PinjamCreateComponent } from './_pages/Pinjam/pinjam-create/pinjam-create.component';
import { PinjamListComponent } from './_pages/Pinjam/pinjam-list/pinjam-list.component';
 

 //antRoomDetailListComponent } from './_pages/Accomodation/occupant-room-detail-list/occupant-room-detail-list.component';

const routes: Routes = [
  {path:'',redirectTo:'selection',pathMatch:'full'},
  {path: '', component:MainLayoutComponent, 
  children:[
    // ,data:{allowedRoles:['Root','Admin']}
     
    {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
    {path:'BukuList',component:BukuListComponent,canActivate:[AuthGuard]},
    {path:'BukuCreate',component:BukuCreateComponent,canActivate:[AuthGuard]},
    {path:'BukuEdit/:id',component:BukuCreateComponent,canActivate:[AuthGuard]},
    {path:'PinjamList',component:PinjamListComponent,canActivate:[AuthGuard]},
    {path:'PinjamanCreate',component:PinjamCreateComponent,canActivate:[AuthGuard]},
    {path:'AnggotaCreate',component:AnggotaCreateComponent,canActivate:[AuthGuard]},
    {path:'AnggotaEdit/:id',component:AnggotaCreateComponent,canActivate:[AuthGuard]},
    {path:'AnggotaList',component:AnggotaListComponent,canActivate:[AuthGuard]},
    {path:'PinjamanEdit/:id',component:PinjamCreateComponent,canActivate:[AuthGuard]},
    /*
    {path:'dashboard',component:DashboardComponent,canActivate:[AuthGuard]},
    {path:'category',component:CategoryComponent,canActivate:[AuthGuard]},
    {path:'document',component:DocumentComponent,canActivate:[AuthGuard]},
    {path:'user',component:UserComponent,canActivate:[AuthGuard]},
    */
    /*
    {path:'AccDashboard',component:AccDashboardComponent,canActivate:[AuthGuard]},
    {path:'AccHistory',component:AccHistoryComponent,canActivate:[AuthGuard]},
    {path:'AccTasklist',component:AccTasklistComponent,canActivate:[AuthGuard]},
    { path: 'OccupantRoomDetailList', component: OccupantRoomDetailListComponent, canActivate:[AuthGuard]},
    {path:'TransHistory',component:TransHistoryComponent,canActivate:[AuthGuard]},
    {path:'TransTasklist',component:TransTasklistComponent,canActivate:[AuthGuard]},

    { path: 'TransCreateRequest', component: TransEditReviewComponent,canActivate:[AuthGuard] },
    { path: 'AccCreateRequest', component: AccEditReviewComponent,canActivate:[AuthGuard] },

    { path: 'TransReview/:id', component: TransEditReviewComponent,canActivate:[AuthGuard]  },
    { path: 'AccReview/:id', component: AccEditReviewComponent,canActivate:[AuthGuard]  },
    */
  ]
  },
  {path: 'login', component:LoginLayoutComponent,
  children:[
    {path:'',component:LoginComponent}
  ]},
  {path:'forbidden',component:ForbiddenComponent},
  {path:'not-found',component:NotFoundComponent},
  {path:'**',redirectTo:'not-found'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
