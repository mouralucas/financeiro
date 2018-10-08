using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Entities
{
    class NotasModerninha
    {
        public String Transacao_Id { set; get; }
        public String Cliente_Nome { set; get; }
        public String Cliente_Email { set; get; }
        public String Debito_Credito { set; get; }
        public String Tipo_Transacao { set; get; }
        public String Status { set; get; }
        public String Tipo_Pagamento { set; get; }
        public double Valor_Bruto { set; get; }
        public double Valor_Desconto { set; get; }
        public double Valor_Taxa { set; get; }
        public double Valor_Liquido { set; get; }
        public String Data_Transacao { set; get; }
        public String Data_Compensacao { set; get; }
        public int Parcelas { set; get; }
        public String Codigo_Usuario { set; get; }
        public String Codigo_Venda { set; get; }
        public String Serial_Leitor { set; get; }
        public int Recebimentos { set; get; }
        public int Recebidos { set; get; }
        public double Valor_Recebido { set; get; }
        public double Valor_Tarifa_Intermediacao { set; get; }
        public double Valor_Taxa_Intermediacao { set; get; }
        public double Valor_Taxa_Parcelamento { set; get; }
        public double Valor_Tarifa_Boleto { set; get; }
        public String Bandeira_Cartao_Credito { set; get; }
    }
}
