using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Financeiro.Entities;
using Financeiro.Util;

namespace Financeiro.Files
{
    class XmlOperation
    {
        List<NotasModerninha> List_NotasModerninha = new List<NotasModerninha>();
        NotasModerninha Notas;

        public List<NotasModerninha> Reader(String Path)
        {
            XmlDocument Doc = new XmlDocument();
            List_NotasModerninha.Clear();
            Doc.Load(Path);

            foreach(XmlNode node in Doc.DocumentElement)
            {
                Notas = new NotasModerninha()
                {
                    Transacao_Id = node["Transacao_ID"] != null                             ? node["Transacao_ID"].InnerText : "",
                    Cliente_Nome = node["Cliente_Nome"] != null                             ? node["Cliente_Nome"].InnerText : "",
                    Cliente_Email = node["Cliente_Email"] != null                           ? node["Cliente_Email"].InnerText : "",
                    Debito_Credito = node["Debito_Credito"] != null                         ? node["Debito_Credito"].InnerText : "",
                    Tipo_Transacao = node["Tipo_Transacao"] != null                         ? node["Tipo_Transacao"].InnerText : "",
                    Status = node["Status"] != null                                         ? node["Status"].InnerText : "",
                    Tipo_Pagamento = node["Tipo_Pagamento"] != null                         ? node["Tipo_Pagamento"].InnerText : "",
                    Valor_Bruto = node["Valor_Bruto"] != null                               ? Convert.ToDouble(node["Valor_Bruto"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Desconto = node["Valor_Desconto"] != null                         ? Convert.ToDouble(node["Valor_Desconto"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Taxa = node["Valor_Taxa"] != null                                 ? Convert.ToDouble(node["Valor_Taxa"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Liquido = node["Valor_Liquido"] != null                           ? Convert.ToDouble(node["Valor_Liquido"].InnerText.Replace(",", ".")) : 0.00,
                    Data_Transacao = node["Data_Transacao"] != null                         ? Util.DateTime.InvertDate(node["Data_Transacao"].InnerText) : "9999/99/99 00:00:00",
                    Data_Compensacao = node["Data_Compensacao"] != null                     ? Util.DateTime.InvertDate(node["Data_Compensacao"].InnerText) : "9999/99/99 00:00:00",
                    Parcelas = node["Parcelas"] != null                                     ? Convert.ToInt32(node["Parcelas"].InnerText.Replace(",", ".")) : 0,
                    Codigo_Usuario = node["Codigo_Usuario"] != null                         ? node["Codigo_Usuario"].InnerText : "",
                    Codigo_Venda = node["Codigo_Venda"] != null                             ? node["Codigo_Venda"].InnerText : "",
                    Serial_Leitor = node["Serial_Leitor"] != null                           ? node["Serial_Leitor"].InnerText : "",
                    Recebimentos = node["Recebimentos"] != null                             ? Convert.ToInt32(node["Recebimentos"].InnerText.Replace(",", ".")) : 0,
                    Recebidos = node["Recebibos"] != null                                   ? Convert.ToInt32(node["Recebibos"].InnerText.Replace(",", ".")) : 0,
                    Valor_Recebido = node["Valor_Recebido"] != null                         ? Convert.ToDouble(node["Valor_Recebido"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Tarifa_Intermediacao = node["Valor_Liquido"] != null              ? Convert.ToDouble(node["Valor_Liquido"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Taxa_Intermediacao = node["Valor_Taxa_intermediacao"] != null     ? Convert.ToDouble(node["Valor_Taxa_intermediacao"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Taxa_Parcelamento = node["Valor_Taxa_Parcelamento"] != null       ? Convert.ToDouble(node["Valor_Taxa_Parcelamento"].InnerText.Replace(",", ".")) : 0.00,
                    Valor_Tarifa_Boleto = node["Valor_Tarifa_Boleto"] != null               ? Convert.ToDouble(node["Valor_Tarifa_Boleto"].InnerText.Replace(",", ".")) : 0.00,
                    Bandeira_Cartao_Credito = node["Bandeira_Cartao_Credito"] != null       ? node["Bandeira_Cartao_Credito"].InnerText : "",
                };


                List_NotasModerninha.Add(Notas);
            }

            return List_NotasModerninha;
        }
        
    }
}
