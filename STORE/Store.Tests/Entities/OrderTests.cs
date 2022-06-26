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
        var item = new Order(_customer, 10, _discount);
        Assert.Equals(item.Status, EOrderStatus.WaitingPayment);

    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pagamento_do_Pedido_seu_status_deve_ser_aguardando_entrega()
    {
        var delivery = new Order(_customer, 10, _discount);
        delivery.AddItem(_order, 2);
        delivery.Total();
        delivery.Pay(100);
        Assert.Equals(delivery.Status, EOrderStatus.WaitingDelivery);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_cancelado_seu_status_deve_ser_cancelado()
    {
        var canceled = new Order(_customer, 10, null);
        Assert.Equals(canceled.Status, EOrderStatus.Canceled);

    }

}