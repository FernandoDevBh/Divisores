import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DivisoresComponent } from './divisores/divisores.component';

const routes: Routes = [
  { path: '', component: DivisoresComponent },
  { path: '**', component: DivisoresComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
