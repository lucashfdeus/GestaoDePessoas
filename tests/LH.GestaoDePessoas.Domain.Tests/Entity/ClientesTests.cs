using LH.GestaoDePessoas.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LH.GestaoDePessoas.Domain.Tests.Entity
{
    [TestClass]
    public class ClientesTests
    {
        //Padrão AAA - Arrange, ACT, Assert

        [TestMethod]
        public void Cliente_ValidarConsistencia_True()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "03829890079",
                Email = "teste@testegmail.com",
                DataNascimento = new DateTime(1992, 12, 02)
            };

            // Act
            var result = cliente.IsValid();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_ValidarConsistencia_False()
        {
            // Arrange
            var cliente = new Cliente()
            {
                CPF = "000000000000",
                Email = "testegmail.com",
                DataNascimento = new DateTime(1901, 12, 02)
            };

            // Act
            var result = cliente.IsValid();

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));
        }
    }
}
