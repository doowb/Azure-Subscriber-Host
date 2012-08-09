using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureSubscriberHost.Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace ConsoleHost
{
    public class Container : IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(ISubscriberService))]
        public IEnumerable<ISubscriberService> Services { get; set; }

        public Container()
        {
            DirectoryCatalog catalog = new DirectoryCatalog(".");
            CompositionContainer container = new CompositionContainer(catalog);
            CompositionBatch batch = new CompositionBatch();
            batch.AddPart(this);

            container.Compose(batch);
        }

        public void OnImportsSatisfied()
        {
            foreach (ISubscriberService service in Services)
                service.Start();
        }

        public void CheckForNewServices()
        {
            //throw new NotImplementedException();
        }

        public void StopAllServices()
        {
            foreach (ISubscriberService service in Services)
                service.Stop();
        }
    }
}
