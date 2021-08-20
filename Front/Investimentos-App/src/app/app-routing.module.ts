import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AtivoDetalheComponent } from './components/ativo/ativo-detalhe/ativo-detalhe.component';
import { AtivoListaComponent } from './components/ativo/ativo-lista/ativo-lista.component';
import { AtivoComponent } from './components/ativo/ativo.component';

const routes: Routes = [
  {path: 'ativos', redirectTo: 'ativos/lista'},
  {
    path: 'ativos', component: AtivoComponent,
    children: [
      { path: 'detalhe/:id', component: AtivoDetalheComponent },
      { path: 'detalhe', component: AtivoDetalheComponent },
      { path: 'lista', component: AtivoListaComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
