import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ServiceWorkerModule } from '@angular/service-worker';
import { TranslateModule } from '@ngx-translate/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginationModule } from 'ngx-bootstrap';
import { HttpModule } from '@angular/http';

import { environment } from '@env/environment';
import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { HomeModule } from './pages/home/home.module';
import { FuncionarioModule } from './pages/funcionario/funcionario.module';
import { AboutModule } from './about/about.module';
import { LoginModule } from './login/login.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ServicesModule } from '@app/core/services/service.module';
import { ToastrModule } from 'ngx-toastr';
import { DepartamentoModule } from '@app/pages/departamento/departamento.module';
import { MovimentacaoModule } from '@app/pages/movimentacao/movimentacao.module';

@NgModule({
  imports: [
    BrowserModule,
    ServiceWorkerModule.register('/ngsw-worker.js', { enabled: environment.production }),
    FormsModule,
    HttpModule,
    HttpClientModule,
    TranslateModule.forRoot(),
    NgbModule.forRoot(),
    CoreModule,
    SharedModule,
    HomeModule,
    FuncionarioModule,
    DepartamentoModule,
    MovimentacaoModule,
    ServicesModule,
    AboutModule,
    LoginModule,
    AppRoutingModule,
    PaginationModule.forRoot(),
    ToastrModule
    
      ],
  declarations: [AppComponent],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
