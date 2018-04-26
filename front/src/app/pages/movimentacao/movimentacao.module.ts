import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { MovimentacaoRoutingModule } from './Movimentacao-routing-module';
import { MovimentacaoComponent } from './Movimentacao.component';
import { ServicesModule } from '@app/core/services/service.module';
import { MovimentacaoFormComponent } from '@app/pages/Movimentacao/form/Movimentacao-form.component';
import { ToastrModule } from 'ngx-toastr';
import { SelectModule } from 'ng-select';

@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    MovimentacaoRoutingModule,
    ServicesModule,
    ToastrModule,
    FormsModule,
    SelectModule
  ],
  declarations: [
    MovimentacaoComponent,
    MovimentacaoFormComponent
  ]
})
export class MovimentacaoModule { }
