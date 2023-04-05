using Microsoft.Extensions.FileProviders;

namespace HouseEmma.HouseTest.Mock
{
    public interface IHostEnvironment
    {
        string ApplicationName { get; set; }
        //
        // Summary:
        //     Gets or sets an Microsoft.Extensions.FileProviders.IFileProvider pointing at
        //     Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath.
        IFileProvider ContentRootFileProvider { get; set; }
        //
        // Summary:
        //     Gets or sets the absolute path to the directory that contains the application
        //     content files.
        string ContentRootPath { get; set; }
        //
        // Summary:
        //     Gets or sets the name of the environment. The host automatically sets this property
        //     to the value of the "environment" key as specified in configuration.
        string EnvironmentName { get; set; }
    }
}