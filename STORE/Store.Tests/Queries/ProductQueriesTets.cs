using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enuns;
using Store.Domain.Querys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Tests.Entities;

[TestClass]
public class ProductQueriesTets
{
    private IList<Product> _products;
    public ProductQueriesTets()
    {
        _products = new List<Product>();
        _products.Add(new Product("Product 01", 10, true));
        _products.Add(new Product("Product 02", 10, true));
        _products.Add(new Product("Product 03", 10, true));
        _products.Add(new Product("Product 04", 10, false));
        _products.Add(new Product("Product 05", 10, false));
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
    {
        var result = _products.AsQueryable().Where(ProductQuerys.GeActiveProducts());
        Assert.AreEqual(result.Count(), 3);
    }
    [TestMethod]
    [TestCategory("Queries")]
    public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
    {
        var result = _products.AsQueryable().Where(ProductQuerys.GetInactiveProducts());
        Assert.AreEqual(result.Count(), 2);
    }
}
