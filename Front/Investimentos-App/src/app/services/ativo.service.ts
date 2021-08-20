import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ativo } from '../models/Ativo';
import { take } from 'rxjs/operators';

@Injectable()

export class AtivoService {

  baseURL = 'https://localhost:5001/api/ativo';

  constructor(private http: HttpClient) { }

  public getAtivos(): Observable<Ativo[]>{
    return this.http.get<Ativo[]>(this.baseURL)
      .pipe(take(3));
  }

  public getAtivosBySigla(sigla: string): Observable<Ativo[]>{
    return this.http.get<Ativo[]>(`${this.baseURL}/sigla/${sigla}`)
      .pipe(take(3));
  }

  public getAtivoById(id: number): Observable<Ativo>{
    return this.http.get<Ativo>(`${this.baseURL}/${id}`)
      .pipe(take(3));
  }

  public postAtivo(ativo: Ativo): Observable<Ativo>{
    return this.http.post<Ativo>(this.baseURL, ativo)
      .pipe(take(3));
  }

  public putAtivo(id: number, ativo: Ativo): Observable<Ativo>{
    return this.http.put<Ativo>(`${this.baseURL}/${id}`, ativo)
      .pipe(take(3));
  }

  public deleteAtivo(id: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${id}`)
      .pipe(take(3));
  }

}
