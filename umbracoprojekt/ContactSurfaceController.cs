using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace umbracoprojekt
{


    public class ContactDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }


    public class ContactSurfaceController : SurfaceController
    {

        private Umbraco.Cms.Infrastructure.Scoping.IScopeProvider _scopeProvider;

        public ContactSurfaceController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            Umbraco.Cms.Infrastructure.Scoping.IScopeProvider scopeProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            this._scopeProvider = scopeProvider;
        }


        public IActionResult contactSubmit(ContactDTO contactForm)
        {

            if (contactForm.Name == null || contactForm.Email == null || contactForm.Message == null)
            {
                return CurrentUmbracoPage();
            }


            using (var scope = _scopeProvider.CreateScope())
            {
                var data = new umbracoprojekt.AddCommentsTable.Contactschema();

                data.Name = contactForm.Name;
                data.Email = contactForm.Email;
                data.Message = contactForm.Message;

                scope.Database.Insert(data);
                scope.Complete();
            }

            
            return RedirectToCurrentUmbracoPage();
        }
        

    }
}

