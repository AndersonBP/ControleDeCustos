import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { MovimentacaoComponent } from './Movimentacao.component';
import { MovimentacaoFormComponent } from '@app/pages/Movimentacao/form/Movimentacao-form.component';

const routes: Routes = [
  Route.withShell([
    { path: 'movimentacao', component: MovimentacaoComponent, data: { title: extract('movimentacao') } },
    { path: 'movimentacao/novo', component: MovimentacaoFormComponent, data: { title: extract('movimentacao') } }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class MovimentacaoRoutingModule { }
