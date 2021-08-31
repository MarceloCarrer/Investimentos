import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Transacao } from '../models/Transacao';

@Injectable()

export class TransacaoService {

  baseURL = 'https://localhost:5001/api/transacao';

  constructor(private http: HttpClient) { }

  public getTransacoesByAtivoId(ativoId: number): Observable<Transacao[]>{
    return this.http.get<Transacao[]>(`${this.baseURL}/${ativoId}`)
      .pipe(take(3));
  }

  public saveTransacao(ativoId: number, transacao: Transacao[]): Observable<Transacao[]>{
    return this.http.put<Transacao[]>(`${this.baseURL}/${ativoId}`, transacao)
      .pipe(take(3));
  }

  public deleteTransacao(ativoId: number, transacaoId: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${ativoId}/${transacaoId}`)
      .pipe(take(3));
  }

}
