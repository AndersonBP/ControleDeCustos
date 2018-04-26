import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { DepartamentoComponent } from './departamento.component';
import { DepartamentoFormComponent } from '@app/pages/departamento/form/departamento-form.component';

const routes: Routes = [
  Route.withShell([
    { path: 'departamento', component: DepartamentoComponent, data: { title: extract('departamento') } },
    { path: 'departamento/novo', component: DepartamentoFormComponent, data: { title: extract('departamento') } }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class DepartamentoRoutingModule { }
