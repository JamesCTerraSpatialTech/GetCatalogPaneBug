using ArcGIS.Desktop.Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework.Threading.Tasks;

namespace BugGetCatalogPane
{
    public class ReportsButton : Button
    {
        public ReportsButton()
        {

        }

        // Async properties.
        private static bool IsBusy { get; set; }
        private static object LockHandle { get; } = new object();

        protected override async void OnClick()
        {
            // Prevent duplicate click.
            if (IsBusy) return;
            lock (LockHandle)
            {
                if (IsBusy) return;
                IsBusy = true;
            }

            try
            {
               
                /* Bug?  the below should open a new catalog pane if one isn't
                open, but it does not do this. */
                var catalog = Project.GetCatalogPane(true);

                // find reports item
                Item reports = Project.Current.ProjectItemContainers.First(c => c.Path == "Report");
                
                // select it (This works if the catalog is open already)
                await catalog.SelectItemAsync(reports, true, true, null).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                // Failure here will cause ArcGIS pro to quit so let's not allow that.
              
            }
            finally
            {
                lock (LockHandle) IsBusy = false;
            }
        }

    }
}
