using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Contoso.Data.Context;
using Contoso.Service.Service;
using Contoso.Data.Repository;
using Contoso.Core.Domain;

namespace ContosoUniversity.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IDbContext, ContosoUniversityContext>( new PerRequestLifetimeManager());
            container.RegisterType<IStudentService, StudentService>(new PerRequestLifetimeManager());
            container.RegisterType<ICourseService, CourseService>(new PerRequestLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentService>(new PerRequestLifetimeManager());
            container.RegisterType<IInstructorService, InstructorService>(new PerRequestLifetimeManager());
            container.RegisterType<IOfficeAssignmentService, OfficeAssignmentService>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Student>, Repository<Student>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Course>, Repository<Course>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Department>, Repository<Department>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Instructor>, Repository<Instructor>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<OfficeAssignment>, Repository<OfficeAssignment>>(new PerRequestLifetimeManager());
        }
    }
}
