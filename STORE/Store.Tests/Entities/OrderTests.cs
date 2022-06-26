using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enuns;
using System;
namespace Store.Tests.Entities;

[TestClass]
public class OrderTests
{
    private readonly Customer _customer = new Customer("Joao", "joaoassisgabriel@gmail.com");
    private readonly Product _order = new Product("produto 100", 5, true);
    private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_valido_ele_deve_gerar_um_numero_de_8_caracters()
    {
        var orderNumber = new Order(_customer, 0, null);
        Assert.AreEqual(8, orderNumber.Number.Length);

    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        var payment = new Order(_customer, 0, null);
        Assert.AreEqual(payment.Status, EOrderStatus.WaitingPayment);
    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pagamento_do_Pedido_seu_status_deve_ser_aguardando_entrega()
    {
        var delivery = new Order(_customer, 0, null);
        delivery.AddItem(_order, 3);
        delivery.Pay(15);
        Assert.AreEqual(delivery.Status, EOrderStatus.WaitingDelivery);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Pedido_cancelado_seu_status_deve_ser_cancelado()
    {
        var canceled = new Order(_customer, 0, null);
        canceled.Cancel();
        Assert.AreEqual(canceled.Status, EOrderStatus.Canceled);
    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Item_sem_Produto_o_mesmo_nao_deve_ser_adicionado()
    {
        var canceled = new Order(_customer, 0, null);
        canceled.AddItem(null, 0);
        Assert.AreEqual(canceled.Itemns.Count, 0);
    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_Item_com_quantidade_0_ou_menor_o_mesmo_nao_deve_ser_adicionado()
    {
        var canceled = new Order(_customer, 0, null);
        canceled.AddItem(_order, 0);
        Assert.AreEqual(canceled.Itemns.Count, 0);
    }
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
    {
        var request = new Order(_customer, 10, _discount);
        request.AddItem(_order, 10);
        Assert.AreEqual(request.Total(), 50);
    }
}