using Gof.CuttingShape.Adapter;
using Gof.CuttingShape.Composite;
using Gof.CuttingShape.Facade;
using Gof.CuttingShape.Facade.Models;
using Gof.CuttingShape.Facade.Services;
using Gof.ManagingState.BankSystem.Models;
using Gof.ManagingState.BankSystem.Models.Enums;
using Gof.ManagingState.BankSystem.Extensions;
using Gof.ManagingState.IndianRestaurant.Models.Enums;
using Gof.ManagingState.IndianRestaurant.Services;
using Gof.ManagingState.FeedManagerApplication.Factories;
using Gof.ManagingState.FeedManagerApplication.Models;
using Gof.ManagingState.FeedManagerApplication.Services;
using Gof.AlteringBehavior.InsuranceCalculator.Factories;
using Gof.AlteringBehavior.InsuranceCalculator.Interfaces;
using Gof.AlteringBehavior.OrderShipment.Factories;
using Gof.AlteringBehavior.OrderShipment.Models.Enums;
using Gof.AlteringBehavior.OrderShipment.Models;

namespace Gof.MainProgram
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cutting shape");

            Console.WriteLine("\n\nAdapter\n");
            RunAdapter();

            Console.WriteLine("\n\nComposite\n");
            RunComposite();

            Console.WriteLine("\n\nFacade\n");
            RunFacade();

            Console.WriteLine("\n\nManaging state\n");

            Console.WriteLine("\n\nTasks 1.1 - 1.3 Bank system\n");
            RunBankSystem();

            Console.WriteLine("\n\nTask 1.4-1.5 Indian restaurant\n");
            RunRestaurant();

            Console.WriteLine("\n\nTasks 2 Feed manager application\n");
            RunFeedManager();

            Console.WriteLine("\n\nAltering behavior\n");
            Console.WriteLine("\n\nInsurance calculator\n");
            RunInsuranceCalculator();

            Console.WriteLine("\n\nOrder shipment\n");
            RunOrderShipment();

            Console.ReadLine();
        }

        #region Cutting shape

        static void RunAdapter()
        {
            var printer = new Printer();
            var elements = new ElementsCollection<Document>(
                new List<Document>
                {
                    new Document { Name = "Doc1" },
                    new Document { Name = "Doc2" }
                });

            var adapter = new Adapter<Document>(elements);
            printer.Print(adapter);
        }

        static void RunComposite()
        {
            int offset = 0;

            IXmlComponent form = new Form("myForm", offset: offset++,
                xmlComponents: new IXmlComponent[]
                {
                    new LabelText("myLabel", offset),
                    new InputText("myInput","myInputValue", offset),
                    new Form("innerForm", offset: offset++,
                        xmlComponents: new IXmlComponent[]
                        {
                            new LabelText("innerFormLabel", offset),
                            new InputText("innerFormInput","innerFormInputValue", offset),
                        }),
                });

            Console.WriteLine(form.ToXmlString());
        }

        static void RunFacade()
        {
            var productCatalog = new ProductCatalog(new[]
            {
                new Product { Id="id1", Name = "P1", Price = 1.11m },
                new Product { Id="id2", Name = "P2", Price = 2.22m },
                new Product { Id="id3", Name = "P3", Price = 3.33m },
                new Product { Id="id4", Name = "P4", Price = 4.44m },
            });

            var invoiceSystem = new ConsoleInvoiceSystem();
            var paymentSystem = new ConsolePaymentSystem();

            var orderFacade = new OrderFacade(invoiceSystem, paymentSystem, productCatalog);

            orderFacade.PlaceOrder("id1", 5, "johndoe@gmail.com");
        }

        #endregion

        #region Managing State

        static void RunBankSystem()
        {
            var trades = new Trade[]
            {
                new Trade
                {
                    Amount = 30,
                    Type = TradeType.Future,
                    Subtype = TradeSubType.None,
                },
                new Trade
                {
                    Amount = 80,
                    Type = TradeType.None,
                    Subtype = TradeSubType.None,
                },
                new Trade
                {
                    Amount = 70,
                    Type = TradeType.Option,
                    Subtype = TradeSubType.NyOption,
                },
                new Trade
                {
                    Amount = 100,
                    Type = TradeType.Option,
                    Subtype = TradeSubType.NyOption,
                },
                new Trade
                {
                    Amount = 150,
                    Type = TradeType.Future,
                },
            };

            OutputTrades(trades.FilterForBank(Bank.Bofa));
            OutputTrades(trades.FilterForBank(Bank.Connacord));
            OutputTrades(trades.FilterForBank(Bank.Barclays, "USA"));
            OutputTrades(trades.FilterForBank(Bank.Barclays, "England"));
            OutputTrades(trades.FilterForBank(Bank.Deutsche));
        }

        private static void OutputTrades(IEnumerable<Trade> trades)
        {
            Console.WriteLine();
            Console.WriteLine($"{nameof(Trade.Type)};{nameof(Trade.Subtype)};{nameof(Trade.Amount)}");
            foreach (var trade in trades)
            {
                Console.WriteLine($"{trade.Type};{trade.Subtype};{trade.Amount}");
            }
            Console.WriteLine();
        }

        static void RunRestaurant()
        {
            var restraunt = new Restaurant();

            restraunt.CookMasala(Country.England, DateTime.Now);
        }

        static void RunFeedManager()
        {
            var deltaFeedCollection = new DeltaOneFeed[]
            {
                new DeltaOneFeed
                {
                    StagingId = -1,
                    SourceTradeRef = -1,
                    CounterpartyId = -1,
                    PrincipalId = -1,
                    ValuationDate = new DateTime(2021, 10, 15),
                    CurrentPrice = 43.5542m,
                    SourceAccountId = null,
                    Isin = "3254345GBDFUS",
                    MaturityDate = new DateTime(2021, 10, 15),
                },
                new DeltaOneFeed
                {
                    StagingId = 0,
                    SourceTradeRef = 2,
                    CounterpartyId = 2,
                    PrincipalId = 2,
                    ValuationDate = new DateTime(2022, 10, 15),
                    CurrentPrice = 55.2525m,
                    SourceAccountId = 55,
                    Isin = "___UUU____",
                    MaturityDate = new DateTime(2021, 10, 15),
                },
                new DeltaOneFeed
                {
                    StagingId = 2,
                    SourceTradeRef = 2,
                    CounterpartyId = 2,
                    PrincipalId = 2,
                    ValuationDate = new DateTime(2020, 10, 15),
                    CurrentPrice = 43.55m,
                    SourceAccountId = 5,
                    Isin = "US1234567890",
                    MaturityDate = new DateTime(2021, 10, 15),
                },
                new DeltaOneFeed
                {
                    StagingId = 3,
                    SourceTradeRef = 3,
                    CounterpartyId = 3,
                    PrincipalId = 3,
                    ValuationDate = new DateTime(2018, 10, 15),
                    CurrentPrice = 55.25m,
                    SourceAccountId = 4,
                    Isin = "AU0987894932",
                    MaturityDate = new DateTime(2021, 10, 15),
                },
            };

            new FeedImporterFacade<DeltaOneFeed>(
                TradeFeedFactory.CreateFeedFactory<DeltaOneFeed>()
            ).Import(deltaFeedCollection);

            Console.WriteLine();

            var emFeedCollection = new EmFeed[]
            {
                new EmFeed
                {
                    StagingId = -1,
                    SourceTradeRef = -1,
                    CounterpartyId = -1,
                    PrincipalId = -1,
                    ValuationDate = new DateTime(2021, 10, 15),
                    CurrentPrice = 43.5542m,
                    SourceAccountId = null,
                    Sedol = 0,
                    AssetValue = 0,
                },
                new EmFeed
                {
                    StagingId = 0,
                    SourceTradeRef = 2,
                    CounterpartyId = 2,
                    PrincipalId = 2,
                    ValuationDate = new DateTime(2022, 10, 15),
                    CurrentPrice = 55.2525m,
                    SourceAccountId = 55,
                    Sedol = 45,
                    AssetValue = 75,
                },
                new EmFeed
                {
                    StagingId = 2,
                    SourceTradeRef = 2,
                    CounterpartyId = 2,
                    PrincipalId = 2,
                    ValuationDate = new DateTime(2020, 10, 15),
                    CurrentPrice = 43.55m,
                    SourceAccountId = 5,
                    Sedol = 55,
                    AssetValue = 25,
                },
                new EmFeed
                {
                    StagingId = 3,
                    SourceTradeRef = 3,
                    CounterpartyId = 3,
                    PrincipalId = 3,
                    ValuationDate = new DateTime(2018, 10, 15),
                    CurrentPrice = 55.25m,
                    SourceAccountId = 4,
                    Sedol = 20,
                    AssetValue = 10,
                },
            };

            new FeedImporterFacade<EmFeed>(
                TradeFeedFactory.CreateFeedFactory<EmFeed>())
            .Import(emFeedCollection);
        }
        #endregion

        #region Altering behavior
        public static void RunInsuranceCalculator()
        {
            var insuranceCalculator = InsuranceCalculatorFactory.CreateCalculatorBuilder()
                .AddCaching()
                .AddLogging(LoggingFactory.CreateLogger())
                .AddRounding()
                .CreateCalculator();

            OutputValue(insuranceCalculator, "touristName#1");
            OutputValue(insuranceCalculator, "touristName#2");
            OutputValue(insuranceCalculator, "touristName#3");

            Console.ReadKey();
        }

        private static void OutputValue(ICalculator insuranceCalculator, string touristName)
        {
            Console.WriteLine($"Calculated value for {touristName} " + insuranceCalculator.CalculatePayment(touristName));
        }

        public static void RunOrderShipment()
        {
            var order = new Order(ShipmentOptions.FedEx, 200, ProductType.Book);

            Console.WriteLine(ShipmentFactory.CreateCalculator(order.ShipmentOptions).CalculatePrice(order));
        }
        #endregion
    }
}