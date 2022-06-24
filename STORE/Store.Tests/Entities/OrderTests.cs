using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enuns;
using System;
namespace Store.Tests.Entities;

[TestClass]
public class OrderTests
{
    private readonly Customer _customer = new Customer("Joao", "joaoassisgabriel@gmail.com");
    private readonly Product _order = new Product("produto 100", 100, true);
    private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_valido_ele_deve_gerar_um_numero_de_8_caracters()
    {

        var order = new Order(_customer, 0, null);

        Assert.AreEqual(8, order.Number.Length);
    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        Assert.Fail();
    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pagamento_do_Pedido_seu_status_deve_ser_aguardando_entrega()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_cancelado_seu_status_deve_ser_cancelado()
    {
        Assert.Fail();
    }

}