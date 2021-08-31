import { Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Ativo } from 'src/app/models/Ativo';
import { Transacao } from 'src/app/models/Transacao';
import { AtivoService } from 'src/app/services/ativo.service';
import { TransacaoService } from 'src/app/services/transacao.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-ativo-detalhe',
  templateUrl: './ativo-detalhe.component.html',
  styleUrls: ['./ativo-detalhe.component.scss']
})
export class AtivoDetalheComponent implements OnInit {

  public form!: FormGroup;
  public modalRef = {} as BsModalRef;
  public ativo = {} as Ativo;
  public modoSalvar: string = 'post';
  public ativoId: number;
  public modalref: BsModalRef;
  public transacaoAtual = {id: 0, dataCompra: '', indice: 0};
  public mostrarTransacao: boolean = false;
  public mostrarAtivo: boolean = true;
  public ocultar: boolean = true;


  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private localeService: BsLocaleService,
    private activateRouter: ActivatedRoute,
    private ativoService: AtivoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: Router,
    private transacaoService: TransacaoService,
    private location: Location,)
    {
      this.localeService.use("pt-br");
    }

  public ngOnInit() {
    this.validation();
    this.carregarAtivo();
  }

  public get modoEditar(): boolean {
    return this.modoSalvar === 'put';
  }

  public get transacoes(): FormArray {
    return this.form.get('transacoes') as FormArray;
  }

  public get fv(): any {
    return this.form.controls;
  }

  public validation(): void{
    this.form = this.fb.group(
      {
        sigla: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(4)]],
        nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
        tipo: ['', Validators.required],
        setor: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
        imagem: [''],
        transacoes: this.fb.array([])
      });
  }

  public adicionarTransacao(): void {
    this.transacoes.push(this.criarTransacao({id: 0} as Transacao));
  }

  public criarTransacao(transacao: Transacao): FormGroup {
    return this.fb.group({
      id: [transacao.id],
      dataCompra: [transacao.dataCompra, Validators.required],
      valorCompra: [transacao.valorCompra, Validators.required],
      qtdCompra: [transacao.qtdCompra, Validators.required],
      valorTotalCompra: [(transacao.valorCompra * transacao.qtdCompra).toFixed(2)],
      dataVenda: [transacao.dataVenda],
      valorVenda: [transacao.valorVenda],
      qtdVenda: [transacao.qtdVenda],
      valorTotalVenda: [(transacao.valorVenda * transacao.qtdVenda).toFixed(2)],
      lucroPorc: [transacao.valorVenda == null || transacao.valorVenda <= 0 ? 0 : (((transacao.valorVenda/transacao.valorCompra)-1)*100).toFixed(2)],
      lucro: [((transacao.valorVenda - transacao.valorCompra) * transacao.qtdVenda).toFixed(2)],
      imposto: [((((transacao.valorVenda - transacao.valorCompra) * transacao.qtdVenda)/100)*15).toFixed(2)],
      lucroLiquido: [transacao.valorCompra > transacao.valorVenda ? 0 : (((transacao.valorVenda - transacao.valorCompra) * transacao.qtdVenda) - ((((transacao.valorVenda - transacao.valorCompra) * transacao.qtdVenda)/100)*15)).toFixed(2)],
      retornoLiquido: [transacao.valorCompra > transacao.valorVenda ? 0 : ((transacao.valorVenda * transacao.qtdVenda) - ((((transacao.valorVenda - transacao.valorCompra) * transacao.qtdVenda)/100)*15)).toFixed(2)],
      vendido: [transacao.vendido],
    })
  }

  // public mudarValorData(value: Date, indice: number, campo: string): void {
  //   this.transacoes.value[indice][campo] = value;
  // }

  public retornaTituloAT(nome: string): string {
    return nome === null || nome === '' ? 'Novo Ativo' : nome;
  }

  public retornaTituloTR(nome: string): string {
    return nome === null || nome === '' ? 'Nova Transação' : nome;
  }

  public ocultarAtivo(): void{
    this.mostrarAtivo = ! this.mostrarAtivo;
  }

  public ocultarTransacao(): void{
    this.mostrarTransacao = ! this.mostrarTransacao;
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return {'is-invalid': campoForm.errors && campoForm.touched};
  }

  // public get bsConfig(): any {
  //   return {
  //       isAnimated: true,
  //       adaptivePosition: true,
  //       dateInputFormat: 'DD/MM/YYYY',
  //       containerClass: 'theme-default',
  //       showWeekNumbers: false
  //   };
  // }

  public carregarAtivo(): void {
    this.ativoId = +this.activateRouter.snapshot.paramMap.get('id');
    if (this.ativoId !== null && this.ativoId !== 0) {
      this.spinner.show();
      this.mostrarAtivo = false;
      this.ocultar = false;
      this.modoSalvar = 'put';

      this.ativoService.getAtivoById(this.ativoId).subscribe(
        (ativo: Ativo) => {
          this.ativo = { ... ativo};
          this.form.patchValue(this.ativo);
          this.ativo.transacao.forEach(tr => {
            this.transacoes.push(this.criarTransacao(tr));
          })
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Ativo não carregado.', 'Erro!');
          console.error(error);
        },
        () => this.spinner.hide(),
      );
    }
  }

  public salvarAtivo(): void {
    this.spinner.show();
    if (this.form.valid) {
      if (this.modoSalvar === 'post') {
        this.ativo = { ... this.form.value};
        this.ativoService.postAtivo(this.ativo).subscribe(
          (ativoRetorno: Ativo) => {
              this.ocultar = false;
              this.toastr.success('Ativo salvo.', 'Sucesso!');
              this.router.navigate([`ativos/detalhe/${ativoRetorno.id}`])
          },
          (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toastr.error('Não foi possível salvar ativo.', 'Erro!');
          },
          () => this.spinner.hide()
        );
      } else{
        this.ativo = {id: this.ativo.id, ... this.form.value};
        this.ativoService.putAtivo(this.ativo.id, this.ativo).subscribe(
          () => this.toastr.success('Ativo atualizado.', 'Sucesso!'),
          (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toastr.error('Não foi possível atualizar ativo.', 'Erro!');
          },
          () => this.spinner.hide()
        );
      }
    }
  }

  public salvarTransacao(): void {
    if(this.form.controls.transacoes.valid){
      this.spinner.show();
      this.transacaoService.saveTransacao(this.ativoId, this.form.value.transacoes)
        .subscribe(
          () => {
            this.toastr.success('Transações salvas.', 'Sucesso!');
            //location.reload();
          },
          (error: any) => {
            this.toastr.error('Não foi possível salvar a transação.', 'Erro!');
          }
        ).add(() => this.spinner.hide());
    }
  }

  public removerTransacao(template: TemplateRef<any>, indice: number) : void {

    this.transacaoAtual.id = this.transacoes.get(indice + '.id').value;
    this.transacaoAtual.dataCompra = this.transacoes.get(indice + '.dataCompra').value;
    this.transacaoAtual.indice = indice;

    this.modalRef = this.modalService.show(template, {class:'modal-sm'})
  }

  public openModal(templateTR: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(templateTR, {class: 'modal-sm'});
  }

  public confirmDeleteTR(): void {
    this.modalRef.hide();
    this.spinner.show();

    this.transacaoService.deleteTransacao(this.ativoId, this.transacaoAtual.id)
      .subscribe(
        () => {
          this.toastr.success(`Transação do dia ${this.transacaoAtual.dataCompra} deletada.`, 'Sucesso!');
          this.transacoes.removeAt(this.transacaoAtual.indice);
        },
        (error: any) => {
          this.toastr.error(`Não foi possível deletar a transação do dia ${this.transacaoAtual.dataCompra}.`, 'Erro!');
        }
      ).add(() => this.spinner.hide());
  }

  public declineDeleteTR(): void {
    this.modalRef.hide();
  }

  public confirm(): void {
    this.form.reset();
    this.modalRef.hide();
  }

  public decline(): void {
    this.modalRef.hide();
  }

}
