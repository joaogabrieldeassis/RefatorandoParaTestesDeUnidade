using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Enuns;
using Store.Domain.Handlers;
using Store.Domain.Querys;
using Stores.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Tests.Entities;

[TestClass]
public class OrderHandlerTests
{

    private readonly ICustomerRepository _custumerRepository;
    private readonly IDeliveryFeeRepository _deliveryRepository;
    private readonly IDiscountRepository _discountyRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderHandlerTests()
    {
        _custumerRepository = new FakeCustomerRepository();
        _deliveryRepository = new FakeDeliveryFeeRepositoy();
        _discountyRepository = new FakeDiscountRepository();
        _orderRepository = new FakeOrderRepository();
        _productRepository = new FakeProductRepository();
    }

    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
    {
        Assert.Fail();
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_cpf_invalido_o_pedido_deve_ser_gerado_normalmente()
    {
        Assert.Fail();
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_codigo_de_promocao_inexistente_o_pedido_deve_ser_gerado_normalmente()
    {
        Assert.Fail();
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_pedido_sem_items_o_mesmo_nao_deve_ser_gerado()
    {
        Assert.Fail();
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
    {
        var itemCommand = new CreateOrderCommand();
        itemCommand.Customer = null;
        itemCommand.ZipCode = "";
        itemCommand.PromoCode = "";
        itemCommand.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), -5));
        itemCommand.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 0));
        var handler = new OrderHandler(
            _custumerRepository,
            _deliveryRepository,
            _discountyRepository,
            _orderRepository,
            _productRepository
        );
        handler.Handle(itemCommand);
        Assert.AreEqual(handler.IsValid, false);
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
    {
        var itemCommand = new CreateOrderCommand();
        itemCommand.Customer = "Joao";
        itemCommand.ZipCode = "12234";
        itemCommand.PromoCode = "Qweasd234";
        itemCommand.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        itemCommand.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        var handler = new OrderHandler(
            _custumerRepository,
            _deliveryRepository,
            _discountyRepository,
            _orderRepository,
            _productRepository
        );
        handler.Handle(itemCommand);
        Assert.AreEqual(handler.IsValid, true);
    }


}
