import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { FuncionarioRoutingModule } from './funcionario-routing-module';
import { FuncionarioComponent } from './funcionario.component';
import { ServicesModule } from '@app/core/services/service.module';
import { FuncionarioFormComponent } from '@app/pages/funcionario/form/funcionario-form.component';
import { ToastrModule } from 'ngx-toastr';
import { SelectModule } from 'ng-select';

@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    FuncionarioRoutingModule,
    ServicesModule,
    ToastrModule,
    FormsModule,
    SelectModule
  ],
  declarations: [
    FuncionarioComponent,
    FuncionarioFormComponent
  ]
})
export class FuncionarioModule { }
