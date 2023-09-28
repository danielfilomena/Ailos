using System.Globalization;

namespace Questao1
{
    class ContaBancaria {


        private int _numeroConta;
        private string _nomeTitular;
        private double _saldo;
        private double _taxaSaque = 3.50;
        
        public ContaBancaria(int numeroConta, string nomeTitular, double depositoInicial)
        {

            _numeroConta = numeroConta;
            _nomeTitular = nomeTitular;
            _saldo = depositoInicial;

        }

        public ContaBancaria(int numeroConta, string nomeTitular)
        {

            _numeroConta = numeroConta;
            _nomeTitular = nomeTitular;

        }

        public double Deposito(double valorDeposito)
        {
            _saldo += valorDeposito;
            return _saldo;
        }

        public double Saque(double valorSaque)
        {

            _saldo = _saldo - valorSaque - _taxaSaque;
            return _saldo;

        }

        public string BuscarDadosConta()
        {

            var dados = $@"Conta: {_numeroConta} | Titular: {_nomeTitular} | Saldo: R${ _saldo }";
            return dados;

        }

        
    }
}
