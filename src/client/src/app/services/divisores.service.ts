import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Divisores } from '../models/divisores';
import { BaseService } from './base.services';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class DivisoresService extends BaseService {

  constructor(http: HttpClient) { super(http) }

  getDivisores(numero: number) {
    return this.http
      .get(this.createUrl(`divisores/${numero}`))
      .pipe(map((response: any) => {
        const divisores = {
          numero : response.numero,
          itensDivisores: []
        };        
        for (let i = 0; i < response.numerosDivisores.length; i++) {
          const itemDivisor = {
            numeroDivisor: response.numerosDivisores[i],
            numeroPrimo: response.divisoresPrimos[i] ?? undefined
          };
          divisores.itensDivisores.push(itemDivisor);
        }
        return divisores;
      }));
  }
}
