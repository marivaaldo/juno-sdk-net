using Juno.Sdk.Models;
using Juno.Sdk.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Juno.Sdk.Tests
{
    [TestClass]
    public class JunoClientTests
    {
        private readonly JunoClient _Client;

        public JunoClientTests()
        {
            _Client = Helpers.CreateClient(authenticate: true);
        }

        [TestMethod]
        public void PublicKey()
        {
            var service = new PublicKeysService(_Client);

            var publicKey = service.GetPublicKey(_Client.Credentials.PrivateToken);

            Assert.IsFalse(string.IsNullOrWhiteSpace(publicKey));
        }

        [TestMethod]
        public void DigitalAccount()
        {
            var service = new DigitalAccountsService(_Client);

            //
            // Criar conta digital - Pessoa Física

            var newCPF = Helpers.NewCPF();
            var newPFDigitalAccount = new DigitalAccount
            {
                Name = $"Harry James Potter - {newCPF}",
                Document = newCPF,
                Email = $"hjp{newCPF}@bibipecas.com.br",
                BirthDate = new DateTime(1980, 07, 31),
                Phone = $"5585982061631",
                BusinessArea = 1000, // Produtos - Acessorios automotivos,
                LinesOfBusiness = $"Pessoa Fisica Teste - {newCPF}",
                Address = new Address
                {
                    Street = "Rua dos Alfeneiros",
                    Number = "4",
                    Complement = "Armário debaixo da escada",
                    Neighborhood = "Surrey",
                    City = "Caucaia",
                    State = AddressState.CE,
                    PostCode = "61611220"
                },
                BankAccount = new BankAccount
                {
                    BankNumber = "341",
                    AgencyNumber = "0000",
                    AccountNumber = "11111-0",
                    AccountType = BankAccountType.CHECKING,
                    AccountHolder = new BankAccountHolder
                    {
                        Name = "Harry James Potter",
                        Document = newCPF
                    }
                }
            };

            var createdPFDigitalAccount = service.CreateDigitalAccount(newPFDigitalAccount);

            Assert.IsNotNull(createdPFDigitalAccount);

            //
            // Consultar conta digital - Pessoa Física

            var queryPFDigitalAccount = service.GetDigitalAccount(createdPFDigitalAccount.ResourceToken);

            Assert.AreEqual(queryPFDigitalAccount.Id, createdPFDigitalAccount.Id);
            Assert.AreEqual(queryPFDigitalAccount.Document, createdPFDigitalAccount.Document);
            Assert.AreEqual(queryPFDigitalAccount.Type, "PAYMENT");
            Assert.AreEqual(queryPFDigitalAccount.PersonType, Models.PersonType.F);

            //
            // Atualizar conta digital - Pessoa Física

            //var updatedPFDigitalAccount = service.UpdateDigitalAccount(newPFDigitalAccount);

            //Assert.IsNotNull(updatedPFDigitalAccount);

            //
            // Criar conta digital - Pessoa Jurídica

            var newCNPJ = Helpers.NewCNPJ();
            var rNewCPJ = Helpers.NewCPF();
            var newPJDigitalAccount = new DigitalAccount
            {
                Name = $"Hogwarts - {newCNPJ}",
                Document = newCNPJ,
                Email = $"hogwarts{newCNPJ}@bibipecas.com.br",
                Phone = $"5585982061631",
                BusinessArea = 1000, // Produtos - Acessorios automotivos,
                LinesOfBusiness = $"Pessoa Juridica Teste - {newCNPJ}",
                CompanyType = CompanyType.LTDA,
                LegalRepresentative = new LegalRepresentative
                {
                    Name = $"Hogwarts - {rNewCPJ}",
                    Document = rNewCPJ,
                    BirthDate = DateTime.UtcNow.AddYears(-1)
                },
                Address = new Address
                {
                    Street = "Castelo de Hogwarts",
                    Number = "N/A",
                    Neighborhood = "Escola de Bruxaria",
                    City = "Caucaia",
                    State = AddressState.CE,
                    PostCode = "61611220"
                },
                BankAccount = new BankAccount
                {
                    BankNumber = "341",
                    AgencyNumber = "0000",
                    AccountNumber = "22222-0",
                    AccountType = BankAccountType.CHECKING,
                    AccountHolder = new BankAccountHolder
                    {
                        Name = "Escola de Magia e Bruxaria de Hogwarts",
                        Document = newCNPJ
                    }
                }
            };

            var createdPJDigitalAccount = service.CreateDigitalAccount(newPJDigitalAccount);

            Assert.IsNotNull(createdPJDigitalAccount);

            //
            // Consultar conta digital - Pessoa Jurídica

            var queryPJDigitalAccount = service.GetDigitalAccount(createdPJDigitalAccount.ResourceToken);

            Assert.AreEqual(queryPJDigitalAccount.Id, createdPJDigitalAccount.Id);
            Assert.AreEqual(queryPJDigitalAccount.Document, createdPJDigitalAccount.Document);
            Assert.AreEqual(queryPJDigitalAccount.Type, "PAYMENT");
            Assert.AreEqual(queryPJDigitalAccount.PersonType, Models.PersonType.J);

            //
            // Atualizar conta digital - Pessoa Jurídica

            //newPJDigitalAccount.TradingName = "Hogwarts";

            //var updatedPJDigitalAccount = service.UpdateDigitalAccount(newPJDigitalAccount);

            //Assert.IsNotNull(updatedPJDigitalAccount);
        }

        [TestMethod]
        public void AdditionalData()
        {
            var service = new AdditionalDataService(_Client);

            var banks = service.ListBanks();

            Assert.IsNotNull(banks);
            Assert.IsNotNull(banks.Embedded);
            Assert.IsNotNull(banks.Embedded.Banks);
            Assert.IsTrue(banks.Embedded.Banks.Count > 0);
            Assert.IsTrue(banks.Embedded.Banks.Any(o => o.Number == "341" && o.Name == "ITAÚ UNIBANCO S.A."));

            var companyTypes = service.ListCompanyTypes();

            Assert.IsNotNull(companyTypes);
            Assert.IsNotNull(companyTypes.CompanyTypes);
            Assert.IsTrue(companyTypes.CompanyTypes.Count > 0);

            var businessAreas = service.ListBusinessAreas();

            Assert.IsNotNull(businessAreas);
            Assert.IsNotNull(businessAreas.Embedded);
            Assert.IsNotNull(businessAreas.Embedded.BusinessAreas);
            Assert.IsTrue(businessAreas.Embedded.BusinessAreas.Count > 0);
        }

        [TestMethod]
        public void Documents()
        {
            var service = new DocumentsService(_Client);

            var bankAccountsResourceTokens = new[]
            {
                "5E64B2E0B0D4AE42A3F2981CC4055CF613F6C17B5C2912029C587581E72ECDB8", // Pessoa Física - Document: 90564489603 - Id: dac_2585CBF0E2A23649
                "F3FEB619853E74753853E0BBFC1A6CBF53189A3F8059035877C136641897AAB9"  // Pessoa Jurídica - Document: 78338726311040 - Id: dac_591251E5D47F08AE
            };

            foreach (var resourceToken in bankAccountsResourceTokens)
            {
                //
                // Lista dos documentos

                var documents = service.ListDocuments(resourceToken);

                Assert.IsNotNull(documents);
                Assert.IsNotNull(documents.Embedded);
                Assert.IsNotNull(documents.Embedded.Documents);
                Assert.IsTrue(documents.Embedded.Documents.Count > 0);

                foreach (var document in documents.Embedded.Documents)
                {
                    //
                    // Consulta os documentos de forma individual

                    var tempDocument = service.GetDocument(resourceToken, document.Id);

                    Assert.IsNotNull(tempDocument);
                    Assert.AreEqual(tempDocument.Id, document.Id);

                    //
                    // Envia os documentos

                    if (tempDocument.ApprovalStatus == DocumentStatus.AWAITING || tempDocument.ApprovalStatus == DocumentStatus.REJECTED)
                    {
                        var filePost = new Models.Requests.PostDocumentResource
                        {
                            ResourceToken = resourceToken,
                            DocumentId = tempDocument.Id,
                            Files = new List<FileData>
                        {
                            new FileData
                            {
                                Name = $"{tempDocument.Type}_{Guid.NewGuid().ToString().Split("-")[0].ToUpper()}.pdf",
                                Contents = File.ReadAllBytes($@"{Environment.CurrentDirectory}\..\..\..\files\{tempDocument.Type}.pdf")
                            }
                        }
                        };

                        var postResult = service.PostDocument(filePost);

                        Assert.IsNotNull(postResult);
                        Assert.AreEqual(postResult.Type, tempDocument.Type);
                    }
                }
            }
        }

        [TestMethod]
        public void Balances()
        {
            var service = new BalancesService(_Client);

            var balance = service.GetBalance(_Client.Credentials.PrivateToken);

            Assert.IsNotNull(balance);
        }

        [TestMethod]
        public void Notifications()
        {
            var service = new NotificationsService(_Client);

            //
            // Listar tipos de eventos

            var eventTypes = service.ListEventTypes();

            Assert.IsNotNull(eventTypes);
            Assert.IsNotNull(eventTypes.Embedded);
            Assert.IsNotNull(eventTypes.Embedded.EventTypes);
            Assert.IsTrue(eventTypes.Embedded.EventTypes.Count > 0);

            //
            // Remove todos os webhooks

            var oldWebhooks = service.ListWebhooks(_Client.Credentials.PrivateToken);

            if (oldWebhooks != null && oldWebhooks.Embedded != null && oldWebhooks.Embedded.Webhooks != null)
            {
                foreach (var webhook in oldWebhooks.Embedded.Webhooks)
                {
                    service.DeleteWebhook(_Client.Credentials.PrivateToken, webhook.Id);
                }
            }

            //
            // Criar webhook

            var allEventTypes = Enum.GetValues<Models.EventName>().ToList();

            var createWebhook = new Models.Requests.CreateWebhookResource.CreateWebhook
            {
                BaseUrl = "https://domain.com",
                QueryParameters = new Dictionary<string, object>
                {
                    ["debug"] = true
                },
                EventTypes = Enum.GetValues<Models.EventName>().ToList()
            };

            var newWebhook = service.CreateWebhook(_Client.Credentials.PrivateToken, createWebhook);

            Assert.IsNotNull(newWebhook);
            Assert.AreEqual(newWebhook.Url.ToLower(), $"{createWebhook.BaseUrl}/juno/wh/notifications?debug=true".ToLower());
            Assert.IsTrue(newWebhook.EventTypes.Count == allEventTypes.Count);

            var newWebhookId = newWebhook.Id;

            //
            // Listar webhooks

            var webhooks = service.ListWebhooks(_Client.Credentials.PrivateToken);

            Assert.IsNotNull(webhooks);
            Assert.IsNotNull(webhooks.Embedded);
            Assert.IsNotNull(webhooks.Embedded.Webhooks);
            Assert.IsTrue(webhooks.Embedded.Webhooks.Count > 0 && webhooks.Embedded.Webhooks.Any(o => o.Id == newWebhookId));

            //
            // Consultar webhook

            newWebhook = service.GetWebhook(_Client.Credentials.PrivateToken, newWebhookId);

            Assert.IsNotNull(newWebhook);
            Assert.AreEqual(newWebhook.Id, newWebhookId);

            //
            // Atualizar webhook

            var updateWebhook = new Models.Requests.UpdateWebhookResource.UpdateWebhook
            {
                Status = Models.WebhookStatus.INACTIVE,
                EventTypes = new List<Models.EventName> { Models.EventName.CHARGE_READ_CONFIRMATION }
            };

            newWebhook = service.UpdateWebhook(_Client.Credentials.PrivateToken, newWebhookId, updateWebhook);

            Assert.IsNotNull(newWebhook);
            Assert.AreEqual(newWebhook.Status, Models.WebhookStatus.INACTIVE);
            Assert.IsTrue(newWebhook.EventTypes.Count == 1 && newWebhook.EventTypes[0].Name == Models.EventNameExtended.CHARGE_READ_CONFIRMATION);

            //
            // Remover webhook

            service.DeleteWebhook(_Client.Credentials.PrivateToken, newWebhookId);

            //
            // Remover todos os webhooks

            webhooks = service.ListWebhooks(_Client.Credentials.PrivateToken);

            if (webhooks != null && webhooks.Embedded != null && webhooks.Embedded.Webhooks != null)
            {
                foreach (var webhook in webhooks.Embedded.Webhooks)
                {
                    service.DeleteWebhook(_Client.Credentials.PrivateToken, webhook.Id);
                }
            }
        }

        [TestMethod]
        public void Charges()
        {
            var service = new ChargesService(_Client);

            var newCharge = new Models.Requests.CreateChargeResource.CreateCharge
            {
                Charge = new Charge
                {
                    Description = $"Cobrança Teste - {Guid.NewGuid()}",
                    //References
                    Amount = 100.0m,
                    //TotalAmount = 100.0m,
                    //Installments = 1,
                    DueDate = DateTime.Now.AddDays(3),
                    PaymentTypes = new List<PaymentType> { PaymentType.CREDIT_CARD },
                    Split = new List<Split>
                    {
                        new Split
                        {
                            AmountRemainder = true,
                            ChargeFee = false,
                            Percentage = 90.0m,
                            RecipientToken = "5E64B2E0B0D4AE42A3F2981CC4055CF613F6C17B5C2912029C587581E72ECDB8", // Seller - Harry Potter - Document: 90564489603 - Id: dac_2585CBF0E2A23649
                        },
                        new Split
                        {
                            AmountRemainder = false,
                            ChargeFee = false,
                            Percentage = 1.0m,
                            RecipientToken = "F3FEB619853E74753853E0BBFC1A6CBF53189A3F8059035877C136641897AAB9", // Optional - Hogwarts - Document: 78338726311040 - Id: dac_591251E5D47F08AE
                        },
                        new Split
                        {
                            AmountRemainder = false,
                            ChargeFee = true,
                            Percentage = 9.0m,
                            RecipientToken = _Client.Credentials.PrivateToken, // Bibi Peças
                        }
                    }
                },
                Billing = new BillingForCharge
                {
                    Name = "Hidelbrando da Silva",
                    Document = Helpers.NewCPF(),
                    Email = "hidelbrando@google.com",
                    Phone = "5585982061631",
                    BirthDate = DateTime.Now.AddYears(-21),
                },
            };

            var createdCharges = service.CreateCharge(_Client.Credentials.PrivateToken, newCharge);

            Assert.IsNotNull(createdCharges);
            Assert.IsNotNull(createdCharges.Embedded);
            Assert.IsNotNull(createdCharges.Embedded.Charges);
            Assert.IsTrue(createdCharges.Embedded.Charges.Count > 0);

            foreach (var createdCharge in createdCharges.Embedded.Charges)
            {
                var queryCharge = service.GetCharge(_Client.Credentials.PrivateToken, createdCharge.Id);

                Assert.IsNotNull(queryCharge);
                Assert.AreEqual(queryCharge.Id, createdCharge.Id);
            }

            var listCharges = service.ListCharges(_Client.Credentials.PrivateToken, new Models.Requests.ListChargeResource
            {
                ShowCancelled = false,
                ShowNotCancelled = true,
                CreatedOnStart = DateTime.Now,
                CreatedOnEnd = DateTime.Now,
                ShowNotPaid = true,
                ShowPaid = false
            });

            Assert.IsNotNull(listCharges);
            Assert.IsNotNull(listCharges.Embedded);
            Assert.IsNotNull(listCharges.Embedded.Charges);
            Assert.IsTrue(listCharges.Embedded.Charges.Count > 0);

            Assert.IsFalse(listCharges.Embedded.Charges.Any(o => o.Status == ChargeStatus.CANCELLED));

            foreach (var createdCharge in createdCharges.Embedded.Charges)
            {
                Assert.IsTrue(listCharges.Embedded.Charges.Any(o => o.Id == createdCharge.Id));

                service.UpdateChargeSplit(_Client.Credentials.PrivateToken, createdCharge.Id, new List<Split>
                {
                    new Split
                    {
                        AmountRemainder = true,
                        ChargeFee = true,
                        Percentage = 100.0m,
                        RecipientToken = _Client.Credentials.PrivateToken, // Bibi Peças
                    }
                });

                service.CancelCharge(_Client.Credentials.PrivateToken, createdCharge.Id);
            }
        }

        [TestMethod]
        public void Payments()
        {
            var service = new PaymentsService(_Client);

            var card = new Models.DirectCheckouts.Card
            {
                CardNumber = "5132 0723 8792 9820",
                ExpirationMonth = "04",
                ExpirationYear = "2022",
                HolderName = "HIDELBRANDO SILVA",
                SecurityCode = "732"
            };

            var dc = new DirectCheckouts.DirectCheckout(_Client.Credentials.PublicToken, false);

            var creditCardHash = dc.GetCardHash(card);

            if (string.IsNullOrWhiteSpace(creditCardHash))
            {
                throw new Exception("Definir hash do cartão de crédito");
            }

            //
            // Cria a cobrança

            var chargesService = new ChargesService(_Client);

            var split = new List<Split>
            {
                new Split
                {
                    AmountRemainder = true,
                    ChargeFee = false,
                    Percentage = 90.0m,
                    RecipientToken = "5E64B2E0B0D4AE42A3F2981CC4055CF613F6C17B5C2912029C587581E72ECDB8", // Seller - Harry Potter - Document: 90564489603 - Id: dac_2585CBF0E2A23649
                },
                new Split
                {
                    AmountRemainder = false,
                    ChargeFee = false,
                    Percentage = 1.0m,
                    RecipientToken = "F3FEB619853E74753853E0BBFC1A6CBF53189A3F8059035877C136641897AAB9", // Optional - Hogwarts - Document: 78338726311040 - Id: dac_591251E5D47F08AE
                },
                new Split
                {
                    AmountRemainder = false,
                    ChargeFee = true,
                    Percentage = 9.0m,
                    RecipientToken = _Client.Credentials.PrivateToken, // Bibi Peças
                }
            };

            var newCharge = new Models.Requests.CreateChargeResource.CreateCharge
            {
                Charge = new Charge
                {
                    Description = $"Cobrança Teste - {Guid.NewGuid()}",
                    //References
                    Amount = 100.0m,
                    //TotalAmount = 100.0m,
                    //Installments = 1,
                    DueDate = DateTime.Now.AddDays(3),
                    PaymentTypes = new List<PaymentType> { PaymentType.CREDIT_CARD },
                    Split = split
                },
                Billing = new BillingForCharge
                {
                    Name = "Hidelbrando da Silva",
                    Document = Helpers.NewCPF(),
                    Email = "hidelbrando@google.com",
                    Phone = "5585982061631",
                    BirthDate = DateTime.Now.AddYears(-21),
                },
            };

            var createdCharges = chargesService.CreateCharge(_Client.Credentials.PrivateToken, newCharge);

            Assert.IsNotNull(createdCharges?.Embedded?.Charges.FirstOrDefault()?.Id);

            var chargeId = createdCharges.Embedded.Charges[0].Id;

            // TODO service.CreditCardTokenization

            var newPayment = new Models.Requests.CreatePaymentResource.CreatePayment
            {
                ChargeId = chargeId,
                Billing = new BillingForPayment
                {
                    Delayed = true,
                    Address = new Address
                    {
                        Street = "Rua dos Alfeneiros",
                        Number = "4",
                        Complement = "Armário debaixo da escada",
                        Neighborhood = "Surrey",
                        City = "Caucaia",
                        State = AddressState.CE,
                        PostCode = "61611220"
                    },
                    Email = "hjp90564489603@bibipecas.com.br"
                },
                CreditCardDetails = new CreditCardDetails
                {
                    CreditCardHash = creditCardHash
                }
            };

            var createdPayment = service.CreatePayment(_Client.Credentials.PrivateToken, newPayment);

            Assert.IsNotNull(createdPayment);
            Assert.IsNotNull(createdPayment.Payments);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createdPayment.TransactionId));

            var newCapturePayment = new Models.Requests.CaptureCreditCardPaymentResource.CaptureCreditCardPayment
            {
                ChargeId = chargeId,
                Amount = newCharge.Charge.Amount,
            };

            var capturedPayment = service.CaptureCreditCardPayment(_Client.Credentials.PrivateToken, createdPayment.Payments[0].Id, newCapturePayment);

            Assert.IsNotNull(capturedPayment);
            Assert.IsNotNull(createdPayment.Payments);
            Assert.IsFalse(string.IsNullOrWhiteSpace(createdPayment.TransactionId));

            var newRefundPayment = new Models.Requests.RefundCreditCardPaymentResource.RefundCreditCardPayment
            {
                Amount = newCharge.Charge.Amount,
                Split = split
            };

            var refundedPayment = service.RefundCreditCardPayment(_Client.Credentials.PrivateToken, createdPayment.Payments[0].Id, newRefundPayment);

            Assert.IsNotNull(refundedPayment);
            Assert.IsNotNull(refundedPayment.Refunds);
            Assert.IsFalse(string.IsNullOrWhiteSpace(refundedPayment.TransactionId));
        }
    }
}
