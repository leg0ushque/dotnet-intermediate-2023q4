using Gof.CuttingShape.Adapter;
using Gof.CuttingShape.Composite;
using Gof.CuttingShape.Facade;
using Gof.CuttingShape.Facade.Models;
using Gof.CuttingShape.Facade.Services;

namespace Gof.MainProgram
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adapter");
            RunAdapter();

            Console.WriteLine("Composite");
            RunComposite();

            Console.WriteLine("Facade");
            RunFacade();

            Console.ReadLine();
        }

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
    }
}