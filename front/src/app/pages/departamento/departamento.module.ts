import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { DepartamentoRoutingModule } from './departamento-routing-module';
import { DepartamentoComponent } from './departamento.component';
import { ServicesModule } from '@app/core/services/service.module';
import { DepartamentoFormComponent } from '@app/pages/departamento/form/departamento-form.component';
import { ToastrModule } from 'ngx-toastr';
import { SelectModule } from 'ng-select';

@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    DepartamentoRoutingModule,
    ServicesModule,
    ToastrModule,
    FormsModule,
    SelectModule
  ],
  declarations: [
    DepartamentoComponent,
    DepartamentoFormComponent
  ]
})
export class DepartamentoModule { }
