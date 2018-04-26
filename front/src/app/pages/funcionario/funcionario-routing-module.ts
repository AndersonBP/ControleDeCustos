import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { FuncionarioComponent } from './funcionario.component';
import { FuncionarioFormComponent } from '@app/pages/funcionario/form/funcionario-form.component';

const routes: Routes = [
  Route.withShell([
    { path: 'funcionario', component: FuncionarioComponent, data: { title: extract('funcionario') } },
    { path: 'funcionario/novo', component: FuncionarioFormComponent, data: { title: extract('funcionario') } }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class FuncionarioRoutingModule { }
