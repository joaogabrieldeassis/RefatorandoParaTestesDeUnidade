using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Enuns;
using Store.Domain.Querys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Tests.Entities;

[TestClass]
public class CreateOrderCommandTestes
{

    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_um_comando_valido_o_pedido_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "";
        command.ZipCode = "13411080";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Validate();

    }

}
