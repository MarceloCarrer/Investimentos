import { Ativo } from "./Ativo";

export interface Transacao {
  id: number;
  dataCompra: string;
  valorCompra: number;
  qtdCompra: number;
  dataVenda: string;
  valorVenda: number;
  qtdVenda: number;
  valorTotalVenda: number;
  lucroPorc: number;
  lucro: number;
  imposto: number;
  lucroLiquido: number;
  retornoLiquido: number;
  vendido: boolean;
  ativoId: number;
  ativo: Ativo[];
}
