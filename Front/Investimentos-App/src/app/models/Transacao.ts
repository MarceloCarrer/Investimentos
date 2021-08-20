import { Ativo } from "./Ativo";

export interface Transacao {
  id: number;
  dataCompra: Date;
  valorCompra: number;
  qtdCompra: number;
  dataVenda: Date;
  valorVenda: number;
  qtdVenda: number;

  ativoId: number;
  ativo: Ativo[];
}
