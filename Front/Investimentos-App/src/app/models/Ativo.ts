import { Transacao } from "./Transacao";

export interface Ativo {
  id: number;
  sigla: string;
  nome: string;
  setor: string;
  tipo: string;
  imagem?: string;

  transacao: Transacao[];
}
