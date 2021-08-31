import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Ativo } from 'src/app/models/Ativo';
import { AtivoService } from 'src/app/services/ativo.service';

@Component({
  selector: 'app-ativo-lista',
  templateUrl: './ativo-lista.component.html',
  styleUrls: ['./ativo-lista.component.scss']
})
export class AtivoListaComponent implements OnInit {

  public modalRef = {} as BsModalRef;
  public ativos: Ativo[] = [];
  public ativosFiltrados:  Ativo[] = [];
  public mostrarImagem: boolean = false;
  public ativoSigla = {} as string;
  public ativoId = {} as number;

  private _filtorLista: string = '';

  public get filtroLista(): string{
    return this._filtorLista;
  }

  public set filtroLista(value: string){
    this._filtorLista = value;
    this.ativosFiltrados = this.filtroLista ? this.filtrarAtivos(this.filtroLista) : this.ativos;
  }

  public filtrarAtivos(filtrarPor: string): Ativo[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.ativos.filter(
      (ativo: any) => ativo.sigla.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                      ativo.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private ativoService: AtivoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router,
    ) { }

    public ngOnInit(): void {
      this.spinner.show();
      this.getAtivos();
    }

    public getAtivos(): void{
      this.ativoService.getAtivos().subscribe(
        (_ativos: Ativo[]) => {
          this.ativos = _ativos;
          this.ativosFiltrados = this.ativos;
        },
        (error: any) => {
          this.toastr.error('Ativos não carregados.', 'Erro!');
        }
      ).add(() => this.spinner.hide());
    }

    public ocultarImagem(): void{
      this.mostrarImagem = ! this.mostrarImagem;
    }

    public openModal(event: any, ativoSigla: string, ativoId: number, template: TemplateRef<any>): void {
      event.stopPropagation();
      this.ativoSigla = ativoSigla;
      this.ativoId = ativoId;
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    public confirm(): void {
      this.modalRef.hide();
      this.spinner.show();

      this.ativoService.deleteAtivo(this.ativoId).subscribe(
        (result: any) => {
            console.log(result);
            this.toastr.success(`${this.ativoSigla} excluído.`, 'Sucesso!');
            this.getAtivos();
        },
        (error: any) => {
          console.log(error);
          this.toastr.error(`${this.ativoSigla} não foi deletado.`, 'erro!')
        }
      ).add(() => this.spinner.hide());
    }

    public decline(): void {
      this.modalRef.hide();
    }

    public detalheAtivo(id: number): void{
      this.router.navigate([`ativos/detalhe/${id}`]);
    }

}
