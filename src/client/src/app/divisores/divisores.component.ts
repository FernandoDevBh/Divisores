import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Divisores } from '../models/divisores';
import { DivisoresService } from '../services/divisores.service';

@Component({
  selector: 'app-divisores',
  templateUrl: './divisores.component.html'
})
export class DivisoresComponent implements OnInit {
  numero: number;
  divisores: Divisores;
  divisorForm: FormGroup;

  constructor(private divisoresService: DivisoresService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.divisorForm = this.fb.group({
      numero:[undefined, [Validators.required, this.verificaSeInteiro(), this.verificaSeMaiorZero()]]
    });
  }

  verificaSeInteiro(): ValidatorFn {
    return (control: AbstractControl) : ValidationErrors | null => {      
      return Number.isInteger(control.value) ?  control.value  : { numeroInvalido: true };
    } 
  }

  verificaSeMaiorZero() : ValidatorFn {
    return (control: AbstractControl) : ValidationErrors | null => {
      if(Number.parseInt(control.value) <= 0) {
        return { menorQueZero: true };
      }      

      return control.value;
    }
  }

  gerarDivisores(){
    if(this.divisorForm.valid){
      this.divisoresService.getDivisores(this.divisorForm.value.numero).subscribe(resultado => {
        this.divisores = resultado;
      });
    }    
  }
}
